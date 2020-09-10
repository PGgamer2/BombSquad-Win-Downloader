using Ionic.Zip;
using Markdig;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace BombSquad_Win_Downloader
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        long DLBytesReceived;
        long DLBytesToReceive;
        string changelogTempPath = Environment.GetEnvironmentVariable("Temp") + @"\BombSquadChangelog.md";
        string BombSquadTempPath = Environment.GetEnvironmentVariable("Temp") + @"\bombsquad.zip";
        string BombSquadFinalPath;
        bool isServer = false;
        string latestVersion;

        #region Download Functions
        private void startDownload(string url, string path, string CustomEndMessage, Action ExecuteOnFinish)
        {
            if (CheckForInternetConnection())
            {
                Thread thread = new Thread(() =>
                {
                    WebClient client = new WebClient();
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                    client.DownloadFileCompleted += (sender, e) => client_DownloadFileCompleted(sender, e, CustomEndMessage, ExecuteOnFinish);
                    client.DownloadFileAsync(new Uri(url), path);
                });
                thread.Start();
                DLButton.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please connect to internet first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                DLInfo.Text = $"Downloaded {ConvertBytesToMegabytes(e.BytesReceived).ToString("0.00")}MB of {ConvertBytesToMegabytes(e.TotalBytesToReceive).ToString("0.00")}MB.";
                progressBar.Value = int.Parse(Math.Truncate(percentage).ToString());
                DLBytesToReceive = e.TotalBytesToReceive;
                DLBytesReceived = e.BytesReceived;
            });
        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e, string CustomEndMessage, Action ExecuteOnFinish)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                if (DLBytesReceived == DLBytesToReceive)
                    DLInfo.Text = CustomEndMessage;
                else
                    DLInfo.Text = "An error has occurred while downloading the file.";
                if (ExecuteOnFinish != null) ExecuteOnFinish();
            });
        }
        #endregion

        private void Main_Load(object sender, EventArgs e)
        {
            PathInput.Text = Environment.GetEnvironmentVariable("PROGRAMFILES") + @"\BombSquad\";
            // Download changelog
            startDownload("https://files.ballistica.net/bombsquad/builds/CHANGELOG.md",
                          changelogTempPath, "Changelog downloaded.", DisplayChangelog);
        }

        private void DisplayChangelog()
        {
            DLButton.Enabled = true;
            webBrowserChangelog.DocumentText = Markdown.ToHtml(File.ReadAllText(changelogTempPath));
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                PathInput.Text = folderBrowserDialog.SelectedPath;
        }

        private void DLButton_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(PathInput.Text);
            if (Directory.Exists(PathInput.Text) && !Directory.EnumerateFileSystemEntries(PathInput.Text).Any())
            {
                DialogResult confirmBox = MessageBox.Show($"Are you sure you want to download the program in this directory?\n({PathInput.Text})", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmBox == DialogResult.Yes)
                {
                    try
                    {
                        // Get latest version
                        latestVersion = File.ReadLines(changelogTempPath).First();
                        latestVersion = Regex.Replace(latestVersion, @"\(.*?\)", "");
                        latestVersion = latestVersion.Replace(" ", "").Replace("#", "");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Cannot get the latest version of the game from the changelog file.\nTrying to redownload the changelog...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        startDownload("https://files.ballistica.net/bombsquad/builds/CHANGELOG.md",
                                      changelogTempPath, "Changelog downloaded.", DisplayChangelog);
                        return;
                    }
                    string downloadURL = "https://files.ballistica.net/bombsquad/builds/BombSquad_Windows_" + latestVersion + ".zip";
                    isServer = false;
                    if (buttonDLserver.Checked)
                    {
                        downloadURL = "https://files.ballistica.net/bombsquad/builds/BombSquad_Server_Windows_" + latestVersion + ".zip";
                        isServer = true;
                    }
                    // Download ZIP file
                    BombSquadFinalPath = PathInput.Text;
                    BombSquadFinalPath = BombSquadFinalPath.Replace('/', '\\');
                    if (!BombSquadFinalPath.EndsWith(@"\")) BombSquadFinalPath += @"\";
                    startDownload(downloadURL, BombSquadTempPath, "ZIP file downloaded. Extracting...", ExtractGame);
                }
                else
                {
                    DeleteDirectory(PathInput.Text);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid and empty directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExtractGame()
        {
            if (DLBytesReceived == DLBytesToReceive)
            {
                Thread thread = new Thread(() =>
                {
                    string ExtractedFolderTemp = Environment.GetEnvironmentVariable("Temp") + @"\BombSquadExtractedTemp\";

                    try
                    {
                        ZipFile zip = ZipFile.Read(BombSquadTempPath);
                        foreach (ZipEntry e in zip)
                        {
                            e.Extract(ExtractedFolderTemp, ExtractExistingFileAction.OverwriteSilently);
                        }

                        if (Directory.Exists(BombSquadFinalPath))
                            Directory.Delete(BombSquadFinalPath);

                        if (isServer)
                            Directory.Move(ExtractedFolderTemp + "BombSquad_Server_Windows_" + latestVersion, BombSquadFinalPath);
                        else
                            Directory.Move(ExtractedFolderTemp + "BombSquad_Windows_" + latestVersion, BombSquadFinalPath);

                        DLInfo.Invoke((MethodInvoker)delegate ()
                        {
                            DLInfo.Text = "The game has been extracted successfully.";
                            DLButton.Enabled = true;
                        });

                        // Make a shortcut
                        string shortcutAddress = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

                        if (isServer)
                            shortcutAddress += @"\BombSquad Server.lnk";
                        else
                            shortcutAddress += @"\BombSquad.lnk";

                        object shDesktop = (object)"Desktop";
                        IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
                        string exec = BombSquadFinalPath + "BombSquad.exe";
                        if (isServer)
                            exec = BombSquadFinalPath + "launch_bombsquad_server.bat";
                        IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(shortcutAddress);
                        shortcut.TargetPath = exec;
                        shortcut.Save();
                    }
                    catch (Exception)
                    {
                        DLInfo.Invoke((MethodInvoker)delegate ()
                        {
                            DLInfo.Text = "An error has occurred while extracting or downloading the file.";
                            DLButton.Enabled = true;
                        });
                    }
                });
                thread.Start();
            }
            else
            {
                DLInfo.Text = "An error has occurred while downloading the file.";
                DLButton.Enabled = true;
            }
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                Console.WriteLine("Cannot connect to internet");
                return false;
            }
        }

        public static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        public static void DeleteDirectory(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(target_dir, false);
        }

        private void buttonDLgame_CheckedChanged(object sender, EventArgs e)
        {
            if (PathInput.Text == Environment.GetEnvironmentVariable("PROGRAMFILES") + @"\BombSquad Server\")
                PathInput.Text = Environment.GetEnvironmentVariable("PROGRAMFILES") + @"\BombSquad\";
        }

        private void buttonDLserver_CheckedChanged(object sender, EventArgs e)
        {
            if (PathInput.Text == Environment.GetEnvironmentVariable("PROGRAMFILES") + @"\BombSquad\")
                PathInput.Text = Environment.GetEnvironmentVariable("PROGRAMFILES") + @"\BombSquad Server\";
        }
    }
}
