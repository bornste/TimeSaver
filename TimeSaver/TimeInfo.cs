using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace TimeSaver
{
    /// <summary>
    /// Provides information about the system type.
    /// </summary>
    internal class TimeInfo
    {
        /// <summary>
        /// Initializes the <see cref="TimeInfo"/> class.
        /// </summary>
        static TimeInfo()
        {
            Format = CultureInfo.CurrentCulture.DateTimeFormat;
            HasAMPM = Format.AMDesignator.Length > 0;

            // create date pattern without day
            string datePattern = Format.LongDatePattern;
            datePattern = datePattern.Replace("dddd, ", string.Empty);
            datePattern = datePattern.Replace(", dddd", string.Empty);
            datePattern = datePattern.Replace(" dddd", string.Empty);
            datePattern = datePattern.Replace("dddd ", string.Empty);
            DatePattern = datePattern;
        }

        public static DateTimeFormatInfo Format { get; private set; }

        public static bool HasAMPM { get; private set; }

        public static string DatePattern { get; private set; }

        public TimeInfo()
        {
            DateTime now = DateTime.Now;
            
            // get the texts to display
            Hours = now.ToString(HasAMPM ? "hh" : "HH");
            Minutes = now.ToString("mm");
            TimeSeparator = Format.TimeSeparator;
            AMPM = now.ToString("tt");

            Day = now.ToString("dddd");
            Date = now.ToString(DatePattern);

            Seconds = now.Second + (now.Millisecond / 1000f);
        }

        public string Hours { get; private set; }

        public string Minutes { get; private set; }

        public string TimeSeparator { get; private set; }

        public string AMPM { get; private set; }

        public string Day { get; private set; }

        public string Date { get; private set; }

        public float Seconds { get; private set; }
    }
}
