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
        private void DeleteRoomDetails_Click(object sender, EventArgs e)
        {

        }
        private void EditRoomDetails_Click(object sender, EventArgs e)
        {

        }
        private void EditSelectedRoom_Click(object sender, EventArgs e)
        {

        }
        private void ColCurRoomList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void ColCollectorList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void EditCollectorUpdatableDetails_Click(object sender, EventArgs e)
        {

        }
        private void EnCurRoomList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void EnEnemyList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void EditEnemyUpdatableDetails_Click(object sender, EventArgs e)
        {

        }
        private void KzCurRoomList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void KzKillZoneList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void EditKillZoneUpdatableDetails_Click(object sender, EventArgs e)
        {

        }
        private void OIICurRoomList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void OIIItemList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void EditOIIUpdatableDetails_Click(object sender, EventArgs e)
        {

        }
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

            }
            else if(this.interactableDetailsTabControl.SelectedTab == this.killZoneDetailsTab)
            {

            }
            else if(this.interactableDetailsTabControl.SelectedTab == this.oneInteractionItemDetailsTab)
            {

            }
            else if(this.interactableDetailsTabControl.SelectedTab == this.pickableItemDetailsTab)
            {

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
                aGivableObjs.Add(mSelectedCollector.mCollectionObject.mName);
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
                this.collectorCollectionObjectSelector.SelectedItem = mSelectedCollector.mCollectionObject.mName;
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
                if (mSelectedCollector.mCollectionObject != null)
                {
                    mGameDetails.UnAssignGivable(mSelectedCollector.mCollectionObject.mName);
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
                    mCollectionObject = mGameDetails.GetPickableItem(PickableItem.Type.Giveable,
                    (string)this.collectorCollectionObjectSelector.SelectedItem)
                };
                mGameDetails.AssignGivable(mSelectedCollector.mCollectionObject.mName);
                if(aCollectorRoom != null)
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
        private void DeleteEnemy_Click(object sender, EventArgs e)
        {

        }
        private void EditEnemyDetails_Click(object sender, EventArgs e)
        {

        }
        private void EditSelectedEnemy_Click(object sender, EventArgs e)
        {

        }
        private void DeleteKillZone_Click(object sender, EventArgs e)
        {

        }
        private void EditKillZoneDetails_Click(object sender, EventArgs e)
        {

        }
        private void EditSelectedKillZone_Click(object sender, EventArgs e)
        {

        }
        private void DeleteOII_Click(object sender, EventArgs e)
        {

        }
        private void EditOIIDetails_Click(object sender, EventArgs e)
        {

        }
        private void EditSelectedOII_Click(object sender, EventArgs e)
        {

        }
        private void DeletePickableItem_Click(object sender, EventArgs e)
        {

        }
        private void EditPickableItemDetails_Click(object sender, EventArgs e)
        {

        }
        private void EditSelectedPickableItem_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
