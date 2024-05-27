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

        public void removeFromParent()
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

        public void FavouriteGameClickAt(int index)
        {
            _controller.NavigateFromFavouriteToGameView(index);
        }

        public void MostPlayedGameClickAt(int index)
        {
            _controller.NavigateFromMostPlayedToGameView(index);
        }
    }
}
