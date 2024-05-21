/**************************************************************************
 *                                                                        *
 *  File:        DatabaseManager                                          *
 *  Copyright:   (c) 2024, Darie Alexandru                                *
 *  E-mail:      alexandru.darie@student.tuiasi.ro                        *
 *  Description: Namespace for full control over a database via methods.  *
 *                                                                        *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/

using API_Manager;
using LibraryCommons;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static LibraryCommons.LibraryCommons;

namespace UserDB_Manager
{
    /// <summary>
    /// Interface for the database, file or memory, offering the basic CRUD operations
    /// </summary>
    public interface SessionInterface
    {
        /// <summary>
        /// This method is used to add a new game to the database
        /// </summary>
        /// <param name="game"> The game to be added </param>
        void AddGame(ref Game game);                    

        /// <summary>
        /// This method is used to remove a game from the database
        /// </summary>
        /// <param name="game">Game to be removed</param>
        void RemoveGame(ref Game game);                  
        /// <summary>
        /// This method is used to update a game from the database
        /// </summary>
        /// <param name="initialGame"> The game to be updated </param>
        /// <param name="updatedGame"> The updated game </param>
        void UpdateGame(ref Game initialGame, ref Game updatedGame);

        /// <summary>
        /// This method is used to get all the games from the database
        /// </summary>
        /// <returns> A list of all the games </returns>
        List<Game> GetAllGames();
        /// <summary>
        /// This method is used to get a game from the database
        /// </summary>
        /// <param name="game"> The game to be retrieved </param>
        /// <returns> The game </returns>
        Game GetGame(ref Game game);
    }
}
