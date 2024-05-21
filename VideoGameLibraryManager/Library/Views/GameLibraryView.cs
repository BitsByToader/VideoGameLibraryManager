/************************************************************************************
*                                                                                   *
*  File:        GameDisplayFormView.cs                                              *
*  Copyright:   (c) 2024, Cristina Andrei Marian                                    *
*  E-mail:      andrei-marian.cristina@student.tuiasi.ro                            *
*  Description:                                                                     *
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFFramework;
using Helpers;
using VideoGameLibraryManager.Library;

namespace VideoGameLibraryManager
{
    public partial class GameLibraryView : Form, IGameLibraryView
    {
        private FormNavigationStack _parent;
        // TODO: De setat aici style-ul in functie de ce are combobox-ul implicit
        private GameSorter _sorter = new GameSorter();
        private IViewCollection _viewCollection;

        public GameLibraryView()
        {
            InitializeComponent();
        }

        void IView.AddToParent(IViewContainer parent)
        {
            _parent = (FormNavigationStack) parent;
        }

        IViewContainer IView.GetParentContainer()
        {
            return _parent;
        }

        void IView.removeFromParent()
        {
            _parent = null;
        }

        void IView.WillAppear()
        {
            _sorter.SetSortStyle(new SortByName());
            GridGameDisplayFromView view = new GridGameDisplayFromView();
            view.SetSorter(ref _sorter);
            gameDisplayViewContainer.ChangeView(view);
            _viewCollection = view;
        }

        void IView.WillBeAddedToParent()
        {
            
        }

        void IView.WillBeRemovedFromParent()
        {
            
        }

        void IView.WillDisappear()
        {
            gridViewButton.BackColor = Color.White;
            listViewButton.BackColor = Color.White;
        }

        private void gridViewButton_Click(object sender, EventArgs e)
        {
            gridViewButton.BackColor = Color.LightBlue;
            listViewButton.BackColor = Color.White;


            GridGameDisplayFromView view = new GridGameDisplayFromView(); // TODO: eventual sorter in constructor si devine one-liner
            view.SetSorter(ref _sorter);
            gameDisplayViewContainer.ChangeView(view);
            _viewCollection = view;
        }

        private void listViewButton_Click(object sender, EventArgs e)
        {
            listViewButton.BackColor = Color.LightBlue;
            gridViewButton.BackColor = Color.White;

            ListGameDisplayFormView view = new ListGameDisplayFormView();
            view.SetSorter(ref _sorter);
            gameDisplayViewContainer.ChangeView(view);
            _viewCollection = view;
        }

        private void sortStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (sortStyleComboBox.SelectedIndex)
            {
                case 0: _sorter.SetSortStyle(new SortByRating()); break;
                case 1: _sorter.SetSortStyle(new SortByName()); break;
                case 2: _sorter.SetSortStyle(new SortByPublisher()); break;
                case 3: _sorter.SetSortStyle(new SortByPlaytime()); break;
                case 4: _sorter.SetSortStyle(new SortByGenre()); break;

                default: _sorter.SetSortStyle(new SortByName()); break;
            }

            _viewCollection.RefreshViews();
        }

        void IGameLibraryView.SetController(IGameLibraryController controller)
        {
            throw new NotImplementedException();
        }
    }
}
