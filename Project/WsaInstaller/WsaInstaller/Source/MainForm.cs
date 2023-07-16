using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Windows.Forms;
using WsaInstaller.Utils;

namespace WsaInstaller
{
    public partial class MainForm : Form
    {
        private string[] downLinks;
        private int downLinksCount = 0;
        private static string wsaDownloadPath = "";
        private TempFolder tempFolder = new TempFolder();
        private FileDownloader fileDownloader = new FileDownloader();
        private PowerShellExecutor pse = new PowerShellExecutor();
        private string[] appxApps;
        private int appxAppsCount = 0;
        private long totalDownloadBytes = 0;
        private long[] allReceivedBytes;
        private int allReceivedBytesCount = 0;
        private static readonly int minumumRamSizeRequirement = 8; // GB
        private bool installationEnabled = false;
        private bool isFormClosable = true;
        private bool installationFinished = false;

        public MainForm()
        {
            InitializeComponent();
            ProgressBar.CheckForIllegalCrossThreadCalls = false;
            pse.CommandFailed += Pse_CommandFailed;
            pse.CommandCompleted += Pse_CommandCompleted;
        }

        /// <summary>
        /// The directory with the downloaded packages is deleted and the program is closed.
        /// </summary>
        private void Shutdown()
        {
            tempFolder.Delete();
            Application.Exit();
        }

        /// <summary>
        /// Checks if there is an active internet connection.
        /// </summary>
        /// <returns>Returns true if there is an active connection, false otherwise</returns>
        private bool CheckConnection()
        {
            if (!InternetConnectionChecker.CheckInternetConnection())
            {
                MessageBox.Show("No internet connection!", "WSA Installer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool IsWin11()
        {
            var name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
                        select x.GetPropertyValue("Caption")).FirstOrDefault();
            if (!name.ToString().StartsWith("Microsoft Windows 11"))
            {
                MessageBox.Show("Official Windows Subsystem for Android™️ is only supported on Windows 11 :(", "WSA Installer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        #region Load Contents

        /// <summary>
        /// Retrieves WSA's information from the server and goes to the next page.
        /// </summary>
        /// <returns>Returns false if it does not receive data from the server</returns>
        private bool GetWsaInfo()
        {
            string wsaInfo = WsaInfoLoader.GetInfo();
            if (wsaInfo != null && wsaInfo.Length != 0)
            {
                tabControl1.SelectTab(TabPageIndexes.WSA_INFO);
                rtbWsaLatestInfo.Rtf = wsaInfo;
                return true;
            }
            MessageBox.Show("There was a problem retrieving data", "WSA Installer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        /// <summary>
        /// fetches download links from server and streams to array
        /// </summary>
        /// <returns>Returns false if it does not receive data from the server</returns>
        private bool LoadDownloadLinks()
        {
            string[] links = GetDownloadLinks.GetLinks();
            if (links != null && links.Length > 0)
            {
                downLinks = links;
                allReceivedBytes = new long[links.Length];
                return true;
            }
            MessageBox.Show("Download link cannot be accessed", "WSA Installer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        /// <summary>
        /// If the CheckConnection(), GetWsaInfo(), LoadDownloadLinks() methods all return true,
        /// they will activate the download button. It is not enabled by default. If it returns false,
        /// the process does not continue.
        /// </summary>
        private void LoadContents()
        {
            if (CheckConnection() && GetWsaInfo() && LoadDownloadLinks())
            {
                btnDAI.Enabled = true;
                isFormClosable = false;
            }
            else
            {
                this.Close();
            }
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!Administration.IsAdministrator())
            {
                MessageBox.Show("You do not have the  required administrator permissions for installation!", "WSA Installer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
            tabControl1.SelectTab(TabPageIndexes.LOAD_CONTENTS);
            LoadContents();
            tabControl1.SelectTab(TabPageIndexes.WSA_INFO);
        }

        #region Download WSA Packages

        /// <summary>
        /// The package is downloaded from their address in the connection string to the temporary folder.
        /// The download will continue as long as the index of the directory is smaller than the size of the directory. 
        /// Otherwise, the installation process starts as all packages are downloaded.
        /// </summary>
        private void DownloadWsaPacks()
        {
            if (downLinksCount < downLinks.Length)
            {
                if (downLinks[downLinksCount].Length != 0 || !downLinks[downLinksCount].Equals("\n"))
                {
                    fileDownloader = new FileDownloader();
                    fileDownloader.DownloadProgressChanged += FileDownloader_DownloadProgressChanged;
                    fileDownloader.DownloadCompleted += FileDownloader_DownloadCompleted;
                    lblNowDownloadFileName.Text = fileDownloader.GetFileName(downLinks[downLinksCount]);
                    fileDownloader.DownloadFile(downLinks[downLinksCount], wsaDownloadPath);
                }
            }
            else
            {
                btnCancel.Enabled = false;
                appxApps = GetPackageFiles();
                tabControl1.SelectTab(TabPageIndexes.INSTALL);
                pbInstall.Style = ProgressBarStyle.Marquee;
                installationEnabled = true;
                InstallWsaPacks();
            }
        }

        /// <summary>
        /// e.Cancelled: The download was canceled by the user.
        /// e.Error: An error occurred while downloading.
        /// Otherwise: Download next pack;
        /// </summary>
        private void FileDownloader_DownloadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Download canceled");
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Download failed(" + e.Error.Message + ")");
                Shutdown();
            }
            else
            {
                downLinksCount++;
                allReceivedBytesCount++;
                DownloadWsaPacks();
            }
        }

        /// <summary>
        /// calculates instant and total progress each time the event is triggered
        /// </summary>
        private void FileDownloader_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            tpDAI_PB.Value = e.ProgressPercentage;
            lblDAIBytes.Text = MemoryConverter.ConvertToMemorySize(e.BytesReceived) + " / " + MemoryConverter.ConvertToMemorySize(e.TotalBytesToReceive);

            allReceivedBytes[allReceivedBytesCount] = e.BytesReceived;
            long currentDownloadBytes = allReceivedBytes.Sum();

            long ratio = (currentDownloadBytes * 100) / totalDownloadBytes;
            pbDAITotal.Value = Convert.ToInt32(ratio);

            lblDAIPercentage.Text = "% " + tpDAI_PB.Value.ToString();
            lblDAITotalPercent.Text = "% " + pbDAITotal.Value.ToString();

            lblDAITotalBytes.Text = MemoryConverter.ConvertToMemorySize(currentDownloadBytes) + " / " + MemoryConverter.ConvertToMemorySize(totalDownloadBytes);
        }

        /// <summary>
        /// calculates the total size of all packages to be downloaded
        /// </summary>
        private void CalculateTotalDownloadBytes()
        {
            for (int i = 0; i < downLinks.Length; i++)
            {
                totalDownloadBytes += fileDownloader.GetFileSize(downLinks[i]);
            }
        }

        #endregion

        #region Install WSA Packs

        /// <summary>
        /// Installs with powershell from array containing package list
        /// </summary>
        private void InstallWsaPacks()
        {
            pse.ExecuteCommand(string.Format("Add-AppxPackage -Path {0}", appxApps[appxAppsCount]));
        }

        /// <summary>
        /// If the array index is less than the array size, 
        /// it moves to the next install. if it is large, 
        /// it completes the installation and the user is notified.
        /// </summary>
        private void Pse_CommandCompleted(object sender, string e)
        {
            if (appxAppsCount < appxApps.Length - 1)
            {
                appxAppsCount++;
                InstallWsaPacks();
            }
            else
            {
                installationEnabled = false;
                installationFinished = true;
                pbInstall.Visible = false;
                lblInstall.Text = "Windows Subsystem for Android™️ installed.";
                btnCancel.Enabled = true;
                btnCancel.Text = "Finish";
            }
        }

        /// <summary>
        /// PowerShell gives an error message if an error occurs during command execution, the process terminates
        /// </summary>
        private void Pse_CommandFailed(object sender, string e)
        {
            MessageBox.Show("Installation failed", "WSA Installer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Shutdown();
        }

        /// <summary>
        /// Retrieves a list of packages with the extension .Appx, .AppxBunle, and Msixbundle downloaded to the temporary directory.
        /// </summary>
        private string[] GetPackageFiles()
        {
            string[] searchPatterns = { "*.appx", "*.Msixbundle", "*.AppxBundle" };

            List<string> fileNames = new List<string>();

            foreach (string searchPattern in searchPatterns)
            {
                string[] files = Directory.GetFiles(wsaDownloadPath, searchPattern);
                fileNames.AddRange(files);
            }

            return fileNames.ToArray();
        }
        #endregion

        /// <summary>
        /// Checks if Developer Mode is enabled.
        /// </summary>
        /// <returns>Returns true if enabled</returns>
        private bool CheckDeveloperMode()
        {
            if (!DeveloperModeChecker.IsDeveloperModeEnbled())
            {
                MessageBox.Show("Developer Mode not enabled! Enable Developer Mode to continue the installation.");
                DeveloperModeChecker.OpenDeveloperSettings();
                return false;
            }
            return true;
        }

        #region Sywtem Requirement

        /// <summary>
        /// Checks if there is enough free space for installation.
        /// </summary>
        /// <returns>Returns true if there is enough storage</returns>
        private bool CheckSpaceAvaliable()
        {
            if (!SystemRequirementsChecker.IsSpaceAvaliable(totalDownloadBytes))
            {
                MessageBox.Show("Unable to install because there is not enough space on your disk.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if this PC meets the minimum amount of memory for WSA
        /// </summary>
        /// <returns>Returns true if it meetsç</returns>
        private bool IsWSARamRequirementCompliant()
        {
            if (!SystemRequirementsChecker.IsRamEnough(minumumRamSizeRequirement))
            {
                MessageBox.Show("This PC does not meet the minimum RAM requirement.");
                return false;
            }
            return true;
        }

        #endregion

        private void btnDAI_Click(object sender, EventArgs e)
        {
            btnDAI.Enabled = false;
            tabControl1.SelectTab(TabPageIndexes.DOWNLOAD);

            if (!(CheckDeveloperMode() && CheckSpaceAvaliable() && IsWSARamRequirementCompliant() && IsWin11()))
            {
                return;
            }

            tempFolder.CreateRandom();
            wsaDownloadPath = tempFolder.GetPath();

            CalculateTotalDownloadBytes();
            DownloadWsaPacks();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (installationFinished)
            {
                Shutdown();
            }
            else
            {
                DialogResult result = MessageBox.Show("Would you like to cancel the process and terminate WSA Installer?", "Close ?", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    if (fileDownloader != null)
                    {
                        fileDownloader.Cancel();
                        tempFolder.Delete();
                    }
                    Application.Exit();
                }
            }
        }

        private void rtbWsaLatestInfo_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        private void MainForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Process.Start(Properties.Resources.projectWebSite);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isFormClosable)
            {
                e.Cancel = false;
                return;
            }
            if (installationEnabled)
            {
                MessageBox.Show("Please wait until the installation is complete", "WSA Installer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
                DialogResult result = MessageBox.Show("Are you sure you want to exit?", "WSA Installer", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
        }

        #region Tab Page Indexes
        protected class TabPageIndexes
        {
            public static readonly int LOAD_CONTENTS = 0;
            public static readonly int WSA_INFO = 1;
            public static readonly int DOWNLOAD = 2;
            public static readonly int INSTALL = 3;
        }
        #endregion
    }
}
