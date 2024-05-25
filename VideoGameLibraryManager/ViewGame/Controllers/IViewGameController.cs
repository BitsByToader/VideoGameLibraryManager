using LibraryCommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameLibraryManager.AddGame;
using VideoGameLibraryManager.ViewGame.Views;

namespace VideoGameLibraryManager.ViewGame
{
    public interface IViewGameController
    {
        IViewGameView GetView();
        void RetrieveGame(string name);
        void UpdateGame(Game game);
        void DeleteGame(string name);
    }
}
