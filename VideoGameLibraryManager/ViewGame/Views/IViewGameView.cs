using LibraryCommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameLibraryManager.ViewGame.Views
{
    public interface IViewGameView
    {
        void DisplayGame(Game game);
        void DisplayError(string message);
        void ConfirmDeletion(bool success);
    }
}
