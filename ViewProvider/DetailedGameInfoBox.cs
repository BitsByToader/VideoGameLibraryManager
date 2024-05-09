using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewProvider
{
    public partial class DetailedGameInfoBox : UserControl
    {
        public DetailedGameInfoBox()
        {
            InitializeComponent();
        }

        private string _gameName;
        private string _gameGenre;
        private string _gameRating;
        private string _gamePlaytime;
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

        [Category("Custom Property")]
        public string GamePlaytime
        {
            get { return "Total Playtime : " + _gamePlaytime; }
            set { _gamePlaytime = value; gamePlaytime.Text = value; }
        }

        [Category("Custom Property")]
        public string GameRating
        {
            get { return "Rating : " + _gameRating; }
            set { _gameRating = value; gameRating.Text = value; }
        }

        [Category("Custom Property")]
        public string GameGenre
        {
            get { return "Genre : " + _gameGenre; }
            set { _gameGenre = value; gameGenre.Text = value; }
        }
    }
}
