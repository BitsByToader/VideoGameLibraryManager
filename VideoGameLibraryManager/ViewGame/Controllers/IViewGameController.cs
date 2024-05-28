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
    /// <summary>
    /// Interface for the ViewGameController to allow for fetching game data.
    /// </summary>
    public interface IViewGameController
    {
        /// <summary>
        /// Fetches the view the controller is managing.
        /// </summary>
        /// <returns> The view. </returns>
        IViewGameView GetView();
        /// <summary>
        /// Retrieves the game from the database.
        /// </summary>
        void RetrieveGame();
        /// <summary>
        /// Updates the game in the view and the database.
        /// </summary>
        /// <param name="game"></param>
        void UpdateGame(Game game);
        /// <summary>
        /// Deletes the game from the database.
        /// </summary>
        void DeleteGame();
        /// <summary>
        /// Adds a todo to the game.
        /// </summary>
        /// <param name="todo"></param>
        void AddToDo(string todo);
        /// <summary>
        /// Gets the todos for the game.
        /// </summary>
        /// <param name="id"> The id of the game to get the todos for. </param>
        /// <returns> A list of todos. </returns>
        List<GameTODO> GetTodos(int id);
        /// <summary>
        /// Updates the rating of the game in the view and the database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        void UpdateRating(int id, int value);
        /// <summary>
        /// Updates the status of the todo.
        /// </summary>
        /// <param name="todoString"></param>
        /// <param name="check"></param>
        void UpdateToDoStatus(string todo, bool check);
    }
}
