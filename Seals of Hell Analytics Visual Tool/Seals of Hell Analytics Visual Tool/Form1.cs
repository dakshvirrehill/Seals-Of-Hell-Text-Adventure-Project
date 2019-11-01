using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seals_of_Hell_Analytics_Visual_Tool
{
    public partial class SealsOfHellVisual : Form
    {
        DataHandler mData;

        public SealsOfHellVisual()
        {
            mData = new DataHandler();
            InitializeComponent();
            this.openDatabase.ShowDialog();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openDatabase.ShowDialog();
        }

        private void ExitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SetVisualData(object sender, CancelEventArgs e)
        {
            this.analyticsTabControl.Visible = false;
            if (string.IsNullOrEmpty(this.openDatabase.FileName) && !mData.mInit)
            {
                Application.Exit();
                return;
            }
            else
            {
                DatabaseManager.SetConnectionString("URI = file:" + this.openDatabase.FileName);
                if (!DatabaseManager.SetData(mData))
                {
                    Application.Exit();
                    return;
                }
            }
            this.analyticsTabControl.Visible = true;
            CreateCharts();
        }

        void CreateCharts()
        {
            CreateActionDataChart();
            CreatePickableDataChart();
            CreateGameDataChart();
        }
        void CreateActionDataChart()
        {
            List<int> aActionCountList = new List<int>();
            List<string> aActionNames = new List<string>();
            foreach (ActionData aData in mData.mActions)
            {
                aActionCountList.Add(aData.mCount);
                aActionNames.Add(aData.mCommandName);
            }
            this.actionDataChart.Series[0].Points.Clear();
            this.actionDataChart.Series[0].Points.DataBindXY(aActionNames, aActionCountList);
            this.actionDataChart.Series[0]["PieLabelStyle"] = "Outside";
            foreach(var aActionPoint in this.actionDataChart.Series[0].Points)
            {
                aActionPoint.Label = "#PERCENT  #VALX";
                aActionPoint.LabelForeColor = Color.Chocolate;
            }
        }
        void CreatePickableDataChart()
        {
            List<int> aPickCountList = new List<int>();
            List<int> aDropCountList = new List<int>();
            List<string> aPickableNames = new List<string>();
            foreach(PickableData aData in mData.mPickables)
            {
                aPickCountList.Add(aData.mPickCount);
                aDropCountList.Add(aData.mDropCount);
                aPickableNames.Add(aData.mPickableName);
            }
            this.pickableDataChart.Series[0].Points.Clear();
            this.pickableDataChart.Series[1].Points.Clear();
            this.pickableDataChart.Series[0].Points.DataBindXY(aPickableNames, aPickCountList);
            this.pickableDataChart.Series[1].Points.DataBindXY(aPickableNames, aDropCountList);
        }
        void CreateGameDataChart()
        {
            List<double> aPlayTimeList = new List<double>();
            List<int> aInvCountList = new List<int>();
            foreach (GameData aData in mData.mGamePlayData)
            {
                aPlayTimeList.Add(aData.mPlayTime);
                aInvCountList.Add(aData.mInventoryCount);
            }
            this.gameDataChart.Series[0].Points.Clear();
            this.gameDataChart.Series[0].Points.DataBindXY(aPlayTimeList, aInvCountList);
        }
    }
}
