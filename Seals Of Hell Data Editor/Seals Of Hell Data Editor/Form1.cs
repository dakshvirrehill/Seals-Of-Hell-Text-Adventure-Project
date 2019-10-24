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
        TreasureCollector mTreasureCollector;
        string mCurrentFilePath;
        string mCurrentFileName;

        public SealsOfHellMain()
        {
            mGameDetails = new DataHandler();
            mTreasureCollector = new TreasureCollector();
            InitializeComponent();
        }
        #region HELPERS
        void MakeAllGroupsInVisible()
        {
            this.RegionTabs.Visible = false;
            this.RoomTabs.Visible = false;
            this.gameDetailsGroup.Visible = false;
        }
        void ResetToSelectedRoom()
        {
            this.EditRoomName.Text = mSelectedRoom.mName;
            this.EditRoomStory.Text = mSelectedRoom.mStory;
            foreach (var aComboItem in this.EditRoomRegion.Items)
            {
                if (((string)aComboItem).Equals(mSelectedRoom.mRegion))
                {
                    this.EditRoomRegion.SelectedItem = aComboItem;
                    break;
                }
            }
        }
        void UpdateRoomNamesInSelector()
        {
            string aRegionN = (string)this.EditRoomRegionSelector.SelectedItem;
            this.EditRoomNameSelector.DataSource = new List<string>(mGameDetails.mRegionDetails[aRegionN].mRooms.Keys);
        }
        #endregion
        #region MAIN MENU
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ChooseFile.ShowDialog();
        }
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SaveFile.FileName = mCurrentFileName;
            this.SaveFile.ShowDialog();
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void RegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeAllGroupsInVisible();
            this.RegionTabs.Visible = true;
            this.RegionTabs.SelectedIndex = 0;
            if(!string.IsNullOrEmpty(mGameDetails.mFirstRegion))
            {
                this.IsEntryRegion.Enabled = false;
                this.EditIsEntryRegion.Enabled = false;
            }
        }
        private void RoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeAllGroupsInVisible();
            this.RoomTabs.Visible = true;
            this.RoomTabs.SelectedIndex = 0;
            this.NewRoomRegionSelector.DataSource = new List<string>(mGameDetails.mRegionDetails.Keys);
        }
        private void GameDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeAllGroupsInVisible();
            this.gameDetailsGroup.Visible = true;
            this.gameDetailsGroup.SelectedIndex = 0;
            this.gameNameText.Text = mGameDetails.mName;
            this.gameStoryText.Text = mGameDetails.mStory;
        }
        #endregion
        #region OPEN AND SAVE
        private void OpenDataFile(object sender, CancelEventArgs e)
        {
            if(!mCurrentFilePath.Equals(this.ChooseFile.FileName))
            {
                mCurrentFilePath = this.ChooseFile.FileName;
            }
            if(!mCurrentFileName.Equals(this.ChooseFile.SafeFileName))
            {
                mCurrentFileName = this.ChooseFile.SafeFileName;
                this.Text = "Seals Of Hell Data Editor - " + mCurrentFileName;
            }
            try
            {
                using (System.IO.StreamReader aReader = new System.IO.StreamReader(mCurrentFilePath))
                {
                    mGameDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<DataHandler>(aReader.ReadToEnd());
                }
                MakeAllGroupsInVisible();
            }
            catch(Exception aE)
            {
                Console.WriteLine("Error:\n{0}\n{1}", aE.Message, aE.StackTrace);
            }
        }

        private void SaveDataFile(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(this.SaveFile.FileName))
            {
                return;
            }
            if(!mGameDetails.IsValid())
            {
                return;
            }
            try
            {
                using (System.IO.StreamWriter aWriter = new System.IO.StreamWriter(this.SaveFile.FileName, false))
                {
                    aWriter.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(mGameDetails,Newtonsoft.Json.Formatting.Indented));
                }
            }
            catch(Exception aE)
            {
                Console.WriteLine("Error:\n{0}\n{1}", aE.Message, aE.StackTrace);
            }
            
        }
        #endregion
        #region REGION DATA EDITOR CODE
        private void AddRegionButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.AddRegionTextBox.Text) || string.IsNullOrEmpty(this.RegionStoryTextBox.Text))
            {
                return;
            }
            string aNewRegion = this.AddRegionTextBox.Text;
            if (mGameDetails.mRegionDetails.ContainsKey(aNewRegion))
            {
                this.AddRegionTextBox.Text = "";
                this.RegionStoryTextBox.Text = "";
                return;
            }
            if(this.IsEntryRegion.Checked)
            {
                mGameDetails.mFirstRegion = aNewRegion;
                this.IsEntryRegion.Enabled = false;
            }
            mGameDetails.mRegionDetails.Add(aNewRegion, new Region());
            mGameDetails.mRegionDetails[aNewRegion].mName = aNewRegion;
            mGameDetails.mRegionDetails[aNewRegion].mStory = this.RegionStoryTextBox.Text;
            mGameDetails.mRegionDetails[aNewRegion].AddDefaultRoom();

            this.AddRegionTextBox.Text = "";
            this.RegionStoryTextBox.Text = "";
            this.IsEntryRegion.Checked = false;
        }
        private void SetEditRegionTextBox(object sender, EventArgs e)
        {
            this.EditCurrentRegionTextBox.Text = (string)this.EditRegionsList.SelectedItem;
            this.EditRegionStoryTBox.Text = mGameDetails.mRegionDetails[this.EditCurrentRegionTextBox.Text].mStory;

            this.EditIsEntryRegion.Enabled = 
            (this.EditCurrentRegionTextBox.Text.Equals(mGameDetails.mFirstRegion) || string.IsNullOrEmpty(mGameDetails.mFirstRegion));
            this.EditIsEntryRegion.Checked = this.EditCurrentRegionTextBox.Text.Equals(mGameDetails.mFirstRegion);

            mSelectedRegion = mGameDetails.mRegionDetails[this.EditCurrentRegionTextBox.Text];
        }
        private void EditRegion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.EditCurrentRegionTextBox.Text))
            {
                this.EditCurrentRegionTextBox.Text = mSelectedRegion.mName;
                return;
            }
            if(this.EditCurrentRegionTextBox.Text == mSelectedRegion.mName)
            {
                if(mSelectedRegion.mStory == this.EditRegionStoryTBox.Text)
                {
                    if(mSelectedRegion.mName == mGameDetails.mFirstRegion && this.EditIsEntryRegion.Checked)
                    {
                        return;
                    }
                    else if(mSelectedRegion.mName != mGameDetails.mFirstRegion && !this.EditIsEntryRegion.Checked)
                    {
                        return;
                    }
                    else
                    {
                        mGameDetails.mFirstRegion = "";
                    }

                }
            }
            mGameDetails.mRegionDetails.Remove(mSelectedRegion.mName);
            mSelectedRegion.mName = this.EditCurrentRegionTextBox.Text;
            mSelectedRegion.mStory = this.EditRegionStoryTBox.Text;
            if(this.EditIsEntryRegion.Checked && string.IsNullOrEmpty(mGameDetails.mFirstRegion))
            {
                mGameDetails.mFirstRegion = mSelectedRegion.mName;
            }
            mGameDetails.mRegionDetails.Add(mSelectedRegion.mName, mSelectedRegion);
            this.EditRegionsList.DataSource = new List<string>(mGameDetails.mRegionDetails.Keys);
        }
        private void ResetEditableRegionsList(object sender, EventArgs e)
        {
            if(this.RegionTabs.SelectedTab != this.EditRegionsTab)
            {
                return;
            }
            this.EditRegionsList.DataSource = new List<string>(mGameDetails.mRegionDetails.Keys);
        }
        #endregion
        #region ROOM DATA EDITOR CODE
        private void NewRoomBtn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.NewRoomNameTBox.Text))
            {
                return;
            }
            string aRegionN = (string)this.NewRoomRegionSelector.SelectedItem;
            if(!mGameDetails.mRegionDetails.ContainsKey(aRegionN))
            {
                return;
            }
            Region aRegion = mGameDetails.mRegionDetails[aRegionN];
            string aRoomKey = aRegion.mName + "_" + this.NewRoomNameTBox.Text;
            if (aRegion.mRooms.ContainsKey(aRoomKey))
            {
                return;
            }
            aRegion.mRooms.Add(aRoomKey,new Room());
            aRegion.mRooms[aRoomKey].mName = this.NewRoomNameTBox.Text;
            aRegion.mRooms[aRoomKey].mStory = this.NewRoomStory.Text;
            aRegion.mRooms[aRoomKey].mRegion = aRegion.mName;
            this.NewRoomNameTBox.Text = "";
            this.NewRoomStory.Text = "";
            this.NewRoomRegionSelector.SelectedIndex = 0;
        }
        private void SaveRoomEdit_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.EditRoomName.Text) || 
                mGameDetails.mRegionDetails[(string)this.EditRoomRegion.SelectedItem].mRooms.ContainsKey((string)this.EditRoomRegion.SelectedItem + "_" + this.EditRoomName.Text))
            {
                ResetToSelectedRoom();
                return;
            }
            mGameDetails.mRegionDetails[mSelectedRoom.mRegion].mRooms.Remove(mSelectedRoom.mRegion+"_"+mSelectedRoom.mName);
            mSelectedRoom.mName = this.EditRoomName.Text;
            mSelectedRoom.mRegion = (string)this.EditRoomRegion.SelectedItem;
            mSelectedRoom.mStory = this.EditRoomStory.Text;
            mGameDetails.mRegionDetails[mSelectedRoom.mRegion].mRooms.Add(mSelectedRoom.mRegion + "_" + mSelectedRoom.mName, mSelectedRoom);
            UpdateRoomNamesInSelector();
        }
        private void UpdateRegionsAndRooms(object sender, EventArgs e)
        {
            if(this.RoomTabs.SelectedTab  != this.EditCurrentRoomsTab)
            {
                return;
            }
            this.EditRoomRegionSelector.DataSource = new List<string>(mGameDetails.mRegionDetails.Keys);
        }
        private void UpdateRoomNames(object sender, EventArgs e)
        {
            UpdateRoomNamesInSelector();
        }
        private void PresetEditRoomData(object sender, EventArgs e)
        {
            string aRegionN = (string)this.EditRoomRegionSelector.SelectedItem;
            string aRoomN = (string)this.EditRoomNameSelector.SelectedItem;
            mSelectedRoom = mGameDetails.mRegionDetails[aRegionN].mRooms[aRoomN];
            ResetToSelectedRoom();
        }
        #endregion
        #region GAME DETAILS EDITOR CODE
        private void ChangeGameDetails_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.gameNameText.Text) || string.IsNullOrEmpty(this.gameStoryText.Text))
            {
                this.gameStoryText.Text = mGameDetails.mStory;
                this.gameNameText.Text = mGameDetails.mName;
                return;
            }
            mGameDetails.mStory = this.gameStoryText.Text;
            mGameDetails.mName = this.gameNameText.Text;
        }
        #endregion

    }
}
