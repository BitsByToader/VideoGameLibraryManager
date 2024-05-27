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
    public interface IHomeController
    {
        List<Game> GetFavouriteGames();

        List<Game> GetMostPlayedGames();

        long GetTotalPlaytime();

        string GetFavouriteGenre();

        void UpdateFavouriteGames();
        void UpdateMostPlayedGames();
        void UpdateTotalPlaytime();

        void UpdateFavouriteGenre();

        void RefreshData();

        IHomeView GetView();

        void SetGamesToSelect(GameListType type);
        void NavigateFromMostPlayedToGameView(int index);
        void NavigateFromFavouriteToGameView(int index);
    }
}
