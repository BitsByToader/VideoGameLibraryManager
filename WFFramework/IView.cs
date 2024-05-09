using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace WFFramework
{
    public interface IView
    {
        void AddToParent(IViewContainer parent);
        void removeFromParent();
        IViewContainer GetParentContainer();
        
        void WillAppear();
        void WillDisappear();

        void WillBeAddedToParent();
        void WillBeRemovedFromParent();
    }
}