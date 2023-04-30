namespace SmartCube
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            richTextBoxReceived = new RichTextBox();
            _labelScan = new Label();
            _progressScanning = new ProgressBar();
            _panelScanInProgress = new Panel();
            _labelAlgoModel = new Label();
            _labelAlgoPlayer = new Label();
            _labelChrono = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            _gameHistory = new ListBox();
            _labelGameVictory = new Label();
            _labelGameCount = new Label();
            _labelTitleGamesCount = new Label();
            label1 = new Label();
            _labelbatteryLevel = new Label();
            _labelGameState = new Label();
            _panelGameCounters = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            _algorithmButton = new PictureBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel4 = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            panel8 = new Panel();
            panel7 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            _panelScanInProgress.SuspendLayout();
            _panelGameCounters.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_algorithmButton).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // richTextBoxReceived
            // 
            richTextBoxReceived.BackColor = Color.Black;
            richTextBoxReceived.BorderStyle = BorderStyle.None;
            richTextBoxReceived.Dock = DockStyle.Fill;
            richTextBoxReceived.ForeColor = Color.White;
            richTextBoxReceived.Location = new Point(0, 0);
            richTextBoxReceived.Name = "richTextBoxReceived";
            richTextBoxReceived.ReadOnly = true;
            richTextBoxReceived.Size = new Size(1839, 244);
            richTextBoxReceived.TabIndex = 1;
            richTextBoxReceived.Text = "";
            // 
            // _labelScan
            // 
            _labelScan.AutoSize = true;
            _labelScan.ForeColor = Color.White;
            _labelScan.Location = new Point(23, 21);
            _labelScan.Name = "_labelScan";
            _labelScan.Size = new Size(105, 25);
            _labelScan.TabIndex = 3;
            _labelScan.Text = "Scanning ....";
            // 
            // _progressScanning
            // 
            _progressScanning.Location = new Point(148, 21);
            _progressScanning.Name = "_progressScanning";
            _progressScanning.Size = new Size(150, 34);
            _progressScanning.Style = ProgressBarStyle.Marquee;
            _progressScanning.TabIndex = 4;
            _progressScanning.Value = 50;
            // 
            // _panelScanInProgress
            // 
            _panelScanInProgress.Controls.Add(_progressScanning);
            _panelScanInProgress.Controls.Add(_labelScan);
            _panelScanInProgress.Location = new Point(35, 14);
            _panelScanInProgress.Name = "_panelScanInProgress";
            _panelScanInProgress.Size = new Size(401, 70);
            _panelScanInProgress.TabIndex = 5;
            _panelScanInProgress.Visible = false;
            // 
            // _labelAlgoModel
            // 
            _labelAlgoModel.AutoSize = true;
            _labelAlgoModel.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            _labelAlgoModel.ForeColor = Color.White;
            _labelAlgoModel.Location = new Point(0, 0);
            _labelAlgoModel.Name = "_labelAlgoModel";
            _labelAlgoModel.Size = new Size(246, 96);
            _labelAlgoModel.TabIndex = 6;
            _labelAlgoModel.Text = "U' L' U";
            // 
            // _labelAlgoPlayer
            // 
            _labelAlgoPlayer.AutoSize = true;
            _labelAlgoPlayer.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            _labelAlgoPlayer.ForeColor = Color.White;
            _labelAlgoPlayer.Location = new Point(0, 0);
            _labelAlgoPlayer.Name = "_labelAlgoPlayer";
            _labelAlgoPlayer.Size = new Size(106, 96);
            _labelAlgoPlayer.TabIndex = 7;
            _labelAlgoPlayer.Text = "U'";
            // 
            // _labelChrono
            // 
            _labelChrono.AutoSize = true;
            _labelChrono.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            _labelChrono.ForeColor = Color.White;
            _labelChrono.Location = new Point(23, 0);
            _labelChrono.Name = "_labelChrono";
            _labelChrono.Size = new Size(251, 96);
            _labelChrono.TabIndex = 8;
            _labelChrono.Text = "00:000";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            // 
            // _gameHistory
            // 
            _gameHistory.BackColor = Color.Black;
            _gameHistory.BorderStyle = BorderStyle.None;
            _gameHistory.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            _gameHistory.ForeColor = Color.White;
            _gameHistory.FormattingEnabled = true;
            _gameHistory.ItemHeight = 48;
            _gameHistory.Location = new Point(0, 215);
            _gameHistory.Name = "_gameHistory";
            _gameHistory.Size = new Size(183, 192);
            _gameHistory.TabIndex = 9;
            _gameHistory.Visible = false;
            // 
            // _labelGameVictory
            // 
            _labelGameVictory.AutoSize = true;
            _labelGameVictory.Dock = DockStyle.Fill;
            _labelGameVictory.Font = new Font("Segoe UI", 28F, FontStyle.Regular, GraphicsUnit.Point);
            _labelGameVictory.ForeColor = Color.White;
            _labelGameVictory.Location = new Point(259, 104);
            _labelGameVictory.Name = "_labelGameVictory";
            _labelGameVictory.Size = new Size(654, 105);
            _labelGameVictory.TabIndex = 10;
            _labelGameVictory.Text = "000";
            // 
            // _labelGameCount
            // 
            _labelGameCount.AutoSize = true;
            _labelGameCount.Dock = DockStyle.Fill;
            _labelGameCount.Font = new Font("Segoe UI", 28F, FontStyle.Regular, GraphicsUnit.Point);
            _labelGameCount.ForeColor = Color.White;
            _labelGameCount.Location = new Point(259, 0);
            _labelGameCount.Name = "_labelGameCount";
            _labelGameCount.Size = new Size(654, 104);
            _labelGameCount.TabIndex = 11;
            _labelGameCount.Text = "000";
            // 
            // _labelTitleGamesCount
            // 
            _labelTitleGamesCount.AutoSize = true;
            _labelTitleGamesCount.Dock = DockStyle.Fill;
            _labelTitleGamesCount.Font = new Font("Segoe UI", 28F, FontStyle.Regular, GraphicsUnit.Point);
            _labelTitleGamesCount.ForeColor = Color.White;
            _labelTitleGamesCount.Location = new Point(3, 0);
            _labelTitleGamesCount.Name = "_labelTitleGamesCount";
            _labelTitleGamesCount.Size = new Size(250, 104);
            _labelTitleGamesCount.TabIndex = 12;
            _labelTitleGamesCount.Text = "Games :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 28F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 104);
            label1.Name = "label1";
            label1.Size = new Size(250, 105);
            label1.TabIndex = 13;
            label1.Text = "Success :";
            // 
            // _labelbatteryLevel
            // 
            _labelbatteryLevel.AutoSize = true;
            _labelbatteryLevel.ForeColor = Color.White;
            _labelbatteryLevel.Location = new Point(114, 35);
            _labelbatteryLevel.Name = "_labelbatteryLevel";
            _labelbatteryLevel.Size = new Size(159, 25);
            _labelbatteryLevel.TabIndex = 15;
            _labelbatteryLevel.Text = "Battery Level: ???%";
            _labelbatteryLevel.Visible = false;
            // 
            // _labelGameState
            // 
            _labelGameState.AutoSize = true;
            _labelGameState.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            _labelGameState.ForeColor = Color.ForestGreen;
            _labelGameState.Location = new Point(508, 0);
            _labelGameState.Name = "_labelGameState";
            _labelGameState.Size = new Size(285, 96);
            _labelGameState.TabIndex = 16;
            _labelGameState.Text = "Success";
            // 
            // _panelGameCounters
            // 
            _panelGameCounters.Controls.Add(tableLayoutPanel1);
            _panelGameCounters.Dock = DockStyle.Top;
            _panelGameCounters.Location = new Point(0, 0);
            _panelGameCounters.Name = "_panelGameCounters";
            _panelGameCounters.Size = new Size(916, 209);
            _panelGameCounters.TabIndex = 17;
            _panelGameCounters.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(_labelTitleGamesCount, 0, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 1);
            tableLayoutPanel1.Controls.Add(_labelGameVictory, 1, 1);
            tableLayoutPanel1.Controls.Add(_labelGameCount, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(916, 209);
            tableLayoutPanel1.TabIndex = 18;
            // 
            // _algorithmButton
            // 
            _algorithmButton.Dock = DockStyle.Right;
            _algorithmButton.Image = Properties.Resources.avatar;
            _algorithmButton.Location = new Point(1749, 0);
            _algorithmButton.Name = "_algorithmButton";
            _algorithmButton.Size = new Size(90, 94);
            _algorithmButton.SizeMode = PictureBoxSizeMode.StretchImage;
            _algorithmButton.TabIndex = 18;
            _algorithmButton.TabStop = false;
            _algorithmButton.Click += algorithmButton_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0271F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.9729F));
            tableLayoutPanel2.Controls.Add(panel4, 1, 3);
            tableLayoutPanel2.Controls.Add(panel3, 0, 2);
            tableLayoutPanel2.Controls.Add(panel2, 0, 1);
            tableLayoutPanel2.Controls.Add(panel1, 0, 0);
            tableLayoutPanel2.Controls.Add(panel7, 0, 3);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 250F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
            tableLayoutPanel2.Size = new Size(1845, 1286);
            tableLayoutPanel2.TabIndex = 19;
            // 
            // panel4
            // 
            panel4.Controls.Add(_gameHistory);
            panel4.Controls.Add(_panelGameCounters);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(926, 453);
            panel4.Name = "panel4";
            panel4.Size = new Size(916, 830);
            panel4.TabIndex = 20;
            // 
            // panel3
            // 
            tableLayoutPanel2.SetColumnSpan(panel3, 2);
            panel3.Controls.Add(_labelGameState);
            panel3.Controls.Add(_labelChrono);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 353);
            panel3.Name = "panel3";
            panel3.Size = new Size(1839, 94);
            panel3.TabIndex = 20;
            // 
            // panel2
            // 
            tableLayoutPanel2.SetColumnSpan(panel2, 2);
            panel2.Controls.Add(richTextBoxReceived);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 103);
            panel2.Name = "panel2";
            panel2.Size = new Size(1839, 244);
            panel2.TabIndex = 20;
            // 
            // panel1
            // 
            tableLayoutPanel2.SetColumnSpan(panel1, 2);
            panel1.Controls.Add(panel8);
            panel1.Controls.Add(_panelScanInProgress);
            panel1.Controls.Add(_algorithmButton);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1839, 94);
            panel1.TabIndex = 20;
            // 
            // panel8
            // 
            panel8.Controls.Add(_labelbatteryLevel);
            panel8.Dock = DockStyle.Right;
            panel8.Location = new Point(1449, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(300, 94);
            panel8.TabIndex = 19;
            // 
            // panel7
            // 
            panel7.Controls.Add(panel5);
            panel7.Controls.Add(panel6);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(3, 453);
            panel7.Name = "panel7";
            panel7.Size = new Size(917, 830);
            panel7.TabIndex = 23;
            // 
            // panel5
            // 
            panel5.Controls.Add(_labelAlgoModel);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 113);
            panel5.Name = "panel5";
            panel5.Size = new Size(917, 116);
            panel5.TabIndex = 21;
            // 
            // panel6
            // 
            panel6.Controls.Add(_labelAlgoPlayer);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(917, 113);
            panel6.TabIndex = 22;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(14, 30, 51);
            ClientSize = new Size(1845, 1286);
            Controls.Add(tableLayoutPanel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Smartcube";
            Load += Form1_Load;
            _panelScanInProgress.ResumeLayout(false);
            _panelScanInProgress.PerformLayout();
            _panelGameCounters.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_algorithmButton).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel7.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private RichTextBox richTextBoxReceived;
        private Label _labelScan;
        private ProgressBar _progressScanning;
        private Panel _panelScanInProgress;
        private Label _labelAlgoModel;
        private Label _labelAlgoPlayer;
        private Label _labelChrono;
        private System.Windows.Forms.Timer timer1;
        private ListBox _gameHistory;
        private Label _labelGameVictory;
        private Label _labelGameCount;
        private Label _labelTitleGamesCount;
        private Label label1;
        private Label _labelbatteryLevel;
        private Label _labelGameState;
        private Panel _panelGameCounters;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox _algorithmButton;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel4;
        private Panel panel7;
        private Panel panel5;
        private Panel panel6;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private Panel panel8;
        //private Label _algoModel;
        //private Label _algoPlayer;
    }
}