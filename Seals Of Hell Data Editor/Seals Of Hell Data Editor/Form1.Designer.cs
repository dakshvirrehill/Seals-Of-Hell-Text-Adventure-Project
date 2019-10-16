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
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChooseFile = new System.Windows.Forms.OpenFileDialog();
            this.SaveFile = new System.Windows.Forms.SaveFileDialog();
            this.AddRegionTextBox = new System.Windows.Forms.TextBox();
            this.AddRegionLabel = new System.Windows.Forms.Label();
            this.AddRegionButton = new System.Windows.Forms.Button();
            this.RegionTabs = new System.Windows.Forms.TabControl();
            this.AddRegionTab = new System.Windows.Forms.TabPage();
            this.StoryNewRegion = new System.Windows.Forms.Label();
            this.RegionStoryTextBox = new System.Windows.Forms.TextBox();
            this.EditRegionsTab = new System.Windows.Forms.TabPage();
            this.EditRegionStoryLabel = new System.Windows.Forms.Label();
            this.EditRegionStoryTBox = new System.Windows.Forms.TextBox();
            this.editregionlabel = new System.Windows.Forms.Label();
            this.EditRegion = new System.Windows.Forms.Button();
            this.EditCurrentRegionTextBox = new System.Windows.Forms.TextBox();
            this.EditRegionsList = new System.Windows.Forms.ListBox();
            this.RoomTabs = new System.Windows.Forms.TabControl();
            this.AddRoomTab = new System.Windows.Forms.TabPage();
            this.NewRoomRegionSelLabel = new System.Windows.Forms.Label();
            this.NewRoomRegionSelector = new System.Windows.Forms.ComboBox();
            this.storynewroomlbl = new System.Windows.Forms.Label();
            this.NewRoomStory = new System.Windows.Forms.TextBox();
            this.newroomnamelabel = new System.Windows.Forms.Label();
            this.NewRoomBtn = new System.Windows.Forms.Button();
            this.NewRoomNameTBox = new System.Windows.Forms.TextBox();
            this.EditCurrentRoomsTab = new System.Windows.Forms.TabPage();
            this.selectroomname = new System.Windows.Forms.Label();
            this.selectregionlbl = new System.Windows.Forms.Label();
            this.EditRoomNameSelector = new System.Windows.Forms.ListBox();
            this.EditRoomRegionSelector = new System.Windows.Forms.ListBox();
            this.editcurroomreglbl = new System.Windows.Forms.Label();
            this.EditRoomRegion = new System.Windows.Forms.ComboBox();
            this.editcurroomstrlbl = new System.Windows.Forms.Label();
            this.EditRoomStory = new System.Windows.Forms.TextBox();
            this.editroomnamelbl = new System.Windows.Forms.Label();
            this.EditRoomName = new System.Windows.Forms.TextBox();
            this.SaveRoomEdit = new System.Windows.Forms.Button();
            this.CommandsTab = new System.Windows.Forms.TabControl();
            this.AddCommandsTab = new System.Windows.Forms.TabPage();
            this.CommandVerbLabel = new System.Windows.Forms.Label();
            this.AddNewCommand = new System.Windows.Forms.Button();
            this.NewCommandVerbText = new System.Windows.Forms.TextBox();
            this.EditCommandsTab = new System.Windows.Forms.TabPage();
            this.EditCommandVerbLabel = new System.Windows.Forms.Label();
            this.EditCommandVerbBtn = new System.Windows.Forms.Button();
            this.EditCommandVerbText = new System.Windows.Forms.TextBox();
            this.EditCommandVerbList = new System.Windows.Forms.ListBox();
            this.MainMenu.SuspendLayout();
            this.RegionTabs.SuspendLayout();
            this.AddRegionTab.SuspendLayout();
            this.EditRegionsTab.SuspendLayout();
            this.RoomTabs.SuspendLayout();
            this.AddRoomTab.SuspendLayout();
            this.EditCurrentRoomsTab.SuspendLayout();
            this.CommandsTab.SuspendLayout();
            this.AddCommandsTab.SuspendLayout();
            this.EditCommandsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.SystemColors.Control;
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.regionToolStripMenuItem,
            this.roomToolStripMenuItem,
            this.commandsToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.MainMenu.Size = new System.Drawing.Size(1344, 28);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "Main Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // regionToolStripMenuItem
            // 
            this.regionToolStripMenuItem.Name = "regionToolStripMenuItem";
            this.regionToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.regionToolStripMenuItem.Text = "Region";
            this.regionToolStripMenuItem.Click += new System.EventHandler(this.RegionToolStripMenuItem_Click);
            // 
            // roomToolStripMenuItem
            // 
            this.roomToolStripMenuItem.Name = "roomToolStripMenuItem";
            this.roomToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.roomToolStripMenuItem.Text = "Room";
            this.roomToolStripMenuItem.Click += new System.EventHandler(this.RoomToolStripMenuItem_Click);
            // 
            // commandsToolStripMenuItem
            // 
            this.commandsToolStripMenuItem.Name = "commandsToolStripMenuItem";
            this.commandsToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.commandsToolStripMenuItem.Text = "Commands";
            this.commandsToolStripMenuItem.Click += new System.EventHandler(this.CommandsToolStripMenuItem_Click);
            // 
            // ChooseFile
            // 
            this.ChooseFile.DefaultExt = "json";
            this.ChooseFile.Filter = "JSON File|*.json";
            this.ChooseFile.InitialDirectory = "..\\\\";
            this.ChooseFile.Title = "Select Data File";
            this.ChooseFile.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenDataFile);
            // 
            // SaveFile
            // 
            this.SaveFile.DefaultExt = "json";
            this.SaveFile.Filter = "JSON Files|*.json";
            this.SaveFile.InitialDirectory = "..\\\\";
            this.SaveFile.Title = "Save Seals Of Hell Data File";
            this.SaveFile.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveDataFile);
            // 
            // AddRegionTextBox
            // 
            this.AddRegionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddRegionTextBox.Location = new System.Drawing.Point(628, 140);
            this.AddRegionTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddRegionTextBox.Name = "AddRegionTextBox";
            this.AddRegionTextBox.Size = new System.Drawing.Size(636, 46);
            this.AddRegionTextBox.TabIndex = 0;
            // 
            // AddRegionLabel
            // 
            this.AddRegionLabel.AutoSize = true;
            this.AddRegionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddRegionLabel.Location = new System.Drawing.Point(101, 144);
            this.AddRegionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AddRegionLabel.Name = "AddRegionLabel";
            this.AddRegionLabel.Size = new System.Drawing.Size(397, 39);
            this.AddRegionLabel.TabIndex = 1;
            this.AddRegionLabel.Text = "Name of the New Region";
            // 
            // AddRegionButton
            // 
            this.AddRegionButton.Location = new System.Drawing.Point(249, 378);
            this.AddRegionButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddRegionButton.Name = "AddRegionButton";
            this.AddRegionButton.Size = new System.Drawing.Size(639, 76);
            this.AddRegionButton.TabIndex = 2;
            this.AddRegionButton.Text = "Add New Region";
            this.AddRegionButton.UseVisualStyleBackColor = true;
            this.AddRegionButton.Click += new System.EventHandler(this.AddRegionButton_Click);
            // 
            // RegionTabs
            // 
            this.RegionTabs.Controls.Add(this.AddRegionTab);
            this.RegionTabs.Controls.Add(this.EditRegionsTab);
            this.RegionTabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegionTabs.Location = new System.Drawing.Point(0, 33);
            this.RegionTabs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RegionTabs.Name = "RegionTabs";
            this.RegionTabs.SelectedIndex = 0;
            this.RegionTabs.Size = new System.Drawing.Size(1344, 864);
            this.RegionTabs.TabIndex = 2;
            this.RegionTabs.Visible = false;
            this.RegionTabs.SelectedIndexChanged += new System.EventHandler(this.ResetEditableRegionsList);
            // 
            // AddRegionTab
            // 
            this.AddRegionTab.Controls.Add(this.StoryNewRegion);
            this.AddRegionTab.Controls.Add(this.RegionStoryTextBox);
            this.AddRegionTab.Controls.Add(this.AddRegionLabel);
            this.AddRegionTab.Controls.Add(this.AddRegionButton);
            this.AddRegionTab.Controls.Add(this.AddRegionTextBox);
            this.AddRegionTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddRegionTab.Location = new System.Drawing.Point(4, 29);
            this.AddRegionTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddRegionTab.Name = "AddRegionTab";
            this.AddRegionTab.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddRegionTab.Size = new System.Drawing.Size(1336, 831);
            this.AddRegionTab.TabIndex = 0;
            this.AddRegionTab.Text = "Add New Region";
            this.AddRegionTab.UseVisualStyleBackColor = true;
            // 
            // StoryNewRegion
            // 
            this.StoryNewRegion.AutoSize = true;
            this.StoryNewRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StoryNewRegion.Location = new System.Drawing.Point(101, 239);
            this.StoryNewRegion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StoryNewRegion.Name = "StoryNewRegion";
            this.StoryNewRegion.Size = new System.Drawing.Size(404, 39);
            this.StoryNewRegion.TabIndex = 4;
            this.StoryNewRegion.Text = "Story Of The New Region";
            // 
            // RegionStoryTextBox
            // 
            this.RegionStoryTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegionStoryTextBox.Location = new System.Drawing.Point(628, 235);
            this.RegionStoryTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RegionStoryTextBox.Name = "RegionStoryTextBox";
            this.RegionStoryTextBox.Size = new System.Drawing.Size(636, 46);
            this.RegionStoryTextBox.TabIndex = 3;
            // 
            // EditRegionsTab
            // 
            this.EditRegionsTab.Controls.Add(this.EditRegionStoryLabel);
            this.EditRegionsTab.Controls.Add(this.EditRegionStoryTBox);
            this.EditRegionsTab.Controls.Add(this.editregionlabel);
            this.EditRegionsTab.Controls.Add(this.EditRegion);
            this.EditRegionsTab.Controls.Add(this.EditCurrentRegionTextBox);
            this.EditRegionsTab.Controls.Add(this.EditRegionsList);
            this.EditRegionsTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditRegionsTab.Location = new System.Drawing.Point(4, 29);
            this.EditRegionsTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EditRegionsTab.Name = "EditRegionsTab";
            this.EditRegionsTab.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EditRegionsTab.Size = new System.Drawing.Size(1336, 831);
            this.EditRegionsTab.TabIndex = 1;
            this.EditRegionsTab.Text = "Edit Current Regions";
            this.EditRegionsTab.UseVisualStyleBackColor = true;
            // 
            // EditRegionStoryLabel
            // 
            this.EditRegionStoryLabel.AutoSize = true;
            this.EditRegionStoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditRegionStoryLabel.Location = new System.Drawing.Point(56, 118);
            this.EditRegionStoryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EditRegionStoryLabel.Name = "EditRegionStoryLabel";
            this.EditRegionStoryLabel.Size = new System.Drawing.Size(478, 39);
            this.EditRegionStoryLabel.TabIndex = 7;
            this.EditRegionStoryLabel.Text = "New Story Of Selected Region";
            // 
            // EditRegionStoryTBox
            // 
            this.EditRegionStoryTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditRegionStoryTBox.Location = new System.Drawing.Point(583, 114);
            this.EditRegionStoryTBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EditRegionStoryTBox.Name = "EditRegionStoryTBox";
            this.EditRegionStoryTBox.Size = new System.Drawing.Size(636, 46);
            this.EditRegionStoryTBox.TabIndex = 6;
            // 
            // editregionlabel
            // 
            this.editregionlabel.AutoSize = true;
            this.editregionlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editregionlabel.Location = new System.Drawing.Point(43, 47);
            this.editregionlabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.editregionlabel.Name = "editregionlabel";
            this.editregionlabel.Size = new System.Drawing.Size(490, 39);
            this.editregionlabel.TabIndex = 4;
            this.editregionlabel.Text = "New Name Of Selected Region";
            // 
            // EditRegion
            // 
            this.EditRegion.Location = new System.Drawing.Point(297, 202);
            this.EditRegion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EditRegion.Name = "EditRegion";
            this.EditRegion.Size = new System.Drawing.Size(639, 76);
            this.EditRegion.TabIndex = 5;
            this.EditRegion.Text = "Save Region Edit";
            this.EditRegion.UseVisualStyleBackColor = true;
            this.EditRegion.Click += new System.EventHandler(this.EditRegion_Click);
            // 
            // EditCurrentRegionTextBox
            // 
            this.EditCurrentRegionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditCurrentRegionTextBox.Location = new System.Drawing.Point(583, 43);
            this.EditCurrentRegionTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EditCurrentRegionTextBox.Name = "EditCurrentRegionTextBox";
            this.EditCurrentRegionTextBox.Size = new System.Drawing.Size(636, 46);
            this.EditCurrentRegionTextBox.TabIndex = 3;
            // 
            // EditRegionsList
            // 
            this.EditRegionsList.FormattingEnabled = true;
            this.EditRegionsList.ItemHeight = 29;
            this.EditRegionsList.Location = new System.Drawing.Point(11, 306);
            this.EditRegionsList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EditRegionsList.MultiColumn = true;
            this.EditRegionsList.Name = "EditRegionsList";
            this.EditRegionsList.Size = new System.Drawing.Size(1311, 497);
            this.EditRegionsList.TabIndex = 0;
            this.EditRegionsList.SelectedIndexChanged += new System.EventHandler(this.SetEditRegionTextBox);
            // 
            // RoomTabs
            // 
            this.RoomTabs.Controls.Add(this.AddRoomTab);
            this.RoomTabs.Controls.Add(this.EditCurrentRoomsTab);
            this.RoomTabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoomTabs.Location = new System.Drawing.Point(0, 33);
            this.RoomTabs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RoomTabs.Name = "RoomTabs";
            this.RoomTabs.SelectedIndex = 0;
            this.RoomTabs.Size = new System.Drawing.Size(1344, 864);
            this.RoomTabs.TabIndex = 3;
            this.RoomTabs.Visible = false;
            this.RoomTabs.SelectedIndexChanged += new System.EventHandler(this.UpdateRegionsAndRooms);
            // 
            // AddRoomTab
            // 
            this.AddRoomTab.Controls.Add(this.NewRoomRegionSelLabel);
            this.AddRoomTab.Controls.Add(this.NewRoomRegionSelector);
            this.AddRoomTab.Controls.Add(this.storynewroomlbl);
            this.AddRoomTab.Controls.Add(this.NewRoomStory);
            this.AddRoomTab.Controls.Add(this.newroomnamelabel);
            this.AddRoomTab.Controls.Add(this.NewRoomBtn);
            this.AddRoomTab.Controls.Add(this.NewRoomNameTBox);
            this.AddRoomTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddRoomTab.Location = new System.Drawing.Point(4, 29);
            this.AddRoomTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddRoomTab.Name = "AddRoomTab";
            this.AddRoomTab.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddRoomTab.Size = new System.Drawing.Size(1336, 831);
            this.AddRoomTab.TabIndex = 0;
            this.AddRoomTab.Text = "Add New Room";
            this.AddRoomTab.UseVisualStyleBackColor = true;
            // 
            // NewRoomRegionSelLabel
            // 
            this.NewRoomRegionSelLabel.AutoSize = true;
            this.NewRoomRegionSelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewRoomRegionSelLabel.Location = new System.Drawing.Point(183, 336);
            this.NewRoomRegionSelLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NewRoomRegionSelLabel.Name = "NewRoomRegionSelLabel";
            this.NewRoomRegionSelLabel.Size = new System.Drawing.Size(283, 29);
            this.NewRoomRegionSelLabel.TabIndex = 6;
            this.NewRoomRegionSelLabel.Text = "Region of the New Room";
            // 
            // NewRoomRegionSelector
            // 
            this.NewRoomRegionSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NewRoomRegionSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewRoomRegionSelector.FormattingEnabled = true;
            this.NewRoomRegionSelector.Location = new System.Drawing.Point(487, 331);
            this.NewRoomRegionSelector.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NewRoomRegionSelector.Name = "NewRoomRegionSelector";
            this.NewRoomRegionSelector.Size = new System.Drawing.Size(636, 38);
            this.NewRoomRegionSelector.TabIndex = 5;
            // 
            // storynewroomlbl
            // 
            this.storynewroomlbl.AutoSize = true;
            this.storynewroomlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storynewroomlbl.Location = new System.Drawing.Point(196, 262);
            this.storynewroomlbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.storynewroomlbl.Name = "storynewroomlbl";
            this.storynewroomlbl.Size = new System.Drawing.Size(260, 29);
            this.storynewroomlbl.TabIndex = 4;
            this.storynewroomlbl.Text = "Story of the New Room";
            // 
            // NewRoomStory
            // 
            this.NewRoomStory.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewRoomStory.Location = new System.Drawing.Point(487, 257);
            this.NewRoomStory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NewRoomStory.Name = "NewRoomStory";
            this.NewRoomStory.Size = new System.Drawing.Size(636, 37);
            this.NewRoomStory.TabIndex = 3;
            // 
            // newroomnamelabel
            // 
            this.newroomnamelabel.AutoSize = true;
            this.newroomnamelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newroomnamelabel.Location = new System.Drawing.Point(196, 182);
            this.newroomnamelabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.newroomnamelabel.Name = "newroomnamelabel";
            this.newroomnamelabel.Size = new System.Drawing.Size(270, 29);
            this.newroomnamelabel.TabIndex = 1;
            this.newroomnamelabel.Text = "Name of the New Room";
            // 
            // NewRoomBtn
            // 
            this.NewRoomBtn.Location = new System.Drawing.Point(289, 412);
            this.NewRoomBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NewRoomBtn.Name = "NewRoomBtn";
            this.NewRoomBtn.Size = new System.Drawing.Size(639, 76);
            this.NewRoomBtn.TabIndex = 2;
            this.NewRoomBtn.Text = "Add New Room";
            this.NewRoomBtn.UseVisualStyleBackColor = true;
            this.NewRoomBtn.Click += new System.EventHandler(this.NewRoomBtn_Click);
            // 
            // NewRoomNameTBox
            // 
            this.NewRoomNameTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewRoomNameTBox.Location = new System.Drawing.Point(487, 177);
            this.NewRoomNameTBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NewRoomNameTBox.Name = "NewRoomNameTBox";
            this.NewRoomNameTBox.Size = new System.Drawing.Size(636, 37);
            this.NewRoomNameTBox.TabIndex = 0;
            // 
            // EditCurrentRoomsTab
            // 
            this.EditCurrentRoomsTab.Controls.Add(this.selectroomname);
            this.EditCurrentRoomsTab.Controls.Add(this.selectregionlbl);
            this.EditCurrentRoomsTab.Controls.Add(this.EditRoomNameSelector);
            this.EditCurrentRoomsTab.Controls.Add(this.EditRoomRegionSelector);
            this.EditCurrentRoomsTab.Controls.Add(this.editcurroomreglbl);
            this.EditCurrentRoomsTab.Controls.Add(this.EditRoomRegion);
            this.EditCurrentRoomsTab.Controls.Add(this.editcurroomstrlbl);
            this.EditCurrentRoomsTab.Controls.Add(this.EditRoomStory);
            this.EditCurrentRoomsTab.Controls.Add(this.editroomnamelbl);
            this.EditCurrentRoomsTab.Controls.Add(this.EditRoomName);
            this.EditCurrentRoomsTab.Controls.Add(this.SaveRoomEdit);
            this.EditCurrentRoomsTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditCurrentRoomsTab.Location = new System.Drawing.Point(4, 29);
            this.EditCurrentRoomsTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EditCurrentRoomsTab.Name = "EditCurrentRoomsTab";
            this.EditCurrentRoomsTab.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EditCurrentRoomsTab.Size = new System.Drawing.Size(1336, 831);
            this.EditCurrentRoomsTab.TabIndex = 1;
            this.EditCurrentRoomsTab.Text = "Edit Current Rooms";
            this.EditCurrentRoomsTab.UseVisualStyleBackColor = true;
            // 
            // selectroomname
            // 
            this.selectroomname.AutoSize = true;
            this.selectroomname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectroomname.Location = new System.Drawing.Point(687, 378);
            this.selectroomname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.selectroomname.Name = "selectroomname";
            this.selectroomname.Size = new System.Drawing.Size(152, 29);
            this.selectroomname.TabIndex = 16;
            this.selectroomname.Text = "Select Room";
            // 
            // selectregionlbl
            // 
            this.selectregionlbl.AutoSize = true;
            this.selectregionlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectregionlbl.Location = new System.Drawing.Point(21, 378);
            this.selectregionlbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.selectregionlbl.Name = "selectregionlbl";
            this.selectregionlbl.Size = new System.Drawing.Size(165, 29);
            this.selectregionlbl.TabIndex = 15;
            this.selectregionlbl.Text = "Select Region";
            // 
            // EditRoomNameSelector
            // 
            this.EditRoomNameSelector.FormattingEnabled = true;
            this.EditRoomNameSelector.ItemHeight = 24;
            this.EditRoomNameSelector.Location = new System.Drawing.Point(692, 418);
            this.EditRoomNameSelector.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EditRoomNameSelector.Name = "EditRoomNameSelector";
            this.EditRoomNameSelector.Size = new System.Drawing.Size(607, 364);
            this.EditRoomNameSelector.TabIndex = 14;
            this.EditRoomNameSelector.SelectedIndexChanged += new System.EventHandler(this.PresetEditRoomData);
            // 
            // EditRoomRegionSelector
            // 
            this.EditRoomRegionSelector.FormattingEnabled = true;
            this.EditRoomRegionSelector.ItemHeight = 24;
            this.EditRoomRegionSelector.Location = new System.Drawing.Point(27, 418);
            this.EditRoomRegionSelector.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EditRoomRegionSelector.Name = "EditRoomRegionSelector";
            this.EditRoomRegionSelector.Size = new System.Drawing.Size(607, 364);
            this.EditRoomRegionSelector.TabIndex = 13;
            this.EditRoomRegionSelector.SelectedIndexChanged += new System.EventHandler(this.UpdateRoomNames);
            // 
            // editcurroomreglbl
            // 
            this.editcurroomreglbl.AutoSize = true;
            this.editcurroomreglbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editcurroomreglbl.Location = new System.Drawing.Point(132, 187);
            this.editcurroomreglbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.editcurroomreglbl.Name = "editcurroomreglbl";
            this.editcurroomreglbl.Size = new System.Drawing.Size(295, 29);
            this.editcurroomreglbl.TabIndex = 12;
            this.editcurroomreglbl.Text = "Edit Current Room Region";
            // 
            // EditRoomRegion
            // 
            this.EditRoomRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EditRoomRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditRoomRegion.FormattingEnabled = true;
            this.EditRoomRegion.Location = new System.Drawing.Point(448, 182);
            this.EditRoomRegion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EditRoomRegion.Name = "EditRoomRegion";
            this.EditRoomRegion.Size = new System.Drawing.Size(636, 38);
            this.EditRoomRegion.TabIndex = 11;
            // 
            // editcurroomstrlbl
            // 
            this.editcurroomstrlbl.AutoSize = true;
            this.editcurroomstrlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editcurroomstrlbl.Location = new System.Drawing.Point(157, 113);
            this.editcurroomstrlbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.editcurroomstrlbl.Name = "editcurroomstrlbl";
            this.editcurroomstrlbl.Size = new System.Drawing.Size(272, 29);
            this.editcurroomstrlbl.TabIndex = 10;
            this.editcurroomstrlbl.Text = "Edit Current Room Story";
            // 
            // EditRoomStory
            // 
            this.EditRoomStory.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditRoomStory.Location = new System.Drawing.Point(448, 108);
            this.EditRoomStory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EditRoomStory.Name = "EditRoomStory";
            this.EditRoomStory.Size = new System.Drawing.Size(636, 37);
            this.EditRoomStory.TabIndex = 9;
            // 
            // editroomnamelbl
            // 
            this.editroomnamelbl.AutoSize = true;
            this.editroomnamelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editroomnamelbl.Location = new System.Drawing.Point(177, 33);
            this.editroomnamelbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.editroomnamelbl.Name = "editroomnamelbl";
            this.editroomnamelbl.Size = new System.Drawing.Size(211, 29);
            this.editroomnamelbl.TabIndex = 8;
            this.editroomnamelbl.Text = "Edit Current Room";
            // 
            // EditRoomName
            // 
            this.EditRoomName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditRoomName.Location = new System.Drawing.Point(448, 28);
            this.EditRoomName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EditRoomName.Name = "EditRoomName";
            this.EditRoomName.Size = new System.Drawing.Size(636, 37);
            this.EditRoomName.TabIndex = 7;
            // 
            // SaveRoomEdit
            // 
            this.SaveRoomEdit.Location = new System.Drawing.Point(348, 252);
            this.SaveRoomEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaveRoomEdit.Name = "SaveRoomEdit";
            this.SaveRoomEdit.Size = new System.Drawing.Size(639, 76);
            this.SaveRoomEdit.TabIndex = 5;
            this.SaveRoomEdit.Text = "Save Room Edit";
            this.SaveRoomEdit.UseVisualStyleBackColor = true;
            this.SaveRoomEdit.Click += new System.EventHandler(this.SaveRoomEdit_Click);
            // 
            // CommandsTab
            // 
            this.CommandsTab.Controls.Add(this.AddCommandsTab);
            this.CommandsTab.Controls.Add(this.EditCommandsTab);
            this.CommandsTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommandsTab.Location = new System.Drawing.Point(0, 33);
            this.CommandsTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CommandsTab.Name = "CommandsTab";
            this.CommandsTab.SelectedIndex = 0;
            this.CommandsTab.Size = new System.Drawing.Size(1344, 864);
            this.CommandsTab.TabIndex = 4;
            this.CommandsTab.Visible = false;
            this.CommandsTab.SelectedIndexChanged += new System.EventHandler(this.UpdateListOfCommands);
            // 
            // AddCommandsTab
            // 
            this.AddCommandsTab.Controls.Add(this.CommandVerbLabel);
            this.AddCommandsTab.Controls.Add(this.AddNewCommand);
            this.AddCommandsTab.Controls.Add(this.NewCommandVerbText);
            this.AddCommandsTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddCommandsTab.Location = new System.Drawing.Point(4, 29);
            this.AddCommandsTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddCommandsTab.Name = "AddCommandsTab";
            this.AddCommandsTab.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddCommandsTab.Size = new System.Drawing.Size(1336, 831);
            this.AddCommandsTab.TabIndex = 0;
            this.AddCommandsTab.Text = "Add Commands";
            this.AddCommandsTab.UseVisualStyleBackColor = true;
            // 
            // CommandVerbLabel
            // 
            this.CommandVerbLabel.AutoSize = true;
            this.CommandVerbLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommandVerbLabel.Location = new System.Drawing.Point(116, 254);
            this.CommandVerbLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CommandVerbLabel.Name = "CommandVerbLabel";
            this.CommandVerbLabel.Size = new System.Drawing.Size(255, 39);
            this.CommandVerbLabel.TabIndex = 1;
            this.CommandVerbLabel.Text = "Command Verb";
            // 
            // AddNewCommand
            // 
            this.AddNewCommand.Location = new System.Drawing.Point(233, 336);
            this.AddNewCommand.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddNewCommand.Name = "AddNewCommand";
            this.AddNewCommand.Size = new System.Drawing.Size(639, 76);
            this.AddNewCommand.TabIndex = 2;
            this.AddNewCommand.Text = "Add New Command";
            this.AddNewCommand.UseVisualStyleBackColor = true;
            this.AddNewCommand.Click += new System.EventHandler(this.AddNewCommand_Click);
            // 
            // NewCommandVerbText
            // 
            this.NewCommandVerbText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewCommandVerbText.Location = new System.Drawing.Point(487, 250);
            this.NewCommandVerbText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NewCommandVerbText.Name = "NewCommandVerbText";
            this.NewCommandVerbText.Size = new System.Drawing.Size(636, 46);
            this.NewCommandVerbText.TabIndex = 0;
            // 
            // EditCommandsTab
            // 
            this.EditCommandsTab.Controls.Add(this.EditCommandVerbLabel);
            this.EditCommandsTab.Controls.Add(this.EditCommandVerbBtn);
            this.EditCommandsTab.Controls.Add(this.EditCommandVerbText);
            this.EditCommandsTab.Controls.Add(this.EditCommandVerbList);
            this.EditCommandsTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditCommandsTab.Location = new System.Drawing.Point(4, 29);
            this.EditCommandsTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EditCommandsTab.Name = "EditCommandsTab";
            this.EditCommandsTab.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EditCommandsTab.Size = new System.Drawing.Size(1336, 831);
            this.EditCommandsTab.TabIndex = 1;
            this.EditCommandsTab.Text = "Edit Current Commands";
            this.EditCommandsTab.UseVisualStyleBackColor = true;
            // 
            // EditCommandVerbLabel
            // 
            this.EditCommandVerbLabel.AutoSize = true;
            this.EditCommandVerbLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditCommandVerbLabel.Location = new System.Drawing.Point(125, 47);
            this.EditCommandVerbLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EditCommandVerbLabel.Name = "EditCommandVerbLabel";
            this.EditCommandVerbLabel.Size = new System.Drawing.Size(323, 39);
            this.EditCommandVerbLabel.TabIndex = 4;
            this.EditCommandVerbLabel.Text = "Edit Command Verb";
            // 
            // EditCommandVerbBtn
            // 
            this.EditCommandVerbBtn.Location = new System.Drawing.Point(289, 129);
            this.EditCommandVerbBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EditCommandVerbBtn.Name = "EditCommandVerbBtn";
            this.EditCommandVerbBtn.Size = new System.Drawing.Size(639, 76);
            this.EditCommandVerbBtn.TabIndex = 5;
            this.EditCommandVerbBtn.Text = "Save Command Edit";
            this.EditCommandVerbBtn.UseVisualStyleBackColor = true;
            this.EditCommandVerbBtn.Click += new System.EventHandler(this.EditCommandVerbBtn_Click);
            // 
            // EditCommandVerbText
            // 
            this.EditCommandVerbText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditCommandVerbText.Location = new System.Drawing.Point(503, 43);
            this.EditCommandVerbText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EditCommandVerbText.Name = "EditCommandVerbText";
            this.EditCommandVerbText.Size = new System.Drawing.Size(636, 46);
            this.EditCommandVerbText.TabIndex = 3;
            // 
            // EditCommandVerbList
            // 
            this.EditCommandVerbList.FormattingEnabled = true;
            this.EditCommandVerbList.ItemHeight = 29;
            this.EditCommandVerbList.Location = new System.Drawing.Point(11, 247);
            this.EditCommandVerbList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EditCommandVerbList.MultiColumn = true;
            this.EditCommandVerbList.Name = "EditCommandVerbList";
            this.EditCommandVerbList.Size = new System.Drawing.Size(1311, 555);
            this.EditCommandVerbList.TabIndex = 0;
            this.EditCommandVerbList.SelectedIndexChanged += new System.EventHandler(this.EditCommandVerbList_SelectedIndexChanged);
            // 
            // SealsOfHellMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1344, 897);
            this.Controls.Add(this.CommandsTab);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.RegionTabs);
            this.Controls.Add(this.RoomTabs);
            this.MainMenuStrip = this.MainMenu;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MaximumSize = new System.Drawing.Size(1914, 1318);
            this.MinimumSize = new System.Drawing.Size(1359, 934);
            this.Name = "SealsOfHellMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seals Of Hell Data Editor";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.RegionTabs.ResumeLayout(false);
            this.AddRegionTab.ResumeLayout(false);
            this.AddRegionTab.PerformLayout();
            this.EditRegionsTab.ResumeLayout(false);
            this.EditRegionsTab.PerformLayout();
            this.RoomTabs.ResumeLayout(false);
            this.AddRoomTab.ResumeLayout(false);
            this.AddRoomTab.PerformLayout();
            this.EditCurrentRoomsTab.ResumeLayout(false);
            this.EditCurrentRoomsTab.PerformLayout();
            this.CommandsTab.ResumeLayout(false);
            this.AddCommandsTab.ResumeLayout(false);
            this.AddCommandsTab.PerformLayout();
            this.EditCommandsTab.ResumeLayout(false);
            this.EditCommandsTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ChooseFile;
        private System.Windows.Forms.SaveFileDialog SaveFile;
        private System.Windows.Forms.ToolStripMenuItem regionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomToolStripMenuItem;
        private System.Windows.Forms.Button AddRegionButton;
        private System.Windows.Forms.Label AddRegionLabel;
        private System.Windows.Forms.TextBox AddRegionTextBox;
        private System.Windows.Forms.TabControl RegionTabs;
        private System.Windows.Forms.TabPage AddRegionTab;
        private System.Windows.Forms.TabPage EditRegionsTab;
        private System.Windows.Forms.ListBox EditRegionsList;
        private System.Windows.Forms.Label editregionlabel;
        private System.Windows.Forms.Button EditRegion;
        private System.Windows.Forms.TextBox EditCurrentRegionTextBox;
        private System.Windows.Forms.Label StoryNewRegion;
        private System.Windows.Forms.TextBox RegionStoryTextBox;
        private System.Windows.Forms.Label EditRegionStoryLabel;
        private System.Windows.Forms.TextBox EditRegionStoryTBox;
        private System.Windows.Forms.TabControl RoomTabs;
        private System.Windows.Forms.TabPage AddRoomTab;
        private System.Windows.Forms.Label storynewroomlbl;
        private System.Windows.Forms.TextBox NewRoomStory;
        private System.Windows.Forms.Label newroomnamelabel;
        private System.Windows.Forms.Button NewRoomBtn;
        private System.Windows.Forms.TextBox NewRoomNameTBox;
        private System.Windows.Forms.TabPage EditCurrentRoomsTab;
        private System.Windows.Forms.Button SaveRoomEdit;
        private System.Windows.Forms.Label NewRoomRegionSelLabel;
        private System.Windows.Forms.ComboBox NewRoomRegionSelector;
        private System.Windows.Forms.Label editcurroomreglbl;
        private System.Windows.Forms.ComboBox EditRoomRegion;
        private System.Windows.Forms.Label editcurroomstrlbl;
        private System.Windows.Forms.TextBox EditRoomStory;
        private System.Windows.Forms.Label editroomnamelbl;
        private System.Windows.Forms.TextBox EditRoomName;
        private System.Windows.Forms.Label selectroomname;
        private System.Windows.Forms.Label selectregionlbl;
        private System.Windows.Forms.ListBox EditRoomNameSelector;
        private System.Windows.Forms.ListBox EditRoomRegionSelector;
        private System.Windows.Forms.ToolStripMenuItem commandsToolStripMenuItem;
        private System.Windows.Forms.TabControl CommandsTab;
        private System.Windows.Forms.TabPage AddCommandsTab;
        private System.Windows.Forms.Label CommandVerbLabel;
        private System.Windows.Forms.Button AddNewCommand;
        private System.Windows.Forms.TextBox NewCommandVerbText;
        private System.Windows.Forms.TabPage EditCommandsTab;
        private System.Windows.Forms.Label EditCommandVerbLabel;
        private System.Windows.Forms.Button EditCommandVerbBtn;
        private System.Windows.Forms.TextBox EditCommandVerbText;
        private System.Windows.Forms.ListBox EditCommandVerbList;
    }
}

