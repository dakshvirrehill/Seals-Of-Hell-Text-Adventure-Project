using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seals_Of_Hell_Data_Editor
{
    public partial class SealsOfHellMain : Form
    {
        DataHandler mGameDetails;
        Region mSelectedRegion;
        Room mSelectedRoom;
        Collector mSelectedCollector;
        Enemy mSelectedEnemy;
        KillZone mSelectedKillZone;
        OneInteractionItem mSelectedOIItem;
        PickableItem mSelectedPickable;
        Portal mSelectedPortal;
        Gateway mSelectedGateway;
        public SealsOfHellMain()
        {
            mGameDetails = new DataHandler();
            InitializeComponent();
            this.Text = mGameDetails.mName;
            CleanUpAtEditorChange();
        }

        void CleanUpAtEditorChange()
        {
            mSelectedRegion = null;
            mSelectedRoom = null;
            mSelectedCollector = null;
            mSelectedEnemy = null;
            mSelectedKillZone = null;
            mSelectedOIItem = null;
            mSelectedPickable = null;
            mSelectedPortal = null;
            mSelectedGateway = null;
            this.gameStartTabControl.Visible = 
            this.interactableDetailsTabControl.Visible = 
            this.regionTabControl.Visible =
            this.roomTabControl.Visible = false;
        }

        #region Main Menu
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openGameJSONData.ShowDialog();
        }
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(mGameDetails.IsDataValid())
            {
                saveGameJSONData.ShowDialog();
            }
            else
            {
                MessageBox.Show(mGameDetails.GetErrorMessage(), "Data Not Valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void EditGameStartDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CleanUpAtEditorChange();
            this.gameStartTabControl.Visible = true;
            this.gameStartTabControl.SelectedIndex = 0;
            GameStartTabControl_SelectedIndexChanged(null, null);
        }
        private void AddNewRegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CleanUpAtEditorChange();
            this.regionTabControl.Visible = true;
            this.regionTabControl.SelectedIndex = 0;
            RegionTabControl_SelectedIndexChanged(null, null);
        }
        private void EditRoomDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CleanUpAtEditorChange();
            this.roomTabControl.Visible = true;
            this.roomTabControl.SelectedIndex = 0;
            RoomTabControl_SelectedIndexChanged(null, null);
        }
        private void EditInteractablesDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CleanUpAtEditorChange();
            this.interactableDetailsTabControl.Visible = true;
            this.interactableDetailsTabControl.SelectedIndex = 0;
            InteractableDetailsTabControl_SelectedIndexChanged(null, null);
        }
        #endregion
        #region Game Start Data
        private void GameStartTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            mSelectedRegion = mGameDetails.mRegionDetails[mGameDetails.mFirstRegion];
            mSelectedRoom = mSelectedRegion.mRooms[mSelectedRegion.mEntryRoom];
            if(this.gameStartTabControl.SelectedTab == this.gameDetailsTab)
            {
                this.gameNameTextBox.Text = mGameDetails.mName;
                this.gameStoryTextBox.Text = mGameDetails.mStory;
            }
            else if(this.gameStartTabControl.SelectedTab == this.firstRegionTab)
            {
                this.firstRegionNameTextBox.Text = mGameDetails.mFirstRegion;
                this.firstRegionStoryTextBox.Text = mSelectedRegion.mStory;
            }
            else if(this.gameStartTabControl.SelectedTab == this.firstRoomTab)
            {
                this.firstRoomNameTextBox.Text = mSelectedRegion.mEntryRoom;
                this.firstRoomStoryTextBox.Text = mSelectedRoom.mStory;
                List<string> aAllCollectorNames = mGameDetails.GetCollectorNames();
                RemoveAssigned(ObjectType.Collector, aAllCollectorNames);
                List<string> aRCNames = new List<string>(mSelectedRoom.mCollectors.Keys);
                aAllCollectorNames.AddRange(aRCNames);
                SetListBoxListAndSelection(this.firstRoomCollectorList, aAllCollectorNames, aRCNames);
                List<string> aAllEnemyNames = mGameDetails.GetEnemyNames();
                RemoveAssigned(ObjectType.Enemy, aAllEnemyNames);
                List<string> aRENames = new List<string>(mSelectedRoom.mEnemies.Keys);
                aAllEnemyNames.AddRange(aRENames);
                SetListBoxListAndSelection(this.firstRoomEnemyList, aAllEnemyNames, aRENames);
                List<string> aAllKillZoneNames = mGameDetails.GetKillZoneNames();
                RemoveAssigned(ObjectType.KillZone, aAllKillZoneNames);
                List<string> aRKZNames = new List<string>(mSelectedRoom.mKillZones.Keys);
                aAllKillZoneNames.AddRange(aRKZNames);
                SetListBoxListAndSelection(this.firstRoomKillZoneList, aAllKillZoneNames, aRKZNames);
                List<string> aAllOIItemNames = mGameDetails.GetOIItemNames();
                RemoveAssigned(ObjectType.OneInteractionItem, aAllOIItemNames);
                List<string> aROIINames = new List<string>(mSelectedRoom.mOneInteractionItems.Keys);
                aAllOIItemNames.AddRange(aROIINames);
                SetListBoxListAndSelection(this.firstRoomOIIList, aAllOIItemNames, aROIINames);
                List<string> aAllPickableNames = mGameDetails.GetPickableItemNames();
                RemoveAssigned(ObjectType.PickableItem, aAllPickableNames);
                List<string> aRPNames = new List<string>(mSelectedRoom.mPickableItems.Keys);
                aAllPickableNames.AddRange(aRPNames);
                SetListBoxListAndSelection(this.firstRoomPIList, aAllPickableNames, aRPNames);
            }
            else if(this.gameStartTabControl.SelectedTab == this.treasureCollectorTab)
            {
                ResetTreasureCollector();
            }
        }
        private void EditGameDetails_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.gameNameTextBox.Text))
            {
                this.gameNameTextBox.Text = mGameDetails.mName;
                return;
            }
            if (string.IsNullOrEmpty(this.gameStoryTextBox.Text))
            {
                this.gameStoryTextBox.Text = mGameDetails.mStory;
                return;
            }
            mGameDetails.mName = this.gameNameTextBox.Text;
            mGameDetails.mStory = this.gameStoryTextBox.Text;
            this.Text = mGameDetails.mName;
        }
        private void EditFirstRegionDetails_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.firstRegionNameTextBox.Text))
            {
                this.firstRegionNameTextBox.Text = mGameDetails.mFirstRegion;
                return;
            }
            if(string.IsNullOrEmpty(this.firstRegionStoryTextBox.Text))
            {
                this.firstRegionStoryTextBox.Text = mSelectedRegion.mStory;
                return;
            }
            mGameDetails.mRegionDetails.Remove(mGameDetails.mFirstRegion);
            mSelectedRegion.mName = this.firstRegionNameTextBox.Text;
            mSelectedRegion.mStory = this.firstRegionStoryTextBox.Text;
            mGameDetails.mFirstRegion = mSelectedRegion.mName;
            mGameDetails.mRegionDetails.Add(mGameDetails.mFirstRegion, mSelectedRegion);
        }
        private void EditFirstRoomDetails_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.firstRoomNameTextBox.Text))
            {
                this.firstRoomNameTextBox.Text = mSelectedRoom.mName;
                return;
            }
            if(string.IsNullOrEmpty(this.firstRoomStoryTextBox.Text))
            {
                this.firstRoomStoryTextBox.Text = mSelectedRoom.mStory;
                return;
            }
            mSelectedRegion.mRooms.Remove(mSelectedRoom.mName);
            mSelectedRoom.mName = this.firstRoomNameTextBox.Text;
            mSelectedRoom.mStory = this.firstRoomStoryTextBox.Text;
            mSelectedRegion.mEntryRoom = mSelectedRoom.mName;
            mSelectedRoom.mTreasureCollector.SetInRoom(mSelectedRoom.mName);
            if (this.firstRoomCollectorList.SelectedItems.Count > 0)
            {
                foreach (var aSelection in this.firstRoomCollectorList.SelectedItems)
                {
                    mSelectedRoom.mCollectors.Add((string)aSelection, mGameDetails.GetCollectorObject((string)aSelection));
                    mSelectedRoom.mCollectors[(string)aSelection].SetInRoom(mSelectedRoom.mName);
                    mGameDetails.AssignObject(ObjectType.Collector, (string)aSelection);
                }
            }
            if (this.firstRoomEnemyList.SelectedItems.Count > 0)
            {
                foreach (var aSelection in this.firstRoomEnemyList.SelectedItems)
                {
                    mSelectedRoom.mEnemies.Add((string)aSelection, mGameDetails.GetEnemyObject((string)aSelection));
                    mSelectedRoom.mEnemies[(string)aSelection].SetInRoom(mSelectedRoom.mName);
                    mGameDetails.AssignObject(ObjectType.Enemy, (string)aSelection);
                }
            }
            if (this.firstRoomKillZoneList.SelectedItems.Count > 0)
            {
                foreach (var aSelection in this.firstRoomKillZoneList.SelectedItems)
                {
                    mSelectedRoom.mKillZones.Add((string)aSelection, mGameDetails.GetKillZoneObject((string)aSelection));
                    mSelectedRoom.mKillZones[(string)aSelection].SetInRoom(mSelectedRoom.mName);
                    mGameDetails.AssignObject(ObjectType.KillZone, (string)aSelection);
                }
            }
            if (this.firstRoomOIIList.SelectedItems.Count > 0)
            {
                foreach (var aSelection in this.firstRoomOIIList.SelectedItems)
                {
                    mSelectedRoom.mOneInteractionItems.Add((string)aSelection, mGameDetails.GetOIItemObject((string)aSelection));
                    mSelectedRoom.mOneInteractionItems[(string)aSelection].SetInRoom(mSelectedRoom.mName);
                    mGameDetails.AssignObject(ObjectType.OneInteractionItem, (string)aSelection);
                }
            }
            if (this.firstRoomPIList.SelectedItems.Count > 0)
            {
                foreach (var aSelection in this.firstRoomPIList.SelectedItems)
                {
                    if(!mSelectedRoom.mPickableItems.ContainsKey((string)aSelection))
                    {
                        mSelectedRoom.mPickableItems.Add((string)aSelection, mGameDetails.GetPickableItem((string)aSelection));
                        mSelectedRoom.mPickableItems[(string)aSelection].SetInRoom(mSelectedRoom.mName);
                        mGameDetails.AssignObject(ObjectType.PickableItem, (string)aSelection);
                    }
                }
            }

            mSelectedRegion.mRooms.Add(mSelectedRegion.mEntryRoom, mSelectedRoom);
        }
        void ResetTreasureCollector()
        {
            List<string> aAllPickableNames = mGameDetails.GetPickableItemNames(PickableItem.Type.Giveable);
            for (int aI = 0; aI < aAllPickableNames.Count; aI++)
            {
                if (mGameDetails.IsGivableAssigned(aAllPickableNames[aI]))
                {
                    aAllPickableNames.RemoveAt(aI--);
                }
            }
            aAllPickableNames.AddRange(mSelectedRoom.mTreasureCollector.mTreasures);
            SetListBoxListAndSelection(this.treasureList, aAllPickableNames, mSelectedRoom.mTreasureCollector.mTreasures);
            SetListBoxListAndSelection(this.updatableList, mSelectedRoom.GetAllInteractableNames(mSelectedRoom.mTreasureCollector.mName), mSelectedRoom.mTreasureCollector.mUpdatableObjects);
            this.TrCollectorNameTextBox.Text = mSelectedRoom.mTreasureCollector.mName;
            this.TrCollectorStoryTextBox.Text = mSelectedRoom.mTreasureCollector.mStory;
            this.TrCollectorAllOutputTextBox.Text = mSelectedRoom.mTreasureCollector.mUpdateStory;
            this.TrCollectorWinStoryTextBox.Text = mSelectedRoom.mTreasureCollector.mEndStory;
            this.visibleTrCol.Checked = mSelectedRoom.mTreasureCollector.mIsVisible;
            this.interactableTrCol.Checked = mSelectedRoom.mTreasureCollector.mIsInteractable;
        }
        bool IsTreasureCollectorValid()
        {
            return !(string.IsNullOrEmpty(this.TrCollectorNameTextBox.Text) || string.IsNullOrEmpty(this.TrCollectorStoryTextBox.Text)
                || this.treasureList.SelectedItems.Count <= 0 || string.IsNullOrEmpty(this.TrCollectorAllOutputTextBox.Text)
                || string.IsNullOrEmpty(this.TrCollectorWinStoryTextBox.Text));
        }
        private void EditTreasureCollectorDetails_Click(object sender, EventArgs e)
        {
            if(IsTreasureCollectorValid())
            {
                mSelectedRoom.mTreasureCollector.mName = this.TrCollectorNameTextBox.Text;
                mSelectedRoom.mTreasureCollector.mStory = this.TrCollectorStoryTextBox.Text;
                mSelectedRoom.mTreasureCollector.mUpdateStory = this.TrCollectorAllOutputTextBox.Text;
                mSelectedRoom.mTreasureCollector.mEndStory = this.TrCollectorWinStoryTextBox.Text;
                mSelectedRoom.mTreasureCollector.mIsVisible = this.visibleTrCol.Checked;
                mSelectedRoom.mTreasureCollector.mIsInteractable = this.interactableTrCol.Checked;
                mSelectedRoom.mTreasureCollector.mTreasures = new List<string>();
                foreach(var aSelected in this.treasureList.SelectedItems)
                {
                    mSelectedRoom.mTreasureCollector.mTreasures.Add((string)aSelected);
                    mGameDetails.AssignGivable((string)aSelected);
                    PickableItem aItem = mGameDetails.GetPickableItem(PickableItem.Type.Giveable, (string)aSelected);
                    aItem.AddConditionalOf(mSelectedRoom.mTreasureCollector.mName);
                }
                mSelectedRoom.mTreasureCollector.mUpdatableObjects = new List<string>();
                foreach(var aSelected in this.updatableList.SelectedItems)
                {
                    mSelectedRoom.mTreasureCollector.mUpdatableObjects.Add((string)aSelected);
                }
            }
            ResetTreasureCollector();
        }
        #endregion
        #region Region Data
        private void RegionTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.regionTabControl.SelectedTab == this.addEditRegionTab)
            {
                ResetRegionEditor();
            }
            else if(this.regionTabControl.SelectedTab == this.regionGateWaysTab)
            {
                ResetGatewayEditor();
            }
            else if(this.regionTabControl.SelectedTab == this.regionPortalTab)
            {
                this.insidePortalsTabControl.SelectedIndex = 0;
                InsidePortalsTabControl_SelectedIndexChanged(null, null);
            }
        }
        #region Region Editor Code
        void ResetRegionEditor()
        {
            mSelectedRegion = null;
            List<string> aRegionNames = new List<string>(mGameDetails.mRegionDetails.Keys);
            aRegionNames.Remove(mGameDetails.mFirstRegion);
            this.currentRegionsList.DataSource = aRegionNames;
            this.currentRegionsList.SelectedIndex = -1;
            this.regionNameTextBox.Text = "";
            this.regionStoryTextBox.Text = "";
            List<string> aRoomNames = mGameDetails.GetRoomNames();
            for(int aI = 0; aI < aRoomNames.Count; aI ++)
            {
                if(mGameDetails.IsRoomAssigned(aRoomNames[aI]))
                {
                    aRoomNames.RemoveAt(aI--);
                }
            }
            this.entryRoomSelector.DataSource = null;
            this.allRoomsRegionList.DataSource = aRoomNames;
            this.allRoomsRegionList.SelectedIndex = -1;
        }
        bool IsRegionValid()
        {
            return !(string.IsNullOrEmpty(this.regionNameTextBox.Text) || string.IsNullOrEmpty(this.regionStoryTextBox.Text)
                || this.entryRoomSelector.DataSource == null || this.allRoomsRegionList.SelectedItems.Count <= 0);
        }
        private void AllRoomsRegionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.allRoomsRegionList.SelectedIndex == -1)
            {
                this.entryRoomSelector.DataSource = null;
                return;
            }
            string aErRoom = "";
            if (this.entryRoomSelector.DataSource != null)
            {
                aErRoom = (string)this.entryRoomSelector.SelectedItem;
            }
            this.entryRoomSelector.DataSource = null;
            List<string> aRooms = new List<string>();
            foreach(var aSelection in this.allRoomsRegionList.SelectedItems)
            {
                aRooms.Add((string)aSelection);
            }
            this.entryRoomSelector.DataSource = aRooms;
            if(!string.IsNullOrEmpty(aErRoom))
            {
                if(aRooms.Contains(aErRoom))
                {
                    this.entryRoomSelector.SelectedItem = aErRoom;
                }
            }
        }
        private void DeleteRegionDetails_Click(object sender, EventArgs e)
        {
            if(mSelectedRegion != null)
            {
                foreach(Room aRoom in mSelectedRegion.mRooms.Values)
                {
                    mGameDetails.UnAssignRoom(aRoom.mName);
                    aRoom.SetInRegion("");
                }
                mGameDetails.mRegionDetails[mGameDetails.mFirstRegion].mRooms[mGameDetails.mRegionDetails[mGameDetails.mFirstRegion].mEntryRoom].
                    mPortals.Remove(mGameDetails.GetRegionPortal(mSelectedRegion.mName).mName);
                mGameDetails.DeletePortal(mSelectedRegion.mName);
                mGameDetails.mRegionDetails.Remove(mSelectedRegion.mName);
                mSelectedRegion = null;
            }
        }
        private void EditRegionDetails_Click(object sender, EventArgs e)
        {
            if(IsRegionValid())
            {
                if(mSelectedRegion == null && mGameDetails.mRegionDetails.ContainsKey(this.regionNameTextBox.Text))
                {
                    return;
                }
                Portal aRegionPortal = null;
                Room aFRoom = mGameDetails.mRegionDetails[mGameDetails.mFirstRegion].mRooms[mGameDetails.mRegionDetails[mGameDetails.mFirstRegion].mEntryRoom];
                if (mSelectedRegion != null)
                {
                    aRegionPortal = mGameDetails.GetRegionPortal(mSelectedRegion.mName);
                    foreach (Room aRoom in mSelectedRegion.mRooms.Values)
                    {
                        mGameDetails.UnAssignRoom(aRoom.mName);
                        aRoom.SetInRegion("");
                        if(aRoom.mPortals.ContainsKey(aRegionPortal.mName))
                        {
                            aRoom.mPortals.Remove(aRegionPortal.mName);
                        }
                    }
                    aFRoom.mPortals.Remove(aRegionPortal.mName);
                    mGameDetails.DeletePortal(mSelectedRegion.mName);
                    mGameDetails.mRegionDetails.Remove(mSelectedRegion.mName);
                    mSelectedRegion = null;
                }
                mSelectedRegion = new Region((string)this.entryRoomSelector.SelectedItem)
                {
                    mName = this.regionNameTextBox.Text,
                    mStory = this.regionStoryTextBox.Text,
                };
                foreach(var aSelected in this.allRoomsRegionList.SelectedItems)
                {
                    mSelectedRegion.mRooms.Add((string)aSelected, mGameDetails.GetRoomObject((string)aSelected));
                    mSelectedRegion.mRooms[(string)aSelected].SetInRegion(mSelectedRegion.mName);
                    mGameDetails.AssignRoom((string)aSelected);
                }
                if(aRegionPortal == null)
                {
                    aRegionPortal = new Portal(mSelectedRegion.mName);
                }
                aRegionPortal.mCurrentRegionName = mSelectedRegion.mName;
                mGameDetails.AddPortal(aRegionPortal);
                mGameDetails.mRegionDetails.Add(mSelectedRegion.mName, mSelectedRegion);
                aFRoom.mPortals.Add(mSelectedRegion.mName, aRegionPortal);
                mSelectedRegion = null;
            }
            ResetRegionEditor();
        }
        private void EditSelectedRegion_Click(object sender, EventArgs e)
        {
            if(this.currentRegionsList.SelectedIndex == -1)
            {
                mSelectedRegion = null;
                return;
            }
            mSelectedRegion = mGameDetails.mRegionDetails[(string)this.currentRegionsList.SelectedItem];
            this.regionNameTextBox.Text = mSelectedRegion.mName;
            this.regionStoryTextBox.Text = mSelectedRegion.mStory;
            List<string> aRoomNames = mGameDetails.GetRoomNames();
            for (int aI = 0; aI < aRoomNames.Count; aI++)
            {
                if (mGameDetails.IsRoomAssigned(aRoomNames[aI]))
                {
                    aRoomNames.RemoveAt(aI--);
                }
            }
            aRoomNames.AddRange(mSelectedRegion.mRooms.Keys);
            SetListBoxListAndSelection(this.allRoomsRegionList, aRoomNames, new List<string>(mSelectedRegion.mRooms.Keys));
            this.entryRoomSelector.SelectedItem = mSelectedRegion.mEntryRoom;
        }
        #endregion
        #region Gateway Editor Code
        void ResetGatewayEditor()
        {
            mSelectedRegion = null;
            mSelectedGateway = null;
            this.gatewayNameTextBox.Text = "";
            this.gatewayStoryTextBox.Text = "";
            this.isGatewayVisible.Checked =
            this.isGatewayInteractable.Checked = false;
            this.gatewayDirection.DataSource = null;
            this.gatewayRoom1.DataSource = null;
            this.gatewayRoom2.DataSource = null;
            List<string> aRegionNames = new List<string>(mGameDetails.mRegionDetails.Keys);
            aRegionNames.Remove(mGameDetails.mFirstRegion);
            this.gwCurrentRegionsList.DataSource = aRegionNames;
            this.gwCurrentRegionsList.SelectedIndex = -1;
        }
        void DeleteGateway()
        {
            if (mSelectedGateway != null)
            {
                Room aR1 = mGameDetails.GetRoomObject(mSelectedGateway.mRoom1);
                Room aR2 = mGameDetails.GetRoomObject(mSelectedGateway.mRoom2);
                aR1.mGateways.Remove(mSelectedGateway.mName);
                aR1.ToggleDirectionBlock(mSelectedGateway.GetRoom1Direction(), false);
                aR2.mGateways.Remove(mSelectedGateway.mName);
                aR2.ToggleDirectionBlock(mSelectedGateway.GetRoom2Direction(), false);
                mGameDetails.DeleteGateway(mSelectedGateway.mName);
                mSelectedGateway = null;
            }
        }
        void PopulateRoomComboBox(Gateway.Direction pDirection1, Gateway.Direction pDirection2, string pRoom1 = null, string pRoom2 = null)
        {
            List<string> aRoom1List = new List<string>(mSelectedRegion.mRooms.Keys);
            List<string> aRoom2List = new List<string>(mSelectedRegion.mRooms.Keys);
            foreach (Room aRoom in mSelectedRegion.mRooms.Values)
            {
                if (aRoom.IsBlocked(pDirection1))
                {
                    aRoom1List.Remove(aRoom.mName);
                }
                if (aRoom.IsBlocked(pDirection2))
                {
                    aRoom2List.Remove(aRoom.mName);
                }
            }
            if(!(pRoom1 == null && pRoom2 == null))
            {
                aRoom1List.Add(pRoom1);
                aRoom2List.Add(pRoom2);
            }
            this.gatewayRoom1.DataSource = aRoom1List;
            this.gatewayRoom2.DataSource = aRoom2List;
            if(pRoom1 == null && pRoom2 == null)
            {
                this.gatewayRoom1.SelectedIndex = -1;
                this.gatewayRoom2.SelectedIndex = -1;
            }
            else
            {
                this.gatewayRoom1.SelectedItem = pRoom1;
                this.gatewayRoom2.SelectedItem = pRoom2;
            }
        }

        private void GwCurrentRegionsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.gwCurrentRegionsList.SelectedIndex == -1)
            {
                mSelectedRegion = null;
                this.currentGatewaysList.DataSource = null;
                this.gatewayDirection.DataSource = null;
                return;
            }
            mSelectedRegion = mGameDetails.mRegionDetails[(string)this.gwCurrentRegionsList.SelectedItem];
            List<string> aCurGws = new List<string>();
            foreach(Room aRoom in mSelectedRegion.mRooms.Values)
            {
                foreach(string aKeys in aRoom.mGateways.Keys)
                {
                    if(!aCurGws.Contains(aKeys))
                    {
                        aCurGws.Add(aKeys);
                    }
                }
            }
            this.currentGatewaysList.DataSource = aCurGws;
            this.currentGatewaysList.SelectedIndex = -1;
            this.gatewayDirection.DataSource = Enum.GetValues(typeof(Gateway.Path));
            this.gatewayDirection.SelectedIndex = -1;
        }
        
        private void GatewayDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.gatewayDirection.SelectedIndex == -1)
            {
                this.gatewayRoom1.DataSource = null;
                this.gatewayRoom2.DataSource = null;
                return;
            }
            Gateway.Path aPath = (Gateway.Path)this.gatewayDirection.SelectedItem;
            switch(aPath)
            {
                case Gateway.Path.North_South:
                    PopulateRoomComboBox(Gateway.Direction.North, Gateway.Direction.South);
                    break;
                case Gateway.Path.East_West:
                    PopulateRoomComboBox(Gateway.Direction.East, Gateway.Direction.West);
                    break;
                case Gateway.Path.NorthWest_SouthEast:
                    PopulateRoomComboBox(Gateway.Direction.NorthWest, Gateway.Direction.SouthEast);
                    break;
                case Gateway.Path.NorthEast_SouthWest:
                    PopulateRoomComboBox(Gateway.Direction.NorthEast, Gateway.Direction.SouthWest);
                    break;
            }
        }
        private void EditSelectedGateway_Click(object sender, EventArgs e)
        {
            if(this.currentGatewaysList.SelectedIndex == -1)
            {
                mSelectedGateway = null;
                return;
            }
            mSelectedGateway = mGameDetails.GetGatewayObject((string)this.currentGatewaysList.SelectedItem);
            if(mGameDetails.GetRoomObject(mSelectedGateway.mRoom1).GetInRegion() != mSelectedRegion.mName)
            {
                DeleteGatewayDetails_Click(null, null);
                return;
            }
            if (mGameDetails.GetRoomObject(mSelectedGateway.mRoom2).GetInRegion() != mSelectedRegion.mName)
            {
                DeleteGatewayDetails_Click(null,null);
                return;
            }
            this.gatewayNameTextBox.Text = mSelectedGateway.mName;
            this.gatewayStoryTextBox.Text = mSelectedGateway.mStory;
            this.gatewayDirection.SelectedItem = mSelectedGateway.mPath;
            switch (mSelectedGateway.mPath)
            {
                case Gateway.Path.North_South:
                    PopulateRoomComboBox(Gateway.Direction.North, Gateway.Direction.South,mSelectedGateway.mRoom1,mSelectedGateway.mRoom2);
                    break;
                case Gateway.Path.East_West:
                    PopulateRoomComboBox(Gateway.Direction.East, Gateway.Direction.West, mSelectedGateway.mRoom1, mSelectedGateway.mRoom2);
                    break;
                case Gateway.Path.NorthWest_SouthEast:
                    PopulateRoomComboBox(Gateway.Direction.NorthWest, Gateway.Direction.SouthEast, mSelectedGateway.mRoom1, mSelectedGateway.mRoom2);
                    break;
                case Gateway.Path.NorthEast_SouthWest:
                    PopulateRoomComboBox(Gateway.Direction.NorthEast, Gateway.Direction.SouthWest, mSelectedGateway.mRoom1, mSelectedGateway.mRoom2);
                    break;
            }
            this.isGatewayVisible.Checked = mSelectedGateway.mIsVisible;
            this.isGatewayInteractable.Checked = mSelectedGateway.mIsInteractable;
        }
        private void EditGatewayDetails_Click(object sender, EventArgs e)
        {
            if(mSelectedRegion == null)
            {
                return;
            }
            if (!(string.IsNullOrEmpty(this.gatewayNameTextBox.Text) || string.IsNullOrEmpty(this.gatewayStoryTextBox.Text) ||
                this.gatewayDirection.SelectedIndex == -1 || this.gatewayRoom1.SelectedIndex == -1 || this.gatewayRoom2.SelectedIndex == -1 || (string)this.gatewayRoom1.SelectedItem == (string)this.gatewayRoom2.SelectedItem))
            {
                if(mSelectedGateway == null && mGameDetails.IsGatewayPresent(this.gameNameTextBox.Text))
                {
                    return;
                }
                DeleteGateway();
                
                mSelectedGateway = new Gateway
                {
                    mName = this.gatewayNameTextBox.Text,
                    mStory = this.gatewayStoryTextBox.Text,
                    mPath = (Gateway.Path)this.gatewayDirection.SelectedItem,
                    mRoom1 = (string)this.gatewayRoom1.SelectedItem,
                    mRoom2 = (string)this.gatewayRoom2.SelectedItem,
                    mIsVisible = this.isGatewayVisible.Checked,
                    mIsInteractable = this.isGatewayInteractable.Checked
                };
                mGameDetails.GetRoomObject(mSelectedGateway.mRoom1).mGateways.Add(mSelectedGateway.mName, mSelectedGateway);
                mGameDetails.GetRoomObject(mSelectedGateway.mRoom1).ToggleDirectionBlock(mSelectedGateway.GetRoom1Direction(), true);
                mGameDetails.GetRoomObject(mSelectedGateway.mRoom2).mGateways.Add(mSelectedGateway.mName, mSelectedGateway);
                mGameDetails.GetRoomObject(mSelectedGateway.mRoom2).ToggleDirectionBlock(mSelectedGateway.GetRoom2Direction(), true);
                mGameDetails.AddGateway(mSelectedGateway);
                mSelectedGateway = null;
            }
            ResetGatewayEditor();
        }
        private void DeleteGatewayDetails_Click(object sender, EventArgs e)
        {
            DeleteGateway();
            ResetGatewayEditor();
        }
        #endregion
        #region Portal Editor Code
        private void InsidePortalsTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetPortalEditor();
        }
        void ResetPortalEditor()
        {
            mSelectedPortal = null;
            if (this.insidePortalsTabControl.SelectedTab == this.editPortalTab)
            {
                List<string> aRegionNames = new List<string>(mGameDetails.mRegionDetails.Keys);
                aRegionNames.Remove(mGameDetails.mFirstRegion);
                this.edPorCurrentRegionsList.DataSource = aRegionNames;
                this.edPorCurrentRegionsList.SelectedIndex = -1;
            }
            else if(this.insidePortalsTabControl.SelectedTab == this.portalRoomsTab)
            {
                List<string> aRegionNames = new List<string>(mGameDetails.mRegionDetails.Keys);
                aRegionNames.Remove(mGameDetails.mFirstRegion);
                this.adptrCurrentRegionsList.DataSource = aRegionNames;
                this.adptrCurrentRegionsList.SelectedIndex = -1;
            }
        }
        private void EdPorCurrentRegionsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.edPorCurrentRegionsList.SelectedIndex == -1)
            {
                mSelectedPortal = null;
                this.portalNameTextBox.Text = "";
                this.portalStoryTextBox.Text = "";
                return;
            }
            mSelectedPortal = mGameDetails.GetRegionPortal((string)this.edPorCurrentRegionsList.SelectedItem);
            this.portalNameTextBox.Text = mSelectedPortal.mName;
            this.portalStoryTextBox.Text = mSelectedPortal.mStory;
        }
        private void EditPortalDetails_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(this.portalNameTextBox.Text) || string.IsNullOrEmpty(this.portalStoryTextBox.Text)))
            {
                if (mSelectedPortal != null)
                {
                    Portal aNewPortal = new Portal(mSelectedPortal.mCurrentRegionName);
                    aNewPortal.mName = this.portalNameTextBox.Text;
                    aNewPortal.mStory = this.portalStoryTextBox.Text;
                    foreach (Room aRoom in mGameDetails.mRegionDetails[mSelectedPortal.mCurrentRegionName].mRooms.Values)
                    {
                        if(aRoom.mPortals.ContainsKey(mSelectedPortal.mName))
                        {
                            aRoom.mPortals.Remove(mSelectedPortal.mName);
                            aRoom.mPortals.Add(aNewPortal.mName, aNewPortal);
                            aRoom.EditUpdatableNames(mSelectedPortal.mName, aNewPortal.mName);
                        }
                    }
                    Room aFRoom = mGameDetails.mRegionDetails[mGameDetails.mFirstRegion].mRooms[mGameDetails.mRegionDetails[mGameDetails.mFirstRegion].mEntryRoom];
                    aFRoom.mPortals.Remove(mSelectedPortal.mName);
                    aFRoom.mPortals.Add(aNewPortal.mName, aNewPortal);
                    aFRoom.EditUpdatableNames(mSelectedPortal.mName, aNewPortal.mName);
                    mGameDetails.AddPortal(aNewPortal);
                }
            }
            ResetPortalEditor();
        }
        private void AdptrCurrentRegionsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.adptrCurrentRegionsList.SelectedIndex == -1)
            {
                mSelectedPortal = null;
                this.currentPortalRoomsList.DataSource = null;
                return;
            }
            mSelectedPortal = mGameDetails.GetRegionPortal((string)this.adptrCurrentRegionsList.SelectedItem);
            List<string> aAllRoomsInRegion = new List<string>(mGameDetails.mRegionDetails[mSelectedPortal.mCurrentRegionName].mRooms.Keys);
            List<string> aPortalContainingRooms = new List<string>();
            foreach (Room aRoom in mGameDetails.mRegionDetails[mSelectedPortal.mCurrentRegionName].mRooms.Values)
            {
                if (aRoom.mPortals.ContainsKey(mSelectedPortal.mName))
                {
                    aPortalContainingRooms.Add(aRoom.mName);
                }
            }
            SetListBoxListAndSelection(this.currentPortalRoomsList, aAllRoomsInRegion, aPortalContainingRooms);
        }
        private void AddPortalsToRooms_Click(object sender, EventArgs e)
        {
            List<string> aSelectedRooms = new List<string>();
            foreach(var aSelected in this.currentPortalRoomsList.SelectedItems)
            {
                aSelectedRooms.Add((string)aSelected);
            }
            foreach(Room aRoom in mGameDetails.mRegionDetails[mSelectedPortal.mCurrentRegionName].mRooms.Values)
            {
                aRoom.mPortals = new Dictionary<string, Portal>();
                if(aSelectedRooms.Contains(aRoom.mName))
                {
                    aRoom.mPortals.Add(mSelectedPortal.mName, mSelectedPortal);
                }
            }
            ResetPortalEditor();
        }
        #endregion
        #endregion
        #region Room Data
        private void RoomTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.roomTabControl.SelectedTab == this.addEditRoomTab)
            {
                ResetRoomEditor();
            }
            else if(this.roomTabControl.SelectedTab == this.collectorUpdatablesTab)
            {
                ResetCollectorUpdatablesEditor();
            }
            else if(this.roomTabControl.SelectedTab == this.enemyUpdatablesTab)
            {
                ResetEnemyUpdatablesEditor();
            }
            else if(this.roomTabControl.SelectedTab == this.killZoneUpdatablesTab)
            {
                ResetKillZoneUpdatablesEditor();
            }
            else if(this.roomTabControl.SelectedTab == this.oIIUpdatablesTab)
            {
                ResetOIIUpdatablesEditor();
            }
        }
        void SetListBoxListAndSelection(ListBox pListBox, List<string> pListNames, List<string> pSelectedNames)
        {
            pListBox.DataSource = pListNames;
            pListBox.SelectedIndex = -1;
            if (pSelectedNames != null)
            {
                foreach (string aSelected in pSelectedNames)
                {
                    pListBox.SetSelected(pListNames.IndexOf(aSelected), true);
                }
            }
        }
        #region Add Edit Room Editor Code
        void ResetRoomEditor()
        {
            List<string> aAllCollectorNames = mGameDetails.GetCollectorNames();
            List<string> aRCNames = null;
            RemoveAssigned(ObjectType.Collector, aAllCollectorNames);
            List<string> aAllEnemyNames = mGameDetails.GetEnemyNames();
            List<string> aRENames = null;
            RemoveAssigned(ObjectType.Enemy, aAllEnemyNames);
            List<string> aAllKillZoneNames = mGameDetails.GetKillZoneNames();
            List<string> aRKZNames = null;
            RemoveAssigned(ObjectType.KillZone, aAllKillZoneNames);
            List<string> aAllOIItemNames = mGameDetails.GetOIItemNames();
            List<string> aROIINames = null;
            RemoveAssigned(ObjectType.OneInteractionItem, aAllOIItemNames);
            List<string> aAllPickableNames = mGameDetails.GetPickableItemNames();
            List<string> aRPNames = null;
            RemoveAssigned(ObjectType.PickableItem, aAllPickableNames);
            if (mSelectedRoom != null)
            {
                this.roomNameTextBox.Text = mSelectedRoom.mName;
                this.roomStoryTextBox.Text = mSelectedRoom.mStory;
                aRCNames = new List<string>(mSelectedRoom.mCollectors.Keys);
                aAllCollectorNames.AddRange(aRCNames);
                aRENames = new List<string>(mSelectedRoom.mEnemies.Keys);
                aAllEnemyNames.AddRange(aRENames);
                aRKZNames = new List<string>(mSelectedRoom.mKillZones.Keys);
                aAllKillZoneNames.AddRange(aRKZNames);
                aROIINames = new List<string>(mSelectedRoom.mOneInteractionItems.Keys);
                aAllOIItemNames.AddRange(aROIINames);
                aRPNames = new List<string>(mSelectedRoom.mPickableItems.Keys);
                aAllPickableNames.AddRange(aRPNames);
            }
            else
            {
                this.roomNameTextBox.Text = "";
                this.roomStoryTextBox.Text = "";
            }
            SetListBoxListAndSelection(this.roomCollectorsList, aAllCollectorNames, aRCNames);
            SetListBoxListAndSelection(this.roomEnemiesList, aAllEnemyNames, aRENames);
            SetListBoxListAndSelection(this.roomKillZonesList, aAllKillZoneNames, aRKZNames);
            SetListBoxListAndSelection(this.roomPickableItemsList, aAllPickableNames, aRPNames);
            SetListBoxListAndSelection(this.roomOIIList, aAllOIItemNames, aROIINames);
            this.currentRoomsList.DataSource = mGameDetails.GetRoomNames();
            this.currentRoomsList.SelectedIndex = -1;
        }
        void RemoveAssigned(ObjectType pType, List<string> pListNames)
        {
            for (int aI = 0; aI < pListNames.Count; aI++)
            {
                if (mGameDetails.IsObjectAssigned(pType, pListNames[aI]))
                {
                    pListNames.RemoveAt(aI--);
                }
            }
        }
        void DeleteSelectedRoom()
        {
            if (mSelectedRoom != null)
            {
                mGameDetails.DeleteRoom(mSelectedRoom.mName);
                mSelectedRoom = null;
            }
        }
        bool IsRoomDataValid()
        {
            return !(string.IsNullOrEmpty(this.roomNameTextBox.Text) || string.IsNullOrEmpty(this.roomStoryTextBox.Text));
        }
        private void DeleteRoomDetails_Click(object sender, EventArgs e)
        {
            DeleteSelectedRoom();
            ResetRoomEditor();
        }
        private void EditRoomDetails_Click(object sender, EventArgs e)
        {
            if(IsRoomDataValid())
            {
                if(mSelectedRoom == null && mGameDetails.IsRoomPresent(this.roomNameTextBox.Text))
                {
                    return;
                }
                Region aRoomRegion = null;
                string aRoomOldName = "";
                if (mSelectedRoom != null && mSelectedRoom.IsInRegion())
                {
                    aRoomRegion = mGameDetails.mRegionDetails[mSelectedRoom.GetInRegion()];
                    aRoomOldName = mSelectedRoom.mName;
                }
                DeleteSelectedRoom();
                mSelectedRoom = new Room
                {
                    mName = this.roomNameTextBox.Text,
                    mStory = this.roomStoryTextBox.Text
                };
                if(this.roomCollectorsList.SelectedItems.Count > 0)
                {
                    foreach(var aSelection in this.roomCollectorsList.SelectedItems)
                    {
                        mSelectedRoom.mCollectors.Add((string)aSelection, mGameDetails.GetCollectorObject((string)aSelection));
                        mSelectedRoom.mCollectors[(string)aSelection].SetInRoom(mSelectedRoom.mName);
                        mGameDetails.AssignObject(ObjectType.Collector, (string)aSelection);
                    }
                }
                if(this.roomEnemiesList.SelectedItems.Count > 0)
                {
                    foreach (var aSelection in this.roomEnemiesList.SelectedItems)
                    {
                        mSelectedRoom.mEnemies.Add((string)aSelection, mGameDetails.GetEnemyObject((string)aSelection));
                        mSelectedRoom.mEnemies[(string)aSelection].SetInRoom(mSelectedRoom.mName);
                        mGameDetails.AssignObject(ObjectType.Enemy, (string)aSelection);
                    }
                }
                if(this.roomKillZonesList.SelectedItems.Count > 0)
                {
                    foreach (var aSelection in this.roomKillZonesList.SelectedItems)
                    {
                        mSelectedRoom.mKillZones.Add((string)aSelection, mGameDetails.GetKillZoneObject((string)aSelection));
                        mSelectedRoom.mKillZones[(string)aSelection].SetInRoom(mSelectedRoom.mName);
                        mGameDetails.AssignObject(ObjectType.KillZone, (string)aSelection);
                    }
                }
                if(this.roomOIIList.SelectedItems.Count > 0)
                {
                    foreach (var aSelection in this.roomOIIList.SelectedItems)
                    {
                        mSelectedRoom.mOneInteractionItems.Add((string)aSelection, mGameDetails.GetOIItemObject((string)aSelection));
                        mSelectedRoom.mOneInteractionItems[(string)aSelection].SetInRoom(mSelectedRoom.mName);
                        mGameDetails.AssignObject(ObjectType.OneInteractionItem, (string)aSelection);
                    }
                }
                if(this.roomPickableItemsList.SelectedItems.Count > 0)
                {
                    foreach (var aSelection in this.roomPickableItemsList.SelectedItems)
                    {
                        mSelectedRoom.mPickableItems.Add((string)aSelection, mGameDetails.GetPickableItem((string)aSelection));
                        mSelectedRoom.mPickableItems[(string)aSelection].SetInRoom(mSelectedRoom.mName);
                        mGameDetails.AssignObject(ObjectType.PickableItem, (string)aSelection);
                    }
                }
                if(aRoomRegion != null)
                {
                    aRoomRegion.mRooms.Remove(aRoomOldName);
                    aRoomRegion.mRooms.Add(mSelectedRoom.mName, mSelectedRoom);
                    mSelectedRoom.SetInRegion(aRoomRegion.mName);
                }
                mGameDetails.AddRoom(mSelectedRoom);
                mSelectedRoom = null;
            }
            ResetRoomEditor();
        }
        private void EditSelectedRoom_Click(object sender, EventArgs e)
        {
            if (mSelectedRoom != null)
            {
                mSelectedRoom = null;
            }
            mSelectedRoom = mGameDetails.GetRoomObject((string)this.currentRoomsList.SelectedItem);
            ResetRoomEditor();
            this.currentRoomsList.SelectedItem = mSelectedRoom.mName;
        }
        #endregion
        #region Collector Updatables Editor Code
        void ResetCollectorUpdatablesEditor()
        {
            mSelectedRoom = null;
            mSelectedCollector = null;
            this.collectorUpdatableList.DataSource = null;
            this.colCollectorList.DataSource = null;
            this.colCurRoomList.DataSource = mGameDetails.GetRoomNames();
            this.colCurRoomList.SelectedIndex = -1;
        }
        private void ColCurRoomList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.colCurRoomList.SelectedIndex == -1)
            {
                mSelectedRoom = null;
                return;
            }
            mSelectedRoom = mGameDetails.GetRoomObject((string)this.colCurRoomList.SelectedItem);
            if(mSelectedRoom != null)
            {
                this.colCollectorList.DataSource = new List<string>(mSelectedRoom.mCollectors.Keys);
                this.colCollectorList.SelectedIndex = -1;
            }
        }
        private void ColCollectorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.colCollectorList.SelectedIndex == -1)
            {
                mSelectedCollector = null;
                return;
            }
            mSelectedCollector = mGameDetails.GetCollectorObject((string)this.colCollectorList.SelectedItem);
            if(mSelectedCollector != null)
            {
                SetListBoxListAndSelection(this.collectorUpdatableList, mSelectedRoom.GetAllInteractableNames(mSelectedCollector.mName), mSelectedCollector.mUpdatableObjects);
            }
        }
        private void EditCollectorUpdatableDetails_Click(object sender, EventArgs e)
        {
            if(mSelectedCollector != null)
            {
                mSelectedCollector.mUpdatableObjects = new List<string>();
                foreach(var aSelection in this.collectorUpdatableList.SelectedItems)
                {
                    mSelectedCollector.mUpdatableObjects.Add((string)aSelection);
                }
            }
            ResetCollectorUpdatablesEditor();
        }
        #endregion
        #region Enemy Updatables Editor Code
        void ResetEnemyUpdatablesEditor()
        {
            mSelectedRoom = null;
            mSelectedEnemy = null;
            this.enemyUpdatableList.DataSource = null;
            this.enEnemyList.DataSource = null;
            this.enCurRoomList.DataSource = mGameDetails.GetRoomNames();
            this.enCurRoomList.SelectedIndex = -1;
        }
        private void EnCurRoomList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.enCurRoomList.SelectedIndex == -1)
            {
                mSelectedRoom = null;
                return;
            }
            mSelectedRoom = mGameDetails.GetRoomObject((string)this.enCurRoomList.SelectedItem);
            if (mSelectedRoom != null)
            {
                this.enEnemyList.DataSource = new List<string>(mSelectedRoom.mEnemies.Keys);
                this.enEnemyList.SelectedIndex = -1;
            }
        }
        private void EnEnemyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.enEnemyList.SelectedIndex == -1)
            {
                mSelectedEnemy = null;
                return;
            }
            mSelectedEnemy = mGameDetails.GetEnemyObject((string)this.enEnemyList.SelectedItem);
            if (mSelectedEnemy != null)
            {
                SetListBoxListAndSelection(this.enemyUpdatableList, mSelectedRoom.GetAllInteractableNames(mSelectedEnemy.mName), mSelectedEnemy.mUpdatableObjects);
            }
        }
        private void EditEnemyUpdatableDetails_Click(object sender, EventArgs e)
        {
            if (mSelectedEnemy != null)
            {
                mSelectedEnemy.mUpdatableObjects = new List<string>();
                foreach (var aSelection in this.enemyUpdatableList.SelectedItems)
                {
                    mSelectedEnemy.mUpdatableObjects.Add((string)aSelection);
                }
            }
            ResetEnemyUpdatablesEditor();
        }
        #endregion
        #region Kill Zone Updatables Editor Code
        void ResetKillZoneUpdatablesEditor()
        {
            mSelectedRoom = null;
            mSelectedKillZone = null;
            this.killZoneUpdatableList.DataSource = null;
            this.kzKillZoneList.DataSource = null;
            this.kzCurRoomList.DataSource = mGameDetails.GetRoomNames();
            this.kzCurRoomList.SelectedIndex = -1;
        }
        private void KzCurRoomList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.kzCurRoomList.SelectedIndex == -1)
            {
                mSelectedRoom = null;
                return;
            }
            mSelectedRoom = mGameDetails.GetRoomObject((string)this.kzCurRoomList.SelectedItem);
            if (mSelectedRoom != null)
            {
                this.kzKillZoneList.DataSource = new List<string>(mSelectedRoom.mKillZones.Keys);
                this.kzKillZoneList.SelectedIndex = -1;
            }
        }
        private void KzKillZoneList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.kzKillZoneList.SelectedIndex == -1)
            {
                mSelectedKillZone = null;
                return;
            }
            mSelectedKillZone = mGameDetails.GetKillZoneObject((string)this.kzKillZoneList.SelectedItem);
            if (mSelectedKillZone != null)
            {
                SetListBoxListAndSelection(this.killZoneUpdatableList, mSelectedRoom.GetAllInteractableNames(mSelectedKillZone.mName), mSelectedKillZone.mUpdatableObjects);
            }
        }
        private void EditKillZoneUpdatableDetails_Click(object sender, EventArgs e)
        {
            if (mSelectedKillZone != null)
            {
                mSelectedKillZone.mUpdatableObjects = new List<string>();
                foreach (var aSelection in this.killZoneUpdatableList.SelectedItems)
                {
                    mSelectedKillZone.mUpdatableObjects.Add((string)aSelection);
                }
            }
            ResetKillZoneUpdatablesEditor();
        }
        #endregion
        #region One Interaction Item Updatables Editor Code
        void ResetOIIUpdatablesEditor()
        {
            mSelectedRoom = null;
            mSelectedOIItem = null;
            this.oIItemUpdatableList.DataSource = null;
            this.oIIItemList.DataSource = null;
            this.oIICurRoomList.DataSource = mGameDetails.GetRoomNames();
            this.oIICurRoomList.SelectedIndex = -1;
        }
        private void OIICurRoomList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.oIICurRoomList.SelectedIndex == -1)
            {
                mSelectedRoom = null;
                return;
            }
            mSelectedRoom = mGameDetails.GetRoomObject((string)this.oIICurRoomList.SelectedItem);
            if (mSelectedRoom != null)
            {
                this.oIIItemList.DataSource = new List<string>(mSelectedRoom.mOneInteractionItems.Keys);
            }
        }
        private void OIIItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.oIIItemList.SelectedIndex == -1)
            {
                mSelectedOIItem = null;
                return;
            }
            mSelectedOIItem = mGameDetails.GetOIItemObject((string)this.oIIItemList.SelectedItem);
            if (mSelectedOIItem != null)
            {
                SetListBoxListAndSelection(this.oIItemUpdatableList, mSelectedRoom.GetAllInteractableNames(mSelectedOIItem.mName), mSelectedOIItem.mUpdatableObjects);
            }
        }
        private void EditOIIUpdatableDetails_Click(object sender, EventArgs e)
        {
            if (mSelectedOIItem != null)
            {
                mSelectedOIItem.mUpdatableObjects = new List<string>();
                foreach (var aSelection in this.oIItemUpdatableList.SelectedItems)
                {
                    mSelectedOIItem.mUpdatableObjects.Add((string)aSelection);
                }
            }
            ResetOIIUpdatablesEditor();
        }
        #endregion
        #endregion
        #region Interactables Data
        private void InteractableDetailsTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            mSelectedCollector = null;
            mSelectedEnemy = null;
            mSelectedKillZone = null;
            mSelectedOIItem = null;
            mSelectedPickable = null;
            if (this.interactableDetailsTabControl.SelectedTab == this.collectorDetailsTab)
            {
                ResetCollectorEditor();
            }
            else if(this.interactableDetailsTabControl.SelectedTab == this.enemyDetailsTab)
            {
                ResetEnemyEditor();
            }
            else if(this.interactableDetailsTabControl.SelectedTab == this.killZoneDetailsTab)
            {
                ResetKillZoneEditor();
            }
            else if(this.interactableDetailsTabControl.SelectedTab == this.oneInteractionItemDetailsTab)
            {
                ResetOIIEditor();
            }
            else if(this.interactableDetailsTabControl.SelectedTab == this.pickableItemDetailsTab)
            {
                ResetPickableEditor();
            }
        }
        #region Collector Editor Code
        void ResetCollectorEditor()
        {
            List<string> aGivableObjs = new List<string>();
            aGivableObjs.Add("Select Collection Object");
            aGivableObjs.AddRange(mGameDetails.GetPickableItemNames(PickableItem.Type.Giveable));
            for (int aI = 0; aI < aGivableObjs.Count; aI++)
            {
                if (mGameDetails.IsGivableAssigned(aGivableObjs[aI]))
                {
                    aGivableObjs.RemoveAt(aI--);
                }
            }
            if(mSelectedCollector != null)
            {
                aGivableObjs.Add(mSelectedCollector.mConditionalObject);
            }
            this.collectorCollectionObjectSelector.DataSource = aGivableObjs;
            this.collectorCollectionObjectSelector.SelectedIndex = 0;
            if (mSelectedCollector != null)
            {
                this.collectorNameTextBox.Text = mSelectedCollector.mName;
                this.collectorStoryTextBox.Text = mSelectedCollector.mStory;
                this.collectorUpdateStoryTextBox.Text = mSelectedCollector.mUpdateStory;
                this.collectorEndUpdateStoryTextBox.Text = mSelectedCollector.mEndStory;
                this.isCollectorVisible.Checked = mSelectedCollector.mIsVisible;
                this.isCollectorInteractable.Checked = mSelectedCollector.mIsInteractable;
                this.collectorCollectionObjectSelector.SelectedItem = mSelectedCollector.mConditionalObject;
                this.currentCollectorsList.SelectedItem = mSelectedCollector.mName;
                return;
            }
            this.collectorNameTextBox.Text = "";
            this.collectorStoryTextBox.Text = "";
            this.collectorUpdateStoryTextBox.Text = "";
            this.collectorEndUpdateStoryTextBox.Text = "";
            this.isCollectorVisible.Checked =
            this.isCollectorInteractable.Checked = false;
            this.collectorCollectionObjectSelector.SelectedIndex = 0;
            this.currentCollectorsList.DataSource = mGameDetails.GetCollectorNames();
            this.currentCollectorsList.SelectedIndex = -1;
        }
        void DeleteSelectedCollector()
        {
            if (mSelectedCollector != null)
            {
                if (string.IsNullOrEmpty(mSelectedCollector.mConditionalObject))
                {
                    PickableItem aItem = mGameDetails.GetPickableItem(PickableItem.Type.Giveable, mSelectedCollector.mConditionalObject);
                    aItem.GetConditionalOf().Remove(mSelectedCollector.mName);
                    mGameDetails.UnAssignGivable(mSelectedCollector.mConditionalObject);

                }
                mGameDetails.DeleteCollector(mSelectedCollector.mName);
                mSelectedCollector = null;
            }
        }
        bool IsCollectorDataValid()
        {
            return !(string.IsNullOrEmpty(this.collectorNameTextBox.Text) || string.IsNullOrEmpty(this.collectorStoryTextBox.Text)
                || string.IsNullOrEmpty(this.collectorUpdateStoryTextBox.Text) || string.IsNullOrEmpty(this.collectorEndUpdateStoryTextBox.Text)
                || this.collectorCollectionObjectSelector.SelectedIndex == 0);
        }
        private void DeleteCollectorDetails_Click(object sender, EventArgs e)
        {
            DeleteSelectedCollector();
            ResetCollectorEditor();
        }
        private void EditCollectorDetails_Click(object sender, EventArgs e)
        {
            if(IsCollectorDataValid())
            {

                if (mSelectedCollector == null && mGameDetails.IsCollectorPresent(this.collectorNameTextBox.Text))
                {
                    return;
                }
                Room aCollectorRoom = null;
                string aCollectorOldName = "";
                if (mSelectedCollector != null && mSelectedCollector.IsInRoom())
                {
                    aCollectorRoom = mGameDetails.GetRoomObject(mSelectedCollector.GetInRoom());
                    aCollectorOldName = mSelectedCollector.mName;
                }
                DeleteSelectedCollector();
                mSelectedCollector = new Collector
                {
                    mName = this.collectorNameTextBox.Text,
                    mStory = this.collectorStoryTextBox.Text,
                    mUpdateStory = this.collectorUpdateStoryTextBox.Text,
                    mEndStory = this.collectorEndUpdateStoryTextBox.Text,
                    mIsVisible = this.isCollectorVisible.Checked,
                    mIsInteractable = this.isCollectorInteractable.Checked,
                    mConditionalObject = (string)this.collectorCollectionObjectSelector.SelectedItem
                };
                mGameDetails.AssignGivable(mSelectedCollector.mConditionalObject);
                PickableItem aItem = mGameDetails.GetPickableItem(PickableItem.Type.Giveable, mSelectedCollector.mConditionalObject);
                aItem.AddConditionalOf(mSelectedCollector.mName);
                if (aCollectorRoom != null)
                {
                    aCollectorRoom.RemoveOldCollectorAndAddNew(aCollectorOldName, mSelectedCollector);
                    mSelectedCollector.SetInRoom(aCollectorRoom.mName);
                }
                mGameDetails.AddCollector(mSelectedCollector);
                mSelectedCollector = null;
            }
            ResetCollectorEditor();
        }
        private void EditSelectedCollector_Click(object sender, EventArgs e)
        {
            if(mSelectedCollector != null)
            {
                mSelectedCollector = null;
            }
            if(this.currentCollectorsList.SelectedIndex == -1)
            {
                return;
            }
            mSelectedCollector = mGameDetails.GetCollectorObject((string)this.currentCollectorsList.SelectedItem);
            ResetCollectorEditor();
            this.currentCollectorsList.SelectedItem = mSelectedCollector.mName;
        }
        #endregion
        #region Enemy Editor Code
        void ResetEnemyEditor()
        {
            List<string> aKillableWeapons = new List<string>();
            aKillableWeapons.Add("Select Killable Weapon");
            aKillableWeapons.AddRange(mGameDetails.GetPickableItemNames(PickableItem.Type.Weapon));
            this.enemyKillableWeaponSelector.DataSource = aKillableWeapons;
            this.enemyKillableWeaponSelector.SelectedIndex = 0;
            if (mSelectedEnemy != null)
            {
                this.enemyNameTextBox.Text = mSelectedEnemy.mName;
                this.enemyStoryTextBox.Text = mSelectedEnemy.mStory;
                this.enemyLifeNumericUpDown.Value = mSelectedEnemy.mLife;
                this.enemyBlockStoryTextBox.Text = mSelectedEnemy.mBlockStory;
                this.enemyAttackStoryTextBox.Text = mSelectedEnemy.mUpdateStory;
                this.enemyDeathStoryTextBox.Text = mSelectedEnemy.mEndStory;
                this.isEnemyVisible.Checked = mSelectedEnemy.mIsVisible;
                this.isEnemyInteractable.Checked = mSelectedEnemy.mIsInteractable;
                this.enemyKillableWeaponSelector.SelectedItem = mSelectedEnemy.mConditionalObject;
                this.currentEnemyList.SelectedItem = mSelectedEnemy.mName;
                return;
            }
            this.enemyNameTextBox.Text = "";
            this.enemyStoryTextBox.Text = "";
            this.enemyLifeNumericUpDown.Value = 1;
            this.enemyBlockStoryTextBox.Text = "";
            this.enemyAttackStoryTextBox.Text = "";
            this.enemyDeathStoryTextBox.Text = "";
            this.isEnemyVisible.Checked =
            this.isEnemyInteractable.Checked = false;
            this.enemyKillableWeaponSelector.SelectedIndex = 0;
            this.currentEnemyList.DataSource = mGameDetails.GetEnemyNames();
            this.currentEnemyList.SelectedIndex = -1;
        }
        void DeleteSelectedEnemy()
        {
            if (mSelectedEnemy != null)
            {
                if(string.IsNullOrEmpty(mSelectedEnemy.mConditionalObject))
                {
                    PickableItem aItem = mGameDetails.GetPickableItem(PickableItem.Type.Weapon, mSelectedEnemy.mConditionalObject);
                    aItem.GetConditionalOf().Remove(mSelectedEnemy.mName);
                }
                mGameDetails.DeleteEnemy(mSelectedEnemy.mName);
                mSelectedEnemy = null;
            }
        }
        bool IsEnemyDataValid()
        {
            return !(string.IsNullOrEmpty(this.enemyNameTextBox.Text) || string.IsNullOrEmpty(this.enemyStoryTextBox.Text)
                || string.IsNullOrEmpty(this.enemyBlockStoryTextBox.Text) || string.IsNullOrEmpty(this.enemyAttackStoryTextBox.Text)
                || string.IsNullOrEmpty(this.enemyDeathStoryTextBox.Text) || this.enemyKillableWeaponSelector.SelectedIndex == 0);
        }
        private void DeleteEnemy_Click(object sender, EventArgs e)
        {
            DeleteSelectedEnemy();
            ResetEnemyEditor();
        }
        private void EditEnemyDetails_Click(object sender, EventArgs e)
        {
            if (IsEnemyDataValid())
            {

                if (mSelectedEnemy == null && mGameDetails.IsEnemyPresent(this.enemyNameTextBox.Text))
                {
                    return;
                }
                Room aEnemyRoom = null;
                string aEnemyOldName = "";
                if (mSelectedEnemy != null && mSelectedEnemy.IsInRoom())
                {
                    aEnemyRoom = mGameDetails.GetRoomObject(mSelectedEnemy.GetInRoom());
                    aEnemyOldName = mSelectedEnemy.mName;
                }
                DeleteSelectedEnemy();
                mSelectedEnemy = new Enemy
                {
                    mName = this.enemyNameTextBox.Text,
                    mStory = this.enemyStoryTextBox.Text,
                    mLife = (int)this.enemyLifeNumericUpDown.Value,
                    mBlockStory = this.enemyBlockStoryTextBox.Text,
                    mUpdateStory = this.enemyAttackStoryTextBox.Text,
                    mEndStory = this.enemyDeathStoryTextBox.Text,
                    mIsVisible = this.isEnemyVisible.Checked,
                    mIsInteractable = this.isEnemyInteractable.Checked,
                    mConditionalObject = (string)this.enemyKillableWeaponSelector.SelectedItem
                };
                if (aEnemyRoom != null)
                {
                    aEnemyRoom.RemoveOldEnemyAndAddNew(aEnemyOldName, mSelectedEnemy);
                    mSelectedEnemy.SetInRoom(aEnemyRoom.mName);
                }
                PickableItem aItem = mGameDetails.GetPickableItem(PickableItem.Type.Weapon, mSelectedEnemy.mConditionalObject);
                aItem.AddConditionalOf(mSelectedEnemy.mName);
                mGameDetails.AddEnemy(mSelectedEnemy);
                mSelectedEnemy = null;
            }
            ResetEnemyEditor();
        }
        private void EditSelectedEnemy_Click(object sender, EventArgs e)
        {
            if (mSelectedEnemy != null)
            {
                mSelectedEnemy = null;
            }
            if(this.currentEnemyList.SelectedIndex == -1)
            {
                return;
            }
            mSelectedEnemy = mGameDetails.GetEnemyObject((string)this.currentEnemyList.SelectedItem);
            ResetEnemyEditor();
            this.currentEnemyList.SelectedItem = mSelectedEnemy.mName;
        }
        #endregion
        #region Kill Zone Editor Code
        void ResetKillZoneEditor()
        {
            List<string> aDisablingObjects = new List<string>();
            aDisablingObjects.Add("No Disabling Object");
            aDisablingObjects.AddRange(mGameDetails.GetPickableItemNames(PickableItem.Type.Wearable));
            aDisablingObjects.AddRange(mGameDetails.GetPickableItemNames(PickableItem.Type.Weapon));
            aDisablingObjects.AddRange(mGameDetails.GetPickableItemNames(PickableItem.Type.Shield));
            this.killZoneDisablerSelector.DataSource = aDisablingObjects;
            this.killZoneDisablerSelector.SelectedIndex = 0;
            if (mSelectedKillZone != null)
            {
                this.killZoneNameTextBox.Text = mSelectedKillZone.mName;
                this.killZoneStoryTextBox.Text = mSelectedKillZone.mStory;
                this.killZoneAttackStoryTextBox.Text = mSelectedKillZone.mUpdateStory;
                this.killZoneDisablingStoryTextBox.Text = mSelectedKillZone.mEndStory;
                this.isKillZoneVisible.Checked = mSelectedKillZone.mIsVisible;
                this.isKillZoneInteractable.Checked = mSelectedKillZone.mIsInteractable;
                if(!string.IsNullOrEmpty(mSelectedKillZone.mConditionalObject))
                {
                    this.killZoneDisablerSelector.SelectedItem = mSelectedKillZone.mConditionalObject;
                }
                this.currentKillZonesList.SelectedItem = mSelectedKillZone.mName;
                return;
            }
            this.killZoneNameTextBox.Text = "";
            this.killZoneStoryTextBox.Text = "";
            this.killZoneAttackStoryTextBox.Text = "";
            this.killZoneDisablingStoryTextBox.Text = "";
            this.isKillZoneVisible.Checked =
            this.isKillZoneInteractable.Checked = false;
            this.killZoneDisablerSelector.SelectedIndex = 0;
            this.currentKillZonesList.DataSource = mGameDetails.GetKillZoneNames();
            this.currentKillZonesList.SelectedIndex = -1;
        }
        void DeleteSelectedKillZone()
        {
            if (mSelectedKillZone != null)
            {
                if(string.IsNullOrEmpty(mSelectedKillZone.mConditionalObject))
                {
                    PickableItem aItem = mGameDetails.GetPickableItem(mSelectedKillZone.mConditionalObject);
                    aItem.GetConditionalOf().Remove(mSelectedKillZone.mName);
                }
                mGameDetails.DeleteKillZone(mSelectedKillZone.mName);
                mSelectedKillZone = null;
            }
        }
        bool IsKillZoneDataValid()
        {
            return !(string.IsNullOrEmpty(this.killZoneNameTextBox.Text) || string.IsNullOrEmpty(this.killZoneStoryTextBox.Text)
                || string.IsNullOrEmpty(this.killZoneAttackStoryTextBox.Text) || string.IsNullOrEmpty(this.killZoneDisablingStoryTextBox.Text));
        }
        private void DeleteKillZone_Click(object sender, EventArgs e)
        {
            DeleteSelectedKillZone();
            ResetKillZoneEditor();
        }
        private void EditKillZoneDetails_Click(object sender, EventArgs e)
        {
            if (IsKillZoneDataValid())
            {

                if (mSelectedKillZone == null && mGameDetails.IsKillZonePresent(this.killZoneNameTextBox.Text))
                {
                    return;
                }
                Room aKillZoneRoom = null;
                string aKillZoneOldName = "";
                if (mSelectedKillZone != null && mSelectedKillZone.IsInRoom())
                {
                    aKillZoneRoom = mGameDetails.GetRoomObject(mSelectedKillZone.GetInRoom());
                    aKillZoneOldName = mSelectedKillZone.mName;
                }
                DeleteSelectedKillZone();
                mSelectedKillZone = new KillZone
                {
                    mName = this.killZoneNameTextBox.Text,
                    mStory = this.killZoneStoryTextBox.Text,
                    mUpdateStory = this.killZoneAttackStoryTextBox.Text,
                    mEndStory = this.killZoneDisablingStoryTextBox.Text,
                    mIsVisible = this.isKillZoneVisible.Checked,
                    mIsInteractable = this.isKillZoneInteractable.Checked
                };
                if(this.killZoneDisablerSelector.SelectedIndex != 0)
                {
                    mSelectedKillZone.mConditionalObject = (string)this.killZoneDisablerSelector.SelectedItem;
                    PickableItem aItem = mGameDetails.GetPickableItem(mSelectedKillZone.mConditionalObject);
                    aItem.AddConditionalOf(mSelectedKillZone.mName);
                }
                if (aKillZoneRoom != null)
                {
                    aKillZoneRoom.RemoveOldKillZoneAndAddNew(aKillZoneOldName, mSelectedKillZone);
                    mSelectedKillZone.SetInRoom(aKillZoneRoom.mName);
                }
                mGameDetails.AddKillZone(mSelectedKillZone);
                mSelectedKillZone = null;
            }
            ResetKillZoneEditor();

        }
        private void EditSelectedKillZone_Click(object sender, EventArgs e)
        {
            if (mSelectedKillZone != null)
            {
                mSelectedKillZone = null;
            }
            if(this.currentKillZonesList.SelectedIndex == -1)
            {
                return;
            }
            mSelectedKillZone = mGameDetails.GetKillZoneObject((string)this.currentKillZonesList.SelectedItem);
            ResetKillZoneEditor();
            this.currentKillZonesList.SelectedItem = mSelectedKillZone.mName;
        }
        #endregion
        #region OII Editor Code
        void ResetOIIEditor()
        {
            this.oIITypeSelector.DataSource = Enum.GetValues(typeof(OneInteractionItem.Type));
            this.oIITypeSelector.SelectedIndex = 0;
            if (mSelectedOIItem != null)
            {
                this.oIINameTextBox.Text = mSelectedOIItem.mName;
                this.oIIStoryTextBox.Text = mSelectedOIItem.mStory;
                this.oIIUpdateStoryTextBox.Text = mSelectedOIItem.mUpdateStory;
                this.oIIEndStoryTextBox.Text = mSelectedOIItem.mEndStory;
                this.isOIIVisible.Checked = mSelectedOIItem.mIsVisible;
                this.isOIIInteractable.Checked = mSelectedOIItem.mIsInteractable;
                this.oIITypeSelector.SelectedItem = mSelectedOIItem.mType;
                this.currentOIIList.SelectedItem = mSelectedOIItem.mName;
                return;
            }
            this.oIINameTextBox.Text = "";
            this.oIIStoryTextBox.Text = "";
            this.oIIUpdateStoryTextBox.Text = "";
            this.oIIEndStoryTextBox.Text = "";
            this.isOIIVisible.Checked =
            this.isOIIInteractable.Checked = false;
            this.oIITypeSelector.SelectedIndex = 0;
            this.currentOIIList.DataSource = mGameDetails.GetOIItemNames();
            this.currentOIIList.SelectedIndex = -1;
        }
        void DeleteSelectedOIItem()
        {
            if (mSelectedOIItem != null)
            {
                mGameDetails.DeleteOIItem(mSelectedOIItem.mName);
                mSelectedOIItem = null;
            }
        }
        bool IsOIItemDataValid()
        {
            return !(string.IsNullOrEmpty(this.oIINameTextBox.Text) || string.IsNullOrEmpty(this.oIIStoryTextBox.Text)
                || string.IsNullOrEmpty(this.oIIUpdateStoryTextBox.Text) || string.IsNullOrEmpty(this.oIIEndStoryTextBox.Text));
        }
        private void DeleteOII_Click(object sender, EventArgs e)
        {
            DeleteSelectedOIItem();
            ResetOIIEditor();
        }
        private void EditOIIDetails_Click(object sender, EventArgs e)
        {
            if (IsOIItemDataValid())
            {

                if (mSelectedOIItem == null && mGameDetails.IsOIItemPresent(this.oIINameTextBox.Text))
                {
                    return;
                }
                Room aOIRoom = null;
                string aOIOldName = "";
                if (mSelectedOIItem != null && mSelectedOIItem.IsInRoom())
                {
                    aOIRoom = mGameDetails.GetRoomObject(mSelectedOIItem.GetInRoom());
                    aOIOldName = mSelectedOIItem.mName;
                }
                DeleteSelectedOIItem();
                mSelectedOIItem = new OneInteractionItem
                {
                    mName = this.oIINameTextBox.Text,
                    mStory = this.oIIStoryTextBox.Text,
                    mUpdateStory = this.oIIUpdateStoryTextBox.Text,
                    mEndStory = this.oIIEndStoryTextBox.Text,
                    mType = (OneInteractionItem.Type) this.oIITypeSelector.SelectedItem,
                    mIsVisible = this.isOIIVisible.Checked,
                    mIsInteractable = this.isOIIInteractable.Checked
                };
                if (aOIRoom != null)
                {
                    aOIRoom.RemoveOldOIItemAndAddNew(aOIOldName, mSelectedOIItem);
                    mSelectedOIItem.SetInRoom(aOIRoom.mName);
                }
                mGameDetails.AddOIItem(mSelectedOIItem);
                mSelectedOIItem = null;
            }
            ResetOIIEditor();
        }
        private void EditSelectedOII_Click(object sender, EventArgs e)
        {
            if (mSelectedOIItem != null)
            {
                mSelectedOIItem = null;
            }
            if(this.currentOIIList.SelectedIndex == -1)
            {
                return;
            }
            mSelectedOIItem = mGameDetails.GetOIItemObject((string)this.currentOIIList.SelectedItem);
            ResetOIIEditor();
            this.currentOIIList.SelectedItem = mSelectedOIItem.mName;
        }
        #endregion
        #region Pickable Item Editor Code
        void ResetPickableEditor()
        {
            this.pickableItemTypeSelector.DataSource = Enum.GetValues(typeof(PickableItem.Type));
            this.pickableItemTypeSelector.SelectedIndex = 0;
            if (mSelectedPickable != null)
            {
                this.pickableItemNameTextBox.Text = mSelectedPickable.mName;
                this.pickableItemStoryTextBox.Text = mSelectedPickable.mStory;
                this.isPickableItemVisible.Checked = mSelectedPickable.mIsVisible;
                this.isPickableItemInteractable.Checked = mSelectedPickable.mIsInteractable;
                this.pickableItemTypeSelector.SelectedItem = mSelectedPickable.mType;
                this.currentPickableItemsList.SelectedItem = mSelectedPickable.mName;
                return;
            }
            this.pickableItemNameTextBox.Text = "";
            this.pickableItemStoryTextBox.Text = "";
            this.isPickableItemVisible.Checked =
            this.isPickableItemInteractable.Checked = false;
            this.pickableItemTypeSelector.SelectedIndex = 0;
            this.currentPickableItemsList.DataSource = mGameDetails.GetPickableItemNames();
            this.currentPickableItemsList.SelectedIndex = -1;
        }
        void DeleteSelectedPickable()
        {
            if (mSelectedPickable != null)
            {
                mGameDetails.DeletePickableItem(mSelectedPickable.mType,mSelectedPickable.mName);
                mSelectedPickable = null;
            }
        }
        bool IsPickableDataValid()
        {
            return !(string.IsNullOrEmpty(this.pickableItemNameTextBox.Text) || string.IsNullOrEmpty(this.pickableItemStoryTextBox.Text));
        }
        private void DeletePickableItem_Click(object sender, EventArgs e)
        {
            DeleteSelectedPickable();
            ResetPickableEditor();
        }
        private void EditPickableItemDetails_Click(object sender, EventArgs e)
        {
            if (IsPickableDataValid())
            {

                if (mSelectedPickable == null && mGameDetails.IsPickableItemPresent(this.pickableItemNameTextBox.Text))
                {
                    return;
                }
                Room aPickableRoom = null;
                string aPickableOldName = "";
                if (mSelectedPickable != null && mSelectedPickable.IsInRoom())
                {
                    aPickableRoom = mGameDetails.GetRoomObject(mSelectedPickable.GetInRoom());
                    aPickableOldName = mSelectedPickable.mName;
                }
                List<string> aConditionalOf = null;
                if(mSelectedPickable != null)
                {
                    aConditionalOf = mSelectedPickable.GetConditionalOf();
                }
                DeleteSelectedPickable();
                mSelectedPickable = new PickableItem
                {
                    mName = this.pickableItemNameTextBox.Text,
                    mStory = this.pickableItemStoryTextBox.Text,
                    mType = (PickableItem.Type)this.pickableItemTypeSelector.SelectedItem,
                    mIsVisible = this.isPickableItemVisible.Checked,
                    mIsInteractable = this.isPickableItemInteractable.Checked
                };
                if (aPickableRoom != null)
                {
                    aPickableRoom.RemoveOldPickableAndAddNew(aPickableOldName, mSelectedPickable);
                    mSelectedPickable.SetInRoom(aPickableRoom.mName);
                }
                if(aConditionalOf != null)
                {
                    if(aConditionalOf.Count > 0)
                    {
                        mGameDetails.UpdatePickableName(aConditionalOf, mSelectedPickable.mName);
                        mSelectedPickable.AddConditionalOf(aConditionalOf);
                    }
                }
                mGameDetails.AddPickable(mSelectedPickable);
                mSelectedPickable = null;
            }
            ResetPickableEditor();
        }
        private void EditSelectedPickableItem_Click(object sender, EventArgs e)
        {
            if (mSelectedPickable != null)
            {
                mSelectedPickable = null;
            }
            if(this.currentPickableItemsList.SelectedIndex == -1)
            {
                return;
            }
            mSelectedPickable = mGameDetails.GetPickableItem((string)this.currentPickableItemsList.SelectedItem);
            ResetPickableEditor();
            this.currentPickableItemsList.SelectedItem = mSelectedPickable.mName;
        }



        #endregion

        #endregion
        #region Open And Save File
        private void OpenGameJSONData_Click(object sender, CancelEventArgs e)
        {
            try
            {
                using(System.IO.StreamReader aReader = new System.IO.StreamReader(openGameJSONData.FileName))
                {
                    mGameDetails.ConvertFromJSON(aReader.ReadToEnd());
                }
            }
            catch(Exception aE)
            {
                Console.WriteLine(aE.StackTrace);
            }
        }
        private void SaveGameJSONData_Click(object sender, CancelEventArgs e)
        {
            try
            {
                using(System.IO.StreamWriter aWriter = new System.IO.StreamWriter(saveGameJSONData.FileName,false))
                {
                    aWriter.WriteLine(mGameDetails.ConvertDataToJSON());
                }
            }
            catch(Exception aE)
            {
                Console.WriteLine(aE.StackTrace);
            }
        }
        #endregion
    }
}
