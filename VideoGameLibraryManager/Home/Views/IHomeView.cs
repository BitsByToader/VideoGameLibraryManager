using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFFramework;

namespace VideoGameLibraryManager.Home.Views
{
    public interface IHomeView: IView
    {
        void RefreshFavouriteGames();
        void RefreshMostPlayedGames();
        void RefreshTotalPlaytime();
        void RefreshFavouriteGenre();

    }
}
