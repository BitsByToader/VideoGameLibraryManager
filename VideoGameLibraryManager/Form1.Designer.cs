﻿namespace VideoGameLibraryManager
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.extraButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.gameLibButton = new System.Windows.Forms.Button();
            this.addGameButton = new System.Windows.Forms.Button();
            this.homeButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPanel
            // 
            this.buttonPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.buttonPanel.Controls.Add(this.extraButton);
            this.buttonPanel.Controls.Add(this.settingsButton);
            this.buttonPanel.Controls.Add(this.gameLibButton);
            this.buttonPanel.Controls.Add(this.addGameButton);
            this.buttonPanel.Controls.Add(this.homeButton);
            this.buttonPanel.Location = new System.Drawing.Point(1, -1);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(72, 450);
            this.buttonPanel.TabIndex = 0;
            // 
            // extraButton
            // 
            this.extraButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("extraButton.BackgroundImage")));
            this.extraButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.extraButton.FlatAppearance.BorderSize = 0;
            this.extraButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.extraButton.Location = new System.Drawing.Point(0, 377);
            this.extraButton.Name = "extraButton";
            this.extraButton.Size = new System.Drawing.Size(72, 72);
            this.extraButton.TabIndex = 4;
            this.extraButton.UseVisualStyleBackColor = true;
            // 
            // settingsButton
            // 
            this.settingsButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("settingsButton.BackgroundImage")));
            this.settingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.settingsButton.FlatAppearance.BorderSize = 0;
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.Location = new System.Drawing.Point(0, 214);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(72, 72);
            this.settingsButton.TabIndex = 3;
            this.settingsButton.UseVisualStyleBackColor = true;
            // 
            // gameLibButton
            // 
            this.gameLibButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gameLibButton.BackgroundImage")));
            this.gameLibButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gameLibButton.FlatAppearance.BorderSize = 0;
            this.gameLibButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gameLibButton.Location = new System.Drawing.Point(0, 144);
            this.gameLibButton.Name = "gameLibButton";
            this.gameLibButton.Size = new System.Drawing.Size(72, 72);
            this.gameLibButton.TabIndex = 2;
            this.gameLibButton.UseVisualStyleBackColor = true;
            // 
            // addGameButton
            // 
            this.addGameButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addGameButton.BackgroundImage")));
            this.addGameButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addGameButton.FlatAppearance.BorderSize = 0;
            this.addGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addGameButton.Location = new System.Drawing.Point(0, 72);
            this.addGameButton.Name = "addGameButton";
            this.addGameButton.Size = new System.Drawing.Size(72, 72);
            this.addGameButton.TabIndex = 1;
            this.addGameButton.UseVisualStyleBackColor = true;
            // 
            // homeButton
            // 
            this.homeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("homeButton.BackgroundImage")));
            this.homeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.homeButton.FlatAppearance.BorderSize = 0;
            this.homeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeButton.Location = new System.Drawing.Point(0, 2);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(72, 72);
            this.homeButton.TabIndex = 0;
            this.homeButton.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(580, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(197, 328);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(552, 28);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(106, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(440, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "VGLM";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.buttonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button homeButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button gameLibButton;
        private System.Windows.Forms.Button addGameButton;
        private System.Windows.Forms.Button extraButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

