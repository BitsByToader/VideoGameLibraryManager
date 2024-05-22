namespace Helpers
{
    partial class DetailedGameInfoBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gamePictureBox = new System.Windows.Forms.PictureBox();
            this.gameName = new System.Windows.Forms.Label();
            this.gameGenre = new System.Windows.Forms.Label();
            this.gamePlaytime = new System.Windows.Forms.Label();
            this.gameRating = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gamePictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gamePictureBox
            // 
            this.gamePictureBox.Location = new System.Drawing.Point(14, 9);
            this.gamePictureBox.Name = "gamePictureBox";
            this.gamePictureBox.Size = new System.Drawing.Size(127, 88);
            this.gamePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gamePictureBox.TabIndex = 0;
            this.gamePictureBox.TabStop = false;
            // 
            // gameName
            // 
            this.gameName.AutoEllipsis = true;
            this.gameName.AutoSize = true;
            this.gameName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.gameName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameName.Location = new System.Drawing.Point(228, 17);
            this.gameName.Name = "gameName";
            this.gameName.Size = new System.Drawing.Size(51, 20);
            this.gameName.TabIndex = 1;
            this.gameName.Text = "label1";
            // 
            // gameGenre
            // 
            this.gameGenre.AutoEllipsis = true;
            this.gameGenre.AutoSize = true;
            this.gameGenre.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.gameGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameGenre.Location = new System.Drawing.Point(228, 77);
            this.gameGenre.Name = "gameGenre";
            this.gameGenre.Size = new System.Drawing.Size(51, 20);
            this.gameGenre.TabIndex = 2;
            this.gameGenre.Text = "label2";
            // 
            // gamePlaytime
            // 
            this.gamePlaytime.AutoEllipsis = true;
            this.gamePlaytime.AutoSize = true;
            this.gamePlaytime.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.gamePlaytime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gamePlaytime.Location = new System.Drawing.Point(555, 50);
            this.gamePlaytime.Name = "gamePlaytime";
            this.gamePlaytime.Size = new System.Drawing.Size(51, 20);
            this.gamePlaytime.TabIndex = 3;
            this.gamePlaytime.Text = "label3";
            // 
            // gameRating
            // 
            this.gameRating.AutoEllipsis = true;
            this.gameRating.AutoSize = true;
            this.gameRating.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.gameRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameRating.Location = new System.Drawing.Point(228, 45);
            this.gameRating.Name = "gameRating";
            this.gameRating.Size = new System.Drawing.Size(51, 20);
            this.gameRating.TabIndex = 4;
            this.gameRating.Text = "label4";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.gamePictureBox);
            this.panel1.Controls.Add(this.gamePlaytime);
            this.panel1.Controls.Add(this.gameRating);
            this.panel1.Controls.Add(this.gameName);
            this.panel1.Controls.Add(this.gameGenre);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(687, 110);
            this.panel1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(467, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Playtime (min.):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Rating:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Genre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(162, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name:";
            // 
            // DetailedGameInfoBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "DetailedGameInfoBox";
            this.Size = new System.Drawing.Size(695, 119);
            ((System.ComponentModel.ISupportInitialize)(this.gamePictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox gamePictureBox;
        private System.Windows.Forms.Label gameName;
        private System.Windows.Forms.Label gameGenre;
        private System.Windows.Forms.Label gamePlaytime;
        private System.Windows.Forms.Label gameRating;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}
