/************************************************************************************
*                                                                                   *
*  File:        IHomeModel.cs                                                       *
*  Copyright:   (c) 2024, Cristina Andrei Marian                                    *
*  E-mail:      andrei-marian.cristina@student.tuiasi.ro                            *
*  Description:                                                                     *
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

        /// <summary>
        /// sets the sort style in the model and sorts the games
        /// </summary>
        /// <param name="style">desired sort style</param>
        /// <returns>list of sorted games</returns>
        List<Game> GetSortedGames(ISortStyle style);

        void SetParent(FormNavigationStack parent);
        FormNavigationStack GetParent();
    }
}
