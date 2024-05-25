using LibraryCommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameLibraryManager.ViewGame.Models
{
    public interface IViewGameModel
    {
        Game GetGame();
        void SetGame(Game game);
        void DeleteGame(string name);
    }
}
