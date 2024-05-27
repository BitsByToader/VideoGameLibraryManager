/************************************************************************************
*                                                                                   *
*  File:        IGameLibraryView.cs                                                 *
*  Copyright:   (c) 2024, Cristina Andrei Marian                                    *
*  E-mail:      andrei-marian.cristina@student.tuiasi.ro                            *
*  Description: interface that provides basic functions of the game library         *
*                                                                                   *
*                                                                                   *
*  This code and information is provided "as is" without warranty of                *
*  any kind, either expressed or implied, including but not limited                 *
*  to the implied warranties of merchantability or fitness for a                    *
*  particular purpose. You are free to use this source code in your                 *
*  applications as long as the original copyright notice is included.               *
*                                                                                   *
************************************************************************************/

using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WFFramework;

namespace VideoGameLibraryManager.Library
{
    public interface IGameLibraryView: IView
    {
        void ChangeView();
        void SetController(ref IGameLibraryController controller);
    }
}
