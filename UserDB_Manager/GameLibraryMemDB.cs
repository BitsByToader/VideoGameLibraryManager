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

using LibraryCommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LibraryCommons.LibraryCommons;

namespace UserDB_Manager
{
    public class GameLibraryMemDB : SessionInterface
    {
        private List<Game> _games;
        private static GameLibraryMemDB _instance;

        /// <summary>
        /// Private constructor for singleton pattern
        /// </summary>
        private GameLibraryMemDB()
        {
            _games = new List<Game>();
        }

        /// <summary>
        /// Get the instance of the GameLibraryMemDB (singleton pattern)
        /// </summary>
        /// <returns> The instance of the GameLibraryMemDB </returns>
        public static GameLibraryMemDB GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GameLibraryMemDB();
            }
            return _instance;
        }

        /// <summary>
        /// Add a game to the list of games based on the game object
        /// </summary>
        /// <param name="game"> The game object to add </param>
        public void AddGame(ref Game game)
        {         
            if (game == null)
            {
                throw new ArgumentNullException("Jocul este NULL.");
            }
            
            _games.Add(game);
        }

        /// <summary>
        /// Get all games in the list of games
        /// </summary>
        /// <returns> The list of games </returns>
        public List<Game> GetAllGames()
        {
            return _games;
        }

        /// <summary>
        /// Get a game from the list of games based on the game object.
        /// This will return the first game found with the same name and id. 
        /// </summary>
        /// <param name="game"> The game object to get based on name or id</param>
        /// <returns> The game object </returns>
        /// <exception cref="DatabaseException"> No game was found with the fields specified </exception>
        public Game GetGame(ref Game game)
        {
            Game foundGame = null;
            Game savedGame = null;

            foreach (Game g in _games)
            {
                if (g.name == game.name)
                {
                    if (g.id == game.id)
                    {
                        foundGame = g;
                        break;
                    }
                    else if (savedGame == null)
                    {
                        savedGame = g;
                    }
                }
            }

            if (foundGame != null)
            {
                return foundGame;
            }
            else if (savedGame != null)
            {
                return savedGame;
            }
            else
            {
                throw new DatabaseException("No game was found to return");
            }
        }

        /// <summary>
        /// Remove a game from the list of games based on the game object.
        /// This will remove the first game found with the same name and id.
        /// If no game is found with the same name and id, it will remove the first game found with the same name.
        /// </summary>
        /// <param name="game"> The game object to remove </param>
        /// <example> You want to remove a game with name "Roblox" with id 1
        /// <code>
        ///     var game = new Game();
        ///     game.name = "Roblox";
        ///     game.id = 1;
        ///     _instance.RemoveGame(ref game);
        /// </code>
        /// </example>
        /// <exception cref="DatabaseException"> No game was found with the fields specified </exception>
        public void RemoveGame(ref Game game)
        {
            Game foundGame = null;
            Game savedGame = null;

            foreach (Game g in _games)
            {
                if (g.name == game.name)
                {
                    if (g.id == game.id)
                    {
                        foundGame = g;
                        break;
                    }
                    else if (savedGame == null)
                    {
                        savedGame = g;
                    }
                }
            }

            if (foundGame != null)
            {
                _games.Remove(foundGame);
            }
            else if (savedGame != null)
            {
                _games.Remove(savedGame);
            }
            else
            {
                throw new DatabaseException("No game was found to remove");
            }
        }

        /// <summary>
        /// Update a game in the list of games
        /// </summary>
        /// <param name="idx"> The index of the game to update </param>
        /// <param name="game">< The game to update </param>
        /// <returns></returns>
        public void UpdateGame(ref Game currentGame, ref Game updatedGame)
        {
            if (currentGame == null || updatedGame == null)
            {
                throw new ArgumentNullException("One of the parrameters is null.");
            }

            int idx = _games.IndexOf(currentGame);
            if (idx != -1)
            {
                _games[idx].LocalUpdateWithDifferences(ref updatedGame);
            }
            else
            {
                int idxFoundGame=-1;
                int idxSavedGame=-1;

                foreach (Game g in _games)
                {
                    if (g.name == currentGame.name)
                    {
                        if (g.id == currentGame.id)
                        {
                            idxFoundGame = _games.IndexOf(g);
                            break;
                        }
                        else if (idxSavedGame == -1)
                        {
                            idxSavedGame = _games.IndexOf(g);
                        }
                    }
                }

                if(idxFoundGame != -1)
                {
                    _games[idx].LocalUpdateWithDifferences(ref updatedGame);
                }
                else if(idxSavedGame != -1)
                {
                    _games[idx].LocalUpdateWithDifferences(ref updatedGame);
                }
                else
                {
                    throw new DatabaseException("No game was found to be updated");
                }
            }

        }
    }
}
