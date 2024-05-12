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

using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DatabaseManager
{
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

    /*========================================STEPS I WENT TO AQUIRE THE ACCESS TOKEN========================================
    PS C:\Users\alexd> $clientId = "p5fnw9ncdtxnzhc0krntyxipfzr8h7"
    PS C:\Users\alexd> $clientSecret = "wpchia4h43d2yayz6vej0rxvgrhmz6"
    PS C:\Users\alexd> $uri = "https://id.twitch.tv/oauth2/token?client_id=$clientId&client_secret=$clientSecret&grant_type=client_credentials"
    PS C:\Users\alexd> $response = Invoke-WebRequest -Uri $uri -Method Post
    PS C:\Users\alexd> $response.Content
    {"access_token":"lsx3tr1bazjawk7ahz7ipd4i6uphmy","expires_in":4732639,"token_type":"bearer"}

                                                                                    in case one of u need it -Alex
    ========================================================================================================================*/

    public class GameIGDB
    {
        //https://api-docs.igdb.com/#game

        public int id { get; set; }                      // Game's ID
        public CoverIGDB cover { get; set; }             // Cover image
        public string name { get; set; }                 // Game's name
        public string publisher { get; set; }            // Game's publisher
        public List<GenreIGDB> genres { get; set; }      // Game's genres
        public List<PlatformIGDB> platforms { get; set; } // Game's platforms
        public List<int> involved_companies { get; set; } // Assuming this is a list of IDs
        [JsonPropertyName("involved_companies.company")]
        public List<CompanyIGDB> developers { get; set; }
        public double rating { get; set; }        // Global rating
        public string coverpath { get; set; }            // Path to cover image
        public string summary { get; set; }              // Game summary
        public string executable_path { get; set; }      // Path to executable
        public bool favorite { get; set; }               // Mark as favorite
        public int playtime { get; set; }                // Playtime in minutes
        public double personal_rating { get; set; }      // Personal rating
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
        public int company { get; set; } // This is the Reference ID for the Company
    }

    public class CompanyIGDB
    {
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
    public class IGDB_API
    {
        private static readonly string _clientId = "p5fnw9ncdtxnzhc0krntyxipfzr8h7";
        private static readonly string _accessToken = "lsx3tr1bazjawk7ahz7ipd4i6uphmy";
        private static HttpClient _httpClient;

        /// <summary>
        /// Task that searches for games by name (query) and returns a list of game names.
        /// </summary>
        /// <param name="query">The search query.</param>
        /// <returns> A list of game names that match the search query. USE GetGameByName to get game info</returns>
        /// <exception cref="Exception"></exception>
        public static async Task<string> SearchGameNames(string query, bool appendID = false)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Client-ID", _clientId);
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_accessToken}");

                string body = $"fields name, cover.url; search \"{query}\";";
                StringContent content = new StringContent(body, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("https://api.igdb.com/v4/games", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var games = JsonSerializer.Deserialize<GameIGDB[]>(responseBody);
                    if (appendID)
                    {
                        return string.Join("\n", games.Select
                            (
                                g => (g.name + " " + g.id)
                            ));
                    }
                    else
                    {
                        return string.Join("\n", games.Select
                            (
                                g => g.name
                            ));
                    }
                }
                else
                {
                    throw new Exception($"Failed to search games: {response.StatusCode}");
                }
            }
        }

        /// <summary>
        /// Task that gets the cover image of a game by its ID.
        /// </summary>
        /// <param name="gameId"> The ID of the game you want to get the cover image of.</param>
        /// <returns> A Bitmap of the game's cover image.</returns>
        /// <exception cref="Exception"> Throws an exception if the request fails.</exception>
        public static async Task<Bitmap> GetGameCoverBitmap_byID_Async(int gameId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Client-ID", _clientId);
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_accessToken}");

                string body = $"fields cover.url; where id = {gameId};";
                StringContent content = new StringContent(body, Encoding.UTF8, "application/json");

                // Send the request to the IGDB API
                HttpResponseMessage response = await client.PostAsync("https://api.igdb.com/v4/games", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var games = JsonSerializer.Deserialize<GameIGDB[]>(responseBody);

                    if (games != null && games.Length > 0 && games[0].cover?.url != null)
                    {
                        string imageUrl = "https:" + games[0].cover.url.Replace("t_thumb", "t_cover_big");
                        HttpResponseMessage imageResponse = await client.GetAsync(imageUrl);

                        if (imageResponse.IsSuccessStatusCode)
                        {
                            // Download the image data and convert it to a Bitmap
                            byte[] imageBytes = await imageResponse.Content.ReadAsByteArrayAsync();
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                Bitmap bitmap = new Bitmap(ms);
                                return bitmap;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Failed to download image from {imageUrl}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No cover image found for game ID {gameId}");
                    }
                }
                else
                {
                    throw new Exception($"Failed to get game cover: {response.StatusCode}");
                }
            }

            return null;
        }
        public static async Task<Bitmap> GetGameCoverBitmapByUrlAsync(string imageUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Download the image data
                    byte[] imageData = await client.GetByteArrayAsync(imageUrl);

                    // Convert the byte array into a Bitmap
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        return new Bitmap(ms);
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., network errors, invalid URL)
                    Console.WriteLine($"Error downloading image: {ex.Message}");
                    return null;
                }
            }
        }
        public static async Task<CompanyIGDB> FetchCompanyById(int companyId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Client-ID", _clientId);
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_accessToken}");

                string body = $"fields name; where id = {companyId};";
                StringContent content = new StringContent(body, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("https://api.igdb.com/v4/companies", content);

                if (response.IsSuccessStatusCode)
                {//TODO: fix this
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var companies = JsonSerializer.Deserialize<CompanyIGDB[]>(responseBody);
                    if (companies != null && companies.Length > 0)
                    {
                        return companies[0];
                    }
                }
                else
                {
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Failed to fetch company by ID: {response.StatusCode}, Details: {errorResponse}");
                }
            }

            return null; // Return null if no company is found or an error occurs
        }


        public static async Task<GameIGDB> GetGameByName(string gameName)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Client-ID", _clientId);
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_accessToken}");

                string body = $"fields name, summary, rating, cover.url, genres.name, platforms.abbreviation, platforms.category, websites.url, websites.category, involved_companies; search \"{gameName}\"; limit 1;";


                StringContent content = new StringContent(body, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("https://api.igdb.com/v4/games", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var games = JsonSerializer.Deserialize<GameIGDB[]>(responseBody);
                    if (games != null && games.Length > 0)
                    {
                        if (games[0].involved_companies != null)
                        {
                            List<CompanyIGDB> developerCompanies = new List<CompanyIGDB>();
                            foreach (var companyId in games[0].involved_companies)
                            {
                                var company = await FetchCompanyById(companyId);
                                if (company != null)
                                {
                                    developerCompanies.Add(company);
                                }
                            }
                            games[0].developers = developerCompanies; // Update the developers list with fetched company names
                        }
                        return games[0];
                    }
                }
                else
                {
                    Console.WriteLine($"Failed to get game by name: {response.StatusCode}");
                    Console.WriteLine(await response.Content.ReadAsStringAsync());
                }
            }

            return null; // Return null if no game is found or an error occurs
        }
    }

}