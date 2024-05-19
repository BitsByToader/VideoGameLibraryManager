﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
<<<<<<< HEAD
using WFFramework;
=======
using API_Manager;
using LibraryCommons;
using UserDB_Manager;
using static LibraryCommons.LibraryCommons;
>>>>>>> database_branch

namespace VideoGameLibraryManager
{
    public partial class Form1 : Form
    {
<<<<<<< HEAD
        IView form3 = new Form3();

=======
        GameLibraryDb _instance;
        GameLibraryMemDB _memInstance;
        IGDB_Abstract _igdbInstance;
>>>>>>> database_branch
        public Form1()
        {
            _instance = GameLibraryDb.GetInstance("MyGameLibrary.db");
            _memInstance = GameLibraryMemDB.GetInstance();
            _igdbInstance = IGDB_API.GetInstance("p5fnw9ncdtxnzhc0krntyxipfzr8h7", "lsx3tr1bazjawk7ahz7ipd4i6uphmy");
            InitializeComponent();
        }

<<<<<<< HEAD
        private void button1_Click(object sender, EventArgs e)
        {
            formNavigationStack1.SetRoot(form3);
=======
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
                    string result = await _igdbInstance.SearchGameNames(query);
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
                    var game = await _igdbInstance.GetGameByName(query);
                    if(game == null)
                    {
                        MessageBox.Show("Game not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Bitmap cover = await _igdbInstance.GetGameCoverBitmap_byID(game.id);
                    var game2 = ((IGDB_API)_igdbInstance).ConvertGame_IGDB(game: ref game);
                    _instance.AddGame(ref game2);
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
            var game = new Game { id = id, name = "Roblox" };
            _instance.RemoveGame(ref game);


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
            Game game = new Game { id = id, name = "Roblox" };
            game = _instance.GetGame(ref game);
            var g = new Game { id = id, name = "NewName" };
            _instance.UpdateGame(ref game, ref g);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = comboBox1.Text;
            //Add the game in mem
            Task.Run(async () =>
            {
                try
                {
                    var game = await _igdbInstance.GetGameByName(query);
                    if (game == null)
                    {
                        MessageBox.Show("Game not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Bitmap cover = await _igdbInstance.GetGameCoverBitmap_byID(game.id);
                    var game1 = ( (IGDB_API)_igdbInstance).ConvertGame_IGDB(game: ref game);
                    _memInstance.AddGame(ref game1);
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

            var game = new Game { id = id, name = "Roblox" };
            _memInstance.RemoveGame(ref game);
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
            var game1 = new Game { id = id, name = "Roblox" };
            Game game2 = _memInstance.GetGame(ref game1);
            game1.name= "NewName";
            _memInstance.UpdateGame(ref game2, ref game1);

>>>>>>> database_branch
        }
    }
}
