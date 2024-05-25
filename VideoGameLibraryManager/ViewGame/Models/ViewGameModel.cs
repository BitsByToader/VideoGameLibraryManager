using LibraryCommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameLibraryManager.ViewGame.Models
{
    public class ViewGameModel : IViewGameModel
    {
        private Game _game; // populated during lifetime

        public void DeleteGame(string name)
        {
            throw new NotImplementedException();
        }

        public Game GetGame()
        {
            return _game;
        }

        public void SetGame(Game game)
        {
            _game = game;
        }
    }
}
