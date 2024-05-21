/**************************************************************************
 *                                                                        *
 *  File:        DatabaseManager                                          *
 *  Copyright:   (c) 2024, Darie Alexandru                                *
 *  E-mail:      alexandru.darie@student.tuiasi.ro                        *
 *  Description: A helper that helps you converting, downloading, etc     *
 *                                                                        *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCommons
{

    public class DB_Helper
    {
        public static string ResourcePath;
        private static DB_Helper _Helper = null;
        /// <summary>
        /// Singleton pattern constructor
        /// </summary>
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
            ResourcePath = coverPhotosFolder;
        }
        /// <summary>
        /// Singleton pattern method to get the instance of the DB_Helper
        /// </summary>
        /// <returns> The instance of the DB_Helper </returns>
        public static DB_Helper GetHelper()
        {
            if (_Helper == null)
            {
                _Helper = new DB_Helper();
            }
            return _Helper;
        }
        /// <summary>
        /// Function to save a bitmap as a PNG file
        /// </summary>
        /// <param name="bitmap"> The bitmap to save </param>
        /// <param name="fileName"> The name of the file </param>
        /// <returns> The path of the saved file </returns>
        /// <exception cref="ArgumentNullException"> Thrown when the bitmap or file name is null </exception>
        public string SaveBitmapAsPng(Bitmap bitmap, string fileName)
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
            Bitmap bitmap1 = new Bitmap(bitmap);
            string filePath = Path.Combine(ResourcePath, fileName + ".png");
            bitmap1.Save(filePath, ImageFormat.Png);
            return filePath;
        }
        /// <summary>
        /// Load a bitmap from a PNG file
        /// </summary>
        /// <param name="fileName"> The name of the file, can be a whole path or just the name </param>
        /// <returns> The loaded bitmap </returns>
        /// <exception cref="ArgumentNullException"> Thrown when the file name is null </exception>
        /// <exception cref="FileNotFoundException"> Thrown when the file is not found </exception>
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
            string filePath = "";
            // if fileName is a whole VALID path, then use it
            if (File.Exists(fileName))
            {
                filePath = fileName;
            }
            else
            {
                filePath = Path.Combine(ResourcePath, fileName + ".png");
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found: " + filePath);
            }
            Bitmap bitmap = new Bitmap(filePath);
            Console.WriteLine("Loaded bitmap from PNG: " + filePath);
            return bitmap;
        }
        /// <summary>
        /// Convert a bitmap to an image
        /// </summary>
        /// <param name="bitmap"> The bitmap to convert </param>
        /// <returns> The converted image </returns>
        /// <exception cref="ArgumentNullException"> Thrown when the bitmap is null </exception>
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
            Image image = Image.FromHbitmap(bitmap.GetHbitmap());
            Console.WriteLine("Converted bitmap to Image.");
            return image;
        }
        /// <summary>
        /// Convert a bitmap to an image from a file
        /// </summary>
        /// <param name="coverPath"> The path of the file </param>
        /// <returns> The converted image </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Image ConvertBitmapToImage(string coverPath)
        {
            if (coverPath == null)
            {
                throw new ArgumentNullException("Cover path is null.");
            }
            if (_Helper == null)
            {
                throw new ArgumentNullException("DB_Helper is null.");
            }

            Bitmap bitmap = LoadBitmapFromPng(coverPath);
            Image image = Image.FromHbitmap(bitmap.GetHbitmap());
            Console.WriteLine("Converted bitmap to Image.");
            return image;
        }




    }
}
