using LibraryCommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameLibraryManager.AddGame
{
    public interface IAddGameModel
    {
        void SetGameAPIQuery(string query);
        string GetGameAPIQuery();
        void SetDesiredGameName(string name);
        string GetDesiredGameName();
        void SetGame(Game game);
    }
}
