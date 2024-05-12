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
using System.Data.SQLite; // Changed from Microsoft.Data.Sqlite

public class GameLibraryDb
{
    private static GameLibraryDb _instance;
    private static readonly object _lock = new object();
    private readonly string _connectionString;


    private GameLibraryDb(string dbPath)
    {
        _connectionString = $"Data Source={dbPath}";
        InitializeDatabase();
    }

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
public void AddGame(GameIGDB game)
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
                    platform += item.abbreviation + ", ";
                }
                command.Parameters.AddWithValue("@platform", platform);
                command.Parameters.AddWithValue("@playtime", game.playtime);
                command.Parameters.AddWithValue("@personal_rating", game.personal_rating);
                command.Parameters.AddWithValue("@name", game.name);
                command.Parameters.AddWithValue("@publisher", game.publisher);
                string genre = "";
                if(game.genres != null)
                {
                    foreach (var item in game.genres)
                    {
                        genre += item.name + ", ";
                    }   
                }
                else
                {
                    genre = "Unknown";
                }
                command.Parameters.AddWithValue("@genre", genre);
                if(game.developers != null)
                {
                    string developer = "";
                    foreach (var item in game.developers)
                    {
                        developer += item.name+ ", ";
                    }
                    command.Parameters.AddWithValue("@developer", developer);
                }
                else
                {
                    command.Parameters.AddWithValue("@developer", "Unknown");
                }
                command.Parameters.AddWithValue("@global_rating", game.rating);
                command.Parameters.AddWithValue("@coverpath", game.coverpath);
                command.Parameters.AddWithValue("@summary", game.summary);
                if(game.websites != null)
                {
                    foreach (var item in game.websites)
                    {
                        if (item.category == WebsiteCategory.Official)
                        {
                            command.Parameters.AddWithValue("@website", item.url);
                            break;
                        }
                    }
                }
                else
                {
                    command.Parameters.AddWithValue("@website", "No Official website found");
                }
                command.Parameters.AddWithValue("@favorite", game.favorite);
                #endregion
                command.ExecuteNonQuery();
            }
        }
    }

    public void GetAllGames()
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SQLiteCommand("SELECT * FROM games;", connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["id"]}, IGDB ID: {reader["id_igdb"]}, Path: {reader["executable_path"]}, Platform: {reader["platform"]}, Playtime: {reader["playtime"]}, Rating: {reader["personal_rating"]}");
                    }
                }
            }
        }
    }

    public void UpdateGame(int id, string executablePath = null, string platform = null, int? playtime = null, int? personalRating = null)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SQLiteCommand(connection))
            {
                var setClauses = new List<string>();
                if (executablePath != null) setClauses.Add("executable_path = @executablePath");
                if (platform != null) setClauses.Add("platform = @platform");
                if (playtime.HasValue) setClauses.Add("playtime = @playtime");
                if (personalRating.HasValue) setClauses.Add("personal_rating = @personalRating");

                command.CommandText = $@"
                UPDATE games
                SET {string.Join(", ", setClauses)}
                WHERE id = @id;
            ";

                if (executablePath != null) command.Parameters.AddWithValue("@executablePath", executablePath);
                if (platform != null) command.Parameters.AddWithValue("@platform", platform);
                if (playtime.HasValue) command.Parameters.AddWithValue("@playtime", playtime.Value);
                if (personalRating.HasValue) command.Parameters.AddWithValue("@personalRating", personalRating.Value);
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
        }
    }
}