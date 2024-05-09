using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace WFFramework
{
    /// <summary>
    /// Primary interface for views that want to be included in WFFramework hierarchies. Supports setting Containers as parents and provides basic lifecycle methods for objects.
    /// In general, the main purpose for the hierarchy is to provide a state machine implementation for the user interface at compile-time.
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Adds this view to the parent's (a container) hierarchy. Ideally, an implementing class will also store this parent for bookkeeping and other View State related tasks.
        /// </summary>
        /// <param name="parent"></param>
        void AddToParent(IViewContainer parent);
        
        /// <summary>
        /// Removes this view from the parent's hierarchy.
        /// </summary>
        void removeFromParent();
        
        /// <summary>
        /// Retrieves the direct parent of this view.
        /// </summary>
        /// <returns></returns>
        IViewContainer GetParentContainer();
        
        /// <summary>
        /// Notifies the view that it is about to be displayes by its parent (or someone else too). Part of the view's lifecycle, useful, usually for UI-related tasks like animations, timers, download tasks, etc.
        /// </summary>
        void WillAppear();
        
        /// <summary>
        /// Notifies the view that it is about to be removed from rendering by its parent (or someone else too). Useful to stop or pause certain tasks, perform cleanup tasks, etc.
        /// </summary>
        void WillDisappear();

        /// <summary>
        /// Notifies the view that it is about to be added to the hierarchy of a container, by an external source. For example, a navigation stack can call this method when this view is pushed onto the stack by someone else.
        /// </summary>
        void WillBeAddedToParent();
        
        /// <summary>
        /// Notifies the view that it is about to be removed from a hierarchy.
        /// </summary>
        void WillBeRemovedFromParent();
    }
}