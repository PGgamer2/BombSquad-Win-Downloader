namespace BombSquad_Win_Downloader
{
    partial class Main
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.buttonDLgame = new System.Windows.Forms.RadioButton();
            this.buttonDLserver = new System.Windows.Forms.RadioButton();
            this.PathInput = new System.Windows.Forms.TextBox();
            this.labelDLPath = new System.Windows.Forms.Label();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.DLButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.DLInfo = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.tabPageChangelog = new System.Windows.Forms.TabPage();
            this.webBrowserChangelog = new System.Windows.Forms.WebBrowser();
            this.tabControl.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.tabPageChangelog.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonDLgame
            // 
            this.buttonDLgame.AutoSize = true;
            this.buttonDLgame.Checked = true;
            this.buttonDLgame.Location = new System.Drawing.Point(6, 6);
            this.buttonDLgame.Name = "buttonDLgame";
            this.buttonDLgame.Size = new System.Drawing.Size(134, 17);
            this.buttonDLgame.TabIndex = 0;
            this.buttonDLgame.TabStop = true;
            this.buttonDLgame.Text = "Download BombSquad";
            this.buttonDLgame.UseVisualStyleBackColor = true;
            this.buttonDLgame.CheckedChanged += new System.EventHandler(this.buttonDLgame_CheckedChanged);
            // 
            // buttonDLserver
            // 
            this.buttonDLserver.AutoSize = true;
            this.buttonDLserver.Location = new System.Drawing.Point(6, 29);
            this.buttonDLserver.Name = "buttonDLserver";
            this.buttonDLserver.Size = new System.Drawing.Size(107, 17);
            this.buttonDLserver.TabIndex = 1;
            this.buttonDLserver.Text = "Download Server";
            this.buttonDLserver.UseVisualStyleBackColor = true;
            this.buttonDLserver.CheckedChanged += new System.EventHandler(this.buttonDLserver_CheckedChanged);
            // 
            // PathInput
            // 
            this.PathInput.Location = new System.Drawing.Point(6, 83);
            this.PathInput.MaxLength = 260;
            this.PathInput.Name = "PathInput";
            this.PathInput.Size = new System.Drawing.Size(280, 20);
            this.PathInput.TabIndex = 2;
            this.PathInput.Text = "C:\\Program Files\\BombSquad\\";
            // 
            // labelDLPath
            // 
            this.labelDLPath.AutoSize = true;
            this.labelDLPath.Location = new System.Drawing.Point(6, 67);
            this.labelDLPath.Name = "labelDLPath";
            this.labelDLPath.Size = new System.Drawing.Size(80, 13);
            this.labelDLPath.TabIndex = 3;
            this.labelDLPath.Text = "Download Path";
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(292, 81);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseButton.TabIndex = 4;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // DLButton
            // 
            this.DLButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DLButton.Location = new System.Drawing.Point(6, 118);
            this.DLButton.Name = "DLButton";
            this.DLButton.Size = new System.Drawing.Size(361, 30);
            this.DLButton.TabIndex = 5;
            this.DLButton.Text = "Download";
            this.DLButton.UseVisualStyleBackColor = true;
            this.DLButton.Click += new System.EventHandler(this.DLButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(6, 169);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(361, 23);
            this.progressBar.TabIndex = 6;
            // 
            // DLInfo
            // 
            this.DLInfo.AutoSize = true;
            this.DLInfo.Location = new System.Drawing.Point(6, 153);
            this.DLInfo.Name = "DLInfo";
            this.DLInfo.Size = new System.Drawing.Size(0, 13);
            this.DLInfo.TabIndex = 8;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageMain);
            this.tabControl.Controls.Add(this.tabPageChangelog);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(381, 224);
            this.tabControl.TabIndex = 9;
            // 
            // tabPageMain
            // 
            this.tabPageMain.Controls.Add(this.buttonDLgame);
            this.tabPageMain.Controls.Add(this.DLInfo);
            this.tabPageMain.Controls.Add(this.buttonDLserver);
            this.tabPageMain.Controls.Add(this.PathInput);
            this.tabPageMain.Controls.Add(this.progressBar);
            this.tabPageMain.Controls.Add(this.labelDLPath);
            this.tabPageMain.Controls.Add(this.DLButton);
            this.tabPageMain.Controls.Add(this.BrowseButton);
            this.tabPageMain.Location = new System.Drawing.Point(4, 22);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(373, 198);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "Download";
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // tabPageChangelog
            // 
            this.tabPageChangelog.Controls.Add(this.webBrowserChangelog);
            this.tabPageChangelog.Location = new System.Drawing.Point(4, 22);
            this.tabPageChangelog.Name = "tabPageChangelog";
            this.tabPageChangelog.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageChangelog.Size = new System.Drawing.Size(373, 198);
            this.tabPageChangelog.TabIndex = 1;
            this.tabPageChangelog.Text = "Changelog";
            this.tabPageChangelog.UseVisualStyleBackColor = true;
            // 
            // webBrowserChangelog
            // 
            this.webBrowserChangelog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserChangelog.IsWebBrowserContextMenuEnabled = false;
            this.webBrowserChangelog.Location = new System.Drawing.Point(3, 3);
            this.webBrowserChangelog.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserChangelog.Name = "webBrowserChangelog";
            this.webBrowserChangelog.Size = new System.Drawing.Size(367, 192);
            this.webBrowserChangelog.TabIndex = 0;
            this.webBrowserChangelog.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            this.webBrowserChangelog.WebBrowserShortcutsEnabled = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 248);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.Text = "BombSquad Downloader for Windows";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.tabPageMain.PerformLayout();
            this.tabPageChangelog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton buttonDLgame;
        private System.Windows.Forms.RadioButton buttonDLserver;
        private System.Windows.Forms.TextBox PathInput;
        private System.Windows.Forms.Label labelDLPath;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Button DLButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label DLInfo;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TabPage tabPageChangelog;
        private System.Windows.Forms.WebBrowser webBrowserChangelog;
    }
}

