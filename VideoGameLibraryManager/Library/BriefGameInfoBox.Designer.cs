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
            this.panel1 = new System.Windows.Forms.Panel();
            this.gameName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gamePictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gamePictureBox
            // 
            this.gamePictureBox.Location = new System.Drawing.Point(68, 17);
            this.gamePictureBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gamePictureBox.Name = "gamePictureBox";
            this.gamePictureBox.Size = new System.Drawing.Size(254, 169);
            this.gamePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gamePictureBox.TabIndex = 0;
            this.gamePictureBox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.gameName);
            this.panel1.Controls.Add(this.gamePictureBox);
            this.panel1.Location = new System.Drawing.Point(30, 25);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 267);
            this.panel1.TabIndex = 2;
            // 
            // gameName
            // 
            this.gameName.AutoEllipsis = true;
            this.gameName.BackColor = System.Drawing.SystemColors.Control;
            this.gameName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameName.Location = new System.Drawing.Point(6, 192);
            this.gameName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.gameName.Name = "gameName";
            this.gameName.Size = new System.Drawing.Size(382, 50);
            this.gameName.TabIndex = 1;
            this.gameName.Text = "label1";
            this.gameName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BriefGameInfoBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "BriefGameInfoBox";
            this.Size = new System.Drawing.Size(462, 325);
            ((System.ComponentModel.ISupportInitialize)(this.gamePictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox gamePictureBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label gameName;
    }
}
