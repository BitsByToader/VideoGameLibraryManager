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
        public void SetView(String type)
        {
            switch (type)
            {
                case "grid": _viewSrategy = new GridView(); break;
                case "list": _viewSrategy = new ListView(); break;
            }
        }

        public void Display()
        {
            _viewSrategy.Display();
        }
    }
}
