namespace Aegis
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
            systemTrayNI = new NotifyIcon(components);
            systemTrayCMS = new ContextMenuStrip(components);
            showGUIToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            quitToolStripMenuItem = new ToolStripMenuItem();
            eventsGB = new GroupBox();
            eventsLB = new ListBox();
            settingsGB = new GroupBox();
            TestModeUserLbl = new Label();
            TestModeInfoLbl = new Label();
            BsodUserLbl = new Label();
            BsodInfoLbl = new Label();
            shutdownUserLbl = new Label();
            shutdownInfoLbl = new Label();
            startGuardBtn = new Button();
            stopGuardBtn = new Button();
            button3 = new Button();
            quitBtn = new Button();
            systemTrayCMS.SuspendLayout();
            eventsGB.SuspendLayout();
            settingsGB.SuspendLayout();
            SuspendLayout();
            // 
            // systemTrayNI
            // 
            systemTrayNI.BalloonTipIcon = ToolTipIcon.Info;
            systemTrayNI.BalloonTipText = "Aegis";
            systemTrayNI.BalloonTipTitle = "Anti-forensics tool";
            systemTrayNI.ContextMenuStrip = systemTrayCMS;
            systemTrayNI.Icon = (Icon)resources.GetObject("systemTrayNI.Icon");
            systemTrayNI.Text = "Aegis";
            systemTrayNI.Visible = true;
            systemTrayNI.MouseDoubleClick += systemTrayNI_MouseDoubleClick_1;
            // 
            // systemTrayCMS
            // 
            systemTrayCMS.ImageScalingSize = new Size(20, 20);
            systemTrayCMS.Items.AddRange(new ToolStripItem[] { showGUIToolStripMenuItem, optionsToolStripMenuItem, quitToolStripMenuItem });
            systemTrayCMS.Name = "contextMenuStrip1";
            systemTrayCMS.Size = new Size(143, 76);
            // 
            // showGUIToolStripMenuItem
            // 
            showGUIToolStripMenuItem.Name = "showGUIToolStripMenuItem";
            showGUIToolStripMenuItem.Size = new Size(142, 24);
            showGUIToolStripMenuItem.Text = "Show GUI";
            showGUIToolStripMenuItem.Click += showGUIToolStripMenuItem_Click;
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(142, 24);
            optionsToolStripMenuItem.Text = "Options";
            optionsToolStripMenuItem.Click += optionsToolStripMenuItem_Click;
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.Size = new Size(142, 24);
            quitToolStripMenuItem.Text = "Quit";
            quitToolStripMenuItem.Click += quitToolStripMenuItem_Click;
            // 
            // eventsGB
            // 
            eventsGB.Controls.Add(eventsLB);
            eventsGB.Location = new Point(12, 12);
            eventsGB.Name = "eventsGB";
            eventsGB.Size = new Size(534, 200);
            eventsGB.TabIndex = 1;
            eventsGB.TabStop = false;
            eventsGB.Text = "Event logs";
            // 
            // eventsLB
            // 
            eventsLB.FormattingEnabled = true;
            eventsLB.HorizontalScrollbar = true;
            eventsLB.Location = new Point(6, 26);
            eventsLB.Name = "eventsLB";
            eventsLB.ScrollAlwaysVisible = true;
            eventsLB.Size = new Size(522, 164);
            eventsLB.TabIndex = 0;
            // 
            // settingsGB
            // 
            settingsGB.Controls.Add(TestModeUserLbl);
            settingsGB.Controls.Add(TestModeInfoLbl);
            settingsGB.Controls.Add(BsodUserLbl);
            settingsGB.Controls.Add(BsodInfoLbl);
            settingsGB.Controls.Add(shutdownUserLbl);
            settingsGB.Controls.Add(shutdownInfoLbl);
            settingsGB.Location = new Point(12, 218);
            settingsGB.Name = "settingsGB";
            settingsGB.Size = new Size(250, 220);
            settingsGB.TabIndex = 2;
            settingsGB.TabStop = false;
            settingsGB.Text = "Options overview";
            // 
            // TestModeUserLbl
            // 
            TestModeUserLbl.AutoSize = true;
            TestModeUserLbl.Location = new Point(6, 185);
            TestModeUserLbl.Name = "TestModeUserLbl";
            TestModeUserLbl.Size = new Size(30, 20);
            TestModeUserLbl.TabIndex = 11;
            TestModeUserLbl.Text = "Yes";
            // 
            // TestModeInfoLbl
            // 
            TestModeInfoLbl.AutoSize = true;
            TestModeInfoLbl.Location = new Point(6, 159);
            TestModeInfoLbl.Name = "TestModeInfoLbl";
            TestModeInfoLbl.Size = new Size(136, 20);
            TestModeInfoLbl.TabIndex = 10;
            TestModeInfoLbl.Text = "Test Mode enabled";
            // 
            // BsodUserLbl
            // 
            BsodUserLbl.AutoSize = true;
            BsodUserLbl.Location = new Point(6, 118);
            BsodUserLbl.Name = "BsodUserLbl";
            BsodUserLbl.Size = new Size(30, 20);
            BsodUserLbl.TabIndex = 9;
            BsodUserLbl.Text = "Yes";
            // 
            // BsodInfoLbl
            // 
            BsodInfoLbl.AutoSize = true;
            BsodInfoLbl.Location = new Point(6, 92);
            BsodInfoLbl.Name = "BsodInfoLbl";
            BsodInfoLbl.Size = new Size(180, 20);
            BsodInfoLbl.TabIndex = 8;
            BsodInfoLbl.Text = "Show BSOD on shutdown:";
            // 
            // shutdownUserLbl
            // 
            shutdownUserLbl.AutoSize = true;
            shutdownUserLbl.Location = new Point(6, 54);
            shutdownUserLbl.Name = "shutdownUserLbl";
            shutdownUserLbl.Size = new Size(29, 20);
            shutdownUserLbl.TabIndex = 7;
            shutdownUserLbl.Text = "No";
            // 
            // shutdownInfoLbl
            // 
            shutdownInfoLbl.AutoSize = true;
            shutdownInfoLbl.Location = new Point(6, 28);
            shutdownInfoLbl.Name = "shutdownInfoLbl";
            shutdownInfoLbl.Size = new Size(213, 20);
            shutdownInfoLbl.TabIndex = 6;
            shutdownInfoLbl.Text = "Shutting down on USB Activity:";
            // 
            // startGuardBtn
            // 
            startGuardBtn.Location = new Point(268, 228);
            startGuardBtn.Name = "startGuardBtn";
            startGuardBtn.Size = new Size(272, 56);
            startGuardBtn.TabIndex = 0;
            startGuardBtn.Text = "Start guarding USB ports";
            startGuardBtn.UseVisualStyleBackColor = true;
            startGuardBtn.Click += startGuardBtn_Click;
            // 
            // stopGuardBtn
            // 
            stopGuardBtn.Enabled = false;
            stopGuardBtn.Location = new Point(268, 290);
            stopGuardBtn.Name = "stopGuardBtn";
            stopGuardBtn.Size = new Size(272, 40);
            stopGuardBtn.TabIndex = 3;
            stopGuardBtn.Text = "Stop guarding USB ports";
            stopGuardBtn.UseVisualStyleBackColor = true;
            stopGuardBtn.Click += stopGuardBtn_Click;
            // 
            // button3
            // 
            button3.Location = new Point(268, 397);
            button3.Name = "button3";
            button3.Size = new Size(119, 41);
            button3.TabIndex = 4;
            button3.Text = "Options";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // quitBtn
            // 
            quitBtn.Location = new Point(421, 397);
            quitBtn.Name = "quitBtn";
            quitBtn.Size = new Size(119, 41);
            quitBtn.TabIndex = 5;
            quitBtn.Text = "Quit";
            quitBtn.UseVisualStyleBackColor = true;
            quitBtn.Click += quitBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(558, 450);
            Controls.Add(quitBtn);
            Controls.Add(button3);
            Controls.Add(stopGuardBtn);
            Controls.Add(startGuardBtn);
            Controls.Add(settingsGB);
            Controls.Add(eventsGB);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Aegis";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            systemTrayCMS.ResumeLayout(false);
            eventsGB.ResumeLayout(false);
            settingsGB.ResumeLayout(false);
            settingsGB.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private NotifyIcon systemTrayNI;
        private ContextMenuStrip systemTrayCMS;
        private GroupBox eventsGB;
        private ListBox eventsLB;
        private ToolStripMenuItem showGUIToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem;
        private GroupBox settingsGB;
        private Button startGuardBtn;
        private Button stopGuardBtn;
        private Button button3;
        private Button quitBtn;
        private Label BsodUserLbl;
        private Label BsodInfoLbl;
        private Label shutdownUserLbl;
        private Label shutdownInfoLbl;
        private Label TestModeUserLbl;
        private Label TestModeInfoLbl;
        private ToolStripMenuItem optionsToolStripMenuItem;
    }
}
