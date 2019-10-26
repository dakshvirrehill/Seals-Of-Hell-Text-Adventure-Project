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
                ResetEnemyEditor();
            }
            else if(this.interactableDetailsTabControl.SelectedTab == this.killZoneDetailsTab)
            {
                ResetKillZoneEditor();
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
                if (mSelectedCollector.mConditionalObject != null)
                {
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
                mGameDetails.DeleteKillZone(mSelectedKillZone.mName);
                mSelectedKillZone = null;
            }
        }
        bool IsKillZoneDataValid()
        {
            return !(string.IsNullOrEmpty(this.killZoneNameTextBox.Text) || string.IsNullOrEmpty(this.killZoneStoryTextBox.Text)
                || string.IsNullOrEmpty(this.killZoneAttackStoryTextBox.Text) || string.IsNullOrEmpty(this.killZoneDisablingStoryTextBox.Text);
        }
        private void DeleteKillZone_Click(object sender, EventArgs e)
        {
            DeleteSelectedKillZone();
            ResetKillZoneEditor();
        }
        private void EditKillZoneDetails_Click(object sender, EventArgs e)
        {
            if (mSelectedKillZone != null)
            {
                mSelectedKillZone = null;
            }
            mSelectedKillZone = mGameDetails.GetKillZoneObject((string)this.currentKillZonesList.SelectedItem);
            ResetKillZoneEditor();
            this.currentKillZonesList.SelectedItem = mSelectedKillZone.mName;
        }
        private void EditSelectedKillZone_Click(object sender, EventArgs e)
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
        #endregion
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
