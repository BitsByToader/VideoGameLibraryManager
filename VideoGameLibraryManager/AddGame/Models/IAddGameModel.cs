/************************************************************************************
*                                                                                   *
*  File:        IAddGameModel                                                       *
*  Copyright:   (c) 2024, Ifrim Tudor                                               *
*  E-mail:      tudor-nicolae.ifrim@student.tuiasi.ro                               *
*  Description: Interface for a data model for AddGameController                    *
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

namespace VideoGameLibraryManager.AddGame
{
    public interface IAddGameModel
    {
        void SetGameAPIQuery(string query);
        string GetGameAPIQuery();
        void SetDesiredGameName(string name);
        string GetDesiredGameName();
        void SetGame(Game game);
    }
}
