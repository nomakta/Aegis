using Microsoft.Win32;

namespace Aegis
{
    public partial class settings : Form
    {
        private Form1 mainForm;
        private bool isInitializing;

        public settings(Form1 form1)
        {
            isInitializing = true;

            InitializeComponent();
            mainForm = form1;

            startTestModeBtn.Enabled = !mainForm.testMode;
            stopTestModeBtn.Enabled = mainForm.testMode;
            showBsodCB.Checked = mainForm.triggerBSODenabled;
            startGuardLaunchCB.Checked = mainForm.startLaunch;
            launchOnStartupCB.Checked = IsAppInStartupList();

            isInitializing = false;
        }

        private void startTestModeBtn_Click(object sender, EventArgs e)
        {
            mainForm.SetTestMode(true);
            startTestModeBtn.Enabled = false;
            stopTestModeBtn.Enabled = true;
        }

        private void stopTestModeBtn_Click(object sender, EventArgs e)
        {
            mainForm.SetTestMode(false);
            startTestModeBtn.Enabled = true;
            stopTestModeBtn.Enabled = false;
        }

        private void showBsodCB_CheckedChanged(object sender, EventArgs e)
        {
            if (isInitializing) return;

            mainForm.SetTriggerBSODEnabled(showBsodCB.Checked);
            if (showBsodCB.Checked)
            {
                MessageBox.Show("Guard is now configured to trigger a Blue Screen of Death (BSOD) on USB activity.", "BSOD Enabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Guard is now configured to shut down the system normally on USB activity.", "BSOD Disabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void launchOnStartupCB_CheckedChanged(object sender, EventArgs e)
        {
            if (isInitializing) return;

            const string runKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Run";
            const string appName = "AegisApp";
            string appPath = Application.ExecutablePath;

            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(runKeyPath, true)) // Open the Run key for the current user
                {
                    if (key != null)
                    {
                        if (launchOnStartupCB.Checked)
                        {
                            // Add the application to startup
                            key.SetValue(appName, appPath);
                            MessageBox.Show("Application set to launch on startup.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            // Remove the application from startup
                            if (key.GetValue(appName) != null)
                            {
                                key.DeleteValue(appName);
                                MessageBox.Show("Application removed from startup.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Failed to modify startup settings. Please run as administrator.\n\nError: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while modifying startup settings:\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void startGuardLaunchCB_CheckedChanged(object sender, EventArgs e)
        {
            if (isInitializing) return;

            mainForm.SetStartLaunch(startGuardLaunchCB.Checked);
            if (startGuardLaunchCB.Checked)
            {
                MessageBox.Show("Guard will now launch automatically at application startup.", "Startup Enabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Guard will no longer launch automatically at application startup.", "Startup Disabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool IsAppInStartupList()
        {
            const string runKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Run";
            const string appName = "AegisApp"; // Name used in the registry
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(runKeyPath, false))
                {
                    if (key != null)
                    {
                        // Check if the app is listed in the Run key
                        object value = key.GetValue(appName);
                        return value != null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking startup settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

    }
}
