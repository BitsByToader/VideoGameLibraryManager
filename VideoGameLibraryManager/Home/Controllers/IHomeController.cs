/************************************************************************************
*                                                                                   *
*  File:        IHomeController.cs*
*  Copyright:   (c) 2024, Cristina Andrei Marian                                    *
*  E-mail:      andrei-marian.cristina@student.tuiasi.ro                            *
*  Description: interface for a controller for home section of the app              *
*                                                                                   *
*                                                                                   *
*  This code and information is provided "as is" without warranty of                *
*  any kind, either expressed or implied, including but not limited                 *
*  to the implied warranties of merchantability or fitness for a                    *
*  particular purpose. You are free to use this source code in your                 *
*  applications as long as the original copyright notice is included.               *
*                                                                                   *
************************************************************************************/

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
    /// <summary>
    /// will be implemented to obtain custom controllers
    /// </summary>
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

        /// <summary>
        /// updates data of a view by retrieving new info from the model
        /// </summary>
        void RefreshData();

        IHomeView GetView();

        void SetGamesToSelect(GameListType type);

        /// <summary>
        /// gets an index of the game shown in a list(most played games) in a container and changes the currently displayed section of the app to the view game section.
        /// </summary>
        /// <param name="index">index of selected game in the list of games shown</param>
        void NavigateFromMostPlayedToGameView(int index);
        void NavigateFromFavouriteToGameView(int index);
    }
}
