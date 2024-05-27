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
        void RetrieveGame();
        void UpdateGame(Game game);
        void DeleteGame();
        void AddToDo(string todo);
        List<GameTODO> GetTodos(int id);
        void UpdateRating(int id, int value);
        void UpdateToDoStatus(string v1, bool v2);
    }
}
