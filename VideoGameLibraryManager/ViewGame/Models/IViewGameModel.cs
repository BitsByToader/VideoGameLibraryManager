using LibraryCommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFFramework;

namespace VideoGameLibraryManager.ViewGame.Models
{
    public interface IViewGameModel
    {
        Game GetGame();
        void SetGame(ref Game game);
        void DeleteGame(int id);
        void SetParent(FormNavigationStack parent);
        FormNavigationStack GetParent();
    }
}
