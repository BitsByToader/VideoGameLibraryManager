using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFFramework;

namespace VideoGameLibraryManager.Library
{
    internal interface IGameLibraryView: IView
    {
        void Refresh();
        void SetController(IGameLibraryController controller);
    }
}
