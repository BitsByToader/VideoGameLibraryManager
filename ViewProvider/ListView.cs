using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewProvider
{
    public class ListView: ICustomView
    {
        private List<DetailedGameInfoBox> _detailedGameInfoBoxes;

        public ListView()
        {
            _detailedGameInfoBoxes = new List<DetailedGameInfoBox>();   
        }

        public void Display()
        {

            // fetch data from database


            // add new item to item list
        }
    }
}
