/************************************************************************************
*                                                                                   *
*  File:        IGameToControlConverter.cs                                          *
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace Helpers
{
    /// <summary>
    /// Interface that provides a way of converting from game object to any type of control that needs information
    /// about a game.
    /// </summary>
    public interface IGameToControlConverter
    {
        /// <summary>
        /// transforms game to desired control.
        /// </summary>
        /// <param name="game"></param>
        /// <returns>Custom control object</returns>
        Control Convert(Game game);
    }
}
