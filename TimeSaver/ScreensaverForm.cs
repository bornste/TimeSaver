using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Diagnostics;

namespace TimeSaver
{
    /// <summary>
    /// Represents the screensaver window.
    /// </summary>
    public partial class ScreensaverForm : BaseForm, IUserActivitySubscriber
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScreensaverForm"/> class.
        /// </summary>
        public ScreensaverForm()
        {
            InitializeComponent();

            // fully owner drawn window
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);

            // load the settings
            this.ForeColor = Settings.Instance.TextColor;
            this.BackColor = Settings.Instance.BackColor;
            m_pnlLayout.BackColor = this.BackColor;
            m_ctlSeparator.UseFading = Settings.Instance.BlinkTimeSeparator;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScreensaverForm"/> class.
        /// This constructor is passed the bounds this form is to show in.
        /// It is used when in normal mode.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        /// <param name="isPrimaryMonitor">true, if this form is for the primary monitor.</param>
        public ScreensaverForm(Rectangle bounds, bool isPrimaryMonitor)
            : this()
        {
            this.Bounds = bounds;
            m_isPrimaryMonitor = isPrimaryMonitor;

            // hide the cursor
            Cursor.Hide();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScreensaverForm"/> class.
        /// This constructor is the handle to the select screensaver dialog preview window.
        /// It is used when in preview mode.
        /// </summary>
        /// <param name="previewHandle">The preview handle.</param>
        public ScreensaverForm(IntPtr previewHandle)
            : this()
        {
            // set the preview window as the parent of this window
            NativeMethods.SetParent(this.Handle, previewHandle);

            // make this a child window, so when the select screensaver dialog closes, this will also close
            int style = NativeMethods.GetWindowLong(this.Handle, GetWindowLong.GWL_STYLE);
            NativeMethods.SetWindowLong(this.Handle, GetWindowLong.GWL_STYLE, style | WindowStyles.WS_CHILD);

            // set our window's size to the size of our window's new parent
            Rectangle ParentRect;
            NativeMethods.GetClientRect(previewHandle, out ParentRect);
            this.Size = ParentRect.Size;

            // set our location at (0, 0)
            this.Location = new Point(0, 0);

            // preview mode
            m_isPreviewMode = true;
        }

        #region IUserActivitySubscriber Members

        /// <summary>
        /// Notifies the subscriber that the user is active.
        /// </summary>
        /// <param name="activity">The performed activity by the user.</param>
        void IUserActivitySubscriber.Notify(UserActivities activity)
        {
            if (activity == UserActivities.MouseMove)
            {
                Point pos = Control.MousePosition;
                
                // see if originallocation has been set
                if (m_originalLocation.X == int.MaxValue && m_originalLocation.Y == int.MaxValue)
                    m_originalLocation = pos;

                // see if the mouse has moved more than 20 pixels in any direction
                if (Math.Abs(pos.X - m_originalLocation.X) > 20 ||
                    Math.Abs(pos.Y - m_originalLocation.Y) > 20)
                    ExitScreensaver();
            }
            else
                ExitScreensaver();
        }

        #endregion

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Load"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            // not primary display and only display on primary?
            if (!m_isPrimaryMonitor &&
                Settings.Instance.DisplayMode == DisplayMode.OnlyOnPrimaryMonitor)
            {
                m_pnlLayout.Visible = false;
            }
            else
            {
                TimeUpdater.Tick += new EventHandler(OnTimeUpdater_Tick);
                UpdateValues();
            }

            // base
            base.OnLoad(e);

            // is primary monitor? attach to the timer
            if (m_isPrimaryMonitor)
            {
                TimeUpdater.SynchronizingObject = this;
                TimeUpdater.Start();

                // track user activities
                m_userActivities = new UserActivityMonitor(this, UserActivities.All);
                m_userActivities.Active = true;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Program.Exit();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Paint"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // clear background
            e.Graphics.Clear(this.BackColor);
        }

        /// <summary>
        /// Called when the time updated.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnTimeUpdater_Tick(object sender, EventArgs e)
        {
            if (!TimeUpdater.Enabled)
                return;

            UpdateValues();
        }

        /// <summary>
        /// Exits the screensaver if not in preview mode.
        /// </summary>
        private void ExitScreensaver()
        {
            if (!m_isPreviewMode)
            {
                TimeUpdater.Stop();
                
                if (m_userActivities != null)
                {
                    m_userActivities.Dispose();
                    m_userActivities = null;
                }

                Program.CloseForms();
            }
        }

        /// <summary>
        /// Updates the values.
        /// </summary>
        private void UpdateValues()
        {
            TimeInfo info = TimeUpdater.Time;

            m_ctlHours.SetValues(info.Hours, info.Seconds);
            m_ctlSeparator.SetValues(":", info.Seconds);
            m_ctlMinutes.SetValues(info.Minutes, info.Seconds);
            m_ctlWeekday.SetValues(info.Day, info.Seconds);
            m_ctlDate.SetValues(info.Date, info.Seconds);

            m_pnlLayout.PerformLayout();
        }

        // private variables
        private Point m_originalLocation = new Point(int.MaxValue, int.MaxValue);
        private bool m_isPreviewMode = false;
        private bool m_isPrimaryMonitor = true;
        private UserActivityMonitor m_userActivities = null;
    }
}
