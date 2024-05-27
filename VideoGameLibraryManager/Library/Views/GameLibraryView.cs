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
using LibraryCommons;

namespace VideoGameLibraryManager
{
    public partial class GameLibraryView : Form, IGameLibraryView
    {
        private FormNavigationStack _parent;
        private IViewCollection _viewCollection;
        private IGameLibraryController _controller;

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

        void IView.RemoveFromParent()
        {
            _parent = null;
        }

        void IView.WillAppear()
        {
            ChangeView();
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

            _controller.SetDisplayType(DisplayType.Grid);
        }

        private void listViewButton_Click(object sender, EventArgs e)
        {
            listViewButton.BackColor = Color.LightBlue;
            gridViewButton.BackColor = Color.White;

            _controller.SetDisplayType(DisplayType.List);

        }

        private void sortStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (sortStyleComboBox.SelectedIndex)
            {
                case 0: _controller.SetSortStyle(new SortByRating()); break;
                case 1: _controller.SetSortStyle(new SortByName()); break;
                case 2: _controller.SetSortStyle(new SortByPublisher()); break;
                case 3: _controller.SetSortStyle(new SortByPlaytime()); break;
                case 4: _controller.SetSortStyle(new SortByGenre()); break;

                default: _controller.SetSortStyle(new SortByName()); break;
            }

            _controller.SetDisplayType(_controller.GetDisplayType());   
        }

        public void ChangeView()
        {
            DisplayType type = _controller.GetDisplayType();

            switch (type)
            {
                case DisplayType.Grid: 
                    GridGameDisplayFormView grid = new GridGameDisplayFormView(_controller.GetGames());
                    grid.ClickHandler = GameClicked;
                    _viewCollection = grid;
                    break;
                case DisplayType.List: 
                    ListGameDisplayFormView list = new ListGameDisplayFormView(_controller.GetGames());
                    list.ClickHandler = GameClicked;
                    _viewCollection = list;
                    break;
            }

            gameDisplayViewContainer.ChangeView(_viewCollection as IView);
        }

        public void SetController(ref IGameLibraryController controller)
        {
            _controller = controller;
        }

        public void GameClicked(int index)
        {
            _controller.NavigateToGameView(index);
        }
    }
}