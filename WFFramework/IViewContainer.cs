/************************************************************************************
*                                                                                   *
*  File:        FormNavigationStack                                                 *
*  Copyright:   (c) 2024, Ifrim Tudor                                               *
*  E-mail:      tudor-nicolae.ifrim@student.tuiasi.ro                               *
*  Description: Provides an interface for containers which make up hierarchies of   *
*               IViews.                                                             *
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
using System.Text;
using System.Threading.Tasks;

namespace WFFramework
{
    /// <summary>
    /// Classes implementing this interface have the role of housing any arbitrary view, one at a time.
    /// </summary>
    public interface IViewContainer
    {
        /// <summary>
        /// Changes the view the container houses, i.e. the state the container is in.
        /// </summary>
        /// <param name="view">The new view the container will store.</param>
        void ChangeView(IView view);
        
        /// <summary>
        /// Retrieves the current view of the container.
        /// </summary>
        /// <returns>The view from the container.</returns>
        IView GetCurrentView();
    }
}