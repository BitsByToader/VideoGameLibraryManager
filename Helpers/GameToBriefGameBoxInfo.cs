using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Helpers
{
    public class GameToBriefGameBoxInfo : IGameToControlConverter
    {
        public UserControl Convert(Game game)
        {
            BriefGameInfoBox userControl = new BriefGameInfoBox();
            
            userControl.GameImage = game.image;
            userControl.GameName = game.name;

            return userControl;
        }
    }
}
