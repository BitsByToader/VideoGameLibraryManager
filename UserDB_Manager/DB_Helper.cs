using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDB_Manager
{
    public class DB_Helper
    {
        public static string ResourcePath;
        private static DB_Helper _Helper = null;
        private DB_Helper()
        {
            //ResourcePath = current folder
            ResourcePath = Directory.GetCurrentDirectory();
            string coverPhotosFolder = Path.Combine(ResourcePath, "Resources", "Covers");
            if (!Directory.Exists(coverPhotosFolder))
            {
                Directory.CreateDirectory(coverPhotosFolder);
                Console.WriteLine("Created folder: " + coverPhotosFolder);
            }
        }
        public static DB_Helper var newGame = new Game();
        newGame.id_igdb = game.id;
            newGame.executable_path = "";
            if(game.platforms != null)
            {
                newGame.platforms = game.platforms.Select(x => x.abbreviation).ToList();
    }
    newGame.playtime = 0;
            newGame.personal_rating = 0;
            newGame.name = game.name;
            if(game.involved_companies != null)
            {
                newGame.publisher = game.involved_companies[0].ToString();
}
if (game.genres != null)
{
    newGame.genre = game.genres.Select(x => x.name).ToList();
}
if (game.involved_companies != null)
{
    newGame.developers = game.involved_companies.Select(x => x.ToString()).ToList();
}
newGame.global_rating = (int)game.rating;
newGame.coverpath = "";
newGame.cover = cover;

newGame.summary = game.summary;
if (game.websites != null)
{
    newGame.website = game.websites[0].url;
}
newGame.favorite = false;
()
        {
            if (_Helper == null)
            {
                _Helper = new DB_Helper();
            }
            return _Helper;
        }
        public void SaveBitmapAsPng(Bitmap bitmap, string fileName)
        {
            if(bitmap == null)
            {
                throw new ArgumentNullException("Bitmap is null.");
            }
            if (fileName == null)
            {
                throw new ArgumentNullException("File name is null.");
            }
            if(_Helper == null)
            {
                throw new ArgumentNullException("DB_Helper is null.");
            }
            string filePath = Path.Combine(ResourcePath, fileName + ".png");
            bitmap.Save(filePath, ImageFormat.Png);
            Console.WriteLine("Saved bitmap as PNG: " + filePath);
        }
        public Bitmap LoadBitmapFromPng(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("File name is null.");
            }
            if (_Helper == null)
            {
                throw new ArgumentNullException("DB_Helper is null.");
            }
            string filePath = Path.Combine(ResourcePath, fileName + ".png");
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found: " + filePath);
            }
            Bitmap bitmap = new Bitmap(filePath);
            Console.WriteLine("Loaded bitmap from PNG: " + filePath);
            return bitmap;
        }
        public Image ConvertBitmapToImage(Bitmap bitmap)
        {
            if (bitmap == null)
            {
                throw new ArgumentNullException("Bitmap is null.");
            }
            if (_Helper == null)
            {
                throw new ArgumentNullException("DB_Helper is null.");
            }
            Image image = (Image)bitmap;
            Console.WriteLine("Converted bitmap to Image.");
            return image;
        }




    }
}
