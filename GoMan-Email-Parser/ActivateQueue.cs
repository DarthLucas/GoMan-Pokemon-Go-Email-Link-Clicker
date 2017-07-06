using System;
using System.Collections.Concurrent;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Email_Url_Parser.Model;
using Email_Url_Parser.Proxy;

namespace Email_Url_Parser
{
    public class ActivateQueue
    {
        private static readonly ConcurrentQueue<Task> Items = new ConcurrentQueue<Task>();
        public static int ItemsCount => Items.Count;
        private static readonly AutoResetEvent QueueNotifier = new AutoResetEvent(false);
        private static readonly AutoResetEvent QueueNotifier1 = new AutoResetEvent(false);
        private static int _queueCounter;
        private static readonly System.Timers.Timer Timer = new System.Timers.Timer(1);
        private static readonly Random Rand = new Random();
        static ActivateQueue()
        {
            Timer.Elapsed += Timer_tick;
            Timer.Enabled = true;
            Timer.Start();
        }
        private static void Timer_tick(object sender, ElapsedEventArgs e)
        {
            if (_queueCounter < StatsCollector.Maxthreads)
                QueueNotifier1.Set();
        }

        public static void Start()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    QueueNotifier.WaitOne();
                    while (!Items.IsEmpty)
                    {
                        if (_queueCounter >= StatsCollector.Maxthreads) QueueNotifier1.WaitOne();
                        Task task;
                        if (!Items.TryDequeue(out task)) continue;
                        Interlocked.Increment(ref _queueCounter);
                        task.Start();
                    }
                }
            });
        }
        public static void AddToQueue(ParsedUrl parsedUrl, Action<ParsedUrl> callback)
        {
            parsedUrl.AddLog(LoggerTypes.Debug, $"Added url to activation queue");
            parsedUrl.Status = StatusType.Pending;
            Items.Enqueue(new Task(() => ClickUrl(parsedUrl, callback)));
            QueueNotifier.Set();
        }

        private static async void ClickUrl(ParsedUrl parsedUrl, Action<ParsedUrl> callback)
        {
            try
            {
                var proxy = ProxyHandlerSingleton.Instance.GetRandomProxy();

                while (proxy == null)
                {
                    parsedUrl.AddLog(LoggerTypes.Warning, "No proxies available, checking again in 5 seconds....");
                    await Task.Delay(5000);
                    proxy = ProxyHandlerSingleton.Instance.GetRandomProxy();
                }
                parsedUrl.Status = StatusType.Activating;
                parsedUrl.Proxy = proxy;
                using (var webClient = new MyWebClient())
                {
                    if (!proxy.Address.Equals("127.0.0.1"))
                        webClient.Proxy = proxy.AsWebProxy();
                    webClient.Headers.Add("Upgrade-Insecure-Requests", "1");
 
                    webClient.Headers.Add("User-Agent", UserAgent.GenerateUserAgent());

                    webClient.DownloadString(parsedUrl.Url);
                }

                parsedUrl.Status = StatusType.Activated;
                parsedUrl.Verified = true;
                parsedUrl.AddLog(LoggerTypes.Success, "Url Clicked!");
            }
            catch (Exception e)
            {
                parsedUrl.Status = StatusType.Failed;
                parsedUrl.Verified = false;
                parsedUrl.AddLog(LoggerTypes.Exception, "Url Clicked!", e);
            }
            finally
            {
                Interlocked.Decrement(ref _queueCounter);
                callback(parsedUrl);
            }

        }
    }
    class MyWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            if (request is HttpWebRequest)
            {
                (request as HttpWebRequest).KeepAlive = false;
            }
            return request;
        }
    }
}
