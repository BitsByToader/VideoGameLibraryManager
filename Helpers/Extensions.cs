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

        public delegate void ClickHandler();

        public static void AddGlobalClick(this Control c, ClickHandler clickHandler)
        {
            foreach (Control control in c.Controls)
            {
                if (control != null)
                {
                    control.Click += (sender, arg) => {
                        clickHandler();
                    };
                    if (control.HasChildren)
                    {
                        control.AddGlobalClick(clickHandler);
                    }
                }
            }
        }
    }
}
