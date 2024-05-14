using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helpers
{
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
