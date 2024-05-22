using API_Manager;
using LibraryCommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDB_Manager;

namespace VideoGameLibraryManager.AddGame
{
    public class AddGameModel: IAddGameModel
    {
        private Game _game = new Game(); // blank by default, populated during lifetime
        private string _desiredGame;
        private string _apiQuery;

        public string GetDesiredGameName()
        {
            return _desiredGame;
        }

        public string GetGameAPIQuery()
        {
            return _apiQuery;
        }

        public void SetDesiredGameName(string name)
        {
            _desiredGame = name;
        }

        public void SetGame(Game game)
        {
            _game = game;
        }

        public void SetGameAPIQuery(string query)
        {
            _apiQuery = query;
        }
    }
}
