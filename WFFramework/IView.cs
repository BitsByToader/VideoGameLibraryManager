/************************************************************************************
*                                                                                   *
*  File:        FormNavigationStack                                                 *
*  Copyright:   (c) 2024, Ifrim Tudor                                               *
*  E-mail:      tudor-nicolae.ifrim@student.tuiasi.ro                               *
*  Description: Provides an interface for views which are part of hierarchies and   *
*               have lifecycles.                                                    *
*                                                                                   *
*                                                                                   *
*  This code and information is provided "as is" without warranty of                *
*  any kind, either expressed or implied, including but not limited                 *
*  to the implied warranties of merchantability or fitness for a                    *
*  particular purpose. You are free to use this source code in your                 *
*  applications as long as the original copyright notice is included.               *
*                                                                                   *
************************************************************************************/

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
        /// Not available in C# 7.3, but this method should be internal as only the parent (container) should call this method.
        /// </summary>
        /// <param name="parent"></param>
        void AddToParent(IViewContainer parent);

        /// <summary>
        /// Removes this view from the parent's hierarchy.
        /// Not available in C# 7.3, but this method should be internal as only the parent (container) should call this method.
        /// </summary>
        void RemoveFromParent();
        
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