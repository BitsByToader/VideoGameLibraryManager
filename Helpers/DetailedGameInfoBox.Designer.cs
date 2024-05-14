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
            ((System.ComponentModel.ISupportInitialize)(this.gamePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // gamePictureBox
            // 
            this.gamePictureBox.Location = new System.Drawing.Point(24, 20);
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
            this.gameName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameName.Location = new System.Drawing.Point(197, 20);
            this.gameName.Name = "gameName";
            this.gameName.Size = new System.Drawing.Size(51, 20);
            this.gameName.TabIndex = 1;
            this.gameName.Text = "label1";
            // 
            // gameGenre
            // 
            this.gameGenre.AutoEllipsis = true;
            this.gameGenre.AutoSize = true;
            this.gameGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameGenre.Location = new System.Drawing.Point(197, 68);
            this.gameGenre.Name = "gameGenre";
            this.gameGenre.Size = new System.Drawing.Size(51, 20);
            this.gameGenre.TabIndex = 2;
            this.gameGenre.Text = "label2";
            // 
            // gamePlaytime
            // 
            this.gamePlaytime.AutoEllipsis = true;
            this.gamePlaytime.AutoSize = true;
            this.gamePlaytime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gamePlaytime.Location = new System.Drawing.Point(527, 68);
            this.gamePlaytime.Name = "gamePlaytime";
            this.gamePlaytime.Size = new System.Drawing.Size(51, 20);
            this.gamePlaytime.TabIndex = 3;
            this.gamePlaytime.Text = "label3";
            // 
            // gameRating
            // 
            this.gameRating.AutoEllipsis = true;
            this.gameRating.AutoSize = true;
            this.gameRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameRating.Location = new System.Drawing.Point(527, 20);
            this.gameRating.Name = "gameRating";
            this.gameRating.Size = new System.Drawing.Size(51, 20);
            this.gameRating.TabIndex = 4;
            this.gameRating.Text = "label4";
            // 
            // DetailedGameInfoBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gameRating);
            this.Controls.Add(this.gamePlaytime);
            this.Controls.Add(this.gameGenre);
            this.Controls.Add(this.gameName);
            this.Controls.Add(this.gamePictureBox);
            this.Name = "DetailedGameInfoBox";
            this.Size = new System.Drawing.Size(883, 132);
            ((System.ComponentModel.ISupportInitialize)(this.gamePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox gamePictureBox;
        private System.Windows.Forms.Label gameName;
        private System.Windows.Forms.Label gameGenre;
        private System.Windows.Forms.Label gamePlaytime;
        private System.Windows.Forms.Label gameRating;
    }
}
