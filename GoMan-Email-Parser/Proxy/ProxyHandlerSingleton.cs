namespace Email_Url_Parser.Proxy
{
    public sealed class ProxyHandlerSingleton : ProxyHandler
    {
        private static ProxyHandlerSingleton instance = null;
        private static readonly object lockObject = new object();

        ProxyHandlerSingleton()
        {
        }

        public static ProxyHandlerSingleton Instance
        {
            get
            {
                lock (lockObject)
                {
                    return instance ?? (instance = new ProxyHandlerSingleton());
                }
            }
        }
    }
}
