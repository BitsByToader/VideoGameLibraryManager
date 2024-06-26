﻿/************************************************************************************
*                                                                                   *
*  File:        IGameLibraryModel.cs                                                *
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
using WFFramework;

namespace VideoGameLibraryManager.Library.Models
{
    public interface IGameLibraryModel
    {
        void SortGames();

        /// <summary>
        /// sets a specific sort style inside the model and sorts the games based on it.
        /// </summary>
        /// <param name="style"></param>
        void SetSortStyle(ISortStyle style);

        void SetDisplayType(DisplayType type);

        DisplayType GetDisplayType();

        List<Game> GetAllGames();

        /// <summary>
        /// gets new data from the database
        /// </summary>
        void RefreshData();
        ISortStyle GetSortStyle();

        /// <summary>
        /// sets parent of the current view
        /// </summary>
        /// <param name="parent"></param>
        void SetParent(FormNavigationStack parent);
        FormNavigationStack GetParent();
    }
}
