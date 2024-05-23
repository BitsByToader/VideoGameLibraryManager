using LibraryCommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFFramework;

namespace VideoGameLibraryManager.AddGame
{
    public interface IAddGameView: IView
    {
        void SetSearchResult(string result);
        void UpdateFieldsUsingGame(Game game);
    }
}
