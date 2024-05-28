/************************************************************************************
*                                                                                   *
*  File:        ViewGameModel.cs                                                    *
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
    /// <summary>
    /// The model for the view game form
    /// </summary>
    public class ViewGameModel : IViewGameModel
    {
        private FormNavigationStack _parent;
        private Game _game; // populated during lifetime

        public void DeleteGame(int id)
        {
            //stub not needed rn
        } 

        public Game GetGame()
        {
            return _game;
        }

        public void SetGame(ref Game game)
        {
            _game = game;
        }

        public void SetParent(FormNavigationStack parent) => _parent = parent;

        public FormNavigationStack GetParent() => _parent;
    }
}
