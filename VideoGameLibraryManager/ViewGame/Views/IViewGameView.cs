/************************************************************************************
*                                                                                   *
*  File:        IViewGameView.cs                                                    *
*  Copyright:   (c) 2024, Darie Alexandru                                           *
*  E-mail:      alexandru.darie@student.tuiasi.ro                                   *
*  Description: Interface for the view of the game view                             *
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

namespace VideoGameLibraryManager.ViewGame.Views
{
    /// <summary>
    /// Interface for the view of the game view
    /// </summary>
    public interface IViewGameView: IView
    {
        /// <summary>
        /// Fill the form with the game's data
        /// </summary>
        /// <param name="game"> The game to display </param>
        void DisplayGame(ref Game game);
        /// <summary>
        /// Display an error message to the user in a dialog if necessary
        /// </summary>
        /// <param name="message"> The message to display </param>
        void DisplayError(string message);
        /// <summary>
        /// Confirm that the game was deleted
        /// </summary>
        /// <param name="success"> Whether the deletion was successful </param>
        void ConfirmDeletion(bool success);
    }
}
