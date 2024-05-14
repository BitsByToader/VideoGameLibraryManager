using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helpers
{
    public class GameToDetailedGameBoxInfo : IGameToControlConverter
    {
        public UserControl Convert(Game game)
        {
            DetailedGameInfoBox detailedGameInfoBox = new DetailedGameInfoBox();

            detailedGameInfoBox.GameGenre = game.genre;
            detailedGameInfoBox.GameImage = game.image; 
            detailedGameInfoBox.GameName = game.name;
            detailedGameInfoBox.GamePlaytime = game.playtime.ToString();
            detailedGameInfoBox.GameRating = game.rating.ToString();

            return detailedGameInfoBox;
        }
    }
}
