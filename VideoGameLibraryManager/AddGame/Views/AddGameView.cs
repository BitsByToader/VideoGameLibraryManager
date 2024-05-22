using API_Manager;
using LibraryCommons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserDB_Manager;
using VideoGameLibraryManager.AddGame;
using WFFramework;

namespace VideoGameLibraryManager.AddGame
{
    public partial class AddGameView : Form, IAddGameView
    {
        FormNavigationStack _parent = null;
        IGameAPI _gameAPI = IGDB_API.GetInstance("p5fnw9ncdtxnzhc0krntyxipfzr8h7", "lsx3tr1bazjawk7ahz7ipd4i6uphmy");
        SessionInterface _userDb = GameLibraryDb.GetInstance("user_library.db");

        public AddGameView()
        {
            InitializeComponent();
        }

        public void AddToParent(IViewContainer parent)
        {
            _parent = (FormNavigationStack) parent;
        }

        public IViewContainer GetParentContainer()
        {
            return _parent;
        }

        public void removeFromParent()
        {
            _parent = null;
        }

        public void WillAppear()
        {
            // stub
        }

        public void WillBeAddedToParent()
        {
            // stub
        }

        public void WillBeRemovedFromParent()
        {
           // stub
        }

        public void WillDisappear()
        {
            // stub
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
                    string result = await _gameAPI.SearchGameNames(query);
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

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string gameName = (string)comboBox.SelectedItem;

            Task.Run(async () =>
            {
                Game game = await _gameAPI.GetGameByName(gameName);
                _userDb.AddGame(ref game);
            });
        }
    }
}
