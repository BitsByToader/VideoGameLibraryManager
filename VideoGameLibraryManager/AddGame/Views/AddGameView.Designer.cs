namespace VideoGameLibraryManager.AddGame
{
    partial class AddGameView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxSearchGames = new System.Windows.Forms.ComboBox();
            this.pictureBoxGameCover = new System.Windows.Forms.PictureBox();
            this.buttonUploadLocalCover = new System.Windows.Forms.Button();
            this.labelSearchGames = new System.Windows.Forms.Label();
            this.buttonRetrieveGame = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxPublisher = new System.Windows.Forms.TextBox();
            this.labelPublisher = new System.Windows.Forms.Label();
            this.labelPlatforms = new System.Windows.Forms.Label();
            this.labelRating = new System.Windows.Forms.Label();
            this.labelGenres = new System.Windows.Forms.Label();
            this.labelDevelopers = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelWebsite = new System.Windows.Forms.Label();
            this.labelExecutablePath = new System.Windows.Forms.Label();
            this.textBoxExecutablePath = new System.Windows.Forms.TextBox();
            this.textBoxWebsite = new System.Windows.Forms.TextBox();
            this.textBoxDevelopers = new System.Windows.Forms.TextBox();
            this.textBoxGenres = new System.Windows.Forms.TextBox();
            this.textBoxRating = new System.Windows.Forms.TextBox();
            this.textBoxPlatforms = new System.Windows.Forms.TextBox();
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.buttonSaveGame = new System.Windows.Forms.Button();
            this.buttonPickExecutable = new System.Windows.Forms.Button();
            this.buttonGameSuggestions = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGameCover)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxSearchGames
            // 
            this.comboBoxSearchGames.FormattingEnabled = true;
            this.comboBoxSearchGames.Location = new System.Drawing.Point(172, 34);
            this.comboBoxSearchGames.Name = "comboBoxSearchGames";
            this.comboBoxSearchGames.Size = new System.Drawing.Size(506, 33);
            this.comboBoxSearchGames.TabIndex = 0;
            this.comboBoxSearchGames.SelectedValueChanged += new System.EventHandler(this.comboBoxSearchGames_SelectedValueChanged);
            this.comboBoxSearchGames.TextChanged += new System.EventHandler(this.comboBoxSearchGames_TextChanged);
            // 
            // pictureBoxGameCover
            // 
            this.pictureBoxGameCover.Location = new System.Drawing.Point(988, 12);
            this.pictureBoxGameCover.Name = "pictureBoxGameCover";
            this.pictureBoxGameCover.Size = new System.Drawing.Size(349, 465);
            this.pictureBoxGameCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxGameCover.TabIndex = 1;
            this.pictureBoxGameCover.TabStop = false;
            // 
            // buttonUploadLocalCover
            // 
            this.buttonUploadLocalCover.Location = new System.Drawing.Point(1057, 497);
            this.buttonUploadLocalCover.Name = "buttonUploadLocalCover";
            this.buttonUploadLocalCover.Size = new System.Drawing.Size(222, 74);
            this.buttonUploadLocalCover.TabIndex = 2;
            this.buttonUploadLocalCover.Text = "Upload from disk...";
            this.buttonUploadLocalCover.UseVisualStyleBackColor = true;
            this.buttonUploadLocalCover.Click += new System.EventHandler(this.buttonUploadLocalCover_Click);
            // 
            // labelSearchGames
            // 
            this.labelSearchGames.AutoSize = true;
            this.labelSearchGames.Location = new System.Drawing.Point(12, 34);
            this.labelSearchGames.Name = "labelSearchGames";
            this.labelSearchGames.Size = new System.Drawing.Size(154, 25);
            this.labelSearchGames.TabIndex = 3;
            this.labelSearchGames.Text = "Search Online:";
            // 
            // buttonRetrieveGame
            // 
            this.buttonRetrieveGame.Enabled = false;
            this.buttonRetrieveGame.Location = new System.Drawing.Point(698, 99);
            this.buttonRetrieveGame.Name = "buttonRetrieveGame";
            this.buttonRetrieveGame.Size = new System.Drawing.Size(223, 55);
            this.buttonRetrieveGame.TabIndex = 4;
            this.buttonRetrieveGame.Text = "Retrieve Game";
            this.buttonRetrieveGame.UseVisualStyleBackColor = true;
            this.buttonRetrieveGame.Click += new System.EventHandler(this.buttonRetrieveGame_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(17, 123);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(68, 25);
            this.labelName.TabIndex = 6;
            this.labelName.Text = "Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(192, 123);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(402, 31);
            this.textBoxName.TabIndex = 7;
            // 
            // textBoxPublisher
            // 
            this.textBoxPublisher.Location = new System.Drawing.Point(192, 185);
            this.textBoxPublisher.Name = "textBoxPublisher";
            this.textBoxPublisher.Size = new System.Drawing.Size(402, 31);
            this.textBoxPublisher.TabIndex = 9;
            // 
            // labelPublisher
            // 
            this.labelPublisher.AutoSize = true;
            this.labelPublisher.Location = new System.Drawing.Point(16, 185);
            this.labelPublisher.Name = "labelPublisher";
            this.labelPublisher.Size = new System.Drawing.Size(102, 25);
            this.labelPublisher.TabIndex = 8;
            this.labelPublisher.Text = "Publisher";
            // 
            // labelPlatforms
            // 
            this.labelPlatforms.AutoSize = true;
            this.labelPlatforms.Location = new System.Drawing.Point(17, 241);
            this.labelPlatforms.Name = "labelPlatforms";
            this.labelPlatforms.Size = new System.Drawing.Size(102, 25);
            this.labelPlatforms.TabIndex = 10;
            this.labelPlatforms.Text = "Platforms";
            // 
            // labelRating
            // 
            this.labelRating.AutoSize = true;
            this.labelRating.Location = new System.Drawing.Point(17, 295);
            this.labelRating.Name = "labelRating";
            this.labelRating.Size = new System.Drawing.Size(74, 25);
            this.labelRating.TabIndex = 11;
            this.labelRating.Text = "Rating";
            // 
            // labelGenres
            // 
            this.labelGenres.AutoSize = true;
            this.labelGenres.Location = new System.Drawing.Point(16, 340);
            this.labelGenres.Name = "labelGenres";
            this.labelGenres.Size = new System.Drawing.Size(82, 25);
            this.labelGenres.TabIndex = 12;
            this.labelGenres.Text = "Genres";
            // 
            // labelDevelopers
            // 
            this.labelDevelopers.AutoSize = true;
            this.labelDevelopers.Location = new System.Drawing.Point(16, 384);
            this.labelDevelopers.Name = "labelDevelopers";
            this.labelDevelopers.Size = new System.Drawing.Size(121, 25);
            this.labelDevelopers.TabIndex = 13;
            this.labelDevelopers.Text = "Developers";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(17, 531);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(120, 25);
            this.labelDescription.TabIndex = 14;
            this.labelDescription.Text = "Description";
            // 
            // labelWebsite
            // 
            this.labelWebsite.AutoSize = true;
            this.labelWebsite.Location = new System.Drawing.Point(17, 432);
            this.labelWebsite.Name = "labelWebsite";
            this.labelWebsite.Size = new System.Drawing.Size(90, 25);
            this.labelWebsite.TabIndex = 15;
            this.labelWebsite.Text = "Website";
            // 
            // labelExecutablePath
            // 
            this.labelExecutablePath.AutoSize = true;
            this.labelExecutablePath.Location = new System.Drawing.Point(17, 471);
            this.labelExecutablePath.Name = "labelExecutablePath";
            this.labelExecutablePath.Size = new System.Drawing.Size(169, 25);
            this.labelExecutablePath.TabIndex = 16;
            this.labelExecutablePath.Text = "Executable Path";
            // 
            // textBoxExecutablePath
            // 
            this.textBoxExecutablePath.Location = new System.Drawing.Point(192, 471);
            this.textBoxExecutablePath.Name = "textBoxExecutablePath";
            this.textBoxExecutablePath.Size = new System.Drawing.Size(402, 31);
            this.textBoxExecutablePath.TabIndex = 17;
            // 
            // textBoxWebsite
            // 
            this.textBoxWebsite.Location = new System.Drawing.Point(192, 429);
            this.textBoxWebsite.Name = "textBoxWebsite";
            this.textBoxWebsite.Size = new System.Drawing.Size(402, 31);
            this.textBoxWebsite.TabIndex = 18;
            // 
            // textBoxDevelopers
            // 
            this.textBoxDevelopers.Location = new System.Drawing.Point(192, 384);
            this.textBoxDevelopers.Name = "textBoxDevelopers";
            this.textBoxDevelopers.Size = new System.Drawing.Size(402, 31);
            this.textBoxDevelopers.TabIndex = 19;
            // 
            // textBoxGenres
            // 
            this.textBoxGenres.Location = new System.Drawing.Point(192, 340);
            this.textBoxGenres.Name = "textBoxGenres";
            this.textBoxGenres.Size = new System.Drawing.Size(402, 31);
            this.textBoxGenres.TabIndex = 20;
            // 
            // textBoxRating
            // 
            this.textBoxRating.Location = new System.Drawing.Point(192, 295);
            this.textBoxRating.Name = "textBoxRating";
            this.textBoxRating.Size = new System.Drawing.Size(402, 31);
            this.textBoxRating.TabIndex = 21;
            // 
            // textBoxPlatforms
            // 
            this.textBoxPlatforms.Location = new System.Drawing.Point(192, 241);
            this.textBoxPlatforms.Name = "textBoxPlatforms";
            this.textBoxPlatforms.Size = new System.Drawing.Size(402, 31);
            this.textBoxPlatforms.TabIndex = 22;
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.Location = new System.Drawing.Point(192, 531);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.Size = new System.Drawing.Size(402, 137);
            this.richTextBoxDescription.TabIndex = 23;
            this.richTextBoxDescription.Text = "";
            // 
            // buttonSaveGame
            // 
            this.buttonSaveGame.Location = new System.Drawing.Point(1154, 677);
            this.buttonSaveGame.Name = "buttonSaveGame";
            this.buttonSaveGame.Size = new System.Drawing.Size(183, 66);
            this.buttonSaveGame.TabIndex = 24;
            this.buttonSaveGame.Text = "Save Game";
            this.buttonSaveGame.UseVisualStyleBackColor = true;
            this.buttonSaveGame.Click += new System.EventHandler(this.buttonSaveGame_Click);
            // 
            // buttonPickExecutable
            // 
            this.buttonPickExecutable.Location = new System.Drawing.Point(619, 460);
            this.buttonPickExecutable.Name = "buttonPickExecutable";
            this.buttonPickExecutable.Size = new System.Drawing.Size(218, 52);
            this.buttonPickExecutable.TabIndex = 25;
            this.buttonPickExecutable.Text = "Select Executable";
            this.buttonPickExecutable.UseVisualStyleBackColor = true;
            this.buttonPickExecutable.Click += new System.EventHandler(this.buttonPickExecutable_Click);
            // 
            // buttonGameSuggestions
            // 
            this.buttonGameSuggestions.Enabled = false;
            this.buttonGameSuggestions.Location = new System.Drawing.Point(698, 22);
            this.buttonGameSuggestions.Name = "buttonGameSuggestions";
            this.buttonGameSuggestions.Size = new System.Drawing.Size(223, 55);
            this.buttonGameSuggestions.TabIndex = 26;
            this.buttonGameSuggestions.Text = "Game Suggestions";
            this.buttonGameSuggestions.UseVisualStyleBackColor = true;
            this.buttonGameSuggestions.Click += new System.EventHandler(this.buttonGameSuggestions_Click);
            // 
            // AddGameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1349, 755);
            this.Controls.Add(this.buttonGameSuggestions);
            this.Controls.Add(this.buttonPickExecutable);
            this.Controls.Add(this.buttonSaveGame);
            this.Controls.Add(this.richTextBoxDescription);
            this.Controls.Add(this.textBoxPlatforms);
            this.Controls.Add(this.textBoxRating);
            this.Controls.Add(this.textBoxGenres);
            this.Controls.Add(this.textBoxDevelopers);
            this.Controls.Add(this.textBoxWebsite);
            this.Controls.Add(this.textBoxExecutablePath);
            this.Controls.Add(this.labelExecutablePath);
            this.Controls.Add(this.labelWebsite);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelDevelopers);
            this.Controls.Add(this.labelGenres);
            this.Controls.Add(this.labelRating);
            this.Controls.Add(this.labelPlatforms);
            this.Controls.Add(this.textBoxPublisher);
            this.Controls.Add(this.labelPublisher);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.buttonRetrieveGame);
            this.Controls.Add(this.labelSearchGames);
            this.Controls.Add(this.buttonUploadLocalCover);
            this.Controls.Add(this.pictureBoxGameCover);
            this.Controls.Add(this.comboBoxSearchGames);
            this.Name = "AddGameView";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGameCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSearchGames;
        private System.Windows.Forms.PictureBox pictureBoxGameCover;
        private System.Windows.Forms.Button buttonUploadLocalCover;
        private System.Windows.Forms.Label labelSearchGames;
        private System.Windows.Forms.Button buttonRetrieveGame;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxPublisher;
        private System.Windows.Forms.Label labelPublisher;
        private System.Windows.Forms.Label labelPlatforms;
        private System.Windows.Forms.Label labelRating;
        private System.Windows.Forms.Label labelGenres;
        private System.Windows.Forms.Label labelDevelopers;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelWebsite;
        private System.Windows.Forms.Label labelExecutablePath;
        private System.Windows.Forms.TextBox textBoxExecutablePath;
        private System.Windows.Forms.TextBox textBoxWebsite;
        private System.Windows.Forms.TextBox textBoxDevelopers;
        private System.Windows.Forms.TextBox textBoxGenres;
        private System.Windows.Forms.TextBox textBoxRating;
        private System.Windows.Forms.TextBox textBoxPlatforms;
        private System.Windows.Forms.RichTextBox richTextBoxDescription;
        private System.Windows.Forms.Button buttonSaveGame;
        private System.Windows.Forms.Button buttonPickExecutable;
        private System.Windows.Forms.Button buttonGameSuggestions;
    }
}