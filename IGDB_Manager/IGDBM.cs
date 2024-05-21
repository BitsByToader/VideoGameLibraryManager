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
using LibraryCommons;
using System.Runtime.ConstrainedExecution;

namespace API_Manager
{
    /*========================================STEPS I WENT TO AQUIRE THE ACCESS TOKEN========================================
    PS C:\Users\alexd> $clientId = "p5fnw9ncdtxnzhc0krntyxipfzr8h7"
    PS C:\Users\alexd> $clientSecret = "wpchia4h43d2yayz6vej0rxvgrhmz6"
    PS C:\Users\alexd> $uri = "https://id.twitch.tv/oauth2/token?client_id=$clientId&client_secret=$clientSecret&grant_type=client_credentials"
    PS C:\Users\alexd> $response = Invoke-WebRequest -Uri $uri -Method Post
    PS C:\Users\alexd> $response.Content
    {"access_token":"lsx3tr1bazjawk7ahz7ipd4i6uphmy","expires_in":4732639,"token_type":"bearer"}

                                                                                    in case one of u need it -Alex
    ========================================================================================================================*/

   
    public class IGDB_API : IGameAPI
    {

        private readonly string _clientId = "p5fnw9ncdtxnzhc0krntyxipfzr8h7";
        private readonly string _accessToken = "lsx3tr1bazjawk7ahz7ipd4i6uphmy";
        private static IGDB_API _instance;
        
        /// <summary>
        /// Constructor for IGDB_API. Requires a client ID and an access token.
        /// </summary>
        /// <param name="clientId"> The client ID for the IGDB API.</param>
        /// <param name="accessToken"> The access token for the IGDB API.</param>
        private IGDB_API(string clientId, string accessToken)
        {
            _clientId = clientId;
            _accessToken = accessToken;
        }

        /// <summary>
        /// Get an instance of the IGDB_API class.
        /// </summary>
        /// <param name="clientId"> The client ID for the IGDB API.</param>
        /// <param name="accessToken"> The access token for the IGDB API.</param>
        /// <returns> An instance of the IGDB_API class.</returns>
        public static IGDB_API GetInstance(string clientId, string accessToken)
        {
            if (_instance == null)
            {
                _instance = new IGDB_API(clientId, accessToken);
            }
            return _instance;
        }

        public Game ConvertGame_IGDB(ref GameIGDB game)
        {
            if (game is null)
            {
                throw new ArgumentNullException();
            }

            //Bitmap gameCover = IGDB_API.GetGameCoverBitmap_byID_Async(game.cover.id);

            Task<Bitmap> task = this.GetGameCoverBitmap_byID(game.id);
            task.Wait();
            var newGame = new Game();
            DB_Helper _Helper = DB_Helper.GetHelper();
            newGame.id_igdb = game.id;
            newGame.executable_path = "";
            if (game.platforms != null)
            {
                newGame.platforms = game.platforms.Select(x => x.abbreviation).ToList();
            }
            newGame.playtime = 0;
            newGame.personal_rating = 0;
            newGame.name = game.name;
            if (game.involved_companies != null)
            {
                newGame.publisher = game.involved_companies[0].ToString();
            }
            if (game.genres != null)
            {
                newGame.genre = game.genres.Select(x => x.name).ToList();
            }
            if (game.involved_companies != null)
            {
                newGame.developers = game.involved_companies.Select(x => x.ToString()).ToList();
            }
            newGame.global_rating = (int)game.rating;
            newGame.cover = task.Result;
            try
            {
                newGame.coverpath = _Helper.SaveBitmapAsPng(newGame.cover, newGame.name + "_" + newGame.id_igdb);
            }
            catch
            {
                newGame.coverpath = "";
            }

            newGame.summary = game.summary;
            if (game.websites != null)
            {
                newGame.website = game.websites[0].url;
            }
            newGame.favorite = false;

            return newGame;
        }

        /// <summary>
        /// Task that searches for games by name (query) and returns a list of game names.
        /// </summary>
        /// <param name="query">The search query.</param>
        /// <returns> A list of game names that match the search query. USE GetGameByName to get game info</returns>
        /// <exception cref="Exception"></exception>
        public async Task<string> SearchGameNames(string query, bool appendID = false)
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
        private async Task<Bitmap> GetGameCoverBitmap_byID(int gameId)
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
        private async Task<Bitmap> GetGameCoverBitmapByUrl(string imageUrl)
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
        private async Task<CompanyIGDB> FetchCompanyById(int companyId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Client-ID", _clientId);
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_accessToken}");

                string body = $"fields name; where id = {companyId};";
                StringContent content = new StringContent(body, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("https://api.igdb.com/v4/companies", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"API response: {responseBody}"); // Print out the API response
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

            Console.WriteLine($"No company found with ID {companyId}"); // Print out the company ID if no company is found
            return null; // Return null if no company is found or an error occurs
        }

        /// <summary>
        /// Searches for a game by name and returns the first game found.
        /// </summary>
        /// <param name="gameName"> Name of the game inside the IGDB </param>
        /// <returns> The first result that comes up with the name</returns>
        public async Task<Game> GetGameByName(string gameName)
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
                    if (games[0].involved_companies != null)
                    {
                        foreach (var involvedCompany in games[0].involved_companies)
                        {
                            // Use 'involvedCompany.company' instead of 'company.id'
                            CompanyIGDB companyIGDB = await FetchCompanyById(involvedCompany);
                            if(companyIGDB != null)
                            {
                                games[0].companies.Add(companyIGDB);
                            }
                           
                        }
                    }
                    return ConvertGame_IGDB(ref games[0]);
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