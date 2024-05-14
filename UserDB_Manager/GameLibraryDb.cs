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
using DatabaseManager;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using UserDB_Manager;

public class GameLibraryDb: SessionInterface
{
    private static GameLibraryDb _instance;
    private static readonly object _lock = new object();
    private readonly string _connectionString;

    public static Game ConvertGame_IGDB(GameIGDB game)
    {
        if(game is null)
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

    /// <summary>
    /// Constructor for the GameLibraryDb
    /// </summary>
    /// <param name="dbPath"> The path to the database file </param>
    private GameLibraryDb(string dbPath)
    {
        _connectionString = $"Data Source={dbPath}";
        InitializeDatabase();
    }

    /// <summary>
    /// Function to get the instance of the GameLibraryDb (Singleton)
    /// </summary>
    /// <param name="dbPath"> The path to the database file </param>
    /// <returns> Instance of the object </returns>
    public static GameLibraryDb GetInstance(string dbPath)
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new GameLibraryDb(dbPath);
                }
            }
        }
        return _instance;
    }

    /// <summary>
    /// Private function to initialize the database
    /// </summary>
    private void InitializeDatabase()
{
    using (var connection = new SQLiteConnection(_connectionString))
    {
        connection.Open();

        using (var command = new SQLiteCommand(connection))
        {
            command.CommandText =
            @"
            CREATE TABLE IF NOT EXISTS games (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                id_igdb INTEGER,
                executable_path TEXT,
                platform TEXT,
                playtime INTEGER,
                personal_rating INTEGER,
                name TEXT,
                publisher TEXT,
                genre TEXT,
                developer TEXT,
                global_rating INTEGER,
                coverpath TEXT,
                summary TEXT,
                website TEXT,
                favorite BOOLEAN
            );
        ";
            command.ExecuteNonQuery();
        }
    }
}

    /// <summary>
    /// Add a game to the database
    /// </summary>
    /// <param name="game"> Object of type Game that will be added to the database </param>
    /// <returns> 0 if ok, others if nothing updated </returns>
    public Byte AddGame(Game game)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText =
                @"
            INSERT INTO games (id_igdb, executable_path, platform, playtime, personal_rating, name, publisher, genre, developer, global_rating, coverpath, summary, website, favorite)
            VALUES (@id_igdb, @executable_path, @platform, @playtime, @personal_rating, @name, @publisher, @genre, @developer, @global_rating, @coverpath, @summary, @website, @favorite);
        ";
                #region Parameters
                command.Parameters.AddWithValue("@id_igdb", game.id);
                command.Parameters.AddWithValue("@executable_path", game.executable_path);
                string platform = "";
                foreach (var item in game.platforms)
                {
                    platform += item + ", ";
                }
                command.Parameters.AddWithValue("@platform", platform);
                command.Parameters.AddWithValue("@playtime", game.playtime);
                command.Parameters.AddWithValue("@personal_rating", game.personal_rating);
                command.Parameters.AddWithValue("@name", game.name);
                command.Parameters.AddWithValue("@publisher", game.publisher);
                string genre = "";
                if(game.genre != null)
                {
                    foreach (var item in game.genre)
                    {
                        genre += item+ ", ";
                    }   
                }
                else
                {
                    genre = "Unknown";
                }
                command.Parameters.AddWithValue("@genre", genre);
                string developer = "";
                if (game.developers != null)
                {
                   
                    foreach (var item in game.developers)
                    {
                        developer += item + ", ";
                    }
                }
                else
                {
                    developer = "Unknown";
                }
                command.Parameters.AddWithValue("@developer", developer);
                

                command.Parameters.AddWithValue("@global_rating", game.global_rating);
                command.Parameters.AddWithValue("@personal_rating", game.personal_rating);
                command.Parameters.AddWithValue("@coverpath", game.coverpath);
                command.Parameters.AddWithValue("@summary", game.summary);
                command.Parameters.AddWithValue("@website", game.website);
                command.Parameters.AddWithValue("@favorite", game.favorite);
                #endregion

                if(command.ExecuteNonQuery() == 0)
                {
                    return 1;
                }
                return 0; 
                
            }
        }
    }

    /// <summary>
    /// Get all games from the database.
    /// </summary>
    /// <returns> List of Game objects </returns>
    public List<Game> GetAllGames()
    {
        List<Game> games = new List<Game>();

        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SQLiteCommand("SELECT * FROM games;", connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Game game = new Game
                        {
                            id = reader.GetInt32(0),
                            id_igdb = reader.GetInt32(1),
                            executable_path = reader.GetString(2),
                            platforms = reader.GetString(3).Split(',').ToList(),
                            playtime = reader.GetInt32(4),
                            personal_rating = reader.GetInt32(5),
                            name = reader.GetString(6),
                            publisher = reader.GetString(7),
                            genre = reader.GetString(8).Split(',').ToList(),
                            developers = reader.GetString(9).Split(',').ToList(),
                            global_rating = reader.GetInt32(10),
                            coverpath = reader.GetString(11),
                            summary = reader.GetString(12),
                            website = reader.GetString(13),
                            favorite = reader.GetBoolean(14)
                        };

                        games.Add(game);
                    }
                }
            }
        }

        return games;
    }

    /// <summary>
    /// Get a game from the database by id
    /// </summary>
    /// <param name="idx"> The index of the game inside database (idx is NOT THE IGDB_ID) </param>
    /// <returns> The game with the id = idx inside the database </returns>
    public Game GetGame(int idx)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = "SELECT * FROM games WHERE id = @id";
                command.Parameters.AddWithValue("@id", idx);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Game game = new Game
                        {
                            id = reader.GetInt32(0),
                            id_igdb = reader.GetInt32(1),
                            executable_path = reader.GetString(2),
                            platforms = reader.GetString(3).Split(',').ToList(),
                            playtime = reader.GetInt32(4),
                            personal_rating = reader.GetInt32(5),
                            name = reader.GetString(6),
                            publisher = reader.GetString(7),
                            genre = reader.GetString(8).Split(',').ToList(),
                            developers = reader.GetString(9).Split(',').ToList(),
                            global_rating = reader.GetInt32(10),
                            coverpath = reader.GetString(11),
                            summary = reader.GetString(12),
                            website = reader.GetString(13),
                            favorite = reader.GetBoolean(14)
                        };

                        return game;
                    }
                }
            }
        }

        return null; // Return null if no game with the specified id is found
    }

    /// <summary>
    /// Update a game in the database
    /// </summary>
    /// <param name="id"> The id of what game to be updated in the database </param>
    /// <param name="game"> The new game object that will replace the old one </param>
    /// <returns></returns>
    public Byte UpdateGame(int id, Game game)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SQLiteCommand(connection))
            {

                // Update the game in the database
                command.CommandText = @"
                    UPDATE games
                    SET id_igdb = @id_igdb,
                        executable_path = @executable_path,
                        platform = @platform,
                        playtime = @playtime,
                        personal_rating = @personal_rating,
                        name = @name,
                        publisher = @publisher,
                        genre = @genre,
                        developer = @developer,
                        global_rating = @global_rating,
                        coverpath = @coverpath,
                        summary = @summary,
                        website = @website,
                        favorite = @favorite
                    WHERE id = @id
                ";

                #region Parameters
                command.Parameters.AddWithValue("@id_igdb", game.id_igdb);
                command.Parameters.AddWithValue("@executable_path", game.executable_path);
                string platform = "";
                foreach (var item in game.platforms)
                {
                    platform += item + ", ";
                }
                command.Parameters.AddWithValue("@platform", platform);
                command.Parameters.AddWithValue("@playtime", game.playtime);
                command.Parameters.AddWithValue("@personal_rating", game.personal_rating);
                command.Parameters.AddWithValue("@name", game.name);
                command.Parameters.AddWithValue("@publisher", game.publisher);
                string genre = "";
                if (game.genre != null)
                {
                    foreach (var item in game.genre)
                    {
                        genre += item + ", ";
                    }
                }
                else
                {
                    genre = "Unknown";
                }
                command.Parameters.AddWithValue("@genre", genre);
                if (game.developers != null)
                {
                    string developer = "";
                    foreach (var item in game.developers)
                    {
                        developer += item + ", ";
                    }
                    command.Parameters.AddWithValue("@developer", developer);
                }
                else
                {
                    command.Parameters.AddWithValue("@developer", "-");
                }
                command.Parameters.AddWithValue("@global_rating", game.global_rating);
                command.Parameters.AddWithValue("@personal_rating", game.personal_rating);
                command.Parameters.AddWithValue("@coverpath", game.coverpath);
                command.Parameters.AddWithValue("@summary", game.summary);
                command.Parameters.AddWithValue("@website", game.website);
                command.Parameters.AddWithValue("@favorite", game.favorite);
                command.Parameters.AddWithValue("@id", id);
                #endregion

                if(command.ExecuteNonQuery() == 0)
                {
                    return 1;
                }
                return 0;
            }
        }
    }

    /// <summary>
    /// Remove a game from the database based on the id
    /// </summary>
    /// <param name="idx"> The id of the game to be removed </param>
    /// <returns> 0 if ok, others if nothing updated </returns>
    public byte RemoveGame(int idx)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = "DELETE FROM games WHERE id = @id";
                command.Parameters.AddWithValue("@id", idx);

                if (command.ExecuteNonQuery() == 0)
                {
                    return 1;
                }
                return 0;
            }
        }
    }
}