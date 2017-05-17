using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Email_Url_Parser.Proxy
{
    public class ProxyHandler
    {
        public HashSet<GoProxy> Proxies { get; private set; }
        private Random _rand = new Random();

        public ProxyHandler()
        {
            Proxies = new HashSet<GoProxy>();
        }

        public void IncreaseFailCounter(GoProxy proxy)
        {
            lock (proxy)
            {
                ++proxy.CurrentConcurrentFails;
            }
        }

        public void ResetFailCounter(GoProxy proxy)
        {
            if (proxy != null)
            {
                proxy.ClearFailCounter();
            }
        }
        public void MarkOnCoolDown(GoProxy proxy, bool onCoolDown = false)
        {
            lock (proxy)
            {
                if (onCoolDown)
                {
                    proxy.CoolDownTimer.Restart();
                    proxy.CurrentCreations = 0;
                }
                else
                {
                    proxy.CoolDownTimer.Stop();
                    proxy.CoolDownTimer.Reset();
                }
            }
        }
        public void ProxyUsed(GoProxy proxy, bool addition = true)
        {
            lock (proxy)
            {
                if (addition)
                {
                    ++proxy.CurrentCreations;
                }
                else
                {
                    --proxy.CurrentCreations;
                }

                if (proxy.CurrentCreations >= proxy.MaxCreations)
                {
                    MarkOnCoolDown(proxy, true);
                }
            }
        }

        public void AddProxy(IEnumerable<GoProxy> proxies)
        {
            foreach (GoProxy proxy in proxies)
            {
                AddProxy(proxy);
            }
        }

        public bool AddProxy(GoProxy proxy)
        {
            if (proxy == null) return false;
            lock (Proxies)
            {
                return Proxies.Add(proxy);
            }
        }

        public async Task TestProxy(GoProxy proxy)
        {
            if (proxy.Address.Equals("127.0.0.1"))
            {
                proxy.GoodProxy = true;
                return;
            }

            try
            {
                using (var webClient = new WebClient())
                {
                    webClient.Proxy = proxy.AsWebProxy();
                   await webClient.DownloadStringTaskAsync("https://club.pokemon.com/us/pokemon-trainer-club/");
                }
                proxy.GoodProxy = true;
            }
            catch (Exception e)
            {
                proxy.GoodProxy = false;
            }


        }

        public bool AddProxy(string data)
        {
            ProxyEx proxy = null;

            if (!ProxyEx.TryParse(data, out proxy))
            {
                return false;
            }


            GoProxy goProxy = new GoProxy
            {
                Address = proxy.Address,
                Password = proxy.Password,
                Port = proxy.Port,
                Username = proxy.Username
            };

            return AddProxy(goProxy);
        }

        public GoProxy GetRandomProxy()
        {
            if (Proxies == null) return null;
            
            List<GoProxy> availableProxies = new List<GoProxy>();

            lock (Proxies)
            {

                availableProxies = Proxies.Where(x =>
                            x.GoodProxy &&
                            x.MaxConcurrentFails > x.CurrentConcurrentFails &&
                            x.MaxCreations > x.CurrentCreations &&
                            (!x.CoolDownTimer.IsRunning || x.CoolDownTimer.Elapsed.Minutes >= x.CoolDownMinutes)).ToList();

                if (availableProxies.Count == 0)
                {
                    return null;
                }

                GoProxy returnProxy = availableProxies[GetRandom(0, availableProxies.Count)];

                MarkOnCoolDown(returnProxy);
                ProxyUsed(returnProxy, true);

                return returnProxy;
            }
        }

        public void RemoveProxy(GoProxy proxy)
        {
            lock (Proxies)
            {
                Proxies.Remove(proxy);
            }
        }

        private int GetRandom(int min, int max)
        {
            lock (_rand)
            {
                return _rand.Next(min, max);
            }
        }
    }
}
