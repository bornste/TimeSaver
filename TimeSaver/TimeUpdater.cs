using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.ComponentModel;

namespace TimeSaver
{
    internal static class TimeUpdater
    {
        public static event EventHandler Tick;

        static TimeUpdater()
        {
            s_timer = new Timer();
            s_timer.AutoReset = true;
            s_timer.Interval = 1000;
            s_timer.Elapsed += new ElapsedEventHandler(OnTick);

            Time = new TimeInfo();
        }

        public static void Start()
        {
            s_timer.Start();
        }

        public static void Stop()
        {
            s_timer.Stop();
        }

        public static bool Enabled
        {
            get { return s_timer.Enabled; }
        }

        public static TimeInfo Time { get; private set; }

        public static ISynchronizeInvoke SynchronizingObject
        {
            get { return s_timer.SynchronizingObject; }
            set { s_timer.SynchronizingObject = value; }
        }

        private static void OnTick(object sender, ElapsedEventArgs e)
        {
            Time = new TimeInfo();
            Tick?.Invoke(null, EventArgs.Empty);
        }

        // private variables
        private static Timer s_timer = null;
    }
}
