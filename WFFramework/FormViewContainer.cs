/************************************************************************************
*                                                                                   *
*  File:        FormNavigationStack                                                 *
*  Copyright:   (c) 2024, Ifrim Tudor                                               *
*  E-mail:      tudor-nicolae.ifrim@student.tuiasi.ro                               *
*  Description: Provides a container whics can hold any arbitrary Form.             *
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
    /// <summary>
    /// Container view that can hold any type of view, but only one at a time. It's meant to be a simple implementation of IViewContainer interface strictly for Windows Forms which implement IView interface.
    /// The container will manage the view's lifecycle as well, notifying of any visibility changes. As such, it's able to createa a basic hierarchy and manage compile-time finite state machines by switching
    /// between views (i.e. states).
    /// 
    /// Inherits TableLayoutPanel control from Windows Forms as it's able to house and type of Form or Control and resize them to match the container's size (something which a regular Panel can't do).
    /// </summary>
    public class FormViewContainer : TableLayoutPanel, IViewContainer
    {
        private IView _currentView = null;

        /// <summary>
        /// Constructor for the container, which also initializez the TableLayoutPanel.
        /// </summary>
        public FormViewContainer(): base()
        {
            ColumnCount = 1;
            RowCount = 1;
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        }

        /// <summary>
        /// Handles resize events from the panel and resizes the current active child.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (Controls.Count == 1)
            {
                Controls[0].Size = Size;
            }
        }

        /// <summary>
        /// Changes the view which the container displays. Notifies the current view that it will dissapear and notifies the new view it's about to be displayed.
        /// Efectively changes the state of the container 'view'.
        /// </summary>
        /// <param name="view">The new view which will be rendered inside the container. NOTE: This implementation of IViewContainer *requires* that views implement Windows.Forms.Control also!</param>
        public void ChangeView(IView view)
        {
            Control wrappedForm = (Control) view; // will throw if view is not derived from Form

            if (Controls.Count == 1 && _currentView != null) // We already have a view in the container
            {
                _currentView.WillDisappear();
                Control curr = Controls[0]; // we only accept Forms so this shouldn't fail, can also use currentView cast as Form which should also not fail
                curr.Hide(); // not necessary (from limited testing), but intuition says this should be done
            }

            view.WillAppear();
            _currentView = view;

            Controls.Clear(); // remove old form
            Controls.Add(wrappedForm); // add new form
            wrappedForm.Size = Size;
            wrappedForm.Show();
            Refresh();
        }

        /// <summary>
        /// Retrieves the currently displayed view/the state the container view is in.
        /// </summary>
        /// <returns>The current view.</returns>
        public IView GetCurrentView()
        {
            return _currentView;
        }
    }
}
