using LibraryCommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            _model = new ViewGameModel();
            _model.SetGame(game);
            // fortam ca acest view sa fie copil al unui navigation stack, altfel consideram ca nu are parinte
            _model.SetParent(parent as FormNavigationStack); 
            _view = new ViewGameView();
        }

        public IViewGameView GetView()
        {
            return _view;
        }

        public void RetrieveGame(string name)
        {
            try
            {
                Game game = _model.GetGame();
                _view.DisplayGame(game);
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
                _model.SetGame(game); // Assuming SetGame updates a game
                _view.DisplayGame(game);
            }
            catch (Exception ex)
            {
                _view.DisplayError(ex.Message);
            }
        }

        public void DeleteGame(string name)
        {
            try
            {
                _model.DeleteGame(name); // Assuming DeleteGame deletes a game by name
                _view.ConfirmDeletion(true);
            }
            catch (Exception ex)
            {
                _view.DisplayError(ex.Message);
            }
        }
    }
}
