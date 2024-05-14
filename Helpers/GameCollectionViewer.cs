using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helpers
{
    public class GameCollectionViewer : FlowLayoutPanel, ICollectionViewer
    {
        private IViewStyle _viewStyle;
        private IGameToControlConverter _converter;

        public GameCollectionViewer(IViewStyle viewStyle, IGameToControlConverter converter): base()
        {
            _viewStyle = viewStyle;
            _converter = converter;

            this.FlowDirection = _viewStyle.GetViewStyle();

            this.WrapContents = true;
            this.AutoScroll = true;
            this.Visible = true;
            this.Dock = DockStyle.Fill;
        }

        public void AddItem(object item)
        {
            this.Controls.Add(_converter.Convert(item as Game));
        }

        public void AddItems(IEnumerable<object> items)
        {
            foreach (var item in items)
                this.AddItem(item);
        }

        public void ClearItems()
        {
            this.Controls.Clear();
        }

        public ICustomIterator GetIterator()
        {
            return new ControlIterator(this.Controls.Cast<Control>().ToArray());
        }
    }
}
