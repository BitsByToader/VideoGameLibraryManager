using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFFramework
{
    public abstract class ListViewCollection : TableLayoutPanel, IViewCollection
    {
        public ListViewCollection(): base()
        {
            this.ColumnCount = 1;
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.AutoScroll = true;
        }

        public abstract int Count();

        /// <summary>
        /// TODO Rest of doc...
        /// NOTE: Implementing classes can choose to override this method if they wish to do any additional actions on the collection, however they must always call the base method to actually refresh the views!
        /// </summary>
        public virtual void RefreshViews()
        {
            this.Controls.Clear();
            this.RowCount = this.Count();
            for (int i = 0; i < this.Count(); i++)
            {
                IView view = this.ViewAt(i);
                this.Controls.Add((Control)view);
            }
        }

        public virtual void RefreshViews<T>(List<T> data)
        {

        }

        public abstract IView ViewAt(int index);
    }
}
