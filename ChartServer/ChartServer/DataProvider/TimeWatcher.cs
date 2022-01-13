namespace ChartServer.DataProvider
{
    /// <summary>
    /// This call will be used to send the data after each second to the client
    /// </summary>
    public class TimeWatcher
    {
        private Action? Executor;
        private Timer? timer;
        // we need to auto-reset the event before the execution
        private AutoResetEvent? autoResetEvent;


        public DateTime WatcherStarted { get; set; }

        public bool IsWatcherStarted { get; set; }

        /// <summary>
        /// Method for the Timer Watcher
        /// This will be invoked when the Controller receives the request
        /// </summary>
        public void Watcher(Action execute)
        {
            int callBackDelayBeforeInvokeCallback = 1000;
            int timeIntervalBetweenInvokeCallback = 2000;
            Executor = execute;
            autoResetEvent = new AutoResetEvent(false);
            timer = new Timer((object? obj) => {
                Executor();
                if ((DateTime.Now - WatcherStarted).TotalSeconds > 60)
                {
                    IsWatcherStarted = false;
                    timer.Dispose();
                }
            }, autoResetEvent, callBackDelayBeforeInvokeCallback, timeIntervalBetweenInvokeCallback);

            WatcherStarted = DateTime.Now;
            IsWatcherStarted = true;
        }
    }
}
