﻿/************************************************************************************
*                                                                                   *
*  File:        GameSorter.cs                                                       *
*  Copyright:   (c) 2024, Cristina Andrei Marian                                    *
*  E-mail:      andrei-marian.cristina@student.tuiasi.ro                            *
*  Description: a custom sorter that has a modifiable sort style                    *          
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
    /// Provides a way of sorting games using a certain algorithm/strategy that can be changed based on needs;
    /// </summary>
    public class GameSorter
    {
        private ISortStyle _sortStyle = new SortByName(); // Implicit, alegem sortare alfabetica

        public GameSorter() { }

        public void SetSortStyle(ISortStyle style)
        {
            _sortStyle = style;
        }

        public List<Game> Sort(List<Game> games)
        {
           return _sortStyle.Sort(games);
        }
    }
}
