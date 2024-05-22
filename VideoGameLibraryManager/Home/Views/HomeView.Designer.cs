namespace VideoGameLibraryManager.Home.Views
{
    partial class HomeView
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
            this.favouriteGamesFormViewContainer = new WFFramework.FormViewContainer();
            this.mostPlayedGamesFormViewContainer = new WFFramework.FormViewContainer();
            this.favouriteGamesLabel = new System.Windows.Forms.Label();
            this.mostPlayedGamesLabel = new System.Windows.Forms.Label();
            this.totalPlaytimeLabel = new System.Windows.Forms.Label();
            this.favouriteGenreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // favouriteGamesFormViewContainer
            // 
            this.favouriteGamesFormViewContainer.ColumnCount = 1;
            this.favouriteGamesFormViewContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.favouriteGamesFormViewContainer.Location = new System.Drawing.Point(12, 48);
            this.favouriteGamesFormViewContainer.Name = "favouriteGamesFormViewContainer";
            this.favouriteGamesFormViewContainer.RowCount = 1;
            this.favouriteGamesFormViewContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.favouriteGamesFormViewContainer.Size = new System.Drawing.Size(776, 139);
            this.favouriteGamesFormViewContainer.TabIndex = 0;
            // 
            // mostPlayedGamesFormViewContainer
            // 
            this.mostPlayedGamesFormViewContainer.ColumnCount = 1;
            this.mostPlayedGamesFormViewContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mostPlayedGamesFormViewContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mostPlayedGamesFormViewContainer.Location = new System.Drawing.Point(12, 238);
            this.mostPlayedGamesFormViewContainer.Name = "mostPlayedGamesFormViewContainer";
            this.mostPlayedGamesFormViewContainer.RowCount = 1;
            this.mostPlayedGamesFormViewContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mostPlayedGamesFormViewContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mostPlayedGamesFormViewContainer.Size = new System.Drawing.Size(776, 133);
            this.mostPlayedGamesFormViewContainer.TabIndex = 1;
            // 
            // favouriteGamesLabel
            // 
            this.favouriteGamesLabel.AutoSize = true;
            this.favouriteGamesLabel.Location = new System.Drawing.Point(12, 21);
            this.favouriteGamesLabel.Name = "favouriteGamesLabel";
            this.favouriteGamesLabel.Size = new System.Drawing.Size(90, 13);
            this.favouriteGamesLabel.TabIndex = 0;
            this.favouriteGamesLabel.Text = "Favourite Games:";
            // 
            // mostPlayedGamesLabel
            // 
            this.mostPlayedGamesLabel.AutoSize = true;
            this.mostPlayedGamesLabel.Location = new System.Drawing.Point(12, 222);
            this.mostPlayedGamesLabel.Name = "mostPlayedGamesLabel";
            this.mostPlayedGamesLabel.Size = new System.Drawing.Size(104, 13);
            this.mostPlayedGamesLabel.TabIndex = 2;
            this.mostPlayedGamesLabel.Text = "Most Played Games:";
            // 
            // totalPlaytimeLabel
            // 
            this.totalPlaytimeLabel.AutoSize = true;
            this.totalPlaytimeLabel.Location = new System.Drawing.Point(12, 384);
            this.totalPlaytimeLabel.Name = "totalPlaytimeLabel";
            this.totalPlaytimeLabel.Size = new System.Drawing.Size(35, 13);
            this.totalPlaytimeLabel.TabIndex = 3;
            this.totalPlaytimeLabel.Text = "label3";
            // 
            // favouriteGenreLabel
            // 
            this.favouriteGenreLabel.AutoSize = true;
            this.favouriteGenreLabel.Location = new System.Drawing.Point(12, 415);
            this.favouriteGenreLabel.Name = "favouriteGenreLabel";
            this.favouriteGenreLabel.Size = new System.Drawing.Size(35, 13);
            this.favouriteGenreLabel.TabIndex = 4;
            this.favouriteGenreLabel.Text = "label4";
            // 
            // HomeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.favouriteGenreLabel);
            this.Controls.Add(this.totalPlaytimeLabel);
            this.Controls.Add(this.mostPlayedGamesLabel);
            this.Controls.Add(this.favouriteGamesLabel);
            this.Controls.Add(this.mostPlayedGamesFormViewContainer);
            this.Controls.Add(this.favouriteGamesFormViewContainer);
            this.Name = "HomeView";
            this.Text = "HomeView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WFFramework.FormViewContainer favouriteGamesFormViewContainer;
        private WFFramework.FormViewContainer mostPlayedGamesFormViewContainer;
        private System.Windows.Forms.Label favouriteGamesLabel;
        private System.Windows.Forms.Label mostPlayedGamesLabel;
        private System.Windows.Forms.Label totalPlaytimeLabel;
        private System.Windows.Forms.Label favouriteGenreLabel;
    }
}