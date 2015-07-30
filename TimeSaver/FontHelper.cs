using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Text;
using System.Drawing;

namespace TimeSaver
{
    internal static class FontHelper
    {
        /// <summary>
        /// Initializes the <see cref="FontHelper"/> class.
        /// </summary>
        static FontHelper()
        {
            LoadEmbeddedFont(Properties.Resources.FontLight);
            LoadEmbeddedFont(Properties.Resources.FontBold);
        }

        public static FontFamily FontFamily
        {
            get { return s_fontCollection.Families[0]; }
        }

        public static Font GetFont(FontType type)
        {
            switch (type)
            {
                case FontType.Light:
                    return new Font(FontHelper.FontFamily, 30);

                case FontType.Bold:
                    return new Font(FontHelper.FontFamily, 30, FontStyle.Bold);

                case FontType.Custom:
                default:
                    throw new NotSupportedException("FontType 'Custom' is not supported!");
            }
        }

        /// <summary>
        /// Loads an embedded font from the specifed data.
        /// </summary>
        /// <param name="fontData">The font data to load the font from.</param>
        private static unsafe void LoadEmbeddedFont(byte[] fontData)
        {
            fixed (byte* pointer = fontData)
            {
                s_fontCollection.AddMemoryFont((IntPtr)pointer, fontData.Length);
            }
        }

        // private variables
        private static PrivateFontCollection s_fontCollection = new PrivateFontCollection();
    }
}
