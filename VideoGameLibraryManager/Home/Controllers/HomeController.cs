using Helpers;
using LibraryCommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoGameLibraryManager.Home.Models;
using VideoGameLibraryManager.Home.Views;
using VideoGameLibraryManager.ViewGame;
using WFFramework;
using ExtensionMethods;


namespace VideoGameLibraryManager.Home.Controllers
{
    public class HomeController : IHomeController
    {
        private IHomeModel _model;
        private IHomeView _view;
        private long _totalPlaytime;
        private GameListType _gameListType;


        public HomeController(IViewContainer parent) 
        {
            _model = new HomeModel();
            _model.SetParent(parent as FormNavigationStack);
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

        public void NavigateToGameView(int index)
        {
            List<Game> games = _model.GetFavouriteGames();

            switch(_gameListType)
            {
                case GameListType.MostPlayed: games = _model.GetMostPlayedGames(); break;
                case GameListType.Favourite: games = _model.GetFavouriteGames(); break;
            }

            IViewGameController viewGameController = new ViewGameController(_model.GetParent(), games[index]);
            ((Form)viewGameController.GetView()).MakeContainerable();
            _model.GetParent().PushView(viewGameController.GetView());
        }

        public void SetGamesToSelect(GameListType type)
        {
            _gameListType = type;
        }
    }
}
