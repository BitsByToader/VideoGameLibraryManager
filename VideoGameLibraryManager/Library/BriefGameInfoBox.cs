/************************************************************************************
*                                                                                   *
*  File:        BriefGameInfoBox.cs                                                 *
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFFramework;

namespace Helpers
{
    /// <summary>
    /// Custom User Control that provides limited info about a game - name and artwork; 
    /// </summary>
    public partial class BriefGameInfoBox : UserControl, IView
    {
        public BriefGameInfoBox()
        {
            InitializeComponent();
        }

        private string _gameName;
        private Image _gameImage;

        [Category("Custom Property")]
        public string GameName
        {
            get { return _gameName; }
            set { _gameName = value; gameName.Text = value; }
        }

        [Category("Custom Property")]
        public Image GameImage
        {
            get { return _gameImage; }
            set { _gameImage = value; gamePictureBox.Image = value; }
        }

        public void AddToParent(IViewContainer parent)
        {
            throw new NotImplementedException();
        }

        public void removeFromParent()
        {
            throw new NotImplementedException();
        }

        public IViewContainer GetParentContainer()
        {
            throw new NotImplementedException();
        }

        public void WillAppear()
        {
            throw new NotImplementedException();
        }

        public void WillDisappear()
        {
            throw new NotImplementedException();
        }

        public void WillBeAddedToParent()
        {
            throw new NotImplementedException();
        }

        public void WillBeRemovedFromParent()
        {
            throw new NotImplementedException();
        }
    }
}
