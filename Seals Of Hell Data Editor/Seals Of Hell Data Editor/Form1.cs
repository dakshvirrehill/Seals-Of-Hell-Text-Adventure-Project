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
        public SealsOfHellMain()
        {
            mGameDetails = new DataHandler();
            InitializeComponent();
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
            this.gameStartTabControl.Visible = true;
            this.gameStartTabControl.SelectedIndex = 0;
        }
        private void AddNewRegionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void EditRoomDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void EditInteractablesDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region Game Start Data
        private void SetAllGameStartData(object sender, EventArgs e)
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
        #endregion
        #region Interactables Data
        private void DeleteCollectorDetails_Click(object sender, EventArgs e)
        {

        }
        private void EditCollectorDetails_Click(object sender, EventArgs e)
        {

        }
        private void EditSelectedCollector_Click(object sender, EventArgs e)
        {

        }
        private void DeleteEnemy_Click(object sender, EventArgs e)
        {

        }
        private void EditEnemyDetails_Click(object sender, EventArgs e)
        {

        }
        private void EditSelectedEnemy_Click(object sender, EventArgs e)
        {

        }
        #endregion


    }
}
