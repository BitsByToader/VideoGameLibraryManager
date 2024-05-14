/************************************************************************************
*                                                                                   *
*  File:        GameToBriefBoxInfo.cs                                               *                                                 
*  Copyright:   (c) 2024, Cristina Andrei Marian                                    *
*  E-mail:      andrei-marian.cristina@student.tuiasi.ro                            *
*  Description:                                                                     *
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
using System.Windows.Forms;


namespace Helpers
{
    /// <summary>
    /// Converter from a Game object to a custom user control that shows brief information about the game.
    /// </summary>
    public class GameToBriefGameBoxInfo : IGameToControlConverter
    {
        public Control Convert(Game game)
        {
            BriefGameInfoBox userControl = new BriefGameInfoBox();
            
            userControl.GameImage = game.image;
            userControl.GameName = game.name;

            return userControl;
        }
    }
}
