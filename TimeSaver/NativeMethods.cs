using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace TimeSaver
{
    /// <summary>
    /// Native Win32 API functions.
    /// </summary>
    internal static class NativeMethods
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        /// <summary>
        /// This function retrieves information about the specified window.
        /// </summary>
        /// <param name="hWnd">Handle to the window and, indirectly, the class to which the window belongs.</param>
        /// <param name="nIndex">Specifies the zero-based offset to the value to be retrieved.</param>
        /// <returns>The requested 32-bit value indicates success. Zero indicates failure.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        /// <summary>
        /// This function changes an attribute of the specified window.
        /// </summary>
        /// <param name="hWnd">Handle to the window and, indirectly, the class to which the window belongs.</param>
        /// <param name="nIndex">Specifies the zero-based offset to the value to be set.</param>
        /// <param name="dwNewLong">Specifies the replacement value. </param>
        /// <returns>The previous value of the specified 32-bit integer indicates success. Zero indicates failure.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        /// <summary>
        /// The SetLayeredWindowAttributes function sets the opacity and transparency color key of a layered window.
        /// </summary>
        /// <param name="hwnd">Handle to the layered window.</param>
        /// <param name="crKey">The color key (not used).</param>
        /// <param name="bAlpha">Alpha value used to describe the opacity of the layered window.</param>
        /// <param name="dwFlags">Specifies an action to take (always LWA_ALPHA).</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, int dwFlags);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);

    }
}
