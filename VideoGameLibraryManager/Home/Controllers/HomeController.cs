using Helpers;
using LibraryCommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameLibraryManager.Home.Models;
using VideoGameLibraryManager.Home.Views;

namespace VideoGameLibraryManager.Home.Controllers
{
    public class HomeController : IHomeController
    {
        private IHomeModel _model;
        private IHomeView _view;
        private long _totalPlaytime;


        public HomeController()
        {
            _model = new HomeModel();
            _view = new HomeView(this);
        }

        public List<Game> GetFavouriteGames() => _model.GetFavouriteGames();

        public string GetFavouriteGenre() => _model.GetFavouriteGenre();

        public List<Game> GetMostPlayedGames() => _model.GetMostPlayedGames();

        public long GetTotalPlaytime() => _totalPlaytime;

        public IHomeView GetView() => _view;

        public void RefreshData()
        {
            UpdateFavouriteGames();
            UpdateMostPlayedGames();
            UpdateFavouriteGenre();
            UpdateTotalPlaytime();

            _view.RefreshTotalPlaytime();
            _view.RefreshFavouriteGenre();
            _view.RefreshFavouriteGames();
            _view.RefreshMostPlayedGames();
        }

        public void UpdateFavouriteGames()
        {
            _model.UpdateFavouriteGames();
        }

        public void UpdateFavouriteGenre()
        {
            _model.UpdateFavouriteGenre();
        }

        public void UpdateMostPlayedGames()
        {
            _model.UpdateMostPlayedGames();
        }

        public void UpdateTotalPlaytime()
        {
            _totalPlaytime =  _model.GetSortedGames(new SortByPlaytime()).Aggregate(0L, (acc, game) => acc + game.playtime);
        }
    }
}
