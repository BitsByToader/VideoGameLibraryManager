namespace VideoGameLibraryManager
{
    partial class GameDisplayFormView
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
            this.sortStyleComboBox = new System.Windows.Forms.ComboBox();
            this.sortStyle = new System.Windows.Forms.Label();
            this.listViewButton = new System.Windows.Forms.Button();
            this.gridViewButton = new System.Windows.Forms.Button();
            this.gameDisplayViewContainer = new WFFramework.FormViewContainer();
            this.SuspendLayout();
            // 
            // sortStyleComboBox
            // 
            this.sortStyleComboBox.FormattingEnabled = true;
            this.sortStyleComboBox.Items.AddRange(new object[] {
            "Rating",
            "Name",
            "Publisher",
            "Playtime",
            "Genre"});
            this.sortStyleComboBox.Location = new System.Drawing.Point(1334, 23);
            this.sortStyleComboBox.Margin = new System.Windows.Forms.Padding(6);
            this.sortStyleComboBox.Name = "sortStyleComboBox";
            this.sortStyleComboBox.Size = new System.Drawing.Size(238, 33);
            this.sortStyleComboBox.TabIndex = 0;
            this.sortStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.sortStyleComboBox_SelectedIndexChanged);
            // 
            // sortStyle
            // 
            this.sortStyle.AutoSize = true;
            this.sortStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sortStyle.Location = new System.Drawing.Point(1192, 29);
            this.sortStyle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.sortStyle.Name = "sortStyle";
            this.sortStyle.Size = new System.Drawing.Size(115, 31);
            this.sortStyle.TabIndex = 1;
            this.sortStyle.Text = "Sort by :";
            // 
            // listViewButton
            // 
            this.listViewButton.BackColor = System.Drawing.Color.White;
            this.listViewButton.Location = new System.Drawing.Point(986, 19);
            this.listViewButton.Margin = new System.Windows.Forms.Padding(6);
            this.listViewButton.Name = "listViewButton";
            this.listViewButton.Size = new System.Drawing.Size(150, 44);
            this.listViewButton.TabIndex = 2;
            this.listViewButton.Text = "List View";
            this.listViewButton.UseVisualStyleBackColor = false;
            this.listViewButton.Click += new System.EventHandler(this.listViewButton_Click);
            // 
            // gridViewButton
            // 
            this.gridViewButton.Location = new System.Drawing.Point(790, 19);
            this.gridViewButton.Margin = new System.Windows.Forms.Padding(6);
            this.gridViewButton.Name = "gridViewButton";
            this.gridViewButton.Size = new System.Drawing.Size(150, 44);
            this.gridViewButton.TabIndex = 3;
            this.gridViewButton.Text = "Grid View";
            this.gridViewButton.UseVisualStyleBackColor = true;
            this.gridViewButton.Click += new System.EventHandler(this.gridViewButton_Click);
            // 
            // gameDisplayViewContainer
            // 
            this.gameDisplayViewContainer.ColumnCount = 1;
            this.gameDisplayViewContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.gameDisplayViewContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gameDisplayViewContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gameDisplayViewContainer.Location = new System.Drawing.Point(12, 73);
            this.gameDisplayViewContainer.Name = "gameDisplayViewContainer";
            this.gameDisplayViewContainer.RowCount = 1;
            this.gameDisplayViewContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.gameDisplayViewContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gameDisplayViewContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gameDisplayViewContainer.Size = new System.Drawing.Size(1576, 780);
            this.gameDisplayViewContainer.TabIndex = 4;
            // 
            // GameDisplayFormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 865);
            this.Controls.Add(this.gameDisplayViewContainer);
            this.Controls.Add(this.gridViewButton);
            this.Controls.Add(this.listViewButton);
            this.Controls.Add(this.sortStyle);
            this.Controls.Add(this.sortStyleComboBox);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "GameDisplayFormView";
            this.Text = "GameDisplayFormView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox sortStyleComboBox;
        private System.Windows.Forms.Label sortStyle;
        private System.Windows.Forms.Button listViewButton;
        private System.Windows.Forms.Button gridViewButton;
        private WFFramework.FormViewContainer gameDisplayViewContainer;
    }
}