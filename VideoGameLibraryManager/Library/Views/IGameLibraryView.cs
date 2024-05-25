using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VideoGameLibraryManager.Models;
using WFFramework;

namespace VideoGameLibraryManager.Library
{
    public interface IGameLibraryView: IView
    {
        void ChangeView(DisplayType type);
        void SetController(ref IGameLibraryController controller);
    }
}
