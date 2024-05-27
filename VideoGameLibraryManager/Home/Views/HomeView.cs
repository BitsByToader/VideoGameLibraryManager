/************************************************************************************
*                                                                                   *
*  File:        HomeView.cs                                                         *
*  Copyright:   (c) 2024, Cristina Andrei Marian, Ifrim Tudor Nicolae               *
*  E-mail:      andrei-marian.cristina@student.tuiasi.ro                            *
*               tudor-nicolae.ifrim@student.tuiasi.ro                               *
*  Description: form implementation of the view for home section                    *
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
using LibraryCommons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoGameLibraryManager.Home.Controllers;
using VideoGameLibraryManager.Home.Models;
using WFFramework;

namespace VideoGameLibraryManager.Home.Views
{
    public partial class HomeView : Form, IHomeView
    {
        private FormNavigationStack _parent = null;
        private IHomeController _controller;
        public HomeView(IHomeController controller)
        {
            InitializeComponent();

            _controller = controller;
            totalPlaytimeLabel.Text = "";
            favouriteGenreLabel.Text = "";

            mostPlayedGamesFormViewContainer.Click += (sender, e) => _controller.SetGamesToSelect(GameListType.MostPlayed);
            favouriteGamesFormViewContainer.Click += (sender, e) => _controller.SetGamesToSelect(GameListType.Favourite);
        }

        public HomeView()
        {
            InitializeComponent();
        }

        public void AddToParent(IViewContainer parent)
        {
            _parent = (FormNavigationStack)parent;
        }

        public IViewContainer GetParentContainer()
        {
            return _parent;
        }

        public void RemoveFromParent()
        {
            _parent = null;
        }

        public void WillAppear()
        {
            _controller.RefreshData();
        }

        public void WillBeAddedToParent()
        {
            
        }

        public void WillBeRemovedFromParent()
        {
            
        }

        public void WillDisappear()
        {
            totalPlaytimeLabel.Text = "";
            favouriteGenreLabel.Text = "";
        }

        public void RefreshFavouriteGames()
        {
            GridGameDisplayFormView grid = new GridGameDisplayFormView(_controller.GetFavouriteGames());
            grid.ClickHandler = FavouriteGameClickAt;
            favouriteGamesFormViewContainer.ChangeView(grid);
        }

        public void RefreshMostPlayedGames()
        {
            GridGameDisplayFormView grid = new GridGameDisplayFormView(_controller.GetMostPlayedGames());
            grid.ClickHandler = MostPlayedGameClickAt;
            mostPlayedGamesFormViewContainer.ChangeView(grid);
        }

        public void RefreshTotalPlaytime()
        {
            totalPlaytimeLabel.Text = "Total playtime : "  +_controller.GetTotalPlaytime().ToString();
        }

        public void RefreshFavouriteGenre()
        {
            favouriteGenreLabel.Text = "Favourite Genre: " + _controller.GetFavouriteGenre();
        }

        private void FavouriteGameClickAt(int index)
        {
            _controller.NavigateFromFavouriteToGameView(index);
        }

        private void MostPlayedGameClickAt(int index)
        {
            _controller.NavigateFromMostPlayedToGameView(index);
        }
    }
}
