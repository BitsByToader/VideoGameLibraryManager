using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDB_Manager
{
    public class GameLibraryMemDB : SessionInterface
    {
        public List<Game> games;
        private static GameLibraryMemDB _instance;

        private GameLibraryMemDB()
        {
            games = new List<Game>();
        }

        public static GameLibraryMemDB GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GameLibraryMemDB();
            }
            return _instance;
        }

        public byte AddGame(Game game)
        {
            throw new NotImplementedException();
        }

        public List<Game> GetAllGames()
        {
            throw new NotImplementedException();
        }

        public Game GetGame(int idx)
        {
            throw new NotImplementedException();
        }

        public byte RemoveGame(int idx)
        {
            throw new NotImplementedException();
        }

        public byte UpdateGame(int idx, Game game)
        {
            throw new NotImplementedException();
        }
    }
}
