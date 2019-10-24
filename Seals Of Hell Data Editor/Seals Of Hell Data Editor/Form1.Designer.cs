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
            this.gameDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameDetailsTab = new System.Windows.Forms.TabPage();
            this.gameNameText = new System.Windows.Forms.TextBox();
            this.ChangeGameDetails = new System.Windows.Forms.Button();
            this.gamenamelabel = new System.Windows.Forms.Label();
            this.gameStoryText = new System.Windows.Forms.TextBox();
            this.gamestorylabel = new System.Windows.Forms.Label();
            this.gameDetailsGroup = new System.Windows.Forms.TabControl();
            this.IsEntryRegion = new System.Windows.Forms.CheckBox();
            this.EditIsEntryRegion = new System.Windows.Forms.CheckBox();
            this.MainMenu.SuspendLayout();
            this.RegionTabs.SuspendLayout();
            this.AddRegionTab.SuspendLayout();
            this.EditRegionsTab.SuspendLayout();
            this.RoomTabs.SuspendLayout();
            this.AddRoomTab.SuspendLayout();
            this.EditCurrentRoomsTab.SuspendLayout();
            this.gameDetailsTab.SuspendLayout();
            this.gameDetailsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.SystemColors.Control;
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.gameDetailsToolStripMenuItem,
            this.regionToolStripMenuItem,
            this.roomToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1008, 24);
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
            // regionToolStripMenuItem
            // 
            this.regionToolStripMenuItem.Name = "regionToolStripMenuItem";
            this.regionToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.regionToolStripMenuItem.Text = "Region";
            this.regionToolStripMenuItem.Click += new System.EventHandler(this.RegionToolStripMenuItem_Click);
            // 
            // roomToolStripMenuItem
            // 
            this.roomToolStripMenuItem.Name = "roomToolStripMenuItem";
            this.roomToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.roomToolStripMenuItem.Text = "Room";
            this.roomToolStripMenuItem.Click += new System.EventHandler(this.RoomToolStripMenuItem_Click);
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
            this.AddRegionTextBox.Location = new System.Drawing.Point(438, 183);
            this.AddRegionTextBox.Name = "AddRegionTextBox";
            this.AddRegionTextBox.Size = new System.Drawing.Size(478, 38);
            this.AddRegionTextBox.TabIndex = 0;
            // 
            // AddRegionLabel
            // 
            this.AddRegionLabel.AutoSize = true;
            this.AddRegionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddRegionLabel.Location = new System.Drawing.Point(43, 186);
            this.AddRegionLabel.Name = "AddRegionLabel";
            this.AddRegionLabel.Size = new System.Drawing.Size(316, 31);
            this.AddRegionLabel.TabIndex = 1;
            this.AddRegionLabel.Text = "Name of the New Region";
            // 
            // AddRegionButton
            // 
            this.AddRegionButton.Location = new System.Drawing.Point(438, 324);
            this.AddRegionButton.Name = "AddRegionButton";
            this.AddRegionButton.Size = new System.Drawing.Size(479, 62);
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
            this.RegionTabs.Location = new System.Drawing.Point(0, 27);
            this.RegionTabs.Name = "RegionTabs";
            this.RegionTabs.SelectedIndex = 0;
            this.RegionTabs.Size = new System.Drawing.Size(1008, 702);
            this.RegionTabs.TabIndex = 2;
            this.RegionTabs.Visible = false;
            this.RegionTabs.SelectedIndexChanged += new System.EventHandler(this.ResetEditableRegionsList);
            // 
            // AddRegionTab
            // 
            this.AddRegionTab.Controls.Add(this.IsEntryRegion);
            this.AddRegionTab.Controls.Add(this.StoryNewRegion);
            this.AddRegionTab.Controls.Add(this.RegionStoryTextBox);
            this.AddRegionTab.Controls.Add(this.AddRegionLabel);
            this.AddRegionTab.Controls.Add(this.AddRegionButton);
            this.AddRegionTab.Controls.Add(this.AddRegionTextBox);
            this.AddRegionTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddRegionTab.Location = new System.Drawing.Point(4, 25);
            this.AddRegionTab.Name = "AddRegionTab";
            this.AddRegionTab.Padding = new System.Windows.Forms.Padding(3);
            this.AddRegionTab.Size = new System.Drawing.Size(1000, 673);
            this.AddRegionTab.TabIndex = 0;
            this.AddRegionTab.Text = "Add New Region";
            this.AddRegionTab.UseVisualStyleBackColor = true;
            // 
            // StoryNewRegion
            // 
            this.StoryNewRegion.AutoSize = true;
            this.StoryNewRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StoryNewRegion.Location = new System.Drawing.Point(43, 263);
            this.StoryNewRegion.Name = "StoryNewRegion";
            this.StoryNewRegion.Size = new System.Drawing.Size(323, 31);
            this.StoryNewRegion.TabIndex = 4;
            this.StoryNewRegion.Text = "Story Of The New Region";
            // 
            // RegionStoryTextBox
            // 
            this.RegionStoryTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegionStoryTextBox.Location = new System.Drawing.Point(438, 260);
            this.RegionStoryTextBox.Name = "RegionStoryTextBox";
            this.RegionStoryTextBox.Size = new System.Drawing.Size(478, 38);
            this.RegionStoryTextBox.TabIndex = 3;
            // 
            // EditRegionsTab
            // 
            this.EditRegionsTab.Controls.Add(this.EditIsEntryRegion);
            this.EditRegionsTab.Controls.Add(this.EditRegionStoryLabel);
            this.EditRegionsTab.Controls.Add(this.EditRegionStoryTBox);
            this.EditRegionsTab.Controls.Add(this.editregionlabel);
            this.EditRegionsTab.Controls.Add(this.EditRegion);
            this.EditRegionsTab.Controls.Add(this.EditCurrentRegionTextBox);
            this.EditRegionsTab.Controls.Add(this.EditRegionsList);
            this.EditRegionsTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditRegionsTab.Location = new System.Drawing.Point(4, 25);
            this.EditRegionsTab.Name = "EditRegionsTab";
            this.EditRegionsTab.Padding = new System.Windows.Forms.Padding(3);
            this.EditRegionsTab.Size = new System.Drawing.Size(1000, 673);
            this.EditRegionsTab.TabIndex = 1;
            this.EditRegionsTab.Text = "Edit Current Regions";
            this.EditRegionsTab.UseVisualStyleBackColor = true;
            // 
            // EditRegionStoryLabel
            // 
            this.EditRegionStoryLabel.AutoSize = true;
            this.EditRegionStoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditRegionStoryLabel.Location = new System.Drawing.Point(42, 96);
            this.EditRegionStoryLabel.Name = "EditRegionStoryLabel";
            this.EditRegionStoryLabel.Size = new System.Drawing.Size(382, 31);
            this.EditRegionStoryLabel.TabIndex = 7;
            this.EditRegionStoryLabel.Text = "New Story Of Selected Region";
            // 
            // EditRegionStoryTBox
            // 
            this.EditRegionStoryTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditRegionStoryTBox.Location = new System.Drawing.Point(437, 93);
            this.EditRegionStoryTBox.Name = "EditRegionStoryTBox";
            this.EditRegionStoryTBox.Size = new System.Drawing.Size(478, 38);
            this.EditRegionStoryTBox.TabIndex = 6;
            // 
            // editregionlabel
            // 
            this.editregionlabel.AutoSize = true;
            this.editregionlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editregionlabel.Location = new System.Drawing.Point(32, 38);
            this.editregionlabel.Name = "editregionlabel";
            this.editregionlabel.Size = new System.Drawing.Size(390, 31);
            this.editregionlabel.TabIndex = 4;
            this.editregionlabel.Text = "New Name Of Selected Region";
            // 
            // EditRegion
            // 
            this.EditRegion.Location = new System.Drawing.Point(437, 163);
            this.EditRegion.Name = "EditRegion";
            this.EditRegion.Size = new System.Drawing.Size(479, 62);
            this.EditRegion.TabIndex = 5;
            this.EditRegion.Text = "Save Region Edit";
            this.EditRegion.UseVisualStyleBackColor = true;
            this.EditRegion.Click += new System.EventHandler(this.EditRegion_Click);
            // 
            // EditCurrentRegionTextBox
            // 
            this.EditCurrentRegionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditCurrentRegionTextBox.Location = new System.Drawing.Point(437, 35);
            this.EditCurrentRegionTextBox.Name = "EditCurrentRegionTextBox";
            this.EditCurrentRegionTextBox.Size = new System.Drawing.Size(478, 38);
            this.EditCurrentRegionTextBox.TabIndex = 3;
            // 
            // EditRegionsList
            // 
            this.EditRegionsList.FormattingEnabled = true;
            this.EditRegionsList.ItemHeight = 24;
            this.EditRegionsList.Location = new System.Drawing.Point(10, 245);
            this.EditRegionsList.MultiColumn = true;
            this.EditRegionsList.Name = "EditRegionsList";
            this.EditRegionsList.Size = new System.Drawing.Size(984, 412);
            this.EditRegionsList.TabIndex = 0;
            this.EditRegionsList.SelectedIndexChanged += new System.EventHandler(this.SetEditRegionTextBox);
            // 
            // RoomTabs
            // 
            this.RoomTabs.Controls.Add(this.AddRoomTab);
            this.RoomTabs.Controls.Add(this.EditCurrentRoomsTab);
            this.RoomTabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoomTabs.Location = new System.Drawing.Point(0, 27);
            this.RoomTabs.Name = "RoomTabs";
            this.RoomTabs.SelectedIndex = 0;
            this.RoomTabs.Size = new System.Drawing.Size(1008, 702);
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
            this.AddRoomTab.Location = new System.Drawing.Point(4, 25);
            this.AddRoomTab.Name = "AddRoomTab";
            this.AddRoomTab.Padding = new System.Windows.Forms.Padding(3);
            this.AddRoomTab.Size = new System.Drawing.Size(1000, 673);
            this.AddRoomTab.TabIndex = 0;
            this.AddRoomTab.Text = "Add New Room";
            this.AddRoomTab.UseVisualStyleBackColor = true;
            // 
            // NewRoomRegionSelLabel
            // 
            this.NewRoomRegionSelLabel.AutoSize = true;
            this.NewRoomRegionSelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewRoomRegionSelLabel.Location = new System.Drawing.Point(137, 273);
            this.NewRoomRegionSelLabel.Name = "NewRoomRegionSelLabel";
            this.NewRoomRegionSelLabel.Size = new System.Drawing.Size(222, 24);
            this.NewRoomRegionSelLabel.TabIndex = 6;
            this.NewRoomRegionSelLabel.Text = "Region of the New Room";
            // 
            // NewRoomRegionSelector
            // 
            this.NewRoomRegionSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NewRoomRegionSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewRoomRegionSelector.FormattingEnabled = true;
            this.NewRoomRegionSelector.Location = new System.Drawing.Point(365, 269);
            this.NewRoomRegionSelector.Name = "NewRoomRegionSelector";
            this.NewRoomRegionSelector.Size = new System.Drawing.Size(478, 33);
            this.NewRoomRegionSelector.TabIndex = 5;
            // 
            // storynewroomlbl
            // 
            this.storynewroomlbl.AutoSize = true;
            this.storynewroomlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storynewroomlbl.Location = new System.Drawing.Point(147, 213);
            this.storynewroomlbl.Name = "storynewroomlbl";
            this.storynewroomlbl.Size = new System.Drawing.Size(203, 24);
            this.storynewroomlbl.TabIndex = 4;
            this.storynewroomlbl.Text = "Story of the New Room";
            // 
            // NewRoomStory
            // 
            this.NewRoomStory.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewRoomStory.Location = new System.Drawing.Point(365, 209);
            this.NewRoomStory.Name = "NewRoomStory";
            this.NewRoomStory.Size = new System.Drawing.Size(478, 31);
            this.NewRoomStory.TabIndex = 3;
            // 
            // newroomnamelabel
            // 
            this.newroomnamelabel.AutoSize = true;
            this.newroomnamelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newroomnamelabel.Location = new System.Drawing.Point(147, 148);
            this.newroomnamelabel.Name = "newroomnamelabel";
            this.newroomnamelabel.Size = new System.Drawing.Size(212, 24);
            this.newroomnamelabel.TabIndex = 1;
            this.newroomnamelabel.Text = "Name of the New Room";
            // 
            // NewRoomBtn
            // 
            this.NewRoomBtn.Location = new System.Drawing.Point(217, 335);
            this.NewRoomBtn.Name = "NewRoomBtn";
            this.NewRoomBtn.Size = new System.Drawing.Size(479, 62);
            this.NewRoomBtn.TabIndex = 2;
            this.NewRoomBtn.Text = "Add New Room";
            this.NewRoomBtn.UseVisualStyleBackColor = true;
            this.NewRoomBtn.Click += new System.EventHandler(this.NewRoomBtn_Click);
            // 
            // NewRoomNameTBox
            // 
            this.NewRoomNameTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewRoomNameTBox.Location = new System.Drawing.Point(365, 144);
            this.NewRoomNameTBox.Name = "NewRoomNameTBox";
            this.NewRoomNameTBox.Size = new System.Drawing.Size(478, 31);
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
            this.EditCurrentRoomsTab.Location = new System.Drawing.Point(4, 25);
            this.EditCurrentRoomsTab.Name = "EditCurrentRoomsTab";
            this.EditCurrentRoomsTab.Padding = new System.Windows.Forms.Padding(3);
            this.EditCurrentRoomsTab.Size = new System.Drawing.Size(1000, 673);
            this.EditCurrentRoomsTab.TabIndex = 1;
            this.EditCurrentRoomsTab.Text = "Edit Current Rooms";
            this.EditCurrentRoomsTab.UseVisualStyleBackColor = true;
            // 
            // selectroomname
            // 
            this.selectroomname.AutoSize = true;
            this.selectroomname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectroomname.Location = new System.Drawing.Point(515, 307);
            this.selectroomname.Name = "selectroomname";
            this.selectroomname.Size = new System.Drawing.Size(118, 24);
            this.selectroomname.TabIndex = 16;
            this.selectroomname.Text = "Select Room";
            // 
            // selectregionlbl
            // 
            this.selectregionlbl.AutoSize = true;
            this.selectregionlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectregionlbl.Location = new System.Drawing.Point(16, 307);
            this.selectregionlbl.Name = "selectregionlbl";
            this.selectregionlbl.Size = new System.Drawing.Size(128, 24);
            this.selectregionlbl.TabIndex = 15;
            this.selectregionlbl.Text = "Select Region";
            // 
            // EditRoomNameSelector
            // 
            this.EditRoomNameSelector.FormattingEnabled = true;
            this.EditRoomNameSelector.ItemHeight = 18;
            this.EditRoomNameSelector.Location = new System.Drawing.Point(519, 340);
            this.EditRoomNameSelector.Name = "EditRoomNameSelector";
            this.EditRoomNameSelector.Size = new System.Drawing.Size(456, 292);
            this.EditRoomNameSelector.TabIndex = 14;
            this.EditRoomNameSelector.SelectedIndexChanged += new System.EventHandler(this.PresetEditRoomData);
            // 
            // EditRoomRegionSelector
            // 
            this.EditRoomRegionSelector.FormattingEnabled = true;
            this.EditRoomRegionSelector.ItemHeight = 18;
            this.EditRoomRegionSelector.Location = new System.Drawing.Point(20, 340);
            this.EditRoomRegionSelector.Name = "EditRoomRegionSelector";
            this.EditRoomRegionSelector.Size = new System.Drawing.Size(456, 292);
            this.EditRoomRegionSelector.TabIndex = 13;
            this.EditRoomRegionSelector.SelectedIndexChanged += new System.EventHandler(this.UpdateRoomNames);
            // 
            // editcurroomreglbl
            // 
            this.editcurroomreglbl.AutoSize = true;
            this.editcurroomreglbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editcurroomreglbl.Location = new System.Drawing.Point(99, 152);
            this.editcurroomreglbl.Name = "editcurroomreglbl";
            this.editcurroomreglbl.Size = new System.Drawing.Size(231, 24);
            this.editcurroomreglbl.TabIndex = 12;
            this.editcurroomreglbl.Text = "Edit Current Room Region";
            // 
            // EditRoomRegion
            // 
            this.EditRoomRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EditRoomRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditRoomRegion.FormattingEnabled = true;
            this.EditRoomRegion.Location = new System.Drawing.Point(336, 148);
            this.EditRoomRegion.Name = "EditRoomRegion";
            this.EditRoomRegion.Size = new System.Drawing.Size(478, 33);
            this.EditRoomRegion.TabIndex = 11;
            // 
            // editcurroomstrlbl
            // 
            this.editcurroomstrlbl.AutoSize = true;
            this.editcurroomstrlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editcurroomstrlbl.Location = new System.Drawing.Point(118, 92);
            this.editcurroomstrlbl.Name = "editcurroomstrlbl";
            this.editcurroomstrlbl.Size = new System.Drawing.Size(212, 24);
            this.editcurroomstrlbl.TabIndex = 10;
            this.editcurroomstrlbl.Text = "Edit Current Room Story";
            // 
            // EditRoomStory
            // 
            this.EditRoomStory.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditRoomStory.Location = new System.Drawing.Point(336, 88);
            this.EditRoomStory.Name = "EditRoomStory";
            this.EditRoomStory.Size = new System.Drawing.Size(478, 31);
            this.EditRoomStory.TabIndex = 9;
            // 
            // editroomnamelbl
            // 
            this.editroomnamelbl.AutoSize = true;
            this.editroomnamelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editroomnamelbl.Location = new System.Drawing.Point(133, 27);
            this.editroomnamelbl.Name = "editroomnamelbl";
            this.editroomnamelbl.Size = new System.Drawing.Size(165, 24);
            this.editroomnamelbl.TabIndex = 8;
            this.editroomnamelbl.Text = "Edit Current Room";
            // 
            // EditRoomName
            // 
            this.EditRoomName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditRoomName.Location = new System.Drawing.Point(336, 23);
            this.EditRoomName.Name = "EditRoomName";
            this.EditRoomName.Size = new System.Drawing.Size(478, 31);
            this.EditRoomName.TabIndex = 7;
            // 
            // SaveRoomEdit
            // 
            this.SaveRoomEdit.Location = new System.Drawing.Point(261, 205);
            this.SaveRoomEdit.Name = "SaveRoomEdit";
            this.SaveRoomEdit.Size = new System.Drawing.Size(479, 62);
            this.SaveRoomEdit.TabIndex = 5;
            this.SaveRoomEdit.Text = "Save Room Edit";
            this.SaveRoomEdit.UseVisualStyleBackColor = true;
            this.SaveRoomEdit.Click += new System.EventHandler(this.SaveRoomEdit_Click);
            // 
            // gameDetailsToolStripMenuItem
            // 
            this.gameDetailsToolStripMenuItem.Name = "gameDetailsToolStripMenuItem";
            this.gameDetailsToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.gameDetailsToolStripMenuItem.Text = "Game Details";
            this.gameDetailsToolStripMenuItem.Click += new System.EventHandler(this.GameDetailsToolStripMenuItem_Click);
            // 
            // gameDetailsTab
            // 
            this.gameDetailsTab.Controls.Add(this.gamestorylabel);
            this.gameDetailsTab.Controls.Add(this.gameStoryText);
            this.gameDetailsTab.Controls.Add(this.gameNameText);
            this.gameDetailsTab.Controls.Add(this.gamenamelabel);
            this.gameDetailsTab.Controls.Add(this.ChangeGameDetails);
            this.gameDetailsTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameDetailsTab.Location = new System.Drawing.Point(4, 25);
            this.gameDetailsTab.Name = "gameDetailsTab";
            this.gameDetailsTab.Padding = new System.Windows.Forms.Padding(3);
            this.gameDetailsTab.Size = new System.Drawing.Size(1000, 673);
            this.gameDetailsTab.TabIndex = 0;
            this.gameDetailsTab.Text = "Change Game Details";
            this.gameDetailsTab.UseVisualStyleBackColor = true;
            // 
            // gameNameText
            // 
            this.gameNameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameNameText.Location = new System.Drawing.Point(396, 117);
            this.gameNameText.Name = "gameNameText";
            this.gameNameText.Size = new System.Drawing.Size(478, 38);
            this.gameNameText.TabIndex = 0;
            // 
            // ChangeGameDetails
            // 
            this.ChangeGameDetails.Location = new System.Drawing.Point(248, 308);
            this.ChangeGameDetails.Name = "ChangeGameDetails";
            this.ChangeGameDetails.Size = new System.Drawing.Size(479, 62);
            this.ChangeGameDetails.TabIndex = 2;
            this.ChangeGameDetails.Text = "Change Game Details";
            this.ChangeGameDetails.UseVisualStyleBackColor = true;
            this.ChangeGameDetails.Click += new System.EventHandler(this.ChangeGameDetails_Click);
            // 
            // gamenamelabel
            // 
            this.gamenamelabel.AutoSize = true;
            this.gamenamelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gamenamelabel.Location = new System.Drawing.Point(118, 117);
            this.gamenamelabel.Name = "gamenamelabel";
            this.gamenamelabel.Size = new System.Drawing.Size(241, 31);
            this.gamenamelabel.TabIndex = 1;
            this.gamenamelabel.Text = "Name of the Game";
            // 
            // gameStoryText
            // 
            this.gameStoryText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameStoryText.Location = new System.Drawing.Point(396, 194);
            this.gameStoryText.Name = "gameStoryText";
            this.gameStoryText.Size = new System.Drawing.Size(478, 38);
            this.gameStoryText.TabIndex = 3;
            // 
            // gamestorylabel
            // 
            this.gamestorylabel.AutoSize = true;
            this.gamestorylabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gamestorylabel.Location = new System.Drawing.Point(118, 194);
            this.gamestorylabel.Name = "gamestorylabel";
            this.gamestorylabel.Size = new System.Drawing.Size(233, 31);
            this.gamestorylabel.TabIndex = 4;
            this.gamestorylabel.Text = "Story of the Game";
            // 
            // gameDetailsGroup
            // 
            this.gameDetailsGroup.Controls.Add(this.gameDetailsTab);
            this.gameDetailsGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameDetailsGroup.Location = new System.Drawing.Point(0, 27);
            this.gameDetailsGroup.Name = "gameDetailsGroup";
            this.gameDetailsGroup.SelectedIndex = 0;
            this.gameDetailsGroup.Size = new System.Drawing.Size(1008, 702);
            this.gameDetailsGroup.TabIndex = 4;
            this.gameDetailsGroup.Visible = false;
            // 
            // IsEntryRegion
            // 
            this.IsEntryRegion.AutoSize = true;
            this.IsEntryRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsEntryRegion.Location = new System.Drawing.Point(125, 335);
            this.IsEntryRegion.Name = "IsEntryRegion";
            this.IsEntryRegion.Size = new System.Drawing.Size(234, 35);
            this.IsEntryRegion.TabIndex = 6;
            this.IsEntryRegion.Text = "Is Entry Region?";
            this.IsEntryRegion.UseVisualStyleBackColor = true;
            // 
            // EditIsEntryRegion
            // 
            this.EditIsEntryRegion.AutoSize = true;
            this.EditIsEntryRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditIsEntryRegion.Location = new System.Drawing.Point(125, 175);
            this.EditIsEntryRegion.Name = "EditIsEntryRegion";
            this.EditIsEntryRegion.Size = new System.Drawing.Size(234, 35);
            this.EditIsEntryRegion.TabIndex = 8;
            this.EditIsEntryRegion.Text = "Is Entry Region?";
            this.EditIsEntryRegion.UseVisualStyleBackColor = true;
            // 
            // SealsOfHellMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.RegionTabs);
            this.Controls.Add(this.gameDetailsGroup);
            this.Controls.Add(this.RoomTabs);
            this.MainMenuStrip = this.MainMenu;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximumSize = new System.Drawing.Size(1440, 1078);
            this.MinimumSize = new System.Drawing.Size(1023, 766);
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
            this.gameDetailsTab.ResumeLayout(false);
            this.gameDetailsTab.PerformLayout();
            this.gameDetailsGroup.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem gameDetailsToolStripMenuItem;
        private System.Windows.Forms.TabPage gameDetailsTab;
        private System.Windows.Forms.Label gamestorylabel;
        private System.Windows.Forms.TextBox gameStoryText;
        private System.Windows.Forms.TextBox gameNameText;
        private System.Windows.Forms.Label gamenamelabel;
        private System.Windows.Forms.Button ChangeGameDetails;
        private System.Windows.Forms.TabControl gameDetailsGroup;
        private System.Windows.Forms.CheckBox IsEntryRegion;
        private System.Windows.Forms.CheckBox EditIsEntryRegion;
    }
}

