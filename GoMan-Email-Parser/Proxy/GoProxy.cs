using System;
using System.Diagnostics;

namespace Email_Url_Parser.Proxy
{
    public class GoProxy : ProxyEx
    {
        public int MaxConcurrentFails { get; set; }
        public int CurrentConcurrentFails { get; set; }
        public int MaxCreations { get; set; }
        public int CurrentCreations { get; set; }
        public int CoolDownMinutes { get; set; }
        public Stopwatch CoolDownTimer { get; set; }
        public bool GoodProxy { get; set; }

        public GoProxy()
        {
            MaxConcurrentFails = 5;
            MaxCreations = 5;
            CoolDownMinutes = 15;
            CoolDownTimer = new Stopwatch();
        }

        public void ClearFailCounter()
        {
            CurrentConcurrentFails = 0;
        }
        public void ClearUsageCounter()
        {
            CurrentCreations = 0;
        }
        public string ToAuth()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                return string.Empty;
            }

            return $"{Username}:{Password}";
        }
        public string ToStringUsedAccounts()
        {
            return $"{CurrentCreations}/{MaxCreations}";
        }
        public string ToStringFailedAccounts()
        {
            return $"{CurrentConcurrentFails}/{MaxConcurrentFails}";
        }

        public string ToStringCoolDownTimer()
        {
            var cooldown = CoolDownTimer.Elapsed;

            if (CoolDownTimer.IsRunning)
            {
                cooldown = TimeSpan.FromMinutes(CoolDownMinutes).Subtract(CoolDownTimer.Elapsed);
            }
            return $"{cooldown.Hours:D2}h:{cooldown.Minutes:D2}m:{cooldown.Seconds:D2}s";
        }
    }
}
