using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFFramework
{
    public abstract class GridViewCollection : FlowLayoutPanel, IViewCollection
    {
        public GridViewCollection(): base()
        {
            this.FlowDirection = FlowDirection.LeftToRight;
            this.WrapContents = true;
            this.AutoScroll = true;
            this.Visible = true;
            this.Dock = DockStyle.Fill;
        }

        public abstract int Count();

        /// <summary>
        /// TODO rest of doc
        /// NOTE: Implementing classes can choose to override this method if they wish to do any additional actions on the collection, however they must always call the base method to actually refresh the views!
        /// </summary>
        public virtual void RefreshViews()
        {
            this.Controls.Clear();
            for (int i = 0; i < this.Count(); i++ )
            {
                IView view = this.ViewAt(i);
                this.Controls.Add((Control)view);
            }
        }

        public virtual void RefreshViews<T> (List<T> data)
        {

        }

        public abstract IView ViewAt(int index);
    }
}