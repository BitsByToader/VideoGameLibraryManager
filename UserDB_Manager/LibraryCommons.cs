/**************************************************************************
 *                                                                        *
 *  File:        DatabaseManager                                          *
 *  Copyright:   (c) 2024, Darie Alexandru                                *
 *  E-mail:      alexandru.darie@student.tuiasi.ro                        *
 *  Description: Namespace for full control over a database via methods.  *
 *                                                                        *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/

using IGDB_Manager;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDB_Manager
{
    // THIS IS THE CLASS TO USE FOR THE GAME OBJECT. USE CONVERTER METHOD BELOW TO CONVERT FROM IGDB TO GAME
    public class Game
    {
        public static Game ConvertGame_IGDB(GameIGDB game)
        {
            if (game is null)
            {
                throw new ArgumentNullException();
            }

            //Bitmap gameCover = IGDB_API.GetGameCoverBitmap_byID_Async(game.cover.id);

            Task<Bitmap> task = IGDB_API.GetGameCoverBitmap_byID_Async(game.cover.id);
            task.Wait();

            var newGame = new Game
            {
                id_igdb = game.id,
                executable_path = "",
                platforms = game.platforms.Select(x => x.abbreviation).ToList(),
                playtime = 0,
                personal_rating = 0,
                name = game.name,
                publisher = game.involved_companies[0].ToString(),
                genre = game.genres.Select(x => x.name).ToList(),
                developers = game.involved_companies.Select(x => x.ToString()).ToList(),
                global_rating = (int)game.rating,
                coverpath = "",
                cover = task.Result,
                summary = game.summary,
                website = game.websites[0].url,
                favorite = false
            };
            return newGame;
        }
        public int id { get; set; }
        public int id_igdb { get; set; }
        public string executable_path { get; set; }
        public List<String> platforms { get; set; }
        public int playtime { get; set; }
        public int personal_rating { get; set; }
        public string name { get; set; }
        public string publisher { get; set; }
        public List<string> genre { get; set; }
        public List<string> developers { get; set; }
        public int global_rating { get; set; }
        public string coverpath { get; set; }
        public Bitmap cover { get; set; }
        public string summary { get; set; }
        public string website { get; set; }
        public bool favorite { get; set; }

    }

    /*-------------------------------------------------------------------------------------------------------*/
}
