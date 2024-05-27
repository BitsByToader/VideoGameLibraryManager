/**************************************************************************
 *                                                                        *
 *  File:        GameLibraryDB.cs                                         *
 *  Copyright:   (c) 2024, Darie Alexandru                                *
 *  E-mail:      alexandru.darie@student.tuiasi.ro                        *
 *  Description: File used for full control over a database via methods.  *
 *                                                                        *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/
using API_Manager;
using LibraryCommons;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using UserDB_Manager;

public class GameLibraryDb: SessionInterface
{
    private static GameLibraryDb _instance;
    private static readonly object _lock = new object();
    private readonly string _connectionString;


    /// <summary>
    /// Constructor for the GameLibraryDb
    /// </summary>
    /// <param name="dbPath"> The path to the database file </param>
    private GameLibraryDb(string dbPath)
    {
        _connectionString = $"Data Source={dbPath}";
        InitializeDatabase();
    }

    public void DeleteInstance()
    {
        _instance = null;
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

                command.CommandText =
                @"
                CREATE TABLE IF NOT EXISTS todos (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    game_id INTEGER,
                    todo TEXT,
                    done BOOLEAN DEFAULT 0
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
    public void AddGame(ref Game game)
    {
        if(game == null)
        {
            throw new ArgumentNullException("Game is null");
        }
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
                command.Parameters.AddWithValue("@id_igdb", game.id_igdb);
                command.Parameters.AddWithValue("@executable_path", game.executable_path);
                string platform = "";
                foreach (var item in game.platforms)
                {
                    if (item.EndsWith(" ") || item.EndsWith(","))
                    {
                        platform += item;
                    }
                    else
                    {
                        platform += item + ", ";
                    }
                }
                decimal index = platform.LastIndexOf(", ");
                if (index != -1)
                {
                    platform = platform.Remove((int)index, 2);
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
                        if(item.EndsWith(" ") || item.EndsWith(","))
                        {
                            genre += item;
                        }
                        else
                        {
                            genre += item + ", ";
                        }
                    }   
                }
                else
                {
                    genre = "Unknown";
                }
                index = genre.LastIndexOf(", ");
                if (index != -1)
                {
                    genre = genre.Remove((int)index, 2);
                }
                command.Parameters.AddWithValue("@genre", genre);
                string developer = "";
                if (game.developers != null)
                {
                   
                    foreach (var item in game.developers)
                    {
                        if (item.EndsWith(" ") || item.EndsWith(","))
                        {
                            developer += item;
                        }
                        else
                        {
                            developer += item + ", ";
                        }
                    }
                }
                else
                {
                    developer = "Unknown";
                }
                index = developer.LastIndexOf(", ");
                if (index != -1)
                {
                    developer = developer.Remove((int)index, 2);
                }
                command.Parameters.AddWithValue("@developer", developer);
                

                command.Parameters.AddWithValue("@global_rating", game.global_rating);
                command.Parameters.AddWithValue("@personal_rating", game.personal_rating);
                game.coverpath = DB_Helper.SaveBitmapAsPng(game.cover, game.name+"_"+game.id_igdb);
                command.Parameters.AddWithValue("@coverpath", game.coverpath);
                command.Parameters.AddWithValue("@summary", game.summary);
                command.Parameters.AddWithValue("@website", game.website);
                command.Parameters.AddWithValue("@favorite", game.favorite);
                #endregion

                if(command.ExecuteNonQuery() == 0)
                {
                    //No updated rows
                    throw new Exception("No update was made");
                } 
                
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

                        Game game = new Game();
                        game.id = reader.GetInt32(0);
                        game.id_igdb = reader.GetInt32(1);
                        game.executable_path = reader.GetString(2);
                        game.platforms = reader.GetString(3).Split(',').ToList();
                        //Remove null or empty strings
                        game.platforms.RemoveAll(x => string.IsNullOrEmpty(x));
                        //Remove spaces from the beginning and end of the strings
                        game.platforms = game.platforms.Select(x => x.Trim()).ToList();
                        game.playtime = reader.GetInt32(4);
                        game.personal_rating = reader.GetInt32(5);
                        game.name = reader.GetString(6);
                        game.publisher = reader.GetString(7);
                        game.genre = reader.GetString(8).Split(',').ToList();
                        game.genre.RemoveAll(x => string.IsNullOrEmpty(x));
                        game.genre = game.genre.Select(x => x.Trim()).ToList();
                        game.developers = reader.GetString(9).Split(',').ToList();
                        game.developers.RemoveAll(x => string.IsNullOrEmpty(x));
                        game.developers = game.developers.Select(x => x.Trim()).ToList();
                        game.global_rating = reader.GetInt32(10);
                        game.coverpath = reader.GetString(11);
                        game.summary = reader.GetString(12);
                        game.website = reader.GetString(13);
                        game.favorite = reader.GetBoolean(14);

                        if(game.coverpath != null && game.coverpath.Length>2)
                        {
                            //convert image to Bitmap

                            try
                            {
                                game.cover = DB_Helper.LoadBitmapFromPng(game.coverpath);
                            }
                            catch(Exception)
                            {
                                game.cover=null;
                            }
                            
                        }

                        games.Add(game);
                    }
                }
            }
        }

        return games;
    }

    /// <summary>
    /// Retrieve a game from the database based on a game object (id / name)
    /// </summary>
    /// <param name="game"> The game object to be filled with the data from the database </param>
    /// <returns> Retrieved game object </returns>
    /// <exception cref="Exception"> Thrown if no id or name is specified </exception>"
    public Game GetGame(ref Game game)  
    {
        // create a new object based on what you want to search, if you want to get a game
        // create a new game with id you want to search and use this, if you want to get it by name, do similarly
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SQLiteCommand(connection))
            {
                if (game.id != null && game.id != -1)
                {
                    command.CommandText = "SELECT * FROM games WHERE id = @id";
                    command.Parameters.AddWithValue("@id", game.id);
                }
                else if (game.name != null)
                {
                    command.CommandText = "SELECT * FROM games WHERE name = @name";
                    command.Parameters.AddWithValue("@name", game.name);
                }
                else
                {
                    throw new Exception("No id or name specified");
                }

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Game tempGame = new Game
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
                        tempGame.cover = DB_Helper.LoadBitmapFromPng(tempGame.coverpath);
                        game = tempGame;
                        return game;
                    }
                }
            }
        }
        game=null;
        return null; // Return null if no game with the specified id is found
    }

    /// <summary>
    /// Update a game in the database based on another game object
    /// </summary>
    /// <param name="currentGame"> The game to be updated </param>
    /// <param name="updatedGame"> The game with the updated data </param>
    /// <exception cref="NoRowsUpdatedException"> Thrown if the function does not update any rows </exception>
    public void UpdateGame(ref Game currentGame,ref Game updatedGame)
    {
        if (currentGame == null || updatedGame == null)
        {
            throw new ArgumentNullException("One of the parameters is null.");
        }
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            bool isUpdated = currentGame.LocalUpdateWithDifferences(ref updatedGame);
            if(!isUpdated)
            {
                throw new NoRowsUpdatedException("No update was made");
            }
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
                command.Parameters.AddWithValue("@id_igdb", currentGame.id_igdb);
                command.Parameters.AddWithValue("@executable_path", currentGame.executable_path);
                string platform = "";
                
                foreach (var item in currentGame.platforms)
                {
                    if (item.EndsWith(" ") || item.EndsWith(","))
                    {
                        platform += item;
                    }
                    else
                    {
                        platform += item + ", ";
                    }
                }
                //Iterate through the platforms and delete each comma-space
                decimal index = platform.LastIndexOf(", ");
                if (index != -1)
                {
                    platform = platform.Remove((int)index, 2);
                }
                command.Parameters.AddWithValue("@platform", platform);
                command.Parameters.AddWithValue("@playtime", currentGame.playtime);
                command.Parameters.AddWithValue("@personal_rating", currentGame.personal_rating);
                command.Parameters.AddWithValue("@name", currentGame.name);
                command.Parameters.AddWithValue("@publisher", currentGame.publisher);
                string genre = "";
                if (currentGame.genre != null)
                {
                    foreach (var item in currentGame.genre)
                    {
                        if (item.EndsWith(" ") || item.EndsWith(","))
                        {
                            genre += item;
                        }
                        else
                        {
                            genre += item + ", ";
                        }
                    }
                }
                else
                {
                    genre = "Unknown";
                }
                index = genre.LastIndexOf(", ");
                if (index != -1)
                {
                    genre = genre.Remove((int)index, 2);
                }
                command.Parameters.AddWithValue("@genre", genre);

                string developer = "";
                if (currentGame.developers != null)
                {
                    foreach (var item in currentGame.developers)
                    {
                        if (item.EndsWith(" ") || item.EndsWith(","))
                        {
                            developer += item;
                        }
                        else
                        {
                            developer += item + ", ";
                        }
                    }
                    command.Parameters.AddWithValue("@developer", developer);
                }
                else
                {
                    command.Parameters.AddWithValue("@developer", "-");
                }
                index = developer.LastIndexOf(", ");
                if (index != -1)
                {
                    developer = developer.Remove((int)index, 2);
                }
                command.Parameters.AddWithValue("@global_rating", currentGame.global_rating);
                command.Parameters.AddWithValue("@personal_rating", currentGame.personal_rating);
                command.Parameters.AddWithValue("@coverpath", currentGame.coverpath);
                command.Parameters.AddWithValue("@summary", currentGame.summary);
                command.Parameters.AddWithValue("@website", currentGame.website);
                command.Parameters.AddWithValue("@favorite", currentGame.favorite);
                command.Parameters.AddWithValue("@id", currentGame.id);
                #endregion

                if(command.ExecuteNonQuery() == 0)
                {
                    throw new NoRowsUpdatedException("No update was made");
                }

                currentGame = updatedGame;
            }
        }
    }

    /// <summary>
    /// Update a game in the database based on the game id
    /// </summary>
    /// <param name="game_id"> The id of the game to be updated </param>
    /// <param name="updatedGame"> The game with the updated data </param>
    /// <exception cref="NoRowsUpdatedException"> Thrown if the function does not update any rows </exception>
    public void UpdateGame(int game_id, ref Game updatedGame)
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
                command.Parameters.AddWithValue("@id_igdb", updatedGame.id_igdb);
                command.Parameters.AddWithValue("@executable_path", updatedGame.executable_path);
                string platform = "";
                foreach (var item in updatedGame.platforms)
                {
                    if (item.EndsWith(" ") || item.EndsWith(","))
                    {
                        platform += item;
                    }
                    else
                    {
                        platform += item + ", ";
                    }
                }
                decimal index = platform.LastIndexOf(", ");
                if (index != -1)
                {
                    platform = platform.Remove((int)index, 2);
                }

                command.Parameters.AddWithValue("@platform", platform);
                command.Parameters.AddWithValue("@playtime", updatedGame.playtime);
                command.Parameters.AddWithValue("@personal_rating", updatedGame.personal_rating);
                command.Parameters.AddWithValue("@name", updatedGame.name);
                command.Parameters.AddWithValue("@publisher", updatedGame.publisher);
                string genre = "";
                if (updatedGame.genre != null)
                {
                    foreach (var item in updatedGame.genre)
                    {
                        if (item.EndsWith(" ") || item.EndsWith(","))
                        {
                            genre += item;
                        }
                        else
                        {
                            genre += item + ", ";
                        }
                    }
                }
                else
                {
                    genre = "Unknown";
                }
                command.Parameters.AddWithValue("@genre", genre);
                string developer = "";
                if (updatedGame.developers != null)
                {
                    foreach (var item in updatedGame.developers)
                    {
                        if (item.EndsWith(" ") || item.EndsWith(","))
                        {
                            developer += item;
                        }
                        else
                        {
                            developer += item + ", ";
                        }
                    }
                    command.Parameters.AddWithValue("@developer", developer);
                }
                else
                {
                    command.Parameters.AddWithValue("@developer", "-");
                }
                index = developer.LastIndexOf(", ");
                if (index != -1)
                {
                    developer = developer.Remove((int)index, 2);
                }
                command.Parameters.AddWithValue("@global_rating", updatedGame.global_rating);
                command.Parameters.AddWithValue("@personal_rating", updatedGame.personal_rating);
                command.Parameters.AddWithValue("@coverpath", updatedGame.coverpath);
                command.Parameters.AddWithValue("@summary", updatedGame.summary);
                command.Parameters.AddWithValue("@website", updatedGame.website);
                command.Parameters.AddWithValue("@favorite", updatedGame.favorite);
                command.Parameters.AddWithValue("@id", game_id);
                #endregion

                if (command.ExecuteNonQuery() == 0)
                {
                    throw new NoRowsUpdatedException("No update was made");
                }
            }
        }
    }


    /// <summary>
    /// Remove a game from the database based on the game object
    /// </summary>
    /// <param name="game"> the game to be removed </param>
    /// <exception cref="NoRowsUpdatedException"></exception>
    public void RemoveGame(ref Game game)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = "DELETE FROM games WHERE id = @id";
                command.Parameters.AddWithValue("@id", game.id);

                if (command.ExecuteNonQuery() == 0)
                {
                    throw new NoRowsUpdatedException("No update was made");
                }
            }
        }
    }
    /// <summary>
    /// Add a todo to the database
    /// </summary>
    /// <param name="gameId"> The id of the game associated with the todo </param>
    /// <param name="todo"> The todo text </param>
    /// <returns> The id of the inserted todo </returns>


    /*----------------------TODO TABLE OPERATIONS----------------------*/
    public int AddTodo(int gameId, string todo)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText =
                @"
                INSERT INTO todos (game_id, todo)
                VALUES (@game_id, @todo);
                SELECT last_insert_rowid();
            ";
                command.Parameters.AddWithValue("@game_id", gameId);
                command.Parameters.AddWithValue("@todo", todo);

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
    }

    /// <summary>
    /// Get all todos for a specific game
    /// </summary>
    /// <param name="gameId"> The id of the game </param>
    /// <returns> List of todos </returns>
    public List<GameTODO> GetTodos(int gameId)
    {
        List<GameTODO> todos = new List<GameTODO>();

        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = "SELECT * FROM todos WHERE game_id = @game_id";
                command.Parameters.AddWithValue("@game_id", gameId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        GameTODO todo = new GameTODO
                        {
                            id = reader.GetInt32(0),
                            game_id = reader.GetInt32(1),
                            todo = reader.GetString(2),
                            done = reader.GetBoolean(3)
                        };

                        todos.Add(todo);
                    }
                }
            }
        }

        return todos;
    }

    /// <summary>
    /// Update a todo in the database
    /// </summary>
    /// <param name="todoId"> The id of the todo </param>
    /// <param name="updatedTodo"> The updated todo text </param>
    public void UpdateTodo(int todoId, string updatedTodo)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = "UPDATE todos SET todo = @updatedTodo WHERE id = @todoId";
                command.Parameters.AddWithValue("@updatedTodo", updatedTodo);
                command.Parameters.AddWithValue("@todoId", todoId);

                command.ExecuteNonQuery();
            }
        }
    }

    /// <summary>
    /// Remove a todo from the database
    /// </summary>
    /// <param name="todoId"> The id of the todo </param>
    public void RemoveTodo(int todoId)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = "DELETE FROM todos WHERE id = @todoId";
                command.Parameters.AddWithValue("@todoId", todoId);

                command.ExecuteNonQuery();
            }
        }
    }

    public void RemoveAllTodos(int gameId)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = "DELETE FROM todos WHERE game_id = @gameId";
                command.Parameters.AddWithValue("@gameId", gameId);

                command.ExecuteNonQuery();
            }
        }
    }
    /// <summary>
    /// Marks a todo as done
    /// </summary>
    /// <param name="todoId"> id of the todo</param>
    public void markAsDone(int todoId)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = "UPDATE todos SET done = 1 WHERE id = @todoId";
                command.Parameters.AddWithValue("@todoId", todoId);

                command.ExecuteNonQuery();
            }
        }
    }

    public void markAsUndone(int todoId)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = "UPDATE todos SET done = 0 WHERE id = @todoId";
                command.Parameters.AddWithValue("@todoId", todoId);

                command.ExecuteNonQuery();
            }
        }
    }

    public void UpdateRating(int id, int value)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = "UPDATE games SET personal_rating = @value WHERE id = @id";
                command.Parameters.AddWithValue("@value", value);
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
        }
    }

    public void MarkWithIdAndString(int id, string str, bool state)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SQLiteCommand(connection))
            {
                List<GameTODO> gameTODOs = GetTodos(id);
                int searchedID = -1;
                foreach (var item in gameTODOs)
                {
                    if (item.todo == str)
                    {
                        searchedID = item.id;
                    }
                }

                if (searchedID != -1)
                {
                    if (state)
                    {
                        command.CommandText = "UPDATE todos SET done = 1 WHERE id = @id";
                    }
                    else
                    {
                        command.CommandText = "UPDATE todos SET done = 0 WHERE id = @id";
                    }
                    command.Parameters.AddWithValue("@id", searchedID);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}