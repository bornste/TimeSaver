using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeSaver
{
    /// <summary>
    /// Layered Window Attributes
    /// </summary>
    public static class LayeredWindowAttributes
    {
        /// <summary>
        /// Use crKey as the transparency color.
        /// </summary>
        public const int LWA_COLORKEY = 0x00000001;

        /// <summary>
        /// Use bAlpha to determine the opacity of the layered window.
        /// </summary>
        public const int LWA_ALPHA = 0x00000002;

        /// <summary>
        /// Use pblend as the blend function. If the display mode is 256 colors or less, the effect of this value is the same as the effect of ULW_OPAQUE.
        /// </summary>
        public const int ULW_ALPHA = 0x00000002;

        /// <summary>
        /// Use crKey as the transparency color.
        /// </summary>
        public const int ULW_COLORKEY = 0x00000001;

        /// <summary>
        /// Draw an opaque layered window.
        /// </summary>
        public const int ULW_OPAQUE = 0x00000004;
    }
}
