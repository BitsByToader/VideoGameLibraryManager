/************************************************************************************
*                                                                                   *
*  File:        FormNavigationStack                                                 *
*  Copyright:   (c) 2024, Ifrim Tudor                                               *
*  E-mail:      tudor-nicolae.ifrim@student.tuiasi.ro                               *
*  Description: Defines an implementation for IViewCollection using a Windows       *
*               Forms TableLayoutPanel for a arranging IViews in a list/table.      *
*                                                                                   *
*                                                                                   *
*  This code and information is provided "as is" without warranty of                *
*  any kind, either expressed or implied, including but not limited                 *
*  to the implied warranties of merchantability or fitness for a                    *
*  particular purpose. You are free to use this source code in your                 *
*  applications as long as the original copyright notice is included.               *
*                                                                                   *
************************************************************************************/

using ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFFramework
{
    /// <summary>
    /// Provides an implementation for a collection of views based on Windows Forms Table Layout Panel.
    /// </summary>
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
        /// Implementing classes can choose to override this method if they wish to do any additional actions on the collection, however they must always call the base method to actually refresh the views!
        /// </summary>
        public virtual void RefreshViews()
        {
            this.Controls.Clear();
            this.RowCount = this.Count();
            for (int i = 0; i < this.Count(); i++)
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

        public abstract IView ViewAt(int index);

        public abstract void ClickedViewAt(int index);

        public void RefreshViews<T>(List<T> data)
        {
            
        }
    }
}
