/************************************************************************************
*                                                                                   *
*  File:                                                                            *
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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    // added just for test purpose -- NEEDS TO BE REMOVED !!!
    public class Game
    {
        public string name;
        public string publisher;
        // asume rating is int 0 - 100
        public int rating;
        // number in seconds;
        public long playtime;
        public Game() { }
    }

    /// <summary>
    /// Interface for different sorting styles/strategies that will be implemented and used for sorting games based on some criteria.
    /// </summary>
    internal interface ISortStyle
    {
        /// <summary>
        /// Sorts games received as parameter.
        /// </summary>
        /// <param name="games"> list of games that need to be sorted</param>
        /// <returns>A new list with sorted games</returns>

        //TODO : replace Game with proper class from the model !!!
        List<Game> Sort(List<Game> games);
    }
}
