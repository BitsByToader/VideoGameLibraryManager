using Helpers;
using LibraryCommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFFramework;

namespace VideoGameLibraryManager.Home.Models
{
    public interface IHomeModel
    {
        List<Game> GetFavouriteGames();
        List<Game> GetMostPlayedGames();

        string GetFavouriteGenre();

        void UpdateFavouriteGames();
        void UpdateMostPlayedGames();

        void UpdateFavouriteGenre();

        List<Game> GetSortedGames(ISortStyle style);

        void SetParent(FormNavigationStack parent);
        FormNavigationStack GetParent();
    }
}
