using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace TimeSaver
{
    /// <summary>
    /// The screensaver main entry point.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // load the settings
            Settings.Instance.Load();

            // any arguments specified?
            if (args.Length > 0)
            {
                // get the argument
                string option = args[0].ToLower(CultureInfo.InvariantCulture).Trim();
                
                // preview?
                if (option.StartsWith("/p"))
                {
                    // args[1] is the handle to the preview window
                    IntPtr handle = new IntPtr(long.Parse(args[1]));

                    // show the screen saver preview
                    Application.Run(new ScreensaverForm(handle));
                    return;
                }
                
                // configure?
                if (option.StartsWith("/c"))
                {
                    Application.Run(new SettingsForm());
                    return;
                }
            }

            // run the screen saver
            ShowScreensaver();
            Application.Run();
        }

        /// <summary>
        /// Closes all open forms.
        /// </summary>
        internal static void CloseForms()
        {
            List<Form> forms = new List<Form>();
            foreach (Form form in Application.OpenForms)
                forms.Add(form);

            forms.ForEach(f => f.Close());
        }

        /// <summary>
        /// Exits the program.
        /// </summary>
        internal static void Exit()
        {
            Application.Exit();
        }

        /// <summary>
        /// Shows the screensaver.
        /// </summary>
        private static void ShowScreensaver()
        {
            // loops through all the computer's screens
            foreach (Screen screen in Screen.AllScreens)
            {
                // creates a form just for that screen and passes it the bounds of that screen
                ScreensaverForm screensaver = new ScreensaverForm(screen.Bounds, screen.Primary);
                screensaver.Show();
            }
        }
    }
}
