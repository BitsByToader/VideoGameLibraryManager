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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGDB_Manager
{
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
    public class CoverIGDB
    {
        public int id { get; set; }
        public string url { get; set; }
    }
    public class InvolvedCompany
    {
        public int id { get; set; }
        public CompanyIGDB company { get; set; } // This is now a CompanyIGDB object
    }


    public class CompanyIGDB
    {
        public int id { get; set; } // Added id field to match the IGDB API response
        public string name { get; set; }
    }

    public class GenreIGDB
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class PlatformIGDB
    {
        public string abbreviation { get; set; }
        public PlatformCategory category { get; set; }
    }
    public class WebsiteIGDB
    {
        public string url { get; set; }
        public WebsiteCategory category { get; set; }
    }
    #endregion
    #region Enums
    public enum PlatformCategory
    {
        Console = 1,
        Arcade = 2,
        Platform = 3,
        OperatingSystem = 4,
        PortableConsole = 5,
        Computer = 6
    }
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

}
