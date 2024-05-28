/************************************************************************************
*                                                                                   *
*  File:        IGameLibraryController.cs                                           *
*  Copyright:   (c) 2024, Cristina Andrei Marian, Ifrim Tudor Nicolae               *
*  E-mail:      andrei-marian.cristina@student.tuiasi.ro                            *
*               tudor-nicolae.ifrim@student.tuiasi.ro                               *
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

namespace VideoGameLibraryManager.Library
{
    public interface IGameLibraryController
    {
      
        void SortGames();
        void SetSortStyle(ISortStyle style);
        ISortStyle GetSortStyle();
        void SetDisplayType(DisplayType type);
        DisplayType GetDisplayType();

        /// <summary>
        /// uses model to retrieve game data
        /// </summary>
        /// <returns>lsit of all games</returns>
        List<Game> GetGames();

        /// <summary>
        /// changes current displayed view of the app the Game View
        /// </summary>
        /// <param name="index"></param>
        void NavigateToGameView(int index);
    }
}
