using Helpers;
using LibraryCommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameLibraryManager.Home.Models
{
    public interface IHomeModel
    {
        List<Game> GetFavouriteGames();
        List<Game> GetMostPlayedGames();

        long GetTotalPlaytime();

        string GetFavouriteGenre();

        void UpdateFavouriteGames();
        void UpdateMostPlayedGames();
        void UpdateTotalPlaytime();

        void UpdateFavouriteGenre();

        List<Game> GetSortedGames(ISortStyle style);


    }
}
