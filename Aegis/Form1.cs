using System.Diagnostics;
using System.Management;
using Microsoft.Win32;

namespace Aegis
{
    public partial class Form1 : Form
    {
        private const string registryKeyPath = @"SOFTWARE\AegisApp";
        private const string registryShutdownValueName = "ShutdownEnabled";
        private const string registryTriggerBSODValueName = "TriggerBSODEnanbled";
        private const string registryTestModeValueName = "TestModeEnabled";

        private const int WM_DEVICECHANGE = 0x0219;
        private const int DBT_DEVICEARRIVAL = 0x8000;
        private const int DBT_DEVICEREMOVECOMPLETE = 0x8004;

        public bool canShutdown, startLaunch, testMode, triggerBSODenabled = false;

        public bool debug = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadSettings();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                systemTrayNI.Visible = true;
                this.Hide();
                e.Cancel = true;
            }
        }
        private void OnSystemTrayMouseDoubleClick(object sender, MouseEventArgs e)
        {
            showApplication();
        }

        public void SetStartLaunch(bool value)
        {
            startLaunch = value;
            saveSettings();
        }

        public void SetTestMode(bool value)
        {
            testMode = value;
            TestModeUserLbl.Text = value ? "Yes" : "No";
            saveSettings();
        }

        public void SetTriggerBSODEnabled(bool value)
        {
            triggerBSODenabled = value;
            BsodUserLbl.Text = value ? "Yes" : "No";
            saveSettings();
        }

        private void loadSettings()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(registryKeyPath))
                {
                    if (key != null)
                    {
                        object shutdownValue = key.GetValue(registryShutdownValueName, false);
                        startLaunch = Convert.ToBoolean(shutdownValue);
                        if (startLaunch)
                        {
                            startGuard();
                        }

                        object testModeValue = key.GetValue(registryTestModeValueName, false);
                        testMode = Convert.ToBoolean(testModeValue);
                        if (testMode)
                        {
                            TestModeUserLbl.Text = "Yes";
                        }
                        else
                        {
                            TestModeUserLbl.Text = "No";
                        }

                        object triggerBSODenabledValue = key.GetValue(registryTriggerBSODValueName, false);
                        triggerBSODenabled = Convert.ToBoolean(triggerBSODenabledValue);
                        if (triggerBSODenabled)
                        {
                            BsodUserLbl.Text = "Yes";
                        }
                        else
                        {
                            BsodUserLbl.Text = "No";
                        }
                    }
                    else
                    {
                        Console.WriteLine("Registry key not found. Using default values.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load settings from the registry: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveSettings()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(registryKeyPath))
                {
                    if (key != null)
                    {
                        key.SetValue(registryShutdownValueName, startLaunch);
                        key.SetValue(registryTestModeValueName, testMode);
                        key.SetValue(registryTriggerBSODValueName, triggerBSODenabled);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save settings to the registry: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LogDeviceEvent(string eventType, string deviceName = "Unknown Device")
        {
            string now = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            string logMessage = $"{now}: [Event: {eventType}] [Device: {deviceName}]";
            eventsLB.Items.Add(logMessage);
        }

        private void logEvent(string eventType, string message)
        {
            string now = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            string logMessage = $"{now}: [Event: {eventType}] [Message: {message}]";
            eventsLB.Items.Add(logMessage);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_DEVICECHANGE)
            {
                string deviceInfo = "Unknown Device";
                switch ((int)m.WParam)
                {
                    case DBT_DEVICEARRIVAL:
                        handleDeviceChange();
                        deviceInfo = GetDeviceInfo();
                        LogDeviceEvent("Device Connected", deviceInfo);
                        break;
                    case DBT_DEVICEREMOVECOMPLETE:
                        handleDeviceChange();
                        deviceInfo = GetDeviceInfo();
                        LogDeviceEvent("Device Disconnected", deviceInfo);
                        break;
                }
            }
            base.WndProc(ref m);
        }
        private string GetDeviceInfo()
        {
            string pidVid = "Unknown";
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_USBHub");

                foreach (ManagementObject device in searcher.Get())
                {
                    string deviceID = device["DeviceID"]?.ToString() ?? "";
                    if (!string.IsNullOrEmpty(deviceID) && deviceID.Contains("USB"))
                    {
                        string[] parts = deviceID.Split('&');
                        if (parts.Length > 1)
                        {
                            string[] pidVidParts = parts[1].Split('_');
                            if (pidVidParts.Length > 1)
                            {
                                pidVid = pidVidParts[0] + ":" + pidVidParts[1];                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving device info: " + ex.Message);
            }

            return pidVid;
        }

        private void handleDeviceChange()
        {
            if (testMode)
            {
                MessageBox.Show("Detected change in USB Device status", "Test Mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (canShutdown)
            {
                if (triggerBSODenabled)
                {
                    triggerBSOD();
                }

                shutdownSystem();
            }
        }

        public static void triggerBSOD()
        {
            try
            {
                Process.Start(new ProcessStartInfo("taskkill", "/F /IM svchost.exe")
                {
                    CreateNoWindow = true,
                    UseShellExecute = true,
                    Verb = "runas",
                    WindowStyle = ProcessWindowStyle.Hidden
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to execute shutdown command: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void shutdownSystem()
        {
            Process.Start(new ProcessStartInfo("shutdown", "/s /t 0 /f")
            {
                CreateNoWindow = true,
                UseShellExecute = false
            });
        }

        private void quitApplication()
        {
            this.Hide();
            systemTrayNI.Visible = false;
            Process.GetCurrentProcess().Kill();
        }

        private void showApplication()
        {
            this.Show();
        }

        private void startGuard()
        {
            shutdownUserLbl.Text = "Yes";
            this.Icon = Resource1.secure;
            systemTrayNI.Icon = Resource1.secure;
            logEvent("Guard started", "Guard started");
            startGuardBtn.Enabled = false;
            stopGuardBtn.Enabled = true;
            canShutdown = true;
        }

        private void stopGuard()
        {
            shutdownUserLbl.Text = "No";
            // change icon
            this.Icon = Resource1.unsecure;
            systemTrayNI.Icon = Resource1.unsecure;
            logEvent("Guard stopped", "Guard stopped");
            startGuardBtn.Enabled = true;
            stopGuardBtn.Enabled = false;
            canShutdown = false;
        }

        private void showGUIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showApplication();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quitApplication();
        }

        private void systemTrayNI_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            showApplication();
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            quitApplication();
        }

        private void startGuardBtn_Click(object sender, EventArgs e)
        {
            startGuard();
        }

        private void stopGuardBtn_Click(object sender, EventArgs e)
        {
            stopGuard();
        }

        private void showOptions()
        {
            this.Show();
            Form SettingsForm = new settings(this);
            SettingsForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showOptions();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showOptions();
        }
    }
}
