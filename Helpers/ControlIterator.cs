/************************************************************************************
*                                                                                   *
*  File:        ControlIterator.cs                                                  *
*  Copyright:   (c) 2024, Cristina Andrei Marian                                    *
*  E-mail:      andrei-marian.cristina@student.tuiasi.ro                            *
*  Description:                                                                     *
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

namespace Helpers
{
    /// <summary>
    /// Custom iterator for Control objects;
    /// </summary>
    public class ControlIterator : ICustomIterator
    {
        private Control[] _controls;
        private int _index = 0;

        public ControlIterator(Control[] controls)
        {
            _controls = controls;
        }

        public bool HasNext()
        {
            return _index < _controls.Length;
        }

        public object Next()
        {
            if (!HasNext())
            {
                throw new InvalidOperationException("No more elements in the collection.");
            }

            Control control = _controls[_index];
            _index++;
            return control;
        }
    }
}
