using API_Manager;
using LibraryCommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameLibraryManager.AddGame
{
    public class AddGameController : IAddGameController
    {
        private IAddGameView _view;
        private IAddGameModel _model;

        public AddGameController()
        {
            _view = new AddGameView(this);
            _model = new AddGameModel();
        }

        public IAddGameView GetView()
        {
            return _view;
        }

        public void PickGameToRetrieve(string name)
        {
            _model.SetDesiredGameName(name);
        }

        public void RetrieveGameFromAPI()
        {
            string gameName = _model.GetDesiredGameName();

            Task.Run(async () =>
            {
                Game game = await IGDB_API.GetInstance("", "").GetGameByName(gameName);
                _view.UpdateFieldsUsingGame(game);
            });
        }

        public void RetrieveSuggestions()
        {
            string query = _model.GetGameAPIQuery();
            Task.Run(async () =>
            {
                string result = await IGDB_API.GetInstance("", "").SearchGameNames(query);
                _view.SetSearchResult(result);
            });
        }

        public void SaveGame(Game game)
        {
            _model.SetGame(game);
            GameLibraryDb.GetInstance("").AddGame(ref game);
        }

        public void SetSuggestedGamesQuery(string query)
        {
            _model.SetGameAPIQuery(query);
        }
    }
}
