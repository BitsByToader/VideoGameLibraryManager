/************************************************************************************
*                                                                                   *
*  File:        FormNavigationStack                                                 *
*  Copyright:   (c) 2024, Ifrim Tudor                                               *
*  E-mail:      tudor-nicolae.ifrim@student.tuiasi.ro                               *
*  Description: Defines an implementation for IViewCollection using a Windows       *
*               Forms FlowLayoutPanel for a arranging IViews in a grid.             *
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

        /// <summary
        /// Implementing classes can choose to override this method if they wish to do any additional actions on the collection, however they must always call the base method to actually refresh the views!
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

        public abstract IView ViewAt(int index);
    }
}