/************************************************************************************
*                                                                                   *
*  File:        UniqueGameSorter.cs                                                 *
*  Copyright:   (c) 2024, Cristina Andrei Marian                                    *
*  E-mail:      andrei-marian.cristina@student.tuiasi.ro                            *
*  Description: singleton that offers the functionality of a sorter                 *                                                                    
*                                                                                   *
*                                                                                   *
*  This code and information is provided "as is" without warranty of                *
*  any kind, either expressed or implied, including but not limited                 *
*  to the implied warranties of merchantability or fitness for a                    *
*  particular purpose. You are free to use this source code in your                 *
*  applications as long as the original copyright notice is included.               *
*                                                                                   *
************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    /// <summary>
    /// Provides a way to transfer sorting style between different forms/views. By being a singleton,
    /// multiple views have acces to selected sorting style;
    /// </summary>
    public class UniqueGameSorter: GameSorter
    {
        static private UniqueGameSorter _sorter = null;

        private UniqueGameSorter() : base() { }

        static public UniqueGameSorter Instance()
        {
            if (_sorter == null)
            {
                _sorter = new UniqueGameSorter();
            }
            
            return _sorter;
        }
    }
}
