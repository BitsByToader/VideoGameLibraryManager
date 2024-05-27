/************************************************************************************
*                                                                                   *
*  File:        IViewGameModel.cs                                                   *
*  Copyright:   (c) 2024, Darie Alexandru                                           *
*  E-mail:      alexandru.darie@student.tuiasi.ro                                   *
*  Description: View File for the View Game Form.                                   *
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

namespace VideoGameLibraryManager.ViewGame.Models
{
    public interface IViewGameModel
    {
        /// <summary>
        /// Fetches the game object
        /// </summary>
        /// <returns> The game object </returns>
        Game GetGame();
        /// <summary>
        /// Sets the game object
        /// </summary>
        /// <param name="game"> The game object to set </param>
        void SetGame(ref Game game);

        /// <summary>
        /// Deletes a game from the list of games
        /// </summary>
        /// <param name="id">The id of the game to delete</param>
        void DeleteGame(int id);

        /// <summary>
        /// Sets the parent form
        /// </summary>
        /// <param name="parent"> The parent form to set </param>
        void SetParent(FormNavigationStack parent);

        /// <summary>
        /// Gets the parent form
        /// </summary>
        /// <returns>The parent form</returns>
        FormNavigationStack GetParent();
    }
}
