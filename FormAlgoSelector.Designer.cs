namespace SmartCube
{
    partial class FormAlgoSelector
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
            _listBoxAlgorithms = new ListBox();
            _buttonLoad = new Button();
            SuspendLayout();
            // 
            // _listBoxAlgorithms
            // 
            _listBoxAlgorithms.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            _listBoxAlgorithms.FormattingEnabled = true;
            _listBoxAlgorithms.ItemHeight = 38;
            _listBoxAlgorithms.Location = new Point(12, 17);
            _listBoxAlgorithms.Name = "_listBoxAlgorithms";
            _listBoxAlgorithms.Size = new Size(776, 346);
            _listBoxAlgorithms.TabIndex = 0;
            _listBoxAlgorithms.SelectedIndexChanged += _listBoxAlgorithms_SelectedIndexChanged;
            // 
            // _buttonLoad
            // 
            _buttonLoad.Location = new Point(272, 393);
            _buttonLoad.Name = "_buttonLoad";
            _buttonLoad.Size = new Size(248, 34);
            _buttonLoad.TabIndex = 1;
            _buttonLoad.Text = "Load algorithms";
            _buttonLoad.UseVisualStyleBackColor = true;
            _buttonLoad.Click += _buttonLoad_Click;
            // 
            // FormAlgoSelector
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(_buttonLoad);
            Controls.Add(_listBoxAlgorithms);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FormAlgoSelector";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Select algorithm";
            Load += FormAlgoSelector_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox _listBoxAlgorithms;
        private Button _buttonLoad;
    }
}