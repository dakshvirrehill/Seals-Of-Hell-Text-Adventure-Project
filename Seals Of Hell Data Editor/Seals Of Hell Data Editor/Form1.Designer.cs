﻿namespace Seals_Of_Hell_Data_Editor
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
            this.editGameDetails = new System.Windows.Forms.Button();
            this.gameStoryTextBox = new System.Windows.Forms.RichTextBox();
            this.gameStoryLabel = new System.Windows.Forms.Label();
            this.gameNameTextBox = new System.Windows.Forms.TextBox();
            this.gameNameLabel = new System.Windows.Forms.Label();
            this.firstRegionTab = new System.Windows.Forms.TabPage();
            this.editFirstRegionDetails = new System.Windows.Forms.Button();
            this.firstRegionStoryTextBox = new System.Windows.Forms.RichTextBox();
            this.firstRegionStoryLabel = new System.Windows.Forms.Label();
            this.firstRegionNameTextBox = new System.Windows.Forms.TextBox();
            this.regionNameLabel = new System.Windows.Forms.Label();
            this.firstRoomTab = new System.Windows.Forms.TabPage();
            this.firstRoomPickableItemLabel = new System.Windows.Forms.Label();
            this.firstRoomOneInteractionItemsLabel = new System.Windows.Forms.Label();
            this.firstRoomKillZoneLabel = new System.Windows.Forms.Label();
            this.firstRoomEnemyLabel = new System.Windows.Forms.Label();
            this.firstRoomCollectorListLabel = new System.Windows.Forms.Label();
            this.editFirstRoomDetails = new System.Windows.Forms.Button();
            this.firstRoomStoryTextBox = new System.Windows.Forms.RichTextBox();
            this.firstRoomStoryLabel = new System.Windows.Forms.Label();
            this.firstRoomNameTextBox = new System.Windows.Forms.TextBox();
            this.firstRoomNameLabel = new System.Windows.Forms.Label();
            this.firstRoomCollectorList = new System.Windows.Forms.ListBox();
            this.firstRoomEnemyList = new System.Windows.Forms.ListBox();
            this.firstRoomKillZoneList = new System.Windows.Forms.ListBox();
            this.firstRoomOIIList = new System.Windows.Forms.ListBox();
            this.firstRoomPIList = new System.Windows.Forms.ListBox();
            this.treasureCollectorTab = new System.Windows.Forms.TabPage();
            this.editTreasureCollectorDetails = new System.Windows.Forms.Button();
            this.TrCollectorStoryTextBox = new System.Windows.Forms.RichTextBox();
            this.treasuerCollectorStoryLabel = new System.Windows.Forms.Label();
            this.TrCollectorNameTextBox = new System.Windows.Forms.TextBox();
            this.treasureCollectorNameLabel = new System.Windows.Forms.Label();
            this.treasureList = new System.Windows.Forms.ListBox();
            this.treasureListLabel = new System.Windows.Forms.Label();
            this.updatableList = new System.Windows.Forms.ListBox();
            this.updatableListLabel = new System.Windows.Forms.Label();
            this.TrCollectorAllOutputTextBox = new System.Windows.Forms.RichTextBox();
            this.treasureCollectorAfterAllStoryLabel = new System.Windows.Forms.Label();
            this.TrCollectorWinStoryTextBox = new System.Windows.Forms.RichTextBox();
            this.winStoryLabel = new System.Windows.Forms.Label();
            this.visibleTrCol = new System.Windows.Forms.CheckBox();
            this.interactableTrCol = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.gameStartTabControl.SuspendLayout();
            this.gameDetailsTab.SuspendLayout();
            this.firstRegionTab.SuspendLayout();
            this.firstRoomTab.SuspendLayout();
            this.treasureCollectorTab.SuspendLayout();
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
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
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
            this.gameStartTabControl.Controls.Add(this.firstRegionTab);
            this.gameStartTabControl.Controls.Add(this.firstRoomTab);
            this.gameStartTabControl.Controls.Add(this.treasureCollectorTab);
            this.gameStartTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameStartTabControl.Location = new System.Drawing.Point(0, 27);
            this.gameStartTabControl.Name = "gameStartTabControl";
            this.gameStartTabControl.SelectedIndex = 0;
            this.gameStartTabControl.Size = new System.Drawing.Size(1008, 703);
            this.gameStartTabControl.TabIndex = 1;
            this.gameStartTabControl.SelectedIndexChanged += new System.EventHandler(this.SetAllGameStartData);
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
            // editGameDetails
            // 
            this.editGameDetails.Location = new System.Drawing.Point(325, 471);
            this.editGameDetails.Name = "editGameDetails";
            this.editGameDetails.Size = new System.Drawing.Size(538, 77);
            this.editGameDetails.TabIndex = 4;
            this.editGameDetails.Text = "Edit Game Details";
            this.editGameDetails.UseVisualStyleBackColor = true;
            this.editGameDetails.Click += new System.EventHandler(this.EditGameDetails_Click);
            // 
            // gameStoryTextBox
            // 
            this.gameStoryTextBox.Location = new System.Drawing.Point(325, 154);
            this.gameStoryTextBox.Name = "gameStoryTextBox";
            this.gameStoryTextBox.Size = new System.Drawing.Size(538, 275);
            this.gameStoryTextBox.TabIndex = 3;
            this.gameStoryTextBox.Text = "";
            // 
            // gameStoryLabel
            // 
            this.gameStoryLabel.AutoSize = true;
            this.gameStoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameStoryLabel.Location = new System.Drawing.Point(73, 154);
            this.gameStoryLabel.Name = "gameStoryLabel";
            this.gameStoryLabel.Size = new System.Drawing.Size(228, 20);
            this.gameStoryLabel.TabIndex = 2;
            this.gameStoryLabel.Text = "Current Story Of The Game";
            // 
            // gameNameTextBox
            // 
            this.gameNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameNameTextBox.Location = new System.Drawing.Point(325, 102);
            this.gameNameTextBox.Name = "gameNameTextBox";
            this.gameNameTextBox.Size = new System.Drawing.Size(538, 26);
            this.gameNameTextBox.TabIndex = 1;
            // 
            // gameNameLabel
            // 
            this.gameNameLabel.AutoSize = true;
            this.gameNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameNameLabel.Location = new System.Drawing.Point(73, 105);
            this.gameNameLabel.Name = "gameNameLabel";
            this.gameNameLabel.Size = new System.Drawing.Size(232, 20);
            this.gameNameLabel.TabIndex = 0;
            this.gameNameLabel.Text = "Current Name Of The Game";
            // 
            // firstRegionTab
            // 
            this.firstRegionTab.Controls.Add(this.editFirstRegionDetails);
            this.firstRegionTab.Controls.Add(this.firstRegionStoryTextBox);
            this.firstRegionTab.Controls.Add(this.firstRegionStoryLabel);
            this.firstRegionTab.Controls.Add(this.firstRegionNameTextBox);
            this.firstRegionTab.Controls.Add(this.regionNameLabel);
            this.firstRegionTab.Location = new System.Drawing.Point(4, 29);
            this.firstRegionTab.Name = "firstRegionTab";
            this.firstRegionTab.Padding = new System.Windows.Forms.Padding(3);
            this.firstRegionTab.Size = new System.Drawing.Size(1000, 670);
            this.firstRegionTab.TabIndex = 1;
            this.firstRegionTab.Text = "First Region Details";
            this.firstRegionTab.UseVisualStyleBackColor = true;
            // 
            // editFirstRegionDetails
            // 
            this.editFirstRegionDetails.Location = new System.Drawing.Point(353, 486);
            this.editFirstRegionDetails.Name = "editFirstRegionDetails";
            this.editFirstRegionDetails.Size = new System.Drawing.Size(538, 77);
            this.editFirstRegionDetails.TabIndex = 9;
            this.editFirstRegionDetails.Text = "Edit First Region Details";
            this.editFirstRegionDetails.UseVisualStyleBackColor = true;
            this.editFirstRegionDetails.Click += new System.EventHandler(this.EditFirstRegionDetails_Click);
            // 
            // firstRegionStoryTextBox
            // 
            this.firstRegionStoryTextBox.Location = new System.Drawing.Point(353, 169);
            this.firstRegionStoryTextBox.Name = "firstRegionStoryTextBox";
            this.firstRegionStoryTextBox.Size = new System.Drawing.Size(538, 275);
            this.firstRegionStoryTextBox.TabIndex = 8;
            this.firstRegionStoryTextBox.Text = "";
            // 
            // firstRegionStoryLabel
            // 
            this.firstRegionStoryLabel.AutoSize = true;
            this.firstRegionStoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstRegionStoryLabel.Location = new System.Drawing.Point(51, 169);
            this.firstRegionStoryLabel.Name = "firstRegionStoryLabel";
            this.firstRegionStoryLabel.Size = new System.Drawing.Size(278, 20);
            this.firstRegionStoryLabel.TabIndex = 7;
            this.firstRegionStoryLabel.Text = "Current Story Of The First Region";
            // 
            // firstRegionNameTextBox
            // 
            this.firstRegionNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstRegionNameTextBox.Location = new System.Drawing.Point(353, 117);
            this.firstRegionNameTextBox.Name = "firstRegionNameTextBox";
            this.firstRegionNameTextBox.Size = new System.Drawing.Size(538, 26);
            this.firstRegionNameTextBox.TabIndex = 6;
            // 
            // regionNameLabel
            // 
            this.regionNameLabel.AutoSize = true;
            this.regionNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regionNameLabel.Location = new System.Drawing.Point(47, 120);
            this.regionNameLabel.Name = "regionNameLabel";
            this.regionNameLabel.Size = new System.Drawing.Size(282, 20);
            this.regionNameLabel.TabIndex = 5;
            this.regionNameLabel.Text = "Current Name Of The First Region";
            // 
            // firstRoomTab
            // 
            this.firstRoomTab.Controls.Add(this.firstRoomPIList);
            this.firstRoomTab.Controls.Add(this.firstRoomOIIList);
            this.firstRoomTab.Controls.Add(this.firstRoomKillZoneList);
            this.firstRoomTab.Controls.Add(this.firstRoomEnemyList);
            this.firstRoomTab.Controls.Add(this.firstRoomCollectorList);
            this.firstRoomTab.Controls.Add(this.firstRoomPickableItemLabel);
            this.firstRoomTab.Controls.Add(this.firstRoomOneInteractionItemsLabel);
            this.firstRoomTab.Controls.Add(this.firstRoomKillZoneLabel);
            this.firstRoomTab.Controls.Add(this.firstRoomEnemyLabel);
            this.firstRoomTab.Controls.Add(this.firstRoomCollectorListLabel);
            this.firstRoomTab.Controls.Add(this.editFirstRoomDetails);
            this.firstRoomTab.Controls.Add(this.firstRoomStoryTextBox);
            this.firstRoomTab.Controls.Add(this.firstRoomStoryLabel);
            this.firstRoomTab.Controls.Add(this.firstRoomNameTextBox);
            this.firstRoomTab.Controls.Add(this.firstRoomNameLabel);
            this.firstRoomTab.Location = new System.Drawing.Point(4, 29);
            this.firstRoomTab.Name = "firstRoomTab";
            this.firstRoomTab.Padding = new System.Windows.Forms.Padding(3);
            this.firstRoomTab.Size = new System.Drawing.Size(1000, 670);
            this.firstRoomTab.TabIndex = 2;
            this.firstRoomTab.Text = "First Room Details";
            this.firstRoomTab.UseVisualStyleBackColor = true;
            // 
            // firstRoomPickableItemLabel
            // 
            this.firstRoomPickableItemLabel.AutoSize = true;
            this.firstRoomPickableItemLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstRoomPickableItemLabel.Location = new System.Drawing.Point(829, 214);
            this.firstRoomPickableItemLabel.Name = "firstRoomPickableItemLabel";
            this.firstRoomPickableItemLabel.Size = new System.Drawing.Size(126, 20);
            this.firstRoomPickableItemLabel.TabIndex = 19;
            this.firstRoomPickableItemLabel.Text = "Pickable Items";
            // 
            // firstRoomOneInteractionItemsLabel
            // 
            this.firstRoomOneInteractionItemsLabel.AutoSize = true;
            this.firstRoomOneInteractionItemsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstRoomOneInteractionItemsLabel.Location = new System.Drawing.Point(602, 214);
            this.firstRoomOneInteractionItemsLabel.Name = "firstRoomOneInteractionItemsLabel";
            this.firstRoomOneInteractionItemsLabel.Size = new System.Drawing.Size(184, 20);
            this.firstRoomOneInteractionItemsLabel.TabIndex = 18;
            this.firstRoomOneInteractionItemsLabel.Text = "One Interaction Items";
            // 
            // firstRoomKillZoneLabel
            // 
            this.firstRoomKillZoneLabel.AutoSize = true;
            this.firstRoomKillZoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstRoomKillZoneLabel.Location = new System.Drawing.Point(453, 214);
            this.firstRoomKillZoneLabel.Name = "firstRoomKillZoneLabel";
            this.firstRoomKillZoneLabel.Size = new System.Drawing.Size(87, 20);
            this.firstRoomKillZoneLabel.TabIndex = 17;
            this.firstRoomKillZoneLabel.Text = "Kill Zones";
            // 
            // firstRoomEnemyLabel
            // 
            this.firstRoomEnemyLabel.AutoSize = true;
            this.firstRoomEnemyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstRoomEnemyLabel.Location = new System.Drawing.Point(263, 214);
            this.firstRoomEnemyLabel.Name = "firstRoomEnemyLabel";
            this.firstRoomEnemyLabel.Size = new System.Drawing.Size(78, 20);
            this.firstRoomEnemyLabel.TabIndex = 16;
            this.firstRoomEnemyLabel.Text = "Enemies";
            // 
            // firstRoomCollectorListLabel
            // 
            this.firstRoomCollectorListLabel.AutoSize = true;
            this.firstRoomCollectorListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstRoomCollectorListLabel.Location = new System.Drawing.Point(64, 214);
            this.firstRoomCollectorListLabel.Name = "firstRoomCollectorListLabel";
            this.firstRoomCollectorListLabel.Size = new System.Drawing.Size(89, 20);
            this.firstRoomCollectorListLabel.TabIndex = 15;
            this.firstRoomCollectorListLabel.Text = "Collectors";
            // 
            // editFirstRoomDetails
            // 
            this.editFirstRoomDetails.Location = new System.Drawing.Point(211, 584);
            this.editFirstRoomDetails.Name = "editFirstRoomDetails";
            this.editFirstRoomDetails.Size = new System.Drawing.Size(538, 77);
            this.editFirstRoomDetails.TabIndex = 14;
            this.editFirstRoomDetails.Text = "Edit First Room Details";
            this.editFirstRoomDetails.UseVisualStyleBackColor = true;
            this.editFirstRoomDetails.Click += new System.EventHandler(this.EditFirstRoomDetails_Click);
            // 
            // firstRoomStoryTextBox
            // 
            this.firstRoomStoryTextBox.Location = new System.Drawing.Point(383, 70);
            this.firstRoomStoryTextBox.Name = "firstRoomStoryTextBox";
            this.firstRoomStoryTextBox.Size = new System.Drawing.Size(538, 134);
            this.firstRoomStoryTextBox.TabIndex = 13;
            this.firstRoomStoryTextBox.Text = "";
            // 
            // firstRoomStoryLabel
            // 
            this.firstRoomStoryLabel.AutoSize = true;
            this.firstRoomStoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstRoomStoryLabel.Location = new System.Drawing.Point(81, 70);
            this.firstRoomStoryLabel.Name = "firstRoomStoryLabel";
            this.firstRoomStoryLabel.Size = new System.Drawing.Size(268, 20);
            this.firstRoomStoryLabel.TabIndex = 12;
            this.firstRoomStoryLabel.Text = "Current Story Of The First Room";
            // 
            // firstRoomNameTextBox
            // 
            this.firstRoomNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstRoomNameTextBox.Location = new System.Drawing.Point(383, 18);
            this.firstRoomNameTextBox.Name = "firstRoomNameTextBox";
            this.firstRoomNameTextBox.Size = new System.Drawing.Size(538, 26);
            this.firstRoomNameTextBox.TabIndex = 11;
            // 
            // firstRoomNameLabel
            // 
            this.firstRoomNameLabel.AutoSize = true;
            this.firstRoomNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstRoomNameLabel.Location = new System.Drawing.Point(77, 21);
            this.firstRoomNameLabel.Name = "firstRoomNameLabel";
            this.firstRoomNameLabel.Size = new System.Drawing.Size(272, 20);
            this.firstRoomNameLabel.TabIndex = 10;
            this.firstRoomNameLabel.Text = "Current Name Of The First Room";
            // 
            // firstRoomCollectorList
            // 
            this.firstRoomCollectorList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstRoomCollectorList.FormattingEnabled = true;
            this.firstRoomCollectorList.ItemHeight = 16;
            this.firstRoomCollectorList.Location = new System.Drawing.Point(23, 237);
            this.firstRoomCollectorList.Name = "firstRoomCollectorList";
            this.firstRoomCollectorList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.firstRoomCollectorList.Size = new System.Drawing.Size(176, 324);
            this.firstRoomCollectorList.TabIndex = 20;
            // 
            // firstRoomEnemyList
            // 
            this.firstRoomEnemyList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstRoomEnemyList.FormattingEnabled = true;
            this.firstRoomEnemyList.ItemHeight = 16;
            this.firstRoomEnemyList.Location = new System.Drawing.Point(217, 237);
            this.firstRoomEnemyList.Name = "firstRoomEnemyList";
            this.firstRoomEnemyList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.firstRoomEnemyList.Size = new System.Drawing.Size(176, 324);
            this.firstRoomEnemyList.TabIndex = 21;
            // 
            // firstRoomKillZoneList
            // 
            this.firstRoomKillZoneList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstRoomKillZoneList.FormattingEnabled = true;
            this.firstRoomKillZoneList.ItemHeight = 16;
            this.firstRoomKillZoneList.Location = new System.Drawing.Point(414, 237);
            this.firstRoomKillZoneList.Name = "firstRoomKillZoneList";
            this.firstRoomKillZoneList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.firstRoomKillZoneList.Size = new System.Drawing.Size(176, 324);
            this.firstRoomKillZoneList.TabIndex = 22;
            // 
            // firstRoomOIIList
            // 
            this.firstRoomOIIList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstRoomOIIList.FormattingEnabled = true;
            this.firstRoomOIIList.ItemHeight = 16;
            this.firstRoomOIIList.Location = new System.Drawing.Point(606, 237);
            this.firstRoomOIIList.Name = "firstRoomOIIList";
            this.firstRoomOIIList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.firstRoomOIIList.Size = new System.Drawing.Size(176, 324);
            this.firstRoomOIIList.TabIndex = 23;
            // 
            // firstRoomPIList
            // 
            this.firstRoomPIList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstRoomPIList.FormattingEnabled = true;
            this.firstRoomPIList.ItemHeight = 16;
            this.firstRoomPIList.Location = new System.Drawing.Point(801, 237);
            this.firstRoomPIList.Name = "firstRoomPIList";
            this.firstRoomPIList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.firstRoomPIList.Size = new System.Drawing.Size(176, 324);
            this.firstRoomPIList.TabIndex = 24;
            // 
            // treasureCollectorTab
            // 
            this.treasureCollectorTab.Controls.Add(this.interactableTrCol);
            this.treasureCollectorTab.Controls.Add(this.visibleTrCol);
            this.treasureCollectorTab.Controls.Add(this.TrCollectorWinStoryTextBox);
            this.treasureCollectorTab.Controls.Add(this.winStoryLabel);
            this.treasureCollectorTab.Controls.Add(this.TrCollectorAllOutputTextBox);
            this.treasureCollectorTab.Controls.Add(this.treasureCollectorAfterAllStoryLabel);
            this.treasureCollectorTab.Controls.Add(this.updatableList);
            this.treasureCollectorTab.Controls.Add(this.updatableListLabel);
            this.treasureCollectorTab.Controls.Add(this.treasureList);
            this.treasureCollectorTab.Controls.Add(this.treasureListLabel);
            this.treasureCollectorTab.Controls.Add(this.editTreasureCollectorDetails);
            this.treasureCollectorTab.Controls.Add(this.TrCollectorStoryTextBox);
            this.treasureCollectorTab.Controls.Add(this.treasuerCollectorStoryLabel);
            this.treasureCollectorTab.Controls.Add(this.TrCollectorNameTextBox);
            this.treasureCollectorTab.Controls.Add(this.treasureCollectorNameLabel);
            this.treasureCollectorTab.Location = new System.Drawing.Point(4, 29);
            this.treasureCollectorTab.Name = "treasureCollectorTab";
            this.treasureCollectorTab.Padding = new System.Windows.Forms.Padding(3);
            this.treasureCollectorTab.Size = new System.Drawing.Size(1000, 670);
            this.treasureCollectorTab.TabIndex = 3;
            this.treasureCollectorTab.Text = "Treasure Collector Details";
            this.treasureCollectorTab.UseVisualStyleBackColor = true;
            // 
            // editTreasureCollectorDetails
            // 
            this.editTreasureCollectorDetails.Location = new System.Drawing.Point(620, 560);
            this.editTreasureCollectorDetails.Name = "editTreasureCollectorDetails";
            this.editTreasureCollectorDetails.Size = new System.Drawing.Size(337, 77);
            this.editTreasureCollectorDetails.TabIndex = 19;
            this.editTreasureCollectorDetails.Text = "Edit Treasure Collector Details";
            this.editTreasureCollectorDetails.UseVisualStyleBackColor = true;
            // 
            // TrCollectorStoryTextBox
            // 
            this.TrCollectorStoryTextBox.Location = new System.Drawing.Point(384, 58);
            this.TrCollectorStoryTextBox.Name = "TrCollectorStoryTextBox";
            this.TrCollectorStoryTextBox.Size = new System.Drawing.Size(538, 54);
            this.TrCollectorStoryTextBox.TabIndex = 18;
            this.TrCollectorStoryTextBox.Text = "";
            // 
            // treasuerCollectorStoryLabel
            // 
            this.treasuerCollectorStoryLabel.AutoSize = true;
            this.treasuerCollectorStoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treasuerCollectorStoryLabel.Location = new System.Drawing.Point(31, 81);
            this.treasuerCollectorStoryLabel.Name = "treasuerCollectorStoryLabel";
            this.treasuerCollectorStoryLabel.Size = new System.Drawing.Size(327, 20);
            this.treasuerCollectorStoryLabel.TabIndex = 17;
            this.treasuerCollectorStoryLabel.Text = "Current Story Of The Treasure Collector";
            // 
            // TrCollectorNameTextBox
            // 
            this.TrCollectorNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrCollectorNameTextBox.Location = new System.Drawing.Point(384, 14);
            this.TrCollectorNameTextBox.Name = "TrCollectorNameTextBox";
            this.TrCollectorNameTextBox.Size = new System.Drawing.Size(538, 26);
            this.TrCollectorNameTextBox.TabIndex = 16;
            // 
            // treasureCollectorNameLabel
            // 
            this.treasureCollectorNameLabel.AutoSize = true;
            this.treasureCollectorNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treasureCollectorNameLabel.Location = new System.Drawing.Point(27, 20);
            this.treasureCollectorNameLabel.Name = "treasureCollectorNameLabel";
            this.treasureCollectorNameLabel.Size = new System.Drawing.Size(331, 20);
            this.treasureCollectorNameLabel.TabIndex = 15;
            this.treasureCollectorNameLabel.Text = "Current Name Of The Treasure Collector";
            // 
            // treasureList
            // 
            this.treasureList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treasureList.FormattingEnabled = true;
            this.treasureList.ItemHeight = 16;
            this.treasureList.Location = new System.Drawing.Point(6, 292);
            this.treasureList.Name = "treasureList";
            this.treasureList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.treasureList.Size = new System.Drawing.Size(176, 356);
            this.treasureList.TabIndex = 26;
            // 
            // treasureListLabel
            // 
            this.treasureListLabel.AutoSize = true;
            this.treasureListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treasureListLabel.Location = new System.Drawing.Point(8, 269);
            this.treasureListLabel.Name = "treasureListLabel";
            this.treasureListLabel.Size = new System.Drawing.Size(161, 20);
            this.treasureListLabel.TabIndex = 25;
            this.treasureListLabel.Text = "Treasure Pickables";
            // 
            // updatableList
            // 
            this.updatableList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updatableList.FormattingEnabled = true;
            this.updatableList.ItemHeight = 16;
            this.updatableList.Location = new System.Drawing.Point(197, 292);
            this.updatableList.Name = "updatableList";
            this.updatableList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.updatableList.Size = new System.Drawing.Size(176, 356);
            this.updatableList.TabIndex = 28;
            // 
            // updatableListLabel
            // 
            this.updatableListLabel.AutoSize = true;
            this.updatableListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updatableListLabel.Location = new System.Drawing.Point(224, 269);
            this.updatableListLabel.Name = "updatableListLabel";
            this.updatableListLabel.Size = new System.Drawing.Size(101, 20);
            this.updatableListLabel.TabIndex = 27;
            this.updatableListLabel.Text = "Updatables";
            // 
            // TrCollectorAllOutputTextBox
            // 
            this.TrCollectorAllOutputTextBox.Location = new System.Drawing.Point(384, 129);
            this.TrCollectorAllOutputTextBox.Name = "TrCollectorAllOutputTextBox";
            this.TrCollectorAllOutputTextBox.Size = new System.Drawing.Size(538, 54);
            this.TrCollectorAllOutputTextBox.TabIndex = 30;
            this.TrCollectorAllOutputTextBox.Text = "";
            // 
            // treasureCollectorAfterAllStoryLabel
            // 
            this.treasureCollectorAfterAllStoryLabel.AutoSize = true;
            this.treasureCollectorAfterAllStoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treasureCollectorAfterAllStoryLabel.Location = new System.Drawing.Point(31, 154);
            this.treasureCollectorAfterAllStoryLabel.Name = "treasureCollectorAfterAllStoryLabel";
            this.treasureCollectorAfterAllStoryLabel.Size = new System.Drawing.Size(320, 20);
            this.treasureCollectorAfterAllStoryLabel.TabIndex = 29;
            this.treasureCollectorAfterAllStoryLabel.Text = "Current After All Output Of Tr Collector";
            // 
            // TrCollectorWinStoryTextBox
            // 
            this.TrCollectorWinStoryTextBox.Location = new System.Drawing.Point(384, 199);
            this.TrCollectorWinStoryTextBox.Name = "TrCollectorWinStoryTextBox";
            this.TrCollectorWinStoryTextBox.Size = new System.Drawing.Size(538, 54);
            this.TrCollectorWinStoryTextBox.TabIndex = 32;
            this.TrCollectorWinStoryTextBox.Text = "";
            // 
            // winStoryLabel
            // 
            this.winStoryLabel.AutoSize = true;
            this.winStoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winStoryLabel.Location = new System.Drawing.Point(78, 217);
            this.winStoryLabel.Name = "winStoryLabel";
            this.winStoryLabel.Size = new System.Drawing.Size(272, 20);
            this.winStoryLabel.TabIndex = 31;
            this.winStoryLabel.Text = "Current Win Story Of Tr Collector";
            // 
            // visibleTrCol
            // 
            this.visibleTrCol.AutoSize = true;
            this.visibleTrCol.Location = new System.Drawing.Point(454, 560);
            this.visibleTrCol.Name = "visibleTrCol";
            this.visibleTrCol.Size = new System.Drawing.Size(101, 24);
            this.visibleTrCol.TabIndex = 33;
            this.visibleTrCol.Text = "Is Visible";
            this.visibleTrCol.UseVisualStyleBackColor = true;
            // 
            // interactableTrCol
            // 
            this.interactableTrCol.AutoSize = true;
            this.interactableTrCol.Location = new System.Drawing.Point(454, 613);
            this.interactableTrCol.Name = "interactableTrCol";
            this.interactableTrCol.Size = new System.Drawing.Size(145, 24);
            this.interactableTrCol.TabIndex = 34;
            this.interactableTrCol.Text = "Is Interactable";
            this.interactableTrCol.UseVisualStyleBackColor = true;
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
            this.firstRegionTab.ResumeLayout(false);
            this.firstRegionTab.PerformLayout();
            this.firstRoomTab.ResumeLayout(false);
            this.firstRoomTab.PerformLayout();
            this.treasureCollectorTab.ResumeLayout(false);
            this.treasureCollectorTab.PerformLayout();
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
        private System.Windows.Forms.TabPage firstRegionTab;
        private System.Windows.Forms.Label gameStoryLabel;
        private System.Windows.Forms.TextBox gameNameTextBox;
        private System.Windows.Forms.Label gameNameLabel;
        private System.Windows.Forms.Button editGameDetails;
        private System.Windows.Forms.RichTextBox gameStoryTextBox;
        private System.Windows.Forms.Button editFirstRegionDetails;
        private System.Windows.Forms.RichTextBox firstRegionStoryTextBox;
        private System.Windows.Forms.Label firstRegionStoryLabel;
        private System.Windows.Forms.TextBox firstRegionNameTextBox;
        private System.Windows.Forms.Label regionNameLabel;
        private System.Windows.Forms.TabPage firstRoomTab;
        private System.Windows.Forms.Label firstRoomPickableItemLabel;
        private System.Windows.Forms.Label firstRoomOneInteractionItemsLabel;
        private System.Windows.Forms.Label firstRoomKillZoneLabel;
        private System.Windows.Forms.Label firstRoomEnemyLabel;
        private System.Windows.Forms.Label firstRoomCollectorListLabel;
        private System.Windows.Forms.Button editFirstRoomDetails;
        private System.Windows.Forms.RichTextBox firstRoomStoryTextBox;
        private System.Windows.Forms.Label firstRoomStoryLabel;
        private System.Windows.Forms.TextBox firstRoomNameTextBox;
        private System.Windows.Forms.Label firstRoomNameLabel;
        private System.Windows.Forms.ListBox firstRoomPIList;
        private System.Windows.Forms.ListBox firstRoomOIIList;
        private System.Windows.Forms.ListBox firstRoomKillZoneList;
        private System.Windows.Forms.ListBox firstRoomEnemyList;
        private System.Windows.Forms.ListBox firstRoomCollectorList;
        private System.Windows.Forms.TabPage treasureCollectorTab;
        private System.Windows.Forms.CheckBox interactableTrCol;
        private System.Windows.Forms.CheckBox visibleTrCol;
        private System.Windows.Forms.RichTextBox TrCollectorWinStoryTextBox;
        private System.Windows.Forms.Label winStoryLabel;
        private System.Windows.Forms.RichTextBox TrCollectorAllOutputTextBox;
        private System.Windows.Forms.Label treasureCollectorAfterAllStoryLabel;
        private System.Windows.Forms.ListBox updatableList;
        private System.Windows.Forms.Label updatableListLabel;
        private System.Windows.Forms.ListBox treasureList;
        private System.Windows.Forms.Label treasureListLabel;
        private System.Windows.Forms.Button editTreasureCollectorDetails;
        private System.Windows.Forms.RichTextBox TrCollectorStoryTextBox;
        private System.Windows.Forms.Label treasuerCollectorStoryLabel;
        private System.Windows.Forms.TextBox TrCollectorNameTextBox;
        private System.Windows.Forms.Label treasureCollectorNameLabel;
    }
}

