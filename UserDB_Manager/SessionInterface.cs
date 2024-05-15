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

using IGDB_Manager;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace UserDB_Manager
{
    interface SessionInterface
    {
        Byte AddGame(Game game);                     // returns an error code , 0 if successful
        Byte RemoveGame(int idx);                    // returns an error code , 0 if successful
        Byte UpdateGame(int idx, Game game);         // returns an error code , 0 if successful
        List<Game> GetAllGames();
        Game GetGame(int idx);
    }
}
