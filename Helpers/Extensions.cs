/************************************************************************************
*                                                                                   *
*  File:        Exetensions                                                         *
*  Copyright:   (c) 2024, Ifrim Tudor                                               *
*  E-mail:      tudor-nicolae.ifrim@student.tuiasi.ro                               *
*  Description: C# extensions of all kinds.                                         *
*                                                                                   *
*                                                                                   *
*  This code and information is provided "as is" without warranty of                *
*  any kind, either expressed or implied, including but not limited                 *
*  to the implied warranties of merchantability or fitness for a                    *
*  particular purpose. You are free to use this source code in your                 *
*  applications as long as the original copyright notice is included.               *
*                                                                                   *
************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtensionMethods
{
    /// <summary>
    /// Generic class for C# extensions.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Extends the Forms class to make a form behave properly when
        /// inside of a container. A containerable form is one which
        /// isn't top level and doesn't have any borders.
        /// </summary>
        /// <param name="f"></param>
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
