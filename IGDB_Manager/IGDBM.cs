/**************************************************************************
 *                                                                        *
 *  File:        DatabaseManager                                          *
 *  Copyright:   (c) 2024, Darie Alexandru                                *
 *  E-mail:      alexandru.darie@student.tuiasi.ro                        *
 *  Description: Namespace for full control over a database via methods.  *
 *               [ the database is made with SQLite! ]                    *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/

using SQLite; //sqlite-net-pcl
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Drawing;

namespace DatabaseManager
{
    public class Genre
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class Platform
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class Company
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class Artwork
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string URL { get; set; }
    }
}
/*
    public class Game
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid Publisher { get; set; } // FK to Company
        public Guid Genre { get; set; } // FK to Genre
        public string ExePath { get; set; }
        public Guid Platform { get; set; } // FK to Platform
        public int Playtime { get; set; }
        public int Rating { get; set; }
        public Guid CoverPath { get; set; } // FK to Artwork
        public Guid Screenshot { get; set; } // FK to Artwork
        public string Summary { get; set; }
        public string Website { get; set; }
        public bool Favorite { get; set; }
    }
*/


/*========================================STEPS I WENT TO AQUIRE THE ACCESS TOKEN========================================
PS C:\Users\alexd> $clientId = "p5fnw9ncdtxnzhc0krntyxipfzr8h7"
PS C:\Users\alexd> $clientSecret = "wpchia4h43d2yayz6vej0rxvgrhmz6"
PS C:\Users\alexd> $uri = "https://id.twitch.tv/oauth2/token?client_id=$clientId&client_secret=$clientSecret&grant_type=client_credentials"
PS C:\Users\alexd> $response = Invoke-WebRequest -Uri $uri -Method Post
PS C:\Users\alexd> $response.Content
{"access_token":"lsx3tr1bazjawk7ahz7ipd4i6uphmy","expires_in":4732639,"token_type":"bearer"}

                                                                                in case one of u need it -Alex
========================================================================================================================*/

public class Game
{
    public int id { get; set; }                      /* game's id */
    public Cover cover { get; set; }
    public string name { get; set; }
}

public class Cover
{
    public int id { get; set; }
    public string url { get; set; }
}

public class IGDB_API
{
    private static readonly string _clientId = "p5fnw9ncdtxnzhc0krntyxipfzr8h7";
    private static readonly string _accessToken = "lsx3tr1bazjawk7ahz7ipd4i6uphmy";
    private static HttpClient _httpClient;

    /// <summary>
    /// Task that searches for games by name (query) and returns a list of game names.
    /// </summary>
    /// <param name="query">The search query.</param>
    /// <returns> A list of game names that match the search query.</returns>
    /// <exception cref="Exception"></exception>
    public static async Task<string> SearchGameNames(string query, bool appendID = true)
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
                var games = JsonSerializer.Deserialize<Game[]>(responseBody);
                if (appendID)
                {
                    return string.Join("\n", games.Select
                        (
                            g => (g.name +" "+g.id)
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
    public static async Task<Bitmap> GetGameCoverBitmapAsync(int gameId)
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
                var games = JsonSerializer.Deserialize<Game[]>(responseBody);

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
}



