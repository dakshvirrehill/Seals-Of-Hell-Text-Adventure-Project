namespace Seals_of_Hell_Analytics_Visual_Tool
{
    partial class SealsOfHellVisual
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.analyticsTabControl = new System.Windows.Forms.TabControl();
            this.actionDataTab = new System.Windows.Forms.TabPage();
            this.actionDataChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pickableDataTab = new System.Windows.Forms.TabPage();
            this.pickableDataChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gameDataTab = new System.Windows.Forms.TabPage();
            this.gameDataChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.openDatabase = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.analyticsTabControl.SuspendLayout();
            this.actionDataTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actionDataChart)).BeginInit();
            this.pickableDataTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pickableDataChart)).BeginInit();
            this.gameDataTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameDataChart)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(38, 20);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.ExitToolStripMenuItem1_Click);
            // 
            // analyticsTabControl
            // 
            this.analyticsTabControl.Controls.Add(this.actionDataTab);
            this.analyticsTabControl.Controls.Add(this.pickableDataTab);
            this.analyticsTabControl.Controls.Add(this.gameDataTab);
            this.analyticsTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.analyticsTabControl.Location = new System.Drawing.Point(0, 27);
            this.analyticsTabControl.Name = "analyticsTabControl";
            this.analyticsTabControl.SelectedIndex = 0;
            this.analyticsTabControl.Size = new System.Drawing.Size(1008, 702);
            this.analyticsTabControl.TabIndex = 1;
            this.analyticsTabControl.Visible = false;
            // 
            // actionDataTab
            // 
            this.actionDataTab.Controls.Add(this.actionDataChart);
            this.actionDataTab.Location = new System.Drawing.Point(4, 29);
            this.actionDataTab.Name = "actionDataTab";
            this.actionDataTab.Padding = new System.Windows.Forms.Padding(3);
            this.actionDataTab.Size = new System.Drawing.Size(1000, 669);
            this.actionDataTab.TabIndex = 0;
            this.actionDataTab.Text = "Action Data";
            this.actionDataTab.UseVisualStyleBackColor = true;
            // 
            // actionDataChart
            // 
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.actionDataChart.ChartAreas.Add(chartArea1);
            legend1.ItemColumnSeparatorColor = System.Drawing.Color.BlanchedAlmond;
            legend1.Name = "Legend1";
            this.actionDataChart.Legends.Add(legend1);
            this.actionDataChart.Location = new System.Drawing.Point(0, 0);
            this.actionDataChart.Name = "actionDataChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "ActionUse";
            this.actionDataChart.Series.Add(series1);
            this.actionDataChart.Size = new System.Drawing.Size(997, 663);
            this.actionDataChart.TabIndex = 0;
            this.actionDataChart.Text = "Action Data Pie Chart";
            // 
            // pickableDataTab
            // 
            this.pickableDataTab.Controls.Add(this.pickableDataChart);
            this.pickableDataTab.Location = new System.Drawing.Point(4, 29);
            this.pickableDataTab.Name = "pickableDataTab";
            this.pickableDataTab.Padding = new System.Windows.Forms.Padding(3);
            this.pickableDataTab.Size = new System.Drawing.Size(1000, 669);
            this.pickableDataTab.TabIndex = 1;
            this.pickableDataTab.Text = "Pickable Data";
            this.pickableDataTab.UseVisualStyleBackColor = true;
            // 
            // pickableDataChart
            // 
            chartArea2.Name = "Pickable Data Chart";
            this.pickableDataChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.pickableDataChart.Legends.Add(legend2);
            this.pickableDataChart.Location = new System.Drawing.Point(2, 3);
            this.pickableDataChart.Name = "pickableDataChart";
            series2.ChartArea = "Pickable Data Chart";
            series2.Legend = "Legend1";
            series2.Name = "Name vs Pick Count";
            series3.ChartArea = "Pickable Data Chart";
            series3.Legend = "Legend1";
            series3.Name = "Name vs Drop Count";
            this.pickableDataChart.Series.Add(series2);
            this.pickableDataChart.Series.Add(series3);
            this.pickableDataChart.Size = new System.Drawing.Size(997, 663);
            this.pickableDataChart.TabIndex = 1;
            this.pickableDataChart.Text = "Pickable Data Bar Graph";
            // 
            // gameDataTab
            // 
            this.gameDataTab.Controls.Add(this.gameDataChart);
            this.gameDataTab.Location = new System.Drawing.Point(4, 29);
            this.gameDataTab.Name = "gameDataTab";
            this.gameDataTab.Padding = new System.Windows.Forms.Padding(3);
            this.gameDataTab.Size = new System.Drawing.Size(1000, 669);
            this.gameDataTab.TabIndex = 2;
            this.gameDataTab.Text = "Game Data";
            this.gameDataTab.UseVisualStyleBackColor = true;
            // 
            // gameDataChart
            // 
            chartArea3.Name = "gameDataCArea";
            this.gameDataChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.gameDataChart.Legends.Add(legend3);
            this.gameDataChart.Location = new System.Drawing.Point(2, 3);
            this.gameDataChart.Name = "gameDataChart";
            series4.ChartArea = "gameDataCArea";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.IsValueShownAsLabel = true;
            series4.Legend = "Legend1";
            series4.Name = "Play Time vs Inventory Count";
            this.gameDataChart.Series.Add(series4);
            this.gameDataChart.Size = new System.Drawing.Size(997, 663);
            this.gameDataChart.TabIndex = 1;
            this.gameDataChart.Text = "Gane Data Line Graph";
            // 
            // openDatabase
            // 
            this.openDatabase.DefaultExt = "db";
            this.openDatabase.Filter = "DB Files|*.db";
            this.openDatabase.Title = "Choose Database File To Visualize";
            this.openDatabase.FileOk += new System.ComponentModel.CancelEventHandler(this.SetVisualData);
            // 
            // SealsOfHellVisual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.analyticsTabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SealsOfHellVisual";
            this.Text = "Seals of Hell Analytics";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.analyticsTabControl.ResumeLayout(false);
            this.actionDataTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.actionDataChart)).EndInit();
            this.pickableDataTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pickableDataChart)).EndInit();
            this.gameDataTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gameDataChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.TabControl analyticsTabControl;
        private System.Windows.Forms.TabPage actionDataTab;
        private System.Windows.Forms.TabPage pickableDataTab;
        private System.Windows.Forms.TabPage gameDataTab;
        private System.Windows.Forms.DataVisualization.Charting.Chart actionDataChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart pickableDataChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart gameDataChart;
        private System.Windows.Forms.OpenFileDialog openDatabase;
    }
}

