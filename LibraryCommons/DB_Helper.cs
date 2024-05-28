/**************************************************************************
 *                                                                        *
 *  File:        DB_Helper.cs                                             *
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
        public static string ResourcePath="";

        public static void SetResourcePath(string RPath="")
        {
            if(RPath == "")
            {
                ResourcePath = Directory.GetCurrentDirectory();
                string coverPhotosFolder = Path.Combine(ResourcePath, "Resources", "Covers");
                if (!Directory.Exists(coverPhotosFolder))
                {
                    Directory.CreateDirectory(coverPhotosFolder);
                    Console.WriteLine("Created folder: " + coverPhotosFolder);
                }
                ResourcePath = coverPhotosFolder;
            }
            else
            {
                if (!Directory.Exists(RPath))
                {
                    Directory.CreateDirectory(RPath);
                    Console.WriteLine("Created folder: " + RPath);
                    ResourcePath = RPath;
                }
            }
        }
        /// <summary>
        /// Function to save a bitmap as a PNG file
        /// </summary>
        /// <param name="bitmap"> The bitmap to save </param>
        /// <param name="fileName"> The name of the file </param>
        /// <returns> The path of the saved file </returns>
        /// <exception cref="ArgumentNullException"> Thrown when the bitmap or file name is null </exception>
        public static string SaveBitmapAsPng(Bitmap bitmap, string fileName)
        {
            if(bitmap == null)
            {
                //throw new ArgumentNullException("Bitmap is null.");
                bitmap = new Bitmap(1, 1);
            }
            if (fileName == null)
            {
                throw new ArgumentNullException("File name is null.");
            }
            if(ResourcePath == "")
            {
                SetResourcePath();
            }
            Bitmap bitmap1 = new Bitmap(bitmap);
            string filePath = Path.Combine(ResourcePath, fileName + ".png");
            if(!File.Exists(filePath))
            {
                bitmap1.Save(filePath, ImageFormat.Png);
            }
            return filePath;
        }
        /// <summary>
        /// Load a bitmap from a PNG file
        /// </summary>
        /// <param name="fileName"> The name of the file, can be a whole path or just the name </param>
        /// <returns> The loaded bitmap </returns>
        /// <exception cref="ArgumentNullException"> Thrown when the file name is null </exception>
        /// <exception cref="FileNotFoundException"> Thrown when the file is not found </exception>
        public static Bitmap LoadBitmapFromPng(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("File name is null.");
            }
            if (ResourcePath == "")
            {
                SetResourcePath();
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
        public static Image ConvertBitmapToImage(Bitmap bitmap)
        {
            if (bitmap == null)
            {
                throw new ArgumentNullException("Bitmap is null.");
            }
            if (ResourcePath == "")
            {
                SetResourcePath();
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
        public static Image ConvertBitmapToImage(string coverPath)
        {
            if (coverPath == null)
            {
                throw new ArgumentNullException("Cover path is null.");
            }
            if (ResourcePath == "")
            {
                SetResourcePath();
            }

            Bitmap bitmap = LoadBitmapFromPng(coverPath);
            Image image = Image.FromHbitmap(bitmap.GetHbitmap());
            Console.WriteLine("Converted bitmap to Image.");
            return image;
        }




    }
}
