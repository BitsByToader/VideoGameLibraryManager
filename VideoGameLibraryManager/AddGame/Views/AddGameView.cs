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
        private FormNavigationStack _parent = null;
        private IAddGameController _controller;

        public AddGameView(IAddGameController controller)
        {
            InitializeComponent();
            _controller = controller;
        }

        // necessary for windows forms designer...
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

        private void comboBoxSearchGames_TextChanged(object sender, EventArgs e)
        {
            _controller.SetSuggestedGamesQuery(comboBoxSearchGames.Text);
            
            if (comboBoxSearchGames.Text == "" )
            {
                buttonRetrieveGame.Enabled = false;
                buttonGameSuggestions.Enabled = false;
            } else
            {
                buttonRetrieveGame.Enabled = true;
                buttonGameSuggestions.Enabled = true;
            }
        }

        private void comboBoxSearchGames_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string gameName = (string)comboBox.SelectedItem;
            _controller.PickGameToRetrieve(gameName);    
        }

        private void buttonRetrieveGame_Click(object sender, EventArgs e)
        {
            _controller.RetrieveGameFromAPI();
        }

        private void buttonUploadLocalCover_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            //TODO: Change dialog to only allow pictures.
            if ( dialog.ShowDialog() == DialogResult.OK )
            {
                pictureBoxGameCover.Image = new Bitmap(dialog.FileName);
            }
        }

        private void buttonPickExecutable_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog() {
                FileName = "Select an executable file.",
                Filter = "Executable files (*.exe)|*.exe",
                Title = "Open executable file"
            };
            if (dialog.ShowDialog() == DialogResult.OK )
            {
                textBoxExecutablePath.Text = dialog.FileName;
            }
        }

        private void buttonSaveGame_Click(object sender, EventArgs e)
        {
            Game gameToSave = new Game();
            
            gameToSave.name = textBoxName.Text;
            gameToSave.platforms = textBoxPlatforms.Text.Split(',').ToList();
            gameToSave.summary = richTextBoxDescription.Text;
            gameToSave.genre = textBoxGenres.Text.Split(',').ToList();
            gameToSave.publisher = textBoxPublisher.Text;
            gameToSave.cover = (Bitmap)pictureBoxGameCover.Image;
            gameToSave.developers = textBoxDevelopers.Text.Split(',').ToList();
            gameToSave.executable_path = textBoxExecutablePath.Text;
            gameToSave.website = textBoxWebsite.Text;
            gameToSave.personal_rating = int.Parse(textBoxRating.Text);
            
            _controller.SaveGame(gameToSave);
        }

        private void buttonGameSuggestions_Click(object sender, EventArgs e)
        {
            _controller.RetrieveSuggestions();
        }

        public void SetSearchResult(string result)
        {
            comboBoxSearchGames.Items.Clear();
            comboBoxSearchGames.SelectionStart = comboBoxSearchGames.Text.Length;
            comboBoxSearchGames.SelectionLength = 0;
            if (result.Contains('\n'))
                comboBoxSearchGames.Items.AddRange(result.Split('\n'));
            else
                comboBoxSearchGames.Items.Add(result);
        }

        public void UpdateFieldsUsingGame(Game game)
        {
            textBoxName.Text = game.name;
            textBoxPlatforms.Text = string.Join(",", game.platforms);
            richTextBoxDescription.Text = game.summary;
            textBoxGenres.Text = string.Join(",", game.genre);
            textBoxPublisher.Text = game.publisher;
            pictureBoxGameCover.Image = game.cover;
            textBoxDevelopers.Text = string.Join(",", game.developers);
            textBoxExecutablePath.Text = game.executable_path;
            textBoxWebsite.Text = game.website;
            textBoxRating.Text = game.global_rating.ToString();
        }
    }
}
