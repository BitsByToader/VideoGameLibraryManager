using LibraryCommons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameLibraryManager.Library;
using VideoGameLibraryManager.Library.Models;
using VideoGameLibraryManager.ViewGame.Models;
using VideoGameLibraryManager.ViewGame.Views;
using WFFramework;

namespace VideoGameLibraryManager.ViewGame
{
    /// <summary>
    /// The controller for the ViewGame view.
    /// </summary>
    public class ViewGameController : IViewGameController
    {
        private IViewGameModel _model;
        private IViewGameView _view;

        /// <summary>
        /// Constructor for the ViewGameController.
        /// </summary>
        /// <param name="parent"> The parent view container. </param>
        /// <param name="game"> The game to be viewed. </param>
        public ViewGameController(IViewContainer parent, Game game)
        {
            //_gameLibraryModel = glm;
            _model = new ViewGameModel();
            _model.SetGame(ref game);
            // fortam ca acest view sa fie copil al unui navigation stack, altfel consideram ca nu are parinte
            _model.SetParent(parent as FormNavigationStack); 
            _view = new ViewGameView(this);
            RetrieveGame();
        }

        /// <summary>
        /// Fetches the view the controller is managing.
        /// </summary>
        /// <returns> The view. </returns>
        public IViewGameView GetView()
        {
            return _view;
        }

        /// <summary>
        /// Retrieves the game from the database.
        /// </summary>
        public void RetrieveGame()
        {
            try
            {
                Game game = _model.GetGame();
                _view.DisplayGame(ref game);
            }
            catch (Exception ex)
            {
                _view.DisplayError(ex.Message);
            }
        }

        /// <summary>
        /// Updates the game in the view and the database.
        /// </summary>
        /// <param name="game"> The game to update. </param>
        public void UpdateGame(Game game)
        {
            try
            {
                _model.SetGame(ref game);
                _view.DisplayGame(ref game);
                try
                {
                    GameLibraryDb.GetInstance("").UpdateGame(game.id, ref game);
                }
                catch(Exception ex)
                {
                    _view.DisplayError(ex.Message);
                }
            }
            catch (Exception ex)
            {
                _view.DisplayError(ex.Message);
            }
        }
        /// <summary>
        /// Adds a todo to the game.
        /// </summary>
        /// <param name="todo">The TODO to be added</param>
        public void AddToDo(string todo)
        {
            GameLibraryDb.GetInstance("").AddTodo(_model.GetGame().id,todo);
        }
        /// <summary>
        /// Deletes the game from the database.
        /// </summary>
        public void DeleteGame()
        {
            try
            {
                //_model.DeleteGame(id);
                var game = _model.GetGame();
                GameLibraryDb.GetInstance("").RemoveGame(ref game);
                _view.ConfirmDeletion(true);

            }
            catch (Exception ex)
            {
                _view.DisplayError(ex.Message);
            }
        }

        /// <summary>
        /// Gets the todos for the game.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<GameTODO> GetTodos(int id)
        {
            return GameLibraryDb.GetInstance("").GetTodos(id);
        }

        /// <summary>
        /// Updates the rating of the game in the view and the database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void UpdateRating(int id, int value)
        {
            GameLibraryDb.GetInstance("").UpdateRating(id, value);
        }

        /// <summary>
        /// Updates the status of the todo.
        /// </summary>
        /// <param name="todo"></param>
        /// <param name="check"></param>
        public void UpdateToDoStatus(string todo, bool check)
        {
            GameLibraryDb.GetInstance("").MarkWithIdAndString(_model.GetGame().id, v1,v2);
        }
    }
}
