using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewProvider
{
    public class GridView : ICustomView
    {
        private List<BriefGameInfoBox> _briefGameInfoBoxes;

        public GridView() {
            _briefGameInfoBoxes = new List<BriefGameInfoBox>();
        }

        public void Display()
        {
            // fetch data from database

            // add new item to item list
        }
    }
}
