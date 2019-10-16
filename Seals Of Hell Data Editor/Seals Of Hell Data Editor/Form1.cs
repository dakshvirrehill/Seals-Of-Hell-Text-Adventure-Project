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
        DataHandler mData;
        Region mSelectedRegion;
        Room mSelectedRoom;
        string mSelectedVerb;
        string mCurrentFilePath;
        string mCurrentFileName;

        public SealsOfHellMain()
        {
            mData = new DataHandler();
            InitializeComponent();
        }
        #region HELPERS
        void MakeAllGroupsInVisible()
        {
            this.RegionTabs.Visible = false;
            this.RoomTabs.Visible = false;
            this.CommandsTab.Visible = false;
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
            this.EditRoomNameSelector.DataSource = new List<string>(mData.mRegionList[aRegionN].mRooms.Keys);
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
        }
        private void RoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeAllGroupsInVisible();
            this.RoomTabs.Visible = true;
            this.RoomTabs.SelectedIndex = 0;
            this.NewRoomRegionSelector.DataSource = new List<string>(mData.mRegionList.Keys);
        }
        private void CommandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeAllGroupsInVisible();
            this.CommandsTab.Visible = true;
            this.CommandsTab.SelectedIndex = 0;
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
                    mData = Newtonsoft.Json.JsonConvert.DeserializeObject<DataHandler>(aReader.ReadToEnd());
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
            if(!mData.IsValid())
            {
                return;
            }
            try
            {
                using (System.IO.StreamWriter aWriter = new System.IO.StreamWriter(this.SaveFile.FileName, false))
                {
                    aWriter.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(mData,Newtonsoft.Json.Formatting.Indented));
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
            if (mData.mRegionList.ContainsKey(aNewRegion))
            {
                this.AddRegionTextBox.Text = "";
                this.RegionStoryTextBox.Text = "";
                return;
            }
            mData.mRegionList.Add(aNewRegion, new Region(aNewRegion,this.RegionStoryTextBox.Text));
            this.AddRegionTextBox.Text = "";
            this.RegionStoryTextBox.Text = "";
        }
        private void SetEditRegionTextBox(object sender, EventArgs e)
        {
            this.EditCurrentRegionTextBox.Text = (string)this.EditRegionsList.SelectedItem;
            this.EditRegionStoryTBox.Text = mData.mRegionList[this.EditCurrentRegionTextBox.Text].mStory;
            mSelectedRegion = mData.mRegionList[this.EditCurrentRegionTextBox.Text];
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
                    return;
                }
            }
            mData.mRegionList.Remove(mSelectedRegion.mName);
            mSelectedRegion.mName = this.EditCurrentRegionTextBox.Text;
            mSelectedRegion.mStory = this.EditRegionStoryTBox.Text;
            mData.mRegionList.Add(mSelectedRegion.mName, mSelectedRegion);
            this.EditRegionsList.DataSource = new List<string>(mData.mRegionList.Keys);
        }
        private void ResetEditableRegionsList(object sender, EventArgs e)
        {
            if(this.RegionTabs.SelectedTab != this.EditRegionsTab)
            {
                return;
            }
            this.EditRegionsList.DataSource = new List<string>(mData.mRegionList.Keys);
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
            if(!mData.mRegionList.ContainsKey(aRegionN))
            {
                return;
            }
            Region aRegion = mData.mRegionList[aRegionN];
            if(aRegion.mRooms.ContainsKey(this.NewRoomNameTBox.Text))
            {
                return;
            }
            Room aRoom = new Room(this.NewRoomNameTBox.Text,aRegionN,this.NewRoomStory.Text);
            aRegion.mRooms.Add(aRoom.mName, aRoom);
            this.NewRoomNameTBox.Text = "";
            this.NewRoomStory.Text = "";
            this.NewRoomRegionSelector.SelectedIndex = 0;
        }
        private void SaveRoomEdit_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.EditRoomName.Text) || 
                mData.mRegionList[(string)this.EditRoomRegion.SelectedItem].mRooms.ContainsKey(this.EditRoomName.Text))
            {
                ResetToSelectedRoom();
                return;
            }
            mData.mRegionList[mSelectedRoom.mRegion].mRooms.Remove(mSelectedRoom.mName);
            mSelectedRoom.mName = this.EditRoomName.Text;
            mSelectedRoom.mRegion = (string)this.EditRoomRegion.SelectedItem;
            mSelectedRoom.mStory = this.EditRoomStory.Text;
            mData.mRegionList[mSelectedRoom.mRegion].mRooms.Add(mSelectedRoom.mName, mSelectedRoom);
            UpdateRoomNamesInSelector();
        }
        private void UpdateRegionsAndRooms(object sender, EventArgs e)
        {
            if(this.RoomTabs.SelectedTab  != this.EditCurrentRoomsTab)
            {
                return;
            }
            this.EditRoomRegionSelector.DataSource = new List<string>(mData.mRegionList.Keys);
        }
        private void UpdateRoomNames(object sender, EventArgs e)
        {
            UpdateRoomNamesInSelector();
        }
        private void PresetEditRoomData(object sender, EventArgs e)
        {
            string aRegionN = (string)this.EditRoomRegionSelector.SelectedItem;
            string aRoomN = (string)this.EditRoomNameSelector.SelectedItem;
            mSelectedRoom = mData.mRegionList[aRegionN].mRooms[aRoomN];
            ResetToSelectedRoom();
        }
        #endregion
        #region COMMANDS DATA EDITOR CODE
        private void UpdateListOfCommands(object sender, EventArgs e)
        {
            if(this.CommandsTab.SelectedTab != this.EditCommandsTab)
            {
                return;
            }
            this.EditCommandVerbList.DataSource = mData.mCommandVerbs;
        }

        private void EditCommandVerbBtn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.EditCommandVerbText.Text) || this.EditCommandVerbText.Text.Equals(mSelectedVerb))
            {
                this.EditCommandVerbText.Text = mSelectedVerb;
                return;
            }
            string aVerb = this.EditCommandVerbText.Text;
            mData.mCommandVerbs.Remove(mSelectedVerb);
            mData.mCommandVerbs.Add(aVerb);
        }
        private void EditCommandVerbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.EditCommandVerbText.Text = (string)this.EditCommandVerbList.SelectedItem;
            mSelectedVerb = this.EditCommandVerbText.Text;
        }
        private void AddNewCommand_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.NewCommandVerbText.Text) || mData.mCommandVerbs.Contains(this.NewCommandVerbText.Text))
            {
                this.NewCommandVerbText.Text = "";
                return;
            }
            mData.mCommandVerbs.Add(this.NewCommandVerbText.Text);
        }
        #endregion
    }
}
