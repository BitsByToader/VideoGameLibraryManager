using LibraryCommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFFramework;

namespace VideoGameLibraryManager.ViewGame.Views
{
    public interface IViewGameView: IView
    {
        void DisplayGame(ref Game game);
        void DisplayError(string message);
        void ConfirmDeletion(bool success);
    }
}
