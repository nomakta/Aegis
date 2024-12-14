namespace Aegis
{
    partial class settings
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
            TestModeGB = new GroupBox();
            stopTestModeBtn = new Button();
            startTestModeBtn = new Button();
            settingsGB = new GroupBox();
            launchOnStartupCB = new CheckBox();
            showBsodCB = new CheckBox();
            startGuardLaunchCB = new CheckBox();
            TestModeGB.SuspendLayout();
            settingsGB.SuspendLayout();
            SuspendLayout();
            // 
            // TestModeGB
            // 
            TestModeGB.Controls.Add(stopTestModeBtn);
            TestModeGB.Controls.Add(startTestModeBtn);
            TestModeGB.Location = new Point(12, 12);
            TestModeGB.Name = "TestModeGB";
            TestModeGB.Size = new Size(277, 110);
            TestModeGB.TabIndex = 0;
            TestModeGB.TabStop = false;
            TestModeGB.Text = "Test mode";
            // 
            // stopTestModeBtn
            // 
            stopTestModeBtn.Location = new Point(6, 71);
            stopTestModeBtn.Name = "stopTestModeBtn";
            stopTestModeBtn.Size = new Size(265, 29);
            stopTestModeBtn.TabIndex = 2;
            stopTestModeBtn.Text = "Stop Test Mode";
            stopTestModeBtn.UseVisualStyleBackColor = true;
            stopTestModeBtn.Click += stopTestModeBtn_Click;
            // 
            // startTestModeBtn
            // 
            startTestModeBtn.Location = new Point(6, 26);
            startTestModeBtn.Name = "startTestModeBtn";
            startTestModeBtn.Size = new Size(265, 39);
            startTestModeBtn.TabIndex = 1;
            startTestModeBtn.Text = "Start Test Mode";
            startTestModeBtn.UseVisualStyleBackColor = true;
            startTestModeBtn.Click += startTestModeBtn_Click;
            // 
            // settingsGB
            // 
            settingsGB.Controls.Add(startGuardLaunchCB);
            settingsGB.Controls.Add(launchOnStartupCB);
            settingsGB.Controls.Add(showBsodCB);
            settingsGB.Location = new Point(12, 128);
            settingsGB.Name = "settingsGB";
            settingsGB.Size = new Size(271, 127);
            settingsGB.TabIndex = 1;
            settingsGB.TabStop = false;
            settingsGB.Text = "Settings";
            // 
            // launchOnStartupCB
            // 
            launchOnStartupCB.AutoSize = true;
            launchOnStartupCB.Location = new Point(6, 95);
            launchOnStartupCB.Name = "launchOnStartupCB";
            launchOnStartupCB.Size = new Size(189, 24);
            launchOnStartupCB.TabIndex = 1;
            launchOnStartupCB.Text = "Launch Aegis on startup";
            launchOnStartupCB.UseVisualStyleBackColor = true;
            launchOnStartupCB.CheckedChanged += launchOnStartupCB_CheckedChanged;
            // 
            // showBsodCB
            // 
            showBsodCB.AutoSize = true;
            showBsodCB.Location = new Point(6, 65);
            showBsodCB.Name = "showBsodCB";
            showBsodCB.Size = new Size(259, 24);
            showBsodCB.TabIndex = 0;
            showBsodCB.Text = "Show blue screen of death (BSOD)";
            showBsodCB.UseVisualStyleBackColor = true;
            showBsodCB.CheckedChanged += showBsodCB_CheckedChanged;
            // 
            // startGuardLaunchCB
            // 
            startGuardLaunchCB.AutoSize = true;
            startGuardLaunchCB.Location = new Point(6, 35);
            startGuardLaunchCB.Name = "startGuardLaunchCB";
            startGuardLaunchCB.Size = new Size(173, 24);
            startGuardLaunchCB.TabIndex = 2;
            startGuardLaunchCB.Text = "Start guard on launch";
            startGuardLaunchCB.UseVisualStyleBackColor = true;
            startGuardLaunchCB.CheckedChanged += startGuardLaunchCB_CheckedChanged;
            // 
            // settings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(301, 266);
            Controls.Add(settingsGB);
            Controls.Add(TestModeGB);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "settings";
            Text = "Aegis - Settings";
            TestModeGB.ResumeLayout(false);
            settingsGB.ResumeLayout(false);
            settingsGB.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox TestModeGB;
        private Button startTestModeBtn;
        private Button stopTestModeBtn;
        private GroupBox settingsGB;
        private CheckBox showBsodCB;
        private CheckBox launchOnStartupCB;
        private CheckBox startGuardLaunchCB;
    }
}