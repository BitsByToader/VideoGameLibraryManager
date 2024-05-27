/************************************************************************************
*                                                                                   *
*  File:        ViewGameView.cs                                                     *
*  Copyright:   (c) 2024, Darie Alexandru                                           *
*  E-mail:      alexandru.darie@student.tuiasi.ro                                   *
*  Description: View File for the View Game Form.                                   *
*                                                                                   *
*                                                                                   *
*  This code and information is provided "as is" without warranty of                *
*  any kind, either expressed or implied, including but not limited                 *
*  to the implied warranties of merchantability or fitness for a                    *
*  particular purpose. You are free to use this source code in your                 *
*  applications as long as the original copyright notice is included.               *
*                                                                                   *
************************************************************************************/
using LibraryCommons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFFramework;

namespace VideoGameLibraryManager.ViewGame.Views
{
    public partial class ViewGameView : Form, IViewGameView
    {
        private FormNavigationStack _parent;
        private IViewGameController _controller;
        private Game _game;
        private bool _editMode = false;
        private bool isDragging = false;
        private NotifyIcon notifyIcon;
        public ViewGameView(IViewGameController controller)
        {
            _controller = controller;
            InitializeComponent();
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = SystemIcons.Application;
            notifyIcon.Visible = false;
            notifyIcon.DoubleClick += (sender, args) => this.Show();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (_game != null)
            {
                if (_editMode)
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Executable Files|*.exe";
                    openFileDialog.Title = "Select the game's executable file";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        _game.executable_path = openFileDialog.FileName;
                    }
                }
                else
                {
                    if (_game.executable_path != null)
                    {
                        try
                        {
                            Process gameProcess = Process.Start(_game.executable_path);

                            foreach (Form form in Application.OpenForms)
                            {
                                form.Hide();
                            }

                            DateTime startTime = DateTime.Now;

                            gameProcess.WaitForExit();

                            TimeSpan elapsedTime = DateTime.Now - startTime;

                            foreach (Form form in Application.OpenForms)
                            {
                                form.Show();
                            }

 
                            //MessageBox.Show("You played for " + elapsedTime.ToString());
                            _game.playtime += (int)elapsedTime.TotalMilliseconds;
                            _controller.UpdateGame(_game);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Could not start the game. " + ex.Message);
                            foreach (Form form in Application.OpenForms)
                            {
                                form.Show();
                            }
                        }
                    }
                }
            }

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void editButton_Click_1(object sender, EventArgs e)
        {
            if(_editMode)
            {
                _game.name = GameTitle.Text;
                _game.summary = descBox.Text;
                _game.favorite = checkBox1.Checked;
                _game.personal_rating = PersonalRating.Value;
                
                _controller.UpdateGame(_game);
                _editMode = false;
                editButton.Text = "Edit";
                GameTitle.Enabled = false;
                descBox.Enabled = false;
                PlayButton.Text = "Play";
                PlayButton.BackColor=Color.FromArgb(192, 255, 192);
            }
            else
            {
                _editMode = true;
                editButton.Text = "Save";
                GameTitle.Enabled = true;
                descBox.Enabled = true;
                PlayButton.Text = "Browse";
                PlayButton.BackColor = Color.LightBlue;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void briefGameInfoBox1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            _game.favorite = checkBox1.Checked;
            _controller.UpdateGame(_game);
        }

        /// <summary>
        /// Function to display the game in the view
        /// </summary>
        /// <param name="game"> The game to be displayed</param>
        public void DisplayGame(ref Game game)
        {
            List<GameTODO> todos=_controller.GetTodos(game.id);
            _game = game;
            ToDos.Items.Clear();
            foreach (var todo in todos)
            {
                if(!todo.isDone())
                    ToDos.Items.Add(todo.todo);
            }
            weblabel.Text = "";
            if (game.website != null)
            {
                weblabel.Text+=game.website;
            }
            TotalPlaytime.Text = "Total Playtime: " + TimeSpan.FromMilliseconds(game.playtime).ToString();
            pictureBoxGameCover.Image = game.cover;
            GameTitle.Text = game.name;
            overallRating.Text = "Overall Rating: " + game.global_rating;
            descBox.Text = game.summary;
            checkBox1.Checked = game.favorite;
            PersonalRating.Value = game.personal_rating;
        }

        /// <summary>
        /// This function displays an error message
        /// </summary>
        /// <param name="message"> The error message to be displayed</param>
        public void DisplayError(string message)
        {
            MessageBox.Show(message);
        }
        /// <summary>
        /// This function confirms the deletion of a game.
        /// </summary>
        /// <param name="success"> A boolean value that indicates if the deletion was successful.</param>
        public void ConfirmDeletion(bool success)
        {
            if (success)
            {
                MessageBox.Show("Game deleted successfully");
                _parent.PopView();
            }
            else
            {
                MessageBox.Show("Game could not be deleted");
            }
        }

        public void AddToParent(IViewContainer parent)
        {
            _parent = (FormNavigationStack)parent;
        }

        public void removeFromParent()
        {
            _parent = null;
        }

        public IViewContainer GetParentContainer()
        {
            return _parent;
        }

        public void WillAppear()
        {
            //throw new NotImplementedException();
        }

        public void WillDisappear()
        {
            //throw new NotImplementedException();
        }

        public void WillBeAddedToParent()
        {
            //throw new NotImplementedException();
        }

        public void WillBeRemovedFromParent()
        {
            //throw new NotImplementedException();
        }

        private void ViewGameView_Load(object sender, EventArgs e)
        {

        }

        private void addToDo_Click(object sender, EventArgs e)
        {
            if (_game != null)
            {
                //Create a Form with a TextBox and a Button
                Form prompt = new Form();
                prompt.Width = 500;
                prompt.Height = 150;
                prompt.Text = "Add a To-Do";
                Label textLabel = new Label() { Left = 50, Top = 20, Text = "Enter a To-Do:" };
                System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox() { Left = 50, Top = 50, Width = 400 };
                System.Windows.Forms.Button confirmation = new System.Windows.Forms.Button() { Text = "Add", Left = 350, Width = 100, Top = 70 };
                confirmation.Click += (sender2, e2) => { prompt.Close(); };
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.ShowDialog();

                //Add the To-Do to the game
                if(textBox.Text != "")
                {
                    ToDos.Items.Add(textBox.Text);
                    _controller.AddToDo(todo: textBox.Text);
                }
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            _controller.DeleteGame();
        }

        private void PersonalRating_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                _controller.UpdateRating(_game.id, PersonalRating.Value);
                isDragging = false;
            }
        }

        private void PersonalRating_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
        }

        private void ToDos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            _controller.UpdateToDoStatus(ToDos.Items[e.Index].ToString(), e.NewValue == CheckState.Checked);
        }
    }
}
