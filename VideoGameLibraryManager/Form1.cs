using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseManager;
using UserDB_Manager;

namespace VideoGameLibraryManager
{
    public partial class Form1 : Form
    {
        GameLibraryDb _instance;
        GameLibraryMemDB _memInstance;
        public Form1()
        {
            _instance = GameLibraryDb.GetInstance("MyGameLibrary.db");
            _memInstance = GameLibraryMemDB.GetInstance();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            //Every time the text changes, we want to update the list of games
            //This is done by calling the IGDB_API.Search() method
            //The method will return a list of games that match the search query
            //The list will be displayed in the listbox
            //The listbox will be cleared before the new list is added

            //Get the search query from the combobox
            string query = comboBox1.Text;

            //Run  public async Task<string> SearchGames(string query)
            //from DatabaseManager and update the listbox with the results
            Task.Run(async () =>
            {
                try
                {
                    string result = await IGDB_API.SearchGameNames(query);
                    // Update the listbox with the results
                    this.Invoke((MethodInvoker)delegate
                    {
                        comboBox1.Items.Clear();
                        comboBox1.SelectionStart = comboBox1.Text.Length;
                        comboBox1.SelectionLength = 0;
                        if (result.Contains('\n'))
                            comboBox1.Items.AddRange(result.Split('\n'));
                        else
                            comboBox1.Items.Add(result);
                    });
                }
                catch (Exception ex)
                {
                    // Handle the exception, e.g. by logging it or showing an error message
                    this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    });
                }
            });

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            //Take the text from the combobox and search for the game in the IGDB database GetGameCoverBitmapAsync
            //The game cover will be displayed in the picturebox
            int id = 0;
            string query = comboBox1.Text;
            Task.Run(async () =>
            {
                try
                {
                    var game = await IGDB_API.GetGameByName(query);
                    if(game == null)
                    {
                        MessageBox.Show("Game not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Bitmap cover = await IGDB_API.GetGameCoverBitmap_byID_Async(game.id);
                    _instance.AddGame(Game.ConvertGame_IGDB(game));
                    _instance.GetAllGames();
                    // Update the picturebox with the cover
                    this.Invoke((MethodInvoker)delegate
                    {
                        pictureBox1.Image = cover;
                    });
                }
                catch (Exception ex)
                {
                    // Handle the exception, e.g. by logging it or showing an error message
                    this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    });
                }
            });
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            //Get the id from the textbox and remove the game from the database
            int id = 0;
            if (!int.TryParse(removeidx.Text, out id))
            {
                MessageBox.Show("Invalid ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Console.WriteLine("Removing game with id: " + id);

            Console.WriteLine(_instance.RemoveGame(id));
            
        }

        private void Rename_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (!int.TryParse(removeidx.Text, out id))
            {
                MessageBox.Show("Invalid ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Console.WriteLine("Renaming game with id: " + id);
            Game game = _instance.GetGame(id);
            game.name = "NewName";
            Console.WriteLine(_instance.UpdateGame(id, game));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = comboBox1.Text;
            //Add the game in mem
            Task.Run(async () =>
            {
                try
                {
                    var game = await IGDB_API.GetGameByName(query);
                    if (game == null)
                    {
                        MessageBox.Show("Game not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Bitmap cover = await IGDB_API.GetGameCoverBitmap_byID_Async(game.id);
                    _memInstance.AddGame(Game.ConvertGame_IGDB(game));
                    _memInstance.GetAllGames();
                    // Update the picturebox with the cover
                    this.Invoke((MethodInvoker)delegate
                    {
                        pictureBox1.Image = cover;
                    });
                }
                catch (Exception ex)
                {
                    // Handle the exception, e.g. by logging it or showing an error message
                    this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    });
                }
            });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (!int.TryParse(removeidx.Text, out id))
            {
                MessageBox.Show("Invalid ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Console.WriteLine("Removing game with id: " + id);

            Console.WriteLine(_memInstance.RemoveGame(id));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (!int.TryParse(removeidx.Text, out id))
            {
                MessageBox.Show("Invalid ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Console.WriteLine("Renaming game with id: " + id);
            Game game = _memInstance.GetGame(id);
            game.name = "NewName";
            Console.WriteLine(_memInstance.UpdateGame(id, game));

        }
    }
}
