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
    public class ViewGameController : IViewGameController
    {
        private IViewGameModel _model;
        private IViewGameView _view;

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

        public IViewGameView GetView()
        {
            return _view;
        }

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
        public void AddToDo(string todo)
        {
            GameLibraryDb.GetInstance("").AddTodo(_model.GetGame().id,todo);
        }
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

        public List<GameTODO> GetTodos(int id)
        {
            return GameLibraryDb.GetInstance("").GetTodos(id);
        }

        public void UpdateRating(int id, int value)
        {
            GameLibraryDb.GetInstance("").UpdateRating(id, value);
        }

        public void UpdateToDoStatus(string v1, bool v2)
        {
            GameLibraryDb.GetInstance("").MarkWithIdAndString(_model.GetGame().id, v1,v2);
        }
    }
}
