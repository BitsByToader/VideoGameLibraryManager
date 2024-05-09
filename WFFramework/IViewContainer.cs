using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFFramework
{
    public interface IViewContainer
    {
        void ChangeView(IView view);
        IView GetCurrentView();
    }
}