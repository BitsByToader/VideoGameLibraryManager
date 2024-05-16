using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtensionMethods
{
    public static class Extensions
    {
        public static void MakeContainerable(this Form f)
        {
            if (f != null)
            {
                f.TopLevel = false;
                f.FormBorderStyle = FormBorderStyle.None;
            }
        }
    }
}
