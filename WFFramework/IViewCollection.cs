/************************************************************************************
*                                                                                   *
*  File:        FormNavigationStack                                                 *
*  Copyright:   (c) 2024, Ifrim Tudor                                               *
*  E-mail:      tudor-nicolae.ifrim@student.tuiasi.ro                               *
*  Description: Provides an interface for a type of container which stores IViews   *
*               arbitrarily.                                                        *
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
    public interface IViewCollection
    {
        /// <summary>
        /// A collection uses this method to compute the total number of views in the collection.
        /// </summary>
        /// <returns>Number of views which will be displayed.</returns>
        int Count();
        
        /// <summary>
        /// Instructs the collection view that the dataset has changed and needs to redraw its contents.
        /// </summary>
        void RefreshViews();

        /// <summary>
        /// Accessor for the collection to retrieve a view at the specified index.
        /// </summary>
        /// <param name="index">Index of the view in the collection.</param>
        /// <returns>The view at the desired index.</returns>
        IView ViewAt(int index);
    }
}