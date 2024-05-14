/************************************************************************************
*                                                                                   *
*  File:        ISortStyle.cs                                                       *
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
using System.Drawing;
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
        public double rating;
        // number in seconds;
        public long playtime;
        public string genre;
        public Image image = null;
        public Game(string name, string publisher, double rating, long time, string genre) {
            this.name = name;
            this.publisher = publisher;
            this.rating = rating;
            this.playtime = time;
            this.genre = genre;
        }
    }

    /// <summary>
    /// Interface for different sorting styles/strategies that will be implemented and used for sorting games based on some criteria.
    /// </summary>
    public interface ISortStyle
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
