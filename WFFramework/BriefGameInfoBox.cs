using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFFramework
{
    public partial class BriefGameInfoBox : UserControl
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

    }
}
