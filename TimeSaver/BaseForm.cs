using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace TimeSaver
{
    /// <summary>
    /// Represents the base class for all forms.
    /// </summary>
    public partial class BaseForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseForm"/> class.
        /// </summary>
        public BaseForm()
        {
            InitializeComponent();

            // default property values
            FadeOnShow = true;
            FadeOnClose = true;
            IsLayeredWindow = false;
            Transparency = 255;
        }

        /// <summary>
        /// Gets or sets the transparency of the form.
        /// </summary>
        /// <value>The transparency of the form (0 = fully transparent, 255 = not transparent).</value>
        [DefaultValue(255)]
        public byte Transparency
        {
            get
            {
                return m_transparency;
            }

            set
            {
                if (m_transparency != value)
                {
                    m_transparency = value;
                    ApplyTransparency();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the form should fade in when it's shown.
        /// </summary>
        /// <value><c>true</c> to fade in; otherwise, <c>false</c>.</value>
        [DefaultValue(true)]
        public bool FadeOnShow { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the form should fade out when it's closed.
        /// </summary>
        /// <value><c>true</c> to fade out; otherwise, <c>false</c>.</value>
        [DefaultValue(true)]
        public bool FadeOnClose { get; set; }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Load"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            this.Transparency = FadeOnShow ? (byte)0 : (byte)255;

            // make it a layered window
            MakeLayeredWindow();

            // lets call base
            base.OnLoad(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Shown"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnShown(EventArgs e)
        {
            // fade in?
            if (FadeOnShow)
            {
                m_fadeIn = true;
                m_fadeTimer.Start();
            }
            else
                base.OnShown(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.FormClosing"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.FormClosingEventArgs"/> that contains the event data.</param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // not cancelled and fading needed?
            if (!e.Cancel && FadeOnClose && !m_closeAfterFade)
            {
                m_closeAfterFade = true;
                m_fadeIn = false;
                m_fadeTimer.Start();
                e.Cancel = true;
            }

            base.OnFormClosing(e);
        }

        /// <summary>
        /// Paints the background of the control.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data.</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // native drawing?
            //if (this.UseNativeBackgroundPaint)
            base.OnPaintBackground(e);
        }

        /// <summary>
        /// Makes the form a layered window.
        /// </summary>
        protected void MakeLayeredWindow()
        {
            int exStyle = NativeMethods.GetWindowLong(this.Handle, GetWindowLong.GWL_EXSTYLE);

            // make layered
            exStyle |= WindowExStyles.WS_EX_LAYERED;

            // set new extended style
            NativeMethods.SetWindowLong(this.Handle, GetWindowLong.GWL_EXSTYLE, exStyle);
            IsLayeredWindow = true;

            // apply transparency (that removes flickering)
            ApplyTransparency();
        }

        /// <summary>
        /// Apply the transparency of the window the the specified value.
        /// </summary>
        protected virtual void ApplyTransparency()
        {
            // not a layered window?
            if (!this.IsLayeredWindow || this.DesignMode)
                return;

            // disposed?
            if (this.Disposing || this.IsDisposed)
                return;

            NativeMethods.SetLayeredWindowAttributes(
                this.Handle, 0, this.Transparency, LayeredWindowAttributes.LWA_ALPHA);
        }

        /// <summary>
        /// Gets a value indicating whether the form is a layered window.
        /// </summary>
        /// <value>
        /// <c>true</c> if the form is a layered window; otherwise, <c>false</c>.
        /// </value>
        protected bool IsLayeredWindow { get; private set; }

        /// <summary>
        /// Called when the fade timer elapses.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnFadeTimer_Tick(object sender, EventArgs e)
        {
            int transparency = this.Transparency;

            // fade in or out?
            if (m_fadeIn)
            {
                // increment
                transparency += FADE_STEP;
                
                // too large? fading is finished
                if (transparency > byte.MaxValue)
                {
                    transparency = byte.MaxValue;
                    m_fadeTimer.Stop();
                }
            }
            else
            {
                // increment
                transparency -= FADE_STEP;

                // too small? fading is finished
                if (transparency < byte.MinValue)
                {
                    transparency = byte.MinValue;
                    m_fadeTimer.Stop();
                }
            }

            this.Transparency = (byte)transparency;

            // close?
            if (!m_fadeIn && m_closeAfterFade && !m_fadeTimer.Enabled)
                this.Close();
        }

        // private variables
        private bool m_closeAfterFade = false;
        private byte m_transparency = 255;
        private bool m_fadeIn = true;

        private const byte FADE_STEP = 75;
    }
}
