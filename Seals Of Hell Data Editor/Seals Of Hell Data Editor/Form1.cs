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
            SetAllGameStartData();
        }
        #endregion
        #region Game Start Data
        void SetAllGameStartData()
        {
            this.gameNameTextBox.Text = mGameDetails.mName;
            this.gameStoryTextBox.Text = mGameDetails.mStory;
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
        #endregion
    }
}
