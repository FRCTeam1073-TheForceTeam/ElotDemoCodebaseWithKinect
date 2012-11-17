namespace Dashboard2011
{
    partial class DashWin
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashWin));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getFromRobotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.packetmon = new System.Windows.Forms.Timer(this.components);
            this.RadioTab = new System.Windows.Forms.TabPage();
            this.webBrowser3 = new System.Windows.Forms.WebBrowser();
            this.CameraTab = new System.Windows.Forms.TabPage();
            this.Cam1 = new System.Windows.Forms.PictureBox();
            this.IOTab = new System.Windows.Forms.TabPage();
            this.NetTab = new System.Windows.Forms.TabPage();
            this.NetConsBox = new System.Windows.Forms.RichTextBox();
            this.MiscTab = new System.Windows.Forms.TabPage();
            this.QueueCntLab = new System.Windows.Forms.Label();
            this.CurrentChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.SpeedLab = new System.Windows.Forms.Label();
            this.DroppedLab = new System.Windows.Forms.Label();
            this.SkippedLab = new System.Windows.Forms.Label();
            this.SkipsLab = new System.Windows.Forms.Label();
            this.checks = new System.Windows.Forms.Label();
            this.Renc = new System.Windows.Forms.Label();
            this.Lenc = new System.Windows.Forms.Label();
            this.UdpId = new System.Windows.Forms.Label();
            this.JoyChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ConstsTab = new System.Windows.Forms.TabPage();
            this.DriverTab = new System.Windows.Forms.TabPage();
            this.BaitDistLab = new System.Windows.Forms.Label();
            this.PegDistLab = new System.Windows.Forms.Label();
            this.LineSensorPictureBox = new System.Windows.Forms.PictureBox();
            this.LineSensorsLabel = new System.Windows.Forms.Label();
            this.BaitLab = new System.Windows.Forms.Label();
            this.PegLab = new System.Windows.Forms.Label();
            this.CamToggle = new System.Windows.Forms.Button();
            this.PieceBox = new System.Windows.Forms.PictureBox();
            this.CameraBox = new System.Windows.Forms.PictureBox();
            this.AngleBox = new System.Windows.Forms.PictureBox();
            this.Time = new System.Windows.Forms.Label();
            this.NaviTab = new System.Windows.Forms.TabPage();
            this.ElevLab = new System.Windows.Forms.Label();
            this.NaviBox = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.cameramon = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.topRPMTextBox = new System.Windows.Forms.TextBox();
            this.BottomRPMTextBox = new System.Windows.Forms.TextBox();
            this.TopRPMlabel = new System.Windows.Forms.Label();
            this.BottomRPMlabel = new System.Windows.Forms.Label();
            this.SendRPMbutton = new System.Windows.Forms.Button();
            this.resetSpeedDropButton = new System.Windows.Forms.Button();
            this.elevator2 = new Dashboard2011.Elevator();
            this.elevator1 = new Dashboard2011.Elevator();
            this.Accel = new Dashboard2011.Joystick();
            this.joystickR = new Dashboard2011.Joystick();
            this.joystickL = new Dashboard2011.Joystick();
            this.menuStrip1.SuspendLayout();
            this.RadioTab.SuspendLayout();
            this.CameraTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Cam1)).BeginInit();
            this.NetTab.SuspendLayout();
            this.MiscTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JoyChart)).BeginInit();
            this.DriverTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LineSensorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PieceBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CameraBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AngleBox)).BeginInit();
            this.NaviTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NaviBox)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1239, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.getFromRobotToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.fileToolStripMenuItem.Text = "Match";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenMatch);
            // 
            // getFromRobotToolStripMenuItem
            // 
            this.getFromRobotToolStripMenuItem.Name = "getFromRobotToolStripMenuItem";
            this.getFromRobotToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.getFromRobotToolStripMenuItem.Text = "Get From Robot";
            this.getFromRobotToolStripMenuItem.Click += new System.EventHandler(this.GetFromRobot);
            // 
            // packetmon
            // 
            this.packetmon.Interval = 6;
            this.packetmon.Tick += new System.EventHandler(this.packetcheck);
            // 
            // RadioTab
            // 
            this.RadioTab.Controls.Add(this.webBrowser3);
            this.RadioTab.Location = new System.Drawing.Point(4, 22);
            this.RadioTab.Name = "RadioTab";
            this.RadioTab.Size = new System.Drawing.Size(1218, 600);
            this.RadioTab.TabIndex = 10;
            this.RadioTab.Text = "Radio";
            this.RadioTab.UseVisualStyleBackColor = true;
            // 
            // webBrowser3
            // 
            this.webBrowser3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser3.Location = new System.Drawing.Point(0, 0);
            this.webBrowser3.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser3.Name = "webBrowser3";
            this.webBrowser3.Size = new System.Drawing.Size(1218, 600);
            this.webBrowser3.TabIndex = 0;
            this.webBrowser3.Url = new System.Uri("http://10.10.73.1", System.UriKind.Absolute);
            // 
            // CameraTab
            // 
            this.CameraTab.Controls.Add(this.Cam1);
            this.CameraTab.Location = new System.Drawing.Point(4, 22);
            this.CameraTab.Name = "CameraTab";
            this.CameraTab.Size = new System.Drawing.Size(1218, 600);
            this.CameraTab.TabIndex = 8;
            this.CameraTab.Text = "Cameras";
            this.CameraTab.UseVisualStyleBackColor = true;
            // 
            // Cam1
            // 
            this.Cam1.Location = new System.Drawing.Point(9, 9);
            this.Cam1.Name = "Cam1";
            this.Cam1.Size = new System.Drawing.Size(585, 443);
            this.Cam1.TabIndex = 0;
            this.Cam1.TabStop = false;
            // 
            // IOTab
            // 
            this.IOTab.Location = new System.Drawing.Point(4, 22);
            this.IOTab.Name = "IOTab";
            this.IOTab.Size = new System.Drawing.Size(1218, 600);
            this.IOTab.TabIndex = 7;
            this.IOTab.Text = "IO";
            this.IOTab.UseVisualStyleBackColor = true;
            // 
            // NetTab
            // 
            this.NetTab.Controls.Add(this.NetConsBox);
            this.NetTab.Location = new System.Drawing.Point(4, 22);
            this.NetTab.Name = "NetTab";
            this.NetTab.Size = new System.Drawing.Size(1218, 600);
            this.NetTab.TabIndex = 5;
            this.NetTab.Text = "Net Console";
            this.NetTab.UseVisualStyleBackColor = true;
            // 
            // NetConsBox
            // 
            this.NetConsBox.Location = new System.Drawing.Point(5, 5);
            this.NetConsBox.Name = "NetConsBox";
            this.NetConsBox.Size = new System.Drawing.Size(653, 508);
            this.NetConsBox.TabIndex = 0;
            this.NetConsBox.Text = "";
            this.NetConsBox.TextChanged += new System.EventHandler(this.NetConsBox_TextChanged);
            // 
            // MiscTab
            // 
            this.MiscTab.Controls.Add(this.QueueCntLab);
            this.MiscTab.Controls.Add(this.CurrentChart);
            this.MiscTab.Controls.Add(this.SpeedLab);
            this.MiscTab.Controls.Add(this.DroppedLab);
            this.MiscTab.Controls.Add(this.SkippedLab);
            this.MiscTab.Controls.Add(this.SkipsLab);
            this.MiscTab.Controls.Add(this.checks);
            this.MiscTab.Controls.Add(this.Renc);
            this.MiscTab.Controls.Add(this.Lenc);
            this.MiscTab.Controls.Add(this.UdpId);
            this.MiscTab.Controls.Add(this.JoyChart);
            this.MiscTab.Controls.Add(this.label2);
            this.MiscTab.Controls.Add(this.label1);
            this.MiscTab.Controls.Add(this.Accel);
            this.MiscTab.Controls.Add(this.joystickR);
            this.MiscTab.Controls.Add(this.joystickL);
            this.MiscTab.Location = new System.Drawing.Point(4, 22);
            this.MiscTab.Name = "MiscTab";
            this.MiscTab.Size = new System.Drawing.Size(1218, 600);
            this.MiscTab.TabIndex = 4;
            this.MiscTab.Text = "Misc";
            this.MiscTab.UseVisualStyleBackColor = true;
            // 
            // QueueCntLab
            // 
            this.QueueCntLab.AutoSize = true;
            this.QueueCntLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.QueueCntLab.Location = new System.Drawing.Point(114, 511);
            this.QueueCntLab.Name = "QueueCntLab";
            this.QueueCntLab.Size = new System.Drawing.Size(137, 29);
            this.QueueCntLab.TabIndex = 16;
            this.QueueCntLab.Text = "Img Queue";
            // 
            // CurrentChart
            // 
            chartArea1.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)(((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisX.LabelStyle.TruncatedLabels = true;
            chartArea1.AxisX.Title = "Time (s)";
            chartArea1.AxisX2.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)(((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep45)));
            chartArea1.AxisY.Title = "Current (A)";
            chartArea1.Name = "ChartArea1";
            this.CurrentChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.CurrentChart.Legends.Add(legend1);
            this.CurrentChart.Location = new System.Drawing.Point(590, 215);
            this.CurrentChart.Name = "CurrentChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Legend = "Legend1";
            series1.LegendText = "L Current";
            series1.Name = "LCurrent";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.Legend = "Legend1";
            series2.LegendText = "R Current";
            series2.Name = "RCurrent";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series3.Legend = "Legend1";
            series3.LegendText = "Pincher Curent";
            series3.Name = "PincherCurrent";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series4.Legend = "Legend1";
            series4.LegendText = "Arm Current";
            series4.Name = "ArmCurrent";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series5.Legend = "Legend1";
            series5.LegendText = "Elevator Current";
            series5.Name = "ElevatorCurrent";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series6.Legend = "Legend1";
            series6.LegendText = "Total";
            series6.Name = "Total";
            this.CurrentChart.Series.Add(series1);
            this.CurrentChart.Series.Add(series2);
            this.CurrentChart.Series.Add(series3);
            this.CurrentChart.Series.Add(series4);
            this.CurrentChart.Series.Add(series5);
            this.CurrentChart.Series.Add(series6);
            this.CurrentChart.Size = new System.Drawing.Size(591, 368);
            this.CurrentChart.TabIndex = 15;
            this.CurrentChart.Text = "chart1";
            // 
            // SpeedLab
            // 
            this.SpeedLab.AutoSize = true;
            this.SpeedLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.SpeedLab.Location = new System.Drawing.Point(252, 354);
            this.SpeedLab.Name = "SpeedLab";
            this.SpeedLab.Size = new System.Drawing.Size(82, 29);
            this.SpeedLab.TabIndex = 14;
            this.SpeedLab.Text = "speed";
            // 
            // DroppedLab
            // 
            this.DroppedLab.AutoSize = true;
            this.DroppedLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.DroppedLab.Location = new System.Drawing.Point(35, 443);
            this.DroppedLab.Name = "DroppedLab";
            this.DroppedLab.Size = new System.Drawing.Size(109, 29);
            this.DroppedLab.TabIndex = 12;
            this.DroppedLab.Text = "Dropped";
            // 
            // SkippedLab
            // 
            this.SkippedLab.AutoSize = true;
            this.SkippedLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.SkippedLab.Location = new System.Drawing.Point(35, 414);
            this.SkippedLab.Name = "SkippedLab";
            this.SkippedLab.Size = new System.Drawing.Size(105, 29);
            this.SkippedLab.TabIndex = 11;
            this.SkippedLab.Text = "Skipped";
            // 
            // SkipsLab
            // 
            this.SkipsLab.AutoSize = true;
            this.SkipsLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.SkipsLab.Location = new System.Drawing.Point(35, 375);
            this.SkipsLab.Name = "SkipsLab";
            this.SkipsLab.Size = new System.Drawing.Size(76, 29);
            this.SkipsLab.TabIndex = 10;
            this.SkipsLab.Text = "Skips";
            // 
            // checks
            // 
            this.checks.AutoSize = true;
            this.checks.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.checks.Location = new System.Drawing.Point(35, 337);
            this.checks.Name = "checks";
            this.checks.Size = new System.Drawing.Size(98, 29);
            this.checks.TabIndex = 9;
            this.checks.Text = "Checks";
            // 
            // Renc
            // 
            this.Renc.AutoSize = true;
            this.Renc.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.Renc.Location = new System.Drawing.Point(252, 325);
            this.Renc.Name = "Renc";
            this.Renc.Size = new System.Drawing.Size(96, 29);
            this.Renc.TabIndex = 8;
            this.Renc.Text = "R. Enc:";
            // 
            // Lenc
            // 
            this.Lenc.AutoSize = true;
            this.Lenc.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.Lenc.Location = new System.Drawing.Point(252, 296);
            this.Lenc.Name = "Lenc";
            this.Lenc.Size = new System.Drawing.Size(92, 29);
            this.Lenc.TabIndex = 7;
            this.Lenc.Text = "L. Enc:";
            // 
            // UdpId
            // 
            this.UdpId.AutoSize = true;
            this.UdpId.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.UdpId.Location = new System.Drawing.Point(35, 298);
            this.UdpId.Name = "UdpId";
            this.UdpId.Size = new System.Drawing.Size(86, 29);
            this.UdpId.TabIndex = 6;
            this.UdpId.Text = "Udp Id";
            // 
            // JoyChart
            // 
            chartArea2.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)(((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea2.AxisX.LabelStyle.TruncatedLabels = true;
            chartArea2.AxisX.Title = "Time (s)";
            chartArea2.AxisX2.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)(((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep45)));
            chartArea2.Name = "ChartArea1";
            this.JoyChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.JoyChart.Legends.Add(legend2);
            this.JoyChart.Location = new System.Drawing.Point(590, 28);
            this.JoyChart.Name = "JoyChart";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series7.Legend = "Legend1";
            series7.LegendText = "L Joystick";
            series7.Name = "Ljoys";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series8.Legend = "Legend1";
            series8.LegendText = "R joystick";
            series8.Name = "Rjoys";
            this.JoyChart.Series.Add(series7);
            this.JoyChart.Series.Add(series8);
            this.JoyChart.Size = new System.Drawing.Size(543, 181);
            this.JoyChart.TabIndex = 5;
            this.JoyChart.Text = "chart1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label2.Location = new System.Drawing.Point(398, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Acceleration";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label1.Location = new System.Drawing.Point(105, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Joysticks";
            // 
            // ConstsTab
            // 
            this.ConstsTab.Location = new System.Drawing.Point(4, 22);
            this.ConstsTab.Name = "ConstsTab";
            this.ConstsTab.Size = new System.Drawing.Size(1218, 600);
            this.ConstsTab.TabIndex = 3;
            this.ConstsTab.Text = "Constants";
            this.ConstsTab.UseVisualStyleBackColor = true;
            // 
            // DriverTab
            // 
            this.DriverTab.Controls.Add(this.resetSpeedDropButton);
            this.DriverTab.Controls.Add(this.SendRPMbutton);
            this.DriverTab.Controls.Add(this.BottomRPMlabel);
            this.DriverTab.Controls.Add(this.TopRPMlabel);
            this.DriverTab.Controls.Add(this.BottomRPMTextBox);
            this.DriverTab.Controls.Add(this.topRPMTextBox);
            this.DriverTab.Controls.Add(this.BaitDistLab);
            this.DriverTab.Controls.Add(this.PegDistLab);
            this.DriverTab.Controls.Add(this.LineSensorPictureBox);
            this.DriverTab.Controls.Add(this.LineSensorsLabel);
            this.DriverTab.Controls.Add(this.elevator1);
            this.DriverTab.Controls.Add(this.BaitLab);
            this.DriverTab.Controls.Add(this.PegLab);
            this.DriverTab.Controls.Add(this.CamToggle);
            this.DriverTab.Controls.Add(this.PieceBox);
            this.DriverTab.Controls.Add(this.CameraBox);
            this.DriverTab.Controls.Add(this.AngleBox);
            this.DriverTab.Controls.Add(this.Time);
            this.DriverTab.Location = new System.Drawing.Point(4, 22);
            this.DriverTab.Name = "DriverTab";
            this.DriverTab.Padding = new System.Windows.Forms.Padding(3);
            this.DriverTab.Size = new System.Drawing.Size(1218, 600);
            this.DriverTab.TabIndex = 1;
            this.DriverTab.Text = "Driver";
            this.DriverTab.UseVisualStyleBackColor = true;
            // 
            // BaitDistLab
            // 
            this.BaitDistLab.AutoSize = true;
            this.BaitDistLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.BaitDistLab.Location = new System.Drawing.Point(165, 263);
            this.BaitDistLab.Name = "BaitDistLab";
            this.BaitDistLab.Size = new System.Drawing.Size(116, 25);
            this.BaitDistLab.TabIndex = 13;
            this.BaitDistLab.Text = "Bait Angle:";
            // 
            // PegDistLab
            // 
            this.PegDistLab.AutoSize = true;
            this.PegDistLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.PegDistLab.Location = new System.Drawing.Point(165, 223);
            this.PegDistLab.Name = "PegDistLab";
            this.PegDistLab.Size = new System.Drawing.Size(117, 25);
            this.PegDistLab.TabIndex = 12;
            this.PegDistLab.Text = "Peg Angle:";
            // 
            // LineSensorPictureBox
            // 
            this.LineSensorPictureBox.Location = new System.Drawing.Point(353, 105);
            this.LineSensorPictureBox.Name = "LineSensorPictureBox";
            this.LineSensorPictureBox.Size = new System.Drawing.Size(150, 100);
            this.LineSensorPictureBox.TabIndex = 11;
            this.LineSensorPictureBox.TabStop = false;
            // 
            // LineSensorsLabel
            // 
            this.LineSensorsLabel.AutoSize = true;
            this.LineSensorsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LineSensorsLabel.Location = new System.Drawing.Point(363, 65);
            this.LineSensorsLabel.Name = "LineSensorsLabel";
            this.LineSensorsLabel.Size = new System.Drawing.Size(138, 25);
            this.LineSensorsLabel.TabIndex = 10;
            this.LineSensorsLabel.Text = "Line Sensors";
            // 
            // BaitLab
            // 
            this.BaitLab.AutoSize = true;
            this.BaitLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.BaitLab.Location = new System.Drawing.Point(22, 263);
            this.BaitLab.Name = "BaitLab";
            this.BaitLab.Size = new System.Drawing.Size(116, 25);
            this.BaitLab.TabIndex = 8;
            this.BaitLab.Text = "Bait Angle:";
            // 
            // PegLab
            // 
            this.PegLab.AutoSize = true;
            this.PegLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.PegLab.Location = new System.Drawing.Point(22, 223);
            this.PegLab.Name = "PegLab";
            this.PegLab.Size = new System.Drawing.Size(117, 25);
            this.PegLab.TabIndex = 7;
            this.PegLab.Text = "Peg Angle:";
            // 
            // CamToggle
            // 
            this.CamToggle.Location = new System.Drawing.Point(674, 463);
            this.CamToggle.Name = "CamToggle";
            this.CamToggle.Size = new System.Drawing.Size(110, 23);
            this.CamToggle.TabIndex = 6;
            this.CamToggle.Text = "Switch Cameras";
            this.CamToggle.UseVisualStyleBackColor = true;
            // 
            // PieceBox
            // 
            this.PieceBox.Location = new System.Drawing.Point(27, 353);
            this.PieceBox.Name = "PieceBox";
            this.PieceBox.Size = new System.Drawing.Size(388, 133);
            this.PieceBox.TabIndex = 4;
            this.PieceBox.TabStop = false;
            this.PieceBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PieceBox_click);
            // 
            // CameraBox
            // 
            this.CameraBox.Location = new System.Drawing.Point(650, 6);
            this.CameraBox.Name = "CameraBox";
            this.CameraBox.Size = new System.Drawing.Size(562, 369);
            this.CameraBox.TabIndex = 2;
            this.CameraBox.TabStop = false;
            // 
            // AngleBox
            // 
            this.AngleBox.Location = new System.Drawing.Point(27, 65);
            this.AngleBox.Name = "AngleBox";
            this.AngleBox.Size = new System.Drawing.Size(300, 150);
            this.AngleBox.TabIndex = 1;
            this.AngleBox.TabStop = false;
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.25F);
            this.Time.Location = new System.Drawing.Point(7, 8);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(201, 44);
            this.Time.TabIndex = 0;
            this.Time.Text = "Time Left: ";
            // 
            // NaviTab
            // 
            this.NaviTab.Controls.Add(this.ElevLab);
            this.NaviTab.Controls.Add(this.elevator2);
            this.NaviTab.Controls.Add(this.NaviBox);
            this.NaviTab.Location = new System.Drawing.Point(4, 22);
            this.NaviTab.Name = "NaviTab";
            this.NaviTab.Padding = new System.Windows.Forms.Padding(3);
            this.NaviTab.Size = new System.Drawing.Size(1218, 600);
            this.NaviTab.TabIndex = 0;
            this.NaviTab.Text = "Navigation";
            this.NaviTab.UseVisualStyleBackColor = true;
            // 
            // ElevLab
            // 
            this.ElevLab.AutoSize = true;
            this.ElevLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.ElevLab.Location = new System.Drawing.Point(1065, 469);
            this.ElevLab.Name = "ElevLab";
            this.ElevLab.Size = new System.Drawing.Size(63, 29);
            this.ElevLab.TabIndex = 11;
            this.ElevLab.Text = "Elev";
            // 
            // NaviBox
            // 
            this.NaviBox.Image = ((System.Drawing.Image)(resources.GetObject("NaviBox.Image")));
            this.NaviBox.Location = new System.Drawing.Point(7, 6);
            this.NaviBox.Name = "NaviBox";
            this.NaviBox.Size = new System.Drawing.Size(1034, 453);
            this.NaviBox.TabIndex = 0;
            this.NaviBox.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.NaviTab);
            this.tabControl1.Controls.Add(this.DriverTab);
            this.tabControl1.Controls.Add(this.ConstsTab);
            this.tabControl1.Controls.Add(this.MiscTab);
            this.tabControl1.Controls.Add(this.NetTab);
            this.tabControl1.Controls.Add(this.IOTab);
            this.tabControl1.Controls.Add(this.CameraTab);
            this.tabControl1.Controls.Add(this.RadioTab);
            this.tabControl1.Location = new System.Drawing.Point(1, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1226, 626);
            this.tabControl1.TabIndex = 0;
            // 
            // cameramon
            // 
            this.cameramon.Interval = 10;
            this.cameramon.Tick += new System.EventHandler(this.cameramon_tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // topRPMTextBox
            // 
            this.topRPMTextBox.Location = new System.Drawing.Point(484, 525);
            this.topRPMTextBox.Name = "topRPMTextBox";
            this.topRPMTextBox.Size = new System.Drawing.Size(100, 20);
            this.topRPMTextBox.TabIndex = 14;
            this.topRPMTextBox.Text = "2000";
            // 
            // BottomRPMTextBox
            // 
            this.BottomRPMTextBox.Location = new System.Drawing.Point(484, 551);
            this.BottomRPMTextBox.Name = "BottomRPMTextBox";
            this.BottomRPMTextBox.Size = new System.Drawing.Size(100, 20);
            this.BottomRPMTextBox.TabIndex = 15;
            this.BottomRPMTextBox.Text = "2000";
            // 
            // TopRPMlabel
            // 
            this.TopRPMlabel.AutoSize = true;
            this.TopRPMlabel.Location = new System.Drawing.Point(422, 528);
            this.TopRPMlabel.Name = "TopRPMlabel";
            this.TopRPMlabel.Size = new System.Drawing.Size(56, 13);
            this.TopRPMlabel.TabIndex = 16;
            this.TopRPMlabel.Text = "Top RPM:";
            // 
            // BottomRPMlabel
            // 
            this.BottomRPMlabel.AutoSize = true;
            this.BottomRPMlabel.Location = new System.Drawing.Point(408, 554);
            this.BottomRPMlabel.Name = "BottomRPMlabel";
            this.BottomRPMlabel.Size = new System.Drawing.Size(70, 13);
            this.BottomRPMlabel.TabIndex = 17;
            this.BottomRPMlabel.Text = "Bottom RPM:";
            // 
            // SendRPMbutton
            // 
            this.SendRPMbutton.Location = new System.Drawing.Point(590, 549);
            this.SendRPMbutton.Name = "SendRPMbutton";
            this.SendRPMbutton.Size = new System.Drawing.Size(75, 23);
            this.SendRPMbutton.TabIndex = 18;
            this.SendRPMbutton.Text = "Send";
            this.SendRPMbutton.UseVisualStyleBackColor = true;
            this.SendRPMbutton.Click += new System.EventHandler(this.SendRPMbutton_Click);
            // 
            // resetSpeedDropButton
            // 
            this.resetSpeedDropButton.Location = new System.Drawing.Point(590, 523);
            this.resetSpeedDropButton.Name = "resetSpeedDropButton";
            this.resetSpeedDropButton.Size = new System.Drawing.Size(121, 23);
            this.resetSpeedDropButton.TabIndex = 19;
            this.resetSpeedDropButton.Text = "Reset Speed Drop";
            this.resetSpeedDropButton.UseVisualStyleBackColor = true;
            this.resetSpeedDropButton.Click += new System.EventHandler(this.resetSpeedDropButton_Click);
            // 
            // elevator2
            // 
            this.elevator2.LeftPegs = new float[] {
        1.94F,
        4.88F,
        7.82F};
            this.elevator2.Location = new System.Drawing.Point(1060, 6);
            this.elevator2.Max = 10D;
            this.elevator2.Name = "elevator2";
            this.elevator2.Position = 0D;
            this.elevator2.RightPegs = new float[] {
        3.11F,
        6.05F,
        8.99F};
            this.elevator2.Size = new System.Drawing.Size(93, 453);
            this.elevator2.TabIndex = 10;
            // 
            // elevator1
            // 
            this.elevator1.LeftPegs = new float[] {
        1.94F,
        4.88F,
        7.82F};
            this.elevator1.Location = new System.Drawing.Point(550, 6);
            this.elevator1.Max = 10D;
            this.elevator1.Name = "elevator1";
            this.elevator1.Position = 0D;
            this.elevator1.RightPegs = new float[] {
        3.11F,
        6.05F,
        8.99F};
            this.elevator1.Size = new System.Drawing.Size(93, 426);
            this.elevator1.TabIndex = 9;
            // 
            // Accel
            // 
            this.Accel.Location = new System.Drawing.Point(389, 74);
            this.Accel.Max = 15F;
            this.Accel.Name = "Accel";
            this.Accel.Size = new System.Drawing.Size(150, 200);
            this.Accel.TabIndex = 2;
            this.Accel.X = 0F;
            this.Accel.Y = 0F;
            // 
            // joystickR
            // 
            this.joystickR.Location = new System.Drawing.Point(174, 74);
            this.joystickR.Max = 1F;
            this.joystickR.Name = "joystickR";
            this.joystickR.Size = new System.Drawing.Size(150, 200);
            this.joystickR.TabIndex = 1;
            this.joystickR.X = 0F;
            this.joystickR.Y = 0F;
            // 
            // joystickL
            // 
            this.joystickL.Location = new System.Drawing.Point(18, 74);
            this.joystickL.Max = 1F;
            this.joystickL.Name = "joystickL";
            this.joystickL.Size = new System.Drawing.Size(150, 200);
            this.joystickL.TabIndex = 0;
            this.joystickL.X = 0F;
            this.joystickL.Y = 0F;
            // 
            // DashWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 664);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DashWin";
            this.Text = "Dashboard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Close);
            this.Load += new System.EventHandler(this.Loaded);
            this.Resize += new System.EventHandler(this.Resized);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.RadioTab.ResumeLayout(false);
            this.CameraTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Cam1)).EndInit();
            this.NetTab.ResumeLayout(false);
            this.MiscTab.ResumeLayout(false);
            this.MiscTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JoyChart)).EndInit();
            this.DriverTab.ResumeLayout(false);
            this.DriverTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LineSensorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PieceBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CameraBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AngleBox)).EndInit();
            this.NaviTab.ResumeLayout(false);
            this.NaviTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NaviBox)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getFromRobotToolStripMenuItem;
        private System.Windows.Forms.Timer packetmon;
        private System.Windows.Forms.TabPage RadioTab;
        private System.Windows.Forms.WebBrowser webBrowser3;
        private System.Windows.Forms.TabPage CameraTab;
        private System.Windows.Forms.PictureBox Cam1;
        private System.Windows.Forms.TabPage IOTab;
        private System.Windows.Forms.TabPage NetTab;
        private System.Windows.Forms.RichTextBox NetConsBox;
        private System.Windows.Forms.TabPage MiscTab;
        private System.Windows.Forms.Label Renc;
        private System.Windows.Forms.Label Lenc;
        private System.Windows.Forms.Label UdpId;
        private System.Windows.Forms.DataVisualization.Charting.Chart JoyChart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Joystick Accel;
        private Joystick joystickR;
        private Joystick joystickL;
        private System.Windows.Forms.TabPage ConstsTab;
        private System.Windows.Forms.TabPage DriverTab;
        private System.Windows.Forms.Button CamToggle;
        private System.Windows.Forms.PictureBox PieceBox;
        private System.Windows.Forms.PictureBox CameraBox;
        private System.Windows.Forms.PictureBox AngleBox;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.TabPage NaviTab;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label checks;
        private System.Windows.Forms.Label SkipsLab;
        private System.Windows.Forms.Label SkippedLab;
        private System.Windows.Forms.Label DroppedLab;
        private System.Windows.Forms.Timer cameramon;
        private System.Windows.Forms.PictureBox NaviBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label BaitLab;
        private System.Windows.Forms.Label PegLab;
        private System.Windows.Forms.Label SpeedLab;
        private Elevator elevator1;
        private System.Windows.Forms.DataVisualization.Charting.Chart CurrentChart;
        private System.Windows.Forms.Label QueueCntLab;
        private Elevator elevator2;
        private System.Windows.Forms.Label ElevLab;
        private System.Windows.Forms.PictureBox LineSensorPictureBox;
        private System.Windows.Forms.Label LineSensorsLabel;
        private System.Windows.Forms.Label BaitDistLab;
        private System.Windows.Forms.Label PegDistLab;
        private System.Windows.Forms.Button resetSpeedDropButton;
        private System.Windows.Forms.Button SendRPMbutton;
        private System.Windows.Forms.Label BottomRPMlabel;
        private System.Windows.Forms.Label TopRPMlabel;
        private System.Windows.Forms.TextBox BottomRPMTextBox;
        private System.Windows.Forms.TextBox topRPMTextBox;
    }
}

