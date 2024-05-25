using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExtensionMethods;

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

                Control correspondingControl = (Control)view; // force views to be an implementation of Control. This limitation makes sense since this implementation of
                                                              // IViewCollection is meant to be used for Windows Forms.

                int local = i; // Create local variable captured inside the loop for the closure below.
                               // Otherwise, the index used in the closure will be update along with the loop.
                               // This means that we'll get the last index for all clicked views.

                correspondingControl.AddGlobalClick(delegate { ClickedViewAt(local); });

                this.Controls.Add(correspondingControl);
            }
        }

        public virtual void RefreshViews<T> (List<T> data)
        {

        }

        public abstract IView ViewAt(int index);

        public abstract void ClickedViewAt(int index);
    }
}