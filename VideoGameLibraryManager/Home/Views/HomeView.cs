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
            favouriteGamesFormViewContainer.ChangeView(new GridGameDisplayFormView(_controller.GetFavouriteGames()));
        }

        public void RefreshMostPlayedGames()
        {
            mostPlayedGamesFormViewContainer.ChangeView(new GridGameDisplayFormView(_controller.GetMostPlayedGames()));
        }

        public void RefreshTotalPlaytime()
        {
            totalPlaytimeLabel.Text = "Total playtime : "  +_controller.GetTotalPlaytime().ToString();
        }

        public void RefreshFavouriteGenre()
        {
            favouriteGenreLabel.Text = "Favourite Genre: " + _controller.GetFavouriteGenre();
        }
    }
}
