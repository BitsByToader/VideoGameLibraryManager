using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Add a game to the list of games
        /// </summary>
        /// <param name="game"></param>
        /// <returns> 1 if the game was added, 0 if the game was not added </returns>
        public byte AddGame(Game game)
        {
            try
            {             
                if (game == null)
                {
                    throw new ArgumentNullException();
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
                return 1;
            }
            _games.Add(game);
            return 0;
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
        /// Get a game from the list of games
        /// </summary>
        /// <param name="idx"> The index of the game to get </param>
        /// <returns></returns>
        public Game GetGame(int idx)
        {
            if(idx < 0 || idx >= _games.Count)
            {
                return null;
            }
            return _games[idx];
        }

        public byte RemoveGame(int idx)
        {
            if (idx < 0 || idx >= _games.Count)
            {
                return 1;
            }
            _games.RemoveAt(idx);
            return 0;
        }

        /// <summary>
        /// Update a game in the list of games
        /// </summary>
        /// <param name="idx"> The index of the game to update </param>
        /// <param name="game">< The game to update </param>
        /// <returns></returns>
        public byte UpdateGame(int idx, Game game)
        {
            if (idx < 0 || idx >= _games.Count)
            {
                return 1;
            }
            _games[idx] = game;
            return 0;
        }
    }
}
