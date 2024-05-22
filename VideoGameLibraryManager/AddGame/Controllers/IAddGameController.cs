using LibraryCommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WFFramework;

namespace VideoGameLibraryManager.AddGame
{
    public interface IAddGameController
    {
        IAddGameView GetView();
        void SetSuggestedGamesQuery(string query);
        void PickGameToRetrieve(string name);
        void RetrieveGameFromAPI();
        void RetrieveSuggestions();
        void SaveGame(Game game);
    }
}
