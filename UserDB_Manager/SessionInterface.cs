using DatabaseManager;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace UserDB_Manager
{
    public class Game
    {
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

        // DEPRECATED
        public Game LocalUpdateWithDifferences(Game game, bool ignoreID = true)
        {
            if(this is null || game is null)
            {
                throw new ArgumentNullException();
            }

            if (this.id_igdb != game.id_igdb && ignoreID == false)
            {
                this.id_igdb = game.id_igdb;
            }

            if (this.executable_path != game.executable_path)
            {
                this.executable_path = game.executable_path;
            }

            if (!this.platforms.SequenceEqual(game.platforms))
            {
                this.platforms = new List<string>(game.platforms);
            }

            if (this.playtime != game.playtime)
            {
                this.playtime = game.playtime;
            }

            if (this.personal_rating != game.personal_rating)
            {
                this.personal_rating = game.personal_rating;
            }

            if (this.name != game.name)
            {
                this.name = game.name;
            }

            if (this.publisher != game.publisher)
            {
                this.publisher = game.publisher;
            }

            if (!this.genre.SequenceEqual(game.genre))
            {
                this.genre = new List<string>(game.genre);
            }

            if (!this.developers.SequenceEqual(game.developers))
            {
                this.developers = new List<string>(game.developers);
            }

            if (this.global_rating != game.global_rating)
            {
                this.global_rating = game.global_rating;
            }

            if (this.coverpath != game.coverpath)
            {
                this.coverpath = game.coverpath;
            }

            if (this.summary != game.summary)
            {
                this.summary = game.summary;
            }

            if (this.website != game.website)
            {
                this.website = game.website;
            }

            if (this.favorite != game.favorite)
            {
                this.favorite = game.favorite;
            }
            return this; // used in special cases
        }
    }
    interface SessionInterface
    {
        Byte AddGame(Game game);                     // returns an error code , 0 if successful
        Byte RemoveGame(int idx);                    // returns an error code , 0 if successful
        Byte UpdateGame(int idx, Game game);         // returns an error code , 0 if successful
        List<Game> GetAllGames();
        Game GetGame(int idx);


        
    }
}
