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

namespace UserDB_Manager
{
    /// <summary>
    /// Interface for the database, file or memory, offering the basic CRUD operations
    /// </summary>
    interface SessionInterface
    {
        //
        void AddGame(ref Game game);                    
        void RemoveGame(ref Game game);                    
        void UpdateGame(ref Game initialGame, ref Game updatedGame);
        List<Game> GetAllGames();
        Game GetGame(ref Game game);
    }
}
