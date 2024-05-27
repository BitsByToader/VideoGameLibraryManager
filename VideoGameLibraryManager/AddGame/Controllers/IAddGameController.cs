/************************************************************************************
*                                                                                   *
*  File:        IAddGameController                                                  *
*  Copyright:   (c) 2024, Ifrim Tudor                                               *
*  E-mail:      tudor-nicolae.ifrim@student.tuiasi.ro                               *
*  Description: Interface for a controller which adds games to the persistence      *
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
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WFFramework;

namespace VideoGameLibraryManager.AddGame
{
    /// <summary>
    /// Controller used for adding games into the persistence layer.
    /// </summary>
    public interface IAddGameController
    {
        /// <summary>
        /// Retrieves the view the controller is managing.
        /// </summary>
        /// <returns>The view.</returns>
        IAddGameView GetView();
        
        /// <summary>
        /// Sets the query the user typed in for getting a list of suggested games from API.
        /// </summary>
        /// <param name="query">The query.</param>
        void SetSuggestedGamesQuery(string query);
        
        /// <summary>
        /// Sets the name of the game the user wants to retrieve later on.
        /// </summary>
        /// <param name="name"></param>
        void PickGameToRetrieve(string name);

        /// <summary>
        /// Retrieves and instructs the view to display the game retrieved from the API.
        /// </summary>
        void RetrieveGameFromAPI();
        
        /// <summary>
        /// Retrieves a list of suggestions from the API.
        /// </summary>
        void RetrieveSuggestions();
        
        /// <summary>
        /// Saves a customized game object to the peristence layer.
        /// </summary>
        /// <param name="game">The customized game to save.</param>
        void SaveGame(Game game);
    }
}
