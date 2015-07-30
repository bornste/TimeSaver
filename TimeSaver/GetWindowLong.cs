﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeSaver
{
    public static class GetWindowLong
    {
        public const int GWL_WNDPROC = (-4);

        public const int GWL_HINSTANCE = (-6);

        public const int GWL_HWNDPARENT = (-8);

        public const int GWL_STYLE = (-16);

        public const int GWL_EXSTYLE = (-20);

        public const int GWL_USERDATA = (-21);

        public const int GWL_ID = (-12);
    }
}
