using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewProvider
{
    public class ViewProvider
    {
        private ICustomView _viewSrategy;
        public ViewProvider() { }
        public void SetView(ICustomView view)
        {
            _viewSrategy = view;
        }

        public void Display()
        {
            _viewSrategy.Display();
        }
    }
}
