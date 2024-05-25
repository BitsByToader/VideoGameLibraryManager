namespace VideoGameLibraryManager.ViewGame.Views
{
    partial class ViewGameView
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
            this.pictureBoxGameCover = new System.Windows.Forms.PictureBox();
            this.GameTitle = new System.Windows.Forms.Label();
            this.PlayButton = new System.Windows.Forms.Button();
            this.ToDos = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.PersonalRating = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.overallRating = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGameCover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonalRating)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxGameCover
            // 
            this.pictureBoxGameCover.Location = new System.Drawing.Point(11, 11);
            this.pictureBoxGameCover.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxGameCover.Name = "pictureBoxGameCover";
            this.pictureBoxGameCover.Size = new System.Drawing.Size(174, 242);
            this.pictureBoxGameCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxGameCover.TabIndex = 2;
            this.pictureBoxGameCover.TabStop = false;
            // 
            // GameTitle
            // 
            this.GameTitle.AutoSize = true;
            this.GameTitle.Location = new System.Drawing.Point(12, 255);
            this.GameTitle.Name = "GameTitle";
            this.GameTitle.Size = new System.Drawing.Size(64, 13);
            this.GameTitle.TabIndex = 3;
            this.GameTitle.Text = "Game name";
            // 
            // PlayButton
            // 
            this.PlayButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PlayButton.Location = new System.Drawing.Point(507, 338);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(154, 43);
            this.PlayButton.TabIndex = 4;
            this.PlayButton.Text = "Play";
            this.PlayButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.PlayButton.UseMnemonic = false;
            this.PlayButton.UseVisualStyleBackColor = false;
            this.PlayButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ToDos
            // 
            this.ToDos.FormattingEnabled = true;
            this.ToDos.Location = new System.Drawing.Point(190, 159);
            this.ToDos.Name = "ToDos";
            this.ToDos.Size = new System.Drawing.Size(471, 94);
            this.ToDos.TabIndex = 5;
            this.ToDos.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.Location = new System.Drawing.Point(11, 358);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Edit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button2.Location = new System.Drawing.Point(82, 358);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Remove";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(190, 13);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(471, 140);
            this.textBox1.TabIndex = 8;
            // 
            // PersonalRating
            // 
            this.PersonalRating.BackColor = System.Drawing.SystemColors.Menu;
            this.PersonalRating.Location = new System.Drawing.Point(234, 294);
            this.PersonalRating.Maximum = 100;
            this.PersonalRating.Name = "PersonalRating";
            this.PersonalRating.Size = new System.Drawing.Size(104, 45);
            this.PersonalRating.TabIndex = 9;
            this.PersonalRating.TickStyle = System.Windows.Forms.TickStyle.None;
            this.PersonalRating.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Rating";
            // 
            // overallRating
            // 
            this.overallRating.AutoSize = true;
            this.overallRating.Location = new System.Drawing.Point(190, 256);
            this.overallRating.Name = "overallRating";
            this.overallRating.Size = new System.Drawing.Size(80, 13);
            this.overallRating.TabIndex = 11;
            this.overallRating.Text = "Overall Rating: ";
            this.overallRating.Click += new System.EventHandler(this.label2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(421, 362);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(64, 17);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Favorite";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ViewGameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 393);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.overallRating);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PersonalRating);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ToDos);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.GameTitle);
            this.Controls.Add(this.pictureBoxGameCover);
            this.Name = "ViewGameView";
            this.Text = "ViewGameView";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGameCover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonalRating)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxGameCover;
        private System.Windows.Forms.Label GameTitle;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.CheckedListBox ToDos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TrackBar PersonalRating;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label overallRating;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}