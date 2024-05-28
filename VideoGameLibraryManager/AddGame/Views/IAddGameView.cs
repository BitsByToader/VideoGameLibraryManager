/************************************************************************************
*                                                                                   *
*  File:        IAddGameView                                                        *
*  Copyright:   (c) 2024, Ifrim Tudor                                               *
*  E-mail:      tudor-nicolae.ifrim@student.tuiasi.ro                               *
*  Description: Interface for a view which adds games to the persistence            *
*               layer.                                                              *
*                                                                                   *
*                                                                                   *
*  This code and information is provided "as is" without warranty of                *
*  any kind, either expressed or implied, including but not limited                 *
*  to the implied warranties of merchantability or fitness for a                    *
*  particular purpose. You are free to use this source code in your                 *
*  applications as long as the original copyright notice is included.               *
*                                                                                   *
************************************************************************************/

using LibraryCommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFFramework;

namespace VideoGameLibraryManager.AddGame
{
    /// <summary>
    /// This view is used by the paired controller to retrieve a game's detail from the user.
    /// </summary>
    public interface IAddGameView: IView
    {
        /// <summary>
        /// Sets the search result for the suggested games retrieved from the API.
        /// </summary>
        /// <param name="result">The result as a array of strings joined by a newline character.</param>
        void SetSearchResult(string result);
        
        /// <summary>
        /// Updates the presentation with a game's details.
        /// </summary>
        /// <param name="game">The new game to present to the user.</param>
        void UpdateFieldsUsingGame(Game game);
    }
}
