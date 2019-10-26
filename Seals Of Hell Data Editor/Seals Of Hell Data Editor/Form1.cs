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
        public SealsOfHellMain()
        {
            mGameDetails = new DataHandler();
            InitializeComponent();
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
            this.gameStartTabControl.Visible = 
            this.interactableDetailsTabControl.Visible = 
            this.regionTabControl.Visible =
            this.roomTabControl.Visible = false;
        }

        #region Main Menu
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void EditGameStartDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CleanUpAtEditorChange();
            this.gameStartTabControl.Visible = true;
            this.gameStartTabControl.SelectedIndex = 0;
        }
        private void AddNewRegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CleanUpAtEditorChange();
            this.regionTabControl.Visible = true;
            this.regionTabControl.SelectedIndex = 0;
        }
        private void EditRoomDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CleanUpAtEditorChange();
            this.roomTabControl.Visible = true;
            this.roomTabControl.SelectedIndex = 0;
        }
        private void EditInteractablesDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CleanUpAtEditorChange();
            this.interactableDetailsTabControl.Visible = true;
            this.interactableDetailsTabControl.SelectedIndex = 0;
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
                this.firstRoomNameTextBox.Text = mSelectedRoom.mStory;
                //add interactable code
            }
            else if(this.gameStartTabControl.SelectedTab == this.treasureCollectorTab)
            {
                //add treasure collector setup code
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
            //add code to add in dictionary
            mSelectedRegion.mRooms.Add(mSelectedRegion.mEntryRoom, mSelectedRoom);
        }
        private void EditTreasureCollectorDetails_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region Region Data
        private void DeleteRegionDetails_Click(object sender, EventArgs e)
        {

        }
        private void EditRegionDetails_Click(object sender, EventArgs e)
        {

        }
        private void EditSelectedRegion_Click(object sender, EventArgs e)
        {

        }
        private void EditSelectedGateway_Click(object sender, EventArgs e)
        {

        }
        private void EditGatewayDetails_Click(object sender, EventArgs e)
        {

        }
        private void DeleteGatewayDetails_Click(object sender, EventArgs e)
        {

        }
        private void EditPortalDetails_Click(object sender, EventArgs e)
        {

        }
        private void AddPortalsToRooms_Click(object sender, EventArgs e)
        {

        }
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
                return;
            }
            this.roomNameTextBox.Text = "";
            this.roomStoryTextBox.Text = "";
            SetListBoxListAndSelection(this.roomCollectorsList, aAllCollectorNames, aRCNames);
            SetListBoxListAndSelection(this.roomEnemiesList, aAllEnemyNames, aRENames);
            SetListBoxListAndSelection(this.roomKillZonesList, aAllKillZoneNames, aRKZNames);
            SetListBoxListAndSelection(this.roomPickableItemsList, aAllPickableNames, aRPNames);
            SetListBoxListAndSelection(this.roomOIIList, aAllOIItemNames, aROIINames);
            this.currentRoomsList.DataSource = mGameDetails.GetRoomNames();
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
            return string.IsNullOrEmpty(this.roomNameTextBox.Text) || string.IsNullOrEmpty(this.roomStoryTextBox.Text);
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
        }
        private void ColCurRoomList_SelectedIndexChanged(object sender, EventArgs e)
        {
            mSelectedRoom = mGameDetails.GetRoomObject((string)this.colCurRoomList.SelectedItem);
            if(mSelectedRoom != null)
            {
                this.colCollectorList.DataSource = new List<string>(mSelectedRoom.mCollectors.Keys);
            }
        }
        private void ColCollectorList_SelectedIndexChanged(object sender, EventArgs e)
        {
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
        }
        private void EnCurRoomList_SelectedIndexChanged(object sender, EventArgs e)
        {
            mSelectedRoom = mGameDetails.GetRoomObject((string)this.enCurRoomList.SelectedItem);
            if (mSelectedRoom != null)
            {
                this.enEnemyList.DataSource = new List<string>(mSelectedRoom.mEnemies.Keys);
            }
        }
        private void EnEnemyList_SelectedIndexChanged(object sender, EventArgs e)
        {
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
        }
        private void KzCurRoomList_SelectedIndexChanged(object sender, EventArgs e)
        {
            mSelectedRoom = mGameDetails.GetRoomObject((string)this.kzCurRoomList.SelectedItem);
            if (mSelectedRoom != null)
            {
                this.kzKillZoneList.DataSource = new List<string>(mSelectedRoom.mKillZones.Keys);
            }
        }
        private void KzKillZoneList_SelectedIndexChanged(object sender, EventArgs e)
        {
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
        }
        private void OIICurRoomList_SelectedIndexChanged(object sender, EventArgs e)
        {
            mSelectedRoom = mGameDetails.GetRoomObject((string)this.oIICurRoomList.SelectedItem);
            if (mSelectedRoom != null)
            {
                this.oIIItemList.DataSource = new List<string>(mSelectedRoom.mOneInteractionItems.Keys);
            }
        }
        private void OIIItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            if(this.interactableDetailsTabControl.SelectedTab == this.collectorDetailsTab)
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
                return;
            }
            this.pickableItemNameTextBox.Text = "";
            this.pickableItemStoryTextBox.Text = "";
            this.isPickableItemVisible.Checked =
            this.isPickableItemInteractable.Checked = false;
            this.pickableItemTypeSelector.SelectedIndex = 0;
            this.currentPickableItemsList.DataSource = mGameDetails.GetPickableItemNames();
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
                if(aConditionalOf != null || aConditionalOf.Count > 0)
                {
                    mGameDetails.UpdatePickableName(aConditionalOf, mSelectedPickable.mName);
                    mSelectedPickable.AddConditionalOf(aConditionalOf);
                }
                mGameDetails.AddOIItem(mSelectedOIItem);
                mSelectedOIItem = null;
            }
            ResetOIIEditor();
        }
        private void EditSelectedPickableItem_Click(object sender, EventArgs e)
        {
            if (mSelectedPickable != null)
            {
                mSelectedPickable = null;
            }
            mSelectedPickable = mGameDetails.GetPickableItem((string)this.currentPickableItemsList.SelectedItem);
            ResetPickableEditor();
            this.currentPickableItemsList.SelectedItem = mSelectedPickable.mName;
        }
        #endregion

        #endregion
    }
}
