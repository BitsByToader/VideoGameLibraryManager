﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helpers
{
    public class ListViewStyle : IViewStyle
    {
        public FlowDirection GetViewStyle()
        {
            return FlowDirection.TopDown;
        }
    }
}