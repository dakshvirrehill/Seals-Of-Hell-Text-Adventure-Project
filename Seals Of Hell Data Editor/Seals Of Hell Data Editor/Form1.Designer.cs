namespace Seals_Of_Hell_Data_Editor
{
    partial class SealsOfHellMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editGameStartDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameStartTabControl = new System.Windows.Forms.TabControl();
            this.gameDetailsTab = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gameNameLabel = new System.Windows.Forms.Label();
            this.gameNameTextBox = new System.Windows.Forms.TextBox();
            this.gameStoryLabel = new System.Windows.Forms.Label();
            this.gameStoryTextBox = new System.Windows.Forms.RichTextBox();
            this.editGameDetails = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.gameStartTabControl.SuspendLayout();
            this.gameDetailsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editGameStartDataToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // editGameStartDataToolStripMenuItem
            // 
            this.editGameStartDataToolStripMenuItem.Name = "editGameStartDataToolStripMenuItem";
            this.editGameStartDataToolStripMenuItem.Size = new System.Drawing.Size(127, 20);
            this.editGameStartDataToolStripMenuItem.Text = "Edit Game Start Data";
            this.editGameStartDataToolStripMenuItem.Click += new System.EventHandler(this.EditGameStartDataToolStripMenuItem_Click);
            // 
            // gameStartTabControl
            // 
            this.gameStartTabControl.Controls.Add(this.gameDetailsTab);
            this.gameStartTabControl.Controls.Add(this.tabPage2);
            this.gameStartTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameStartTabControl.Location = new System.Drawing.Point(0, 27);
            this.gameStartTabControl.Name = "gameStartTabControl";
            this.gameStartTabControl.SelectedIndex = 0;
            this.gameStartTabControl.Size = new System.Drawing.Size(1008, 703);
            this.gameStartTabControl.TabIndex = 1;
            // 
            // gameDetailsTab
            // 
            this.gameDetailsTab.Controls.Add(this.editGameDetails);
            this.gameDetailsTab.Controls.Add(this.gameStoryTextBox);
            this.gameDetailsTab.Controls.Add(this.gameStoryLabel);
            this.gameDetailsTab.Controls.Add(this.gameNameTextBox);
            this.gameDetailsTab.Controls.Add(this.gameNameLabel);
            this.gameDetailsTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameDetailsTab.Location = new System.Drawing.Point(4, 29);
            this.gameDetailsTab.Name = "gameDetailsTab";
            this.gameDetailsTab.Padding = new System.Windows.Forms.Padding(3);
            this.gameDetailsTab.Size = new System.Drawing.Size(1000, 670);
            this.gameDetailsTab.TabIndex = 0;
            this.gameDetailsTab.Text = "Game Details";
            this.gameDetailsTab.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 74);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gameNameLabel
            // 
            this.gameNameLabel.AutoSize = true;
            this.gameNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameNameLabel.Location = new System.Drawing.Point(80, 109);
            this.gameNameLabel.Name = "gameNameLabel";
            this.gameNameLabel.Size = new System.Drawing.Size(232, 20);
            this.gameNameLabel.TabIndex = 0;
            this.gameNameLabel.Text = "Current Name Of The Game";
            // 
            // gameNameTextBox
            // 
            this.gameNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameNameTextBox.Location = new System.Drawing.Point(332, 106);
            this.gameNameTextBox.Name = "gameNameTextBox";
            this.gameNameTextBox.Size = new System.Drawing.Size(538, 26);
            this.gameNameTextBox.TabIndex = 1;
            // 
            // gameStoryLabel
            // 
            this.gameStoryLabel.AutoSize = true;
            this.gameStoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameStoryLabel.Location = new System.Drawing.Point(80, 158);
            this.gameStoryLabel.Name = "gameStoryLabel";
            this.gameStoryLabel.Size = new System.Drawing.Size(228, 20);
            this.gameStoryLabel.TabIndex = 2;
            this.gameStoryLabel.Text = "Current Story Of The Game";
            // 
            // gameStoryTextBox
            // 
            this.gameStoryTextBox.Location = new System.Drawing.Point(332, 158);
            this.gameStoryTextBox.Name = "gameStoryTextBox";
            this.gameStoryTextBox.Size = new System.Drawing.Size(538, 275);
            this.gameStoryTextBox.TabIndex = 3;
            this.gameStoryTextBox.Text = "";
            // 
            // editGameDetails
            // 
            this.editGameDetails.Location = new System.Drawing.Point(332, 475);
            this.editGameDetails.Name = "editGameDetails";
            this.editGameDetails.Size = new System.Drawing.Size(538, 77);
            this.editGameDetails.TabIndex = 4;
            this.editGameDetails.Text = "Edit Game Details";
            this.editGameDetails.UseVisualStyleBackColor = true;
            this.editGameDetails.Click += new System.EventHandler(this.EditGameDetails_Click);
            // 
            // SealsOfHellMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.gameStartTabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximumSize = new System.Drawing.Size(1440, 1078);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "SealsOfHellMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seals Of Hell Data Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gameStartTabControl.ResumeLayout(false);
            this.gameDetailsTab.ResumeLayout(false);
            this.gameDetailsTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editGameStartDataToolStripMenuItem;
        private System.Windows.Forms.TabControl gameStartTabControl;
        private System.Windows.Forms.TabPage gameDetailsTab;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label gameStoryLabel;
        private System.Windows.Forms.TextBox gameNameTextBox;
        private System.Windows.Forms.Label gameNameLabel;
        private System.Windows.Forms.Button editGameDetails;
        private System.Windows.Forms.RichTextBox gameStoryTextBox;
    }
}

