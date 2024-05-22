using API_Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoGameLibraryManager
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IGDB_API.GetInstance("p5fnw9ncdtxnzhc0krntyxipfzr8h7", "lsx3tr1bazjawk7ahz7ipd4i6uphmy");
            GameLibraryDb.GetInstance("user_library.db");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MenuFormView());
        }
    }
}
