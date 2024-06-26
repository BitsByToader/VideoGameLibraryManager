﻿/************************************************************************************
*                                                                                   *
*  File:        SortByRating.cs                                                     *
*  Copyright:   (c) 2024, Cristina Andrei Marian                                    *
*  E-mail:      andrei-marian.cristina@student.tuiasi.ro                            *
*  Description: concrete implementation for sorting by game rating strategy         *
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

namespace Helpers
{
    /// <summary>
    /// Implementation used for sorting games by rating.
    /// </summary>
    public class SortByRating : ISortStyle
    {
        public List<Game> Sort(List<Game> games)
        {
            return games.OrderBy(game => game.personal_rating).ToList();
        }
    }
}
