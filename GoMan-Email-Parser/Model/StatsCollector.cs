using System;
using System.Threading;

namespace Email_Url_Parser.Model
{
    public class StatsCollector
    {
        private static int _pendingCount;
        public static int PendingCount => _pendingCount;

        private static int _activatingCount;
        public static int ActivatingCount => _activatingCount;

        private static int _activatedCount;
        public static int ActivatedCount => _activatedCount;

        private static int _failedCount;
        public static int FailedCount => _failedCount;

        public static void UpdateCount(StatusType oldStatus, StatusType newStatus)
        {
            if(oldStatus != StatusType.Null)
                DecreaseCount(oldStatus);

            IncreaseCount(newStatus);
        }

        private static void IncreaseCount(StatusType status)
        {
            switch (status)
            {
                case StatusType.Pending:
                    Interlocked.Increment(ref _pendingCount);
                    break;
                case StatusType.Activating:
                    Interlocked.Increment(ref _activatingCount);
                    break;
                case StatusType.Activated:
                    Interlocked.Increment(ref _activatedCount);
                    break;
                case StatusType.Failed:
                    Interlocked.Increment(ref _failedCount);
                    break;
            }
        }

        private static void DecreaseCount(StatusType status)
        {
            switch (status)
            {
                case StatusType.Pending:
                    Interlocked.Decrement(ref _pendingCount);
                    break;
                case StatusType.Activating:
                    Interlocked.Decrement(ref _activatingCount);
                    break;
                case StatusType.Activated:
                    Interlocked.Decrement(ref _activatedCount);
                    break;
                case StatusType.Failed:
                    Interlocked.Decrement(ref _failedCount);
                    break;
            }
        }

    }
}
