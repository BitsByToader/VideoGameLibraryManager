namespace Helpers
{
    partial class BriefGameInfoBox
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
            ((System.ComponentModel.ISupportInitialize)(this.gamePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // gamePictureBox
            // 
            this.gamePictureBox.Location = new System.Drawing.Point(20, 12);
            this.gamePictureBox.Name = "gamePictureBox";
            this.gamePictureBox.Size = new System.Drawing.Size(127, 88);
            this.gamePictureBox.TabIndex = 0;
            this.gamePictureBox.TabStop = false;
            // 
            // gameName
            // 
            this.gameName.AutoEllipsis = true;
            this.gameName.AutoSize = true;
            this.gameName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameName.Location = new System.Drawing.Point(62, 103);
            this.gameName.Name = "gameName";
            this.gameName.Size = new System.Drawing.Size(51, 20);
            this.gameName.TabIndex = 1;
            this.gameName.Text = "label1";
            // 
            // BriefGameInfoBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gameName);
            this.Controls.Add(this.gamePictureBox);
            this.Name = "BriefGameInfoBox";
            this.Size = new System.Drawing.Size(167, 150);
            ((System.ComponentModel.ISupportInitialize)(this.gamePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox gamePictureBox;
        private System.Windows.Forms.Label gameName;
    }
}
