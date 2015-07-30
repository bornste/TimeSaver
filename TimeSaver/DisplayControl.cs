using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace TimeSaver
{
    [ToolboxItem(true)]
    internal partial class DisplayControl : Control
    {
        /// <summary>
        /// Initializes the <see cref="DisplayControl"/> class.
        /// </summary>
        static DisplayControl()
        {
            s_stringFormatDefault = StringFormat.GenericTypographic;
            s_stringFormatDefault.Alignment = StringAlignment.Center;
            s_stringFormatDefault.Trimming = StringTrimming.None;
            s_stringFormatDefault.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.NoClip;
        }

        /// <summary>
        /// Occurs when the value of the AutoSize property changes.
        /// </summary>
        [
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        Category("Property Changed")
        ]
        public new event EventHandler AutoSizeChanged
        {
            add { base.AutoSizeChanged += value; }
            remove { base.AutoSizeChanged -= value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayControl"/> class.
        /// </summary>
        public DisplayControl()
        {
            InitializeComponent();

            // fully owner drawn window
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);

            SetAutoSizeMode(AutoSizeMode.GrowAndShrink);
            AutoSize = false;

            UseFading = false;
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            // load the settings
            this.ForeColor = Settings.Instance.TextColor;
            this.BackColor = Settings.Instance.BackColor;
            
            this.Text = string.Empty;

            CalculateLayout();

            m_initialized = true;
        }

        /// <summary>
        /// Sets the values.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="seconds">The seconds and milliseconds of the current time.</param>
        public void SetValues(string text, float seconds)
        {
            if (!m_initialized)
                Initialize();
            
            bool repaint = false;

            // text changed?
            if (this.Text != text)
            {
                if (Settings.Instance.UseUpperCase)
                    this.Text = text.ToUpper();
                else
                    this.Text = text;
                
                repaint = true;
            }

            // use fading?
            if (UseFading)
            {
                byte fadeMin = 100;
                byte fadeMax = 255;
                
                int mod = (int)Math.Floor(seconds) % 2;
                byte textAlpha = (byte)(mod == 1 ? fadeMin : fadeMax);
                if (textAlpha != m_textAlpha)
                {
                    m_textAlpha = textAlpha;
                    repaint = true;
                }
            }

            // refresh needed?
            if (repaint)
                Invalidate();
        }

        /// <summary>
        /// Retrieves the size of a rectangular area into which a control can be fitted.
        /// </summary>
        /// <param name="proposedSize">The custom-sized area for a control.</param>
        /// <returns>
        /// An ordered pair of type <see cref="T:System.Drawing.Size"/> representing the width and height of a rectangle.
        /// </returns>
        public override Size GetPreferredSize(Size proposedSize)
        {
            if (this.AutoSize)
            {
                Size preferedSize = proposedSize;
                if (preferedSize.Height < 1)
                    preferedSize.Height = this.Height;

                preferedSize.Width = (int)Math.Ceiling(
                    m_contentSize.Width / m_contentSize.Height * preferedSize.Height);

                return preferedSize;
            }

            return base.GetPreferredSize(proposedSize);
        }

        /// <summary>
        /// This property is not relevant for this class.
        /// </summary>
        /// <value></value>
        /// <returns>true if enabled; otherwise, false.
        /// </returns>
        [
        DefaultValue(false),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
        ]
        public override bool AutoSize
        {
            get { return base.AutoSize; }
            set 
            {
                if (base.AutoSize != value)
                {
                    base.AutoSize = value;
                    CalculateLayout();
                }
            }
        }

        /// <summary>
        /// Gets or sets the type of the font.
        /// </summary>
        /// <value>The type of the font.</value>
        [DefaultValue(typeof(FontType), "Custom")]
        public FontType FontType
        {
            get { return m_fontType; }
            set
            {
                if (value != m_fontType)
                {
                    m_fontType = value;
                    CalculateLayout();
                    Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets the text alignment.
        /// </summary>
        /// <value>The text align.</value>
        [DefaultValue(typeof(StringAlignment), "Center")]
        public StringAlignment TextAlign
        {
            get { return m_stringFormat.Alignment; }
            set { m_stringFormat.Alignment = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use fading when updating the values.
        /// </summary>
        /// <value><c>true</c> to use fading; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        public bool UseFading { get; set; }

        /// <summary>
        /// Gets or sets the vertical offset.
        /// </summary>
        /// <value>The vertical offset.</value>
        [DefaultValue(0)]
        public int VerticalOffset 
        {
            get { return m_verticalOffset; }
            set 
            {
                if (m_verticalOffset != value)
                {
                    m_verticalOffset = value;
                    CalculateLayout();
                    Invalidate();
                }
            } 
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Resize"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CalculateLayout();
        }

        /// <summary>
        /// Raises the TextChanged event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the data.</param>
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            CalculateLayout();

            // perform a layout if autosizing
            if (this.AutoSize)
                base.Size = this.PreferredSize;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.PaddingChanged"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);
            CalculateLayout();

            // perform a layout if autosizing
            if (this.AutoSize)
                base.Size = this.PreferredSize;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            e.Graphics.Clear(this.BackColor);

            // get the fore bounds
            Rectangle foreBounds = DisplayRectangle;

            // too small?
            if (foreBounds.Width < 1 || foreBounds.Height < 1)
                return;

            // not layouted yet?
            if (m_textBounds.IsEmpty)
                CalculateLayout();
            
            // backup the graphics state
            GraphicsState state = g.Save();

            try
            {
                // set the rendering quality we need
                ApplyRenderingQuality(g);

                // transform
                SetTransformation(g, foreBounds, m_contentSize);

                // draw the document
                Color color = m_textAlpha == 255 ? ForeColor : Color.FromArgb(m_textAlpha, ForeColor);
                using (SolidBrush brush = new SolidBrush(color))
                    g.DrawString(Text, Font, brush, m_textBounds, m_stringFormat);
            }
            finally
            {
                g.Restore(state);
            }
        }

        /// <summary>
        /// Applies the quality for rendering to the specified graphics object.
        /// </summary>
        /// <param name="g">The graphics object to apply the rendering quality.</param>
        private void ApplyRenderingQuality(Graphics g)
        {
            // enable anti-aliasing
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // highest quality for shrinked images
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // use anti-aliasing for text as well
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        }

        /// <summary>
        /// Setup transforamtion required to transform coordiantes between the given 
        /// screen coordiantes and world coordinates. As we want to keep the X/Y ration 
        /// of the world coordinate system the scale factor for X and Y are the same.
        /// </summary>
        /// <param name="g">Graphics to set transformation on</param>
        /// <param name="screenCoords">Rectangle of interest in screen coordinates</param>
        /// <param name="worldCoords">Rectangle of interest in world coordinates</param>
        private void SetTransformation(Graphics g, Rectangle screenCoords, SizeF worldCoords)
        {
            float scaleFactorY = 1.0F;
            if (worldCoords.Height > 0.0F)
                scaleFactorY = (float)screenCoords.Height / worldCoords.Height;

            // we want to fit the height, therefore the 
            // Y scale factor is taken
            m_scaleFactor = scaleFactorY;

            // set transformation for scaling between world and screen coordinated whereby
            // the Y values are inverted to move the origin from upper/left to lower/left corner
            g.ScaleTransform(m_scaleFactor, m_scaleFactor, MatrixOrder.Append);
        }

        /// <summary>
        /// Calculates the layout.
        /// </summary>
        private void CalculateLayout()
        {
            if (FontType != FontType.Custom)
                this.Font = FontHelper.GetFont(this.FontType);
            else
                this.ResetFont();

            // calculate the text height
            using (Graphics g = this.CreateGraphics())
            {
                SizeF size = g.MeasureString(this.Text, this.Font, int.MaxValue, m_stringFormat);
                float width;
                if (this.AutoSize)
                    width = size.Width;
                else
                    width = (Width / (float)Height) * size.Height;

                m_textBounds = new RectangleF(
                    Padding.Left, 
                    Padding.Top + VerticalOffset, 
                    width, 
                    size.Height);

                m_contentSize = m_textBounds.Size + Padding.Size;
            }
        }

        // private variables
        private float m_scaleFactor = 1.0f;
        private FontType m_fontType = FontType.Custom;
        private RectangleF m_textBounds = RectangleF.Empty;
        private SizeF m_contentSize = SizeF.Empty;
        private byte m_textAlpha = 255;
        private StringFormat m_stringFormat = new StringFormat(s_stringFormatDefault);
        private bool m_initialized = false;
        private int m_verticalOffset = 0;

        // constants
        private static readonly StringFormat s_stringFormatDefault;
    }
}
