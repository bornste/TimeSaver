using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeSaver
{
    /// <summary>
    /// Window Styles.
    /// The following styles can be specified wherever a window style is required. After the control has been created, these styles cannot be modified, except as noted.
    /// </summary>
    public static class WindowStyles
    {
        /// <summary>
        /// Creates an overlapped window. An overlapped window usually has a caption and a border.
        /// </summary>
        public const int WS_OVERLAPPED = 0x00000000;

        /// <summary>
        /// Creates a pop-up window. Cannot be used with the <see cref="WS_CHILD"/> style.
        /// </summary>
        public const int WS_POPUP = -2147483648;

        /// <summary>
        /// Creates a child window. Cannot be used with the <see cref="WS_POPUP"/> style.
        /// </summary>
        public const int WS_CHILD = 0x40000000;

        /// <summary>
        /// Creates a window that is initially minimized. For use with the <see cref="WS_OVERLAPPED"/> style only.
        /// </summary>
        public const int WS_MINIMIZE = 0x20000000;

        /// <summary>
        /// Creates a window that is initially visible.
        /// </summary>
        public const int WS_VISIBLE = 0x10000000;

        /// <summary>
        /// Creates a window that is initially disabled.
        /// </summary>
        public const int WS_DISABLED = 0x08000000;

        /// <summary>
        /// Clips child windows relative to each other; that is, when a particular child window receives a paint message, the WS_CLIPSIBLINGS style clips all other overlapped child windows out of the region of the child window to be updated. (If WS_CLIPSIBLINGS is not given and child windows overlap, when you draw within the client area of a child window, it is possible to draw within the client area of a neighboring child window.) For use with the <see cref="WS_CHILD"/> style only.
        /// </summary>
        public const int WS_CLIPSIBLINGS = 0x04000000;

        /// <summary>
        /// Excludes the area occupied by child windows when you draw within the parent window.
        /// Used when you create the parent window.
        /// </summary>
        public const int WS_CLIPCHILDREN = 0x02000000;

        /// <summary>
        /// Creates a window of maximum size.
        /// </summary>
        public const int WS_MAXIMIZE = 0x01000000;

        /// <summary>
        /// Creates a window that has a border.
        /// </summary>
        public const int WS_BORDER = 0x00800000;

        /// <summary>
        /// Creates a window with a double border but no title.
        /// </summary>
        public const int WS_DLGFRAME = 0x00400000;

        /// <summary>
        /// Creates a window that has a vertical scroll bar.
        /// </summary>
        public const int WS_VSCROLL = 0x00200000;

        /// <summary>
        /// Creates a window that has a horizontal scroll bar.
        /// </summary>
        public const int WS_HSCROLL = 0x00100000;

        /// <summary>
        /// Creates a window that has a Control-menu box in its title bar. Used only for windows with title bars.
        /// </summary>
        public const int WS_SYSMENU = 0x00080000;

        /// <summary>
        /// Creates a window with a thick frame that can be used to size the window.
        /// </summary>
        public const int WS_THICKFRAME = 0x00040000;

        /// <summary>
        /// Specifies the first control of a group of controls in which the user can move from one control to the next with the arrow keys. All controls defined with the WS_GROUP style FALSE after the first control belong to the same group. The next control with the WS_GROUP style starts the next group (that is, one group ends where the next begins).
        /// </summary>
        public const int WS_GROUP = 0x00020000;

        /// <summary>
        /// Specifies one of any number of controls through which the user can move by using the TAB key. The TAB key moves the user to the next control specified by the WS_TABSTOP style.
        /// </summary>
        public const int WS_TABSTOP = 0x00010000;

        /// <summary>
        /// Creates a window that has a Minimize button.
        /// </summary>
        public const int WS_MINIMIZEBOX = 0x00020000;

        /// <summary>
        /// Creates a window that has a Maximize button.
        /// </summary>
        public const int WS_MAXIMIZEBOX = 0x00010000;

        /// <summary>
        /// Creates a window that has a title bar (implies the <see cref="WS_BORDER"/> style).
        /// Cannot be used with the <see cref="WS_DLGFRAME"/> style.
        /// </summary>
        public const int WS_CAPTION = WS_BORDER | WS_DLGFRAME;

        /// <summary>
        /// Creates an overlapped window. An overlapped window has a title bar and a border. Same as the <see cref="WS_OVERLAPPED"/> style.
        /// </summary>
        public const int WS_TILED = WS_OVERLAPPED;

        /// <summary>
        /// Creates a window that is initially minimized. Same as the <see cref="WS_MINIMIZE"/> style.
        /// </summary>
        public const int WS_ICONIC = WS_MINIMIZE;

        /// <summary>
        /// Creates a window that has a sizing border. Same as the <see cref="WS_THICKFRAME"/> style.
        /// </summary>
        public const int WS_SIZEBOX = WS_THICKFRAME;

        /// <summary>
        /// Creates an overlapped window with the <see cref="WS_OVERLAPPED"/>, <see cref="WS_CAPTION"/>, <see cref="WS_SYSMENU"/>, <see cref="WS_THICKFRAME"/>, <see cref="WS_MINIMIZEBOX"/>, and <see cref="WS_MAXIMIZEBOX"/> styles. Same as the <see cref="WS_OVERLAPPEDWINDOW"/> style.
        /// </summary>
        public const int WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW;

        /// <summary>
        /// Creates an overlapped window with the <see cref="WS_OVERLAPPED"/>, <see cref="WS_CAPTION"/>, <see cref="WS_SYSMENU"/>, <see cref="WS_THICKFRAME"/>, <see cref="WS_MINIMIZEBOX"/>, and <see cref="WS_MAXIMIZEBOX"/> styles.
        /// </summary>
        public const int WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX;

        /// <summary>
        /// Creates a pop-up window with the <see cref="WS_BORDER"/>, <see cref="WS_POPUP"/>, and <see cref="WS_SYSMENU"/> styles. The WS_CAPTION style must be combined with the <see cref="WS_POPUPWINDOW"/> style to make the Control menu visible.
        /// </summary>
        public const int WS_POPUPWINDOW = WS_POPUP | WS_BORDER | WS_SYSMENU;

        /// <summary>
        /// Same as the <see cref="WS_CHILD"/> style.
        /// </summary>
        public const int WS_CHILDWINDOW = WS_CHILD;
    }
}
