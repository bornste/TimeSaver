using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeSaver
{
    /// <summary>
    /// Defines the display mode.
    /// </summary>
    public enum DisplayMode
    {
        /// <summary>
        /// The screensaver is only displayed on the primary monitor.
        /// </summary>
        OnlyOnPrimaryMonitor = 0,

        /// <summary>
        /// The screensaver is displayed on all monitors.
        /// </summary>
        AllMonitors = 1,
    }
}
