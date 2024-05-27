/************************************************************************************
*                                                                                   *
*  File:        HomeController.cs                                                   *
*  Copyright:   (c) 2024, Cristina Andrei Marian                                    *
*  E-mail:      andrei-marian.cristina@student.tuiasi.ro                            *
*  Description: implementation on IHomeController interface                         *
*                                                                                   *
*                                                                                   *
*  This code and information is provided "as is" without warranty of                *
*  any kind, either expressed or implied, including but not limited                 *
*  to the implied warranties of merchantability or fitness for a                    *
*  particular purpose. You are free to use this source code in your                 *
*  applications as long as the original copyright notice is included.               *
*                                                                                   *
************************************************************************************/

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
using System.Security.Cryptography;


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

        /// <summary>
        /// uses a reduce method for calculating total playtime
        /// </summary>
        public void UpdateTotalPlaytime()
        {
            _totalPlaytime =  _model.GetSortedGames(new SortByPlaytime()).Aggregate(0L, (acc, game) => acc + game.playtime);
        }

        public void NavigateFromFavouriteToGameView(int index)
        {
            Game game = _model.GetFavouriteGames()[index];
            NavigateToGameView(game);
        }

        public void NavigateFromMostPlayedToGameView(int index)
        {
            Game game = _model.GetMostPlayedGames()[index];
            NavigateToGameView(game);
        }

        private void NavigateToGameView(Game game)
        {
            IViewGameController viewGameController = new ViewGameController(_model.GetParent(), game);
            ((Form)viewGameController.GetView()).MakeContainerable();
            _model.GetParent().PushView(viewGameController.GetView());
        }

        public void SetGamesToSelect(GameListType type)
        {
            _gameListType = type;
        }
    }
}
