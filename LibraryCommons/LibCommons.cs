/**************************************************************************
 *                                                                        *
 *  File:        LibCommons.cs                                            *
 *  Copyright:   (c) 2024, Darie Alexandru                                *
 *  E-mail:      alexandru.darie@student.tuiasi.ro                        *
 *  Description: A file holding all the classes and enums for DBS.        *
 *                                                                        *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCommons
{
    /// <summary>
    /// Class that holds the data for a game from the IGDB API.
    /// </summary>
    public class GameIGDB
    {
        //https://api-docs.igdb.com/#game

        public int id { get; set; }                      // Game's ID
        public CoverIGDB cover { get; set; }             // Cover image
        public string name { get; set; }                 // Game's name
        public string publisher { get; set; }            // Game's publisher
        public List<GenreIGDB> genres { get; set; }      // Game's genres
        public List<PlatformIGDB> platforms { get; set; } // Game's platforms
        public List<int> involved_companies { get; set; }
        public List<CompanyIGDB> companies { get; set; } // Game's companies
        public double rating { get; set; }               // Global rating
        public string coverpath { get; set; }            // Path to cover image
        public string summary { get; set; }              // Game summary
        public string executable_path { get; set; }      // Path to executable
        public int playtime { get; set; }                // Playtime in minutes
        public List<WebsiteIGDB> websites { get; set; }  // Game's websites
    }
    #region CLASSES FOR GAMEIGDB
    /// <summary>
    /// Class that holds the data for a cover image from the IGDB API.
    /// </summary>
    public class CoverIGDB
    {
        public int id { get; set; }
        public string url { get; set; }
    }
    /// <summary>
    /// Class that holds the data for a company from the IGDB API.
    /// </summary>
    public class InvolvedCompany
    {
        public int id { get; set; }
        public CompanyIGDB company { get; set; } // This is now a CompanyIGDB object
    }

    /// <summary>
    /// Class that holds the data for a company from the IGDB API.
    /// </summary>
    public class CompanyIGDB
    {
        public int id { get; set; } // Added id field to match the IGDB API response
        public string name { get; set; }
    }

    /// <summary>
    /// Class that holds the data for a genre from the IGDB API.
    /// </summary>
    public class GenreIGDB
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    /// <summary>
    /// Class that holds the data for a platform from the IGDB API.
    /// </summary>
    public class PlatformIGDB
    {
        public string abbreviation { get; set; }
        public PlatformCategory category { get; set; }
    }
    /// <summary>
    /// Class that holds the data for a website from the IGDB API.
    /// </summary>
    public class WebsiteIGDB
    {
        public string url { get; set; }
        public WebsiteCategory category { get; set; }
    }
    #endregion
    #region Enums
    /// <summary>
    /// Enum for the platform category.
    /// </summary>
    public enum PlatformCategory
    {
        Console = 1,
        Arcade = 2,
        Platform = 3,
        OperatingSystem = 4,
        PortableConsole = 5,
        Computer = 6
    }

    /// <summary>
    /// Enum for the website category.
    /// </summary>
    public enum WebsiteCategory
    {
        Official = 1,
        Wikia = 2,
        Wikipedia = 3,
        Facebook = 4,
        Twitter = 5,
        Twitch = 6,
        Instagram = 8,
        YouTube = 9,
        IPhone = 10,
        IPad = 11,
        Android = 12,
        Steam = 13,
        Reddit = 14,
        Itch = 15,
        EpicGames = 16,
        GOG = 17,
        Discord = 18
    }
    #endregion
    /// <summary>
    /// Class that holds the data for a game from the local database.
    /// </summary>
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

        /// <summary>
        /// Update the game with the differences from another game
        /// </summary>
        /// <param name="game"> The game to update from </param>
        /// <param name="ignoreID"> If true, the ID will not be updated </param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"> Thrown when the game is null </exception>
        public bool LocalUpdateWithDifferences(ref Game game, bool ignoreID = true)
        {
            if (this is null || game is null)
            {
                throw new ArgumentNullException();
            }
            bool updated = false;
            if (this.id_igdb != null && this.id_igdb != game.id_igdb && ignoreID == false)
            {
                this.id_igdb = game.id_igdb;
                updated = true;
            }

            if (this.executable_path != null && this.executable_path != game.executable_path && game.executable_path != "" && game.executable_path != null)
            {
                this.executable_path = game.executable_path;
                updated = true;
            }

            if (this.platforms != null && game.platforms != null && !this.platforms.SequenceEqual(game.platforms) && game.platforms.Count > 0)
            {
                this.platforms = new List<string>(game.platforms);
                updated = true;
            }

            if (this.playtime != null && this.playtime != game.playtime && game.playtime != -1)
            {
                this.playtime = game.playtime;
                updated = true;
            }

            if (this.personal_rating != null && this.personal_rating != game.personal_rating && game.personal_rating != -1)
            {
                this.personal_rating = game.personal_rating;
                updated = true;
            }

            if (this.name != null && this.name != game.name && (game.name != null || game.name != ""))
            {
                this.name = game.name;
                updated = true;
            }

            if (this.publisher != null && this.publisher != game.publisher && game.publisher != null && game.publisher != "")
            {
                this.publisher = game.publisher;
                updated = true;
            }

            if (this.genre != null && game.genre != null && !this.genre.SequenceEqual(game.genre) && game.genre.Count > 0)
            {
                this.genre = new List<string>(game.genre);
                updated = true;
            }

            if (this.developers != null && game.developers != null && !this.developers.SequenceEqual(game.developers) && game.developers.Count > 0)
            {
                this.developers = new List<string>(game.developers);
                updated = true;
            }

            if (this.global_rating != null && this.global_rating != game.global_rating && game.global_rating != -1)
            {
                this.global_rating = game.global_rating;
                updated = true;
            }

            if (this.coverpath != null && this.coverpath != game.coverpath && game.coverpath != null && game.coverpath != "")
            {
                this.coverpath = game.coverpath;
                updated = true;
            }

            if (this.summary != null && this.summary != game.summary && game.summary != null && game.summary != "")
            {
                this.summary = game.summary;
                updated = true;
            }

            if (this.website != null && this.website != game.website && game.website != null && game.website != "")
            {
                this.website = game.website;
                updated = true;
            }

            if (this.favorite != null && this.favorite != game.favorite)
            {
                this.favorite = game.favorite;
                updated = true;
            }
            return updated; // used in special cases
        }

        /// <summary>
        /// Constructor for the Game class
        /// </summary>
        /// <param name="id"> The ID of the game </param>
        /// <param name="id_igdb"> The ID of the game in the IGDB API </param>
        /// <param name="executable_path"> The path to the executable </param>
        /// <param name="platforms"> The platforms the game is available on </param>
        /// <param name="playtime"> The playtime in miliseconds </param>
        /// <param name="personal_rating"> The personal rating of the game </param>
        /// <param name="name"> The name of the game </param>
        /// <param name="publisher"> The publisher of the game </param>
        /// <param name="genre"> The genre of the game </param>
        /// <param name="developers"> The developers of the game </param> 
        /// <param name="global_rating"> The global rating of the game </param>
        /// <param name="coverpath"> The path to the cover image </param>
        /// <param name="cover"> The cover image </param>
        /// <param name="summary"> The summary of the game </param>
        /// <param name="website"> The website of the game </param>
        /// <param name="favorite"> The favorite status of the game </param>
        public Game(int id, int id_igdb, string executable_path, List<string> platforms, int playtime, int personal_rating, string name, string publisher, List<string> genre, List<string> developers, int global_rating, string coverpath, Bitmap cover, string summary, string website, bool favorite)
        {
            this.id = id;
            this.id_igdb = id_igdb;
            this.executable_path = executable_path;
            this.platforms = platforms;
            this.playtime = playtime;
            this.personal_rating = personal_rating;
            this.name = name;
            this.publisher = publisher;
            this.genre = genre;
            this.developers = developers;
            this.global_rating = global_rating;
            this.coverpath = coverpath;
            this.cover = cover;
            this.summary = summary;
            this.website = website;
            this.favorite = favorite;
        }

        public Game(Game game)
        {
            this.id = game.id;
            this.id_igdb = game.id_igdb;
            this.executable_path = game.executable_path;
            this.platforms = game.platforms;
            this.playtime = game.playtime;
            this.personal_rating = game.personal_rating;
            this.name = game.name;
            this.publisher = game.publisher;
            this.genre = game.genre;
            this.developers = game.developers;
            this.global_rating = game.global_rating;
            this.coverpath = game.coverpath;
            this.cover = game.cover;
            this.summary = game.summary;
            this.website = game.website;
            this.favorite = game.favorite;
        }
        /// <summary>
        /// Constructor for the Game class. Initializes all fields to default values (-1, "", null, 0, false).
        /// </summary>
        public Game()
        {
            this.id = -1;
            this.id_igdb = -1;
            this.executable_path = "";
            this.platforms = new List<string>();
            this.playtime = 0;
            this.personal_rating = 0;
            this.name = "";
            this.publisher = "";
            this.genre = new List<string>();
            this.developers = new List<string>();
            this.global_rating = 0;
            this.coverpath = "";
            this.cover = null;
            this.summary = "";
            this.website = "";
            this.favorite = false;
        }
    }

    /// <summary>
    /// Class that holds the data for a game's TODO list.
    /// </summary>
    public class GameTODO
    {
        public int id { get; set; }
        public int game_id { get; set; }
        public string todo { get; set; }
        public bool done { get; set; }
        /// <summary>
        /// Constructor for the GameTODO class
        /// </summary>
        public GameTODO()
        {
            this.id = -1;
            this.game_id = -1;
            this.todo = "";
            this.done = false;
        }
        /// <summary>
        /// GameTODO constructor.
        /// </summary>
        /// <param name="id"> Id of the TODO </param>
        /// <param name="game_id"> The game's ID coresponding to the todo </param>
        /// <param name="todo"> The TODO as strong </param>
        /// <param name="done"> Completion status </param>
        public GameTODO(int id, int game_id, string todo, bool done)
        {
            this.id = id;
            this.game_id = game_id;
            this.todo = todo;
            this.done = done;
        }

        /// <summary>
        /// Toggles the done status of the TODO.
        /// </summary>
        public void toggleDone()
        {
            done = !done;
        }

        /// <summary>
        /// Checks if the TODO is done.
        /// </summary>
        /// <returns> TODO's completion status </returns>
        public bool isDone()
        {
            return done;
        }
    }
}

/*-------------------------------------------------------------------------------------------------------*/
