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

        public HomeController()
        {
            _model = new HomeModel();
            _view = new HomeView(this);
        }

        public List<Game> GetFavouriteGames() => _model.GetFavouriteGames();

        public string GetFavouriteGenre() => _model.GetFavouriteGenre();

        public List<Game> GetMostPlayedGames() => _model.GetMostPlayedGames();

        public long GetTotalPlaytime() => _model.GetTotalPlaytime();

        public IHomeView GetView() => _view;

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
            _model.UpdateTotalPlaytime();
        }
    }
}
