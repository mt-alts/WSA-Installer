namespace WsaInstaller
{
    partial class MainForm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDAI = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tPageGetWsaInfo = new System.Windows.Forms.TabPage();
            this.tpCL_LBL = new System.Windows.Forms.Label();
            this.tpLC_PB = new System.Windows.Forms.ProgressBar();
            this.tPageWsaInfo = new System.Windows.Forms.TabPage();
            this.rtbWsaLatestInfo = new System.Windows.Forms.RichTextBox();
            this.tPageWsaDownload = new System.Windows.Forms.TabPage();
            this.lblDAITotalPercent = new System.Windows.Forms.Label();
            this.lblDAITotalBytes = new System.Windows.Forms.Label();
            this.lblNowDownloadFileName = new System.Windows.Forms.Label();
            this.lblDAITotal = new System.Windows.Forms.Label();
            this.lblDAIPercentage = new System.Windows.Forms.Label();
            this.lblDAIBytes = new System.Windows.Forms.Label();
            this.pbDAITotal = new System.Windows.Forms.ProgressBar();
            this.tpDAI_PB = new System.Windows.Forms.ProgressBar();
            this.tpDAI_LBL = new System.Windows.Forms.Label();
            this.tPageWsaInstall = new System.Windows.Forms.TabPage();
            this.pbInstall = new System.Windows.Forms.ProgressBar();
            this.lblInstall = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tPageGetWsaInfo.SuspendLayout();
            this.tPageWsaInfo.SuspendLayout();
            this.tPageWsaDownload.SuspendLayout();
            this.tPageWsaInstall.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDAI
            // 
            this.btnDAI.Enabled = false;
            this.btnDAI.Location = new System.Drawing.Point(138, 305);
            this.btnDAI.Name = "btnDAI";
            this.btnDAI.Size = new System.Drawing.Size(158, 30);
            this.btnDAI.TabIndex = 0;
            this.btnDAI.Text = "Download and Install";
            this.btnDAI.UseVisualStyleBackColor = true;
            this.btnDAI.Click += new System.EventHandler(this.btnDAI_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 305);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 30);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tPageGetWsaInfo);
            this.tabControl1.Controls.Add(this.tPageWsaInfo);
            this.tabControl1.Controls.Add(this.tPageWsaDownload);
            this.tabControl1.Controls.Add(this.tPageWsaInstall);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(312, 299);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 1;
            // 
            // tPageGetWsaInfo
            // 
            this.tPageGetWsaInfo.BackColor = System.Drawing.SystemColors.Control;
            this.tPageGetWsaInfo.Controls.Add(this.tpCL_LBL);
            this.tPageGetWsaInfo.Controls.Add(this.tpLC_PB);
            this.tPageGetWsaInfo.Location = new System.Drawing.Point(4, 5);
            this.tPageGetWsaInfo.Name = "tPageGetWsaInfo";
            this.tPageGetWsaInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tPageGetWsaInfo.Size = new System.Drawing.Size(304, 290);
            this.tPageGetWsaInfo.TabIndex = 0;
            // 
            // tpCL_LBL
            // 
            this.tpCL_LBL.AutoSize = true;
            this.tpCL_LBL.Location = new System.Drawing.Point(6, 6);
            this.tpCL_LBL.Name = "tpCL_LBL";
            this.tpCL_LBL.Size = new System.Drawing.Size(106, 16);
            this.tpCL_LBL.TabIndex = 2;
            this.tpCL_LBL.Text = "Checking WSA...";
            // 
            // tpLC_PB
            // 
            this.tpLC_PB.Location = new System.Drawing.Point(8, 33);
            this.tpLC_PB.MarqueeAnimationSpeed = 20;
            this.tpLC_PB.Name = "tpLC_PB";
            this.tpLC_PB.Size = new System.Drawing.Size(284, 28);
            this.tpLC_PB.Step = 1;
            this.tpLC_PB.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.tpLC_PB.TabIndex = 0;
            // 
            // tPageWsaInfo
            // 
            this.tPageWsaInfo.BackColor = System.Drawing.SystemColors.Control;
            this.tPageWsaInfo.Controls.Add(this.rtbWsaLatestInfo);
            this.tPageWsaInfo.Location = new System.Drawing.Point(4, 5);
            this.tPageWsaInfo.Name = "tPageWsaInfo";
            this.tPageWsaInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tPageWsaInfo.Size = new System.Drawing.Size(304, 290);
            this.tPageWsaInfo.TabIndex = 1;
            // 
            // rtbWsaLatestInfo
            // 
            this.rtbWsaLatestInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbWsaLatestInfo.Location = new System.Drawing.Point(8, 7);
            this.rtbWsaLatestInfo.Name = "rtbWsaLatestInfo";
            this.rtbWsaLatestInfo.Size = new System.Drawing.Size(284, 277);
            this.rtbWsaLatestInfo.TabIndex = 0;
            this.rtbWsaLatestInfo.Text = "";
            this.rtbWsaLatestInfo.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbWsaLatestInfo_LinkClicked);
            // 
            // tPageWsaDownload
            // 
            this.tPageWsaDownload.BackColor = System.Drawing.SystemColors.Control;
            this.tPageWsaDownload.Controls.Add(this.lblDAITotalPercent);
            this.tPageWsaDownload.Controls.Add(this.lblDAITotalBytes);
            this.tPageWsaDownload.Controls.Add(this.lblNowDownloadFileName);
            this.tPageWsaDownload.Controls.Add(this.lblDAITotal);
            this.tPageWsaDownload.Controls.Add(this.lblDAIPercentage);
            this.tPageWsaDownload.Controls.Add(this.lblDAIBytes);
            this.tPageWsaDownload.Controls.Add(this.pbDAITotal);
            this.tPageWsaDownload.Controls.Add(this.tpDAI_PB);
            this.tPageWsaDownload.Controls.Add(this.tpDAI_LBL);
            this.tPageWsaDownload.Location = new System.Drawing.Point(4, 5);
            this.tPageWsaDownload.Name = "tPageWsaDownload";
            this.tPageWsaDownload.Size = new System.Drawing.Size(304, 290);
            this.tPageWsaDownload.TabIndex = 2;
            this.tPageWsaDownload.Text = "Installing WSA";
            // 
            // lblDAITotalPercent
            // 
            this.lblDAITotalPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDAITotalPercent.Location = new System.Drawing.Point(239, 178);
            this.lblDAITotalPercent.Name = "lblDAITotalPercent";
            this.lblDAITotalPercent.Size = new System.Drawing.Size(56, 23);
            this.lblDAITotalPercent.TabIndex = 6;
            this.lblDAITotalPercent.Text = "0";
            this.lblDAITotalPercent.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDAITotalBytes
            // 
            this.lblDAITotalBytes.AutoSize = true;
            this.lblDAITotalBytes.Location = new System.Drawing.Point(6, 178);
            this.lblDAITotalBytes.Name = "lblDAITotalBytes";
            this.lblDAITotalBytes.Size = new System.Drawing.Size(31, 16);
            this.lblDAITotalBytes.TabIndex = 5;
            this.lblDAITotalBytes.Text = "0 / 0";
            // 
            // lblNowDownloadFileName
            // 
            this.lblNowDownloadFileName.AutoEllipsis = true;
            this.lblNowDownloadFileName.Location = new System.Drawing.Point(96, 6);
            this.lblNowDownloadFileName.Name = "lblNowDownloadFileName";
            this.lblNowDownloadFileName.Size = new System.Drawing.Size(200, 23);
            this.lblNowDownloadFileName.TabIndex = 4;
            this.lblNowDownloadFileName.Text = "file_name.extension";
            // 
            // lblDAITotal
            // 
            this.lblDAITotal.AutoSize = true;
            this.lblDAITotal.Location = new System.Drawing.Point(6, 110);
            this.lblDAITotal.Name = "lblDAITotal";
            this.lblDAITotal.Size = new System.Drawing.Size(38, 16);
            this.lblDAITotal.TabIndex = 3;
            this.lblDAITotal.Text = "Total";
            this.lblDAITotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDAIPercentage
            // 
            this.lblDAIPercentage.Location = new System.Drawing.Point(242, 73);
            this.lblDAIPercentage.Name = "lblDAIPercentage";
            this.lblDAIPercentage.Size = new System.Drawing.Size(50, 16);
            this.lblDAIPercentage.TabIndex = 2;
            this.lblDAIPercentage.Text = "0";
            this.lblDAIPercentage.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDAIBytes
            // 
            this.lblDAIBytes.AutoSize = true;
            this.lblDAIBytes.Location = new System.Drawing.Point(6, 73);
            this.lblDAIBytes.Name = "lblDAIBytes";
            this.lblDAIBytes.Size = new System.Drawing.Size(31, 16);
            this.lblDAIBytes.TabIndex = 2;
            this.lblDAIBytes.Text = "0 / 0";
            // 
            // pbDAITotal
            // 
            this.pbDAITotal.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.pbDAITotal.Location = new System.Drawing.Point(8, 138);
            this.pbDAITotal.MarqueeAnimationSpeed = 20;
            this.pbDAITotal.Name = "pbDAITotal";
            this.pbDAITotal.Size = new System.Drawing.Size(284, 28);
            this.pbDAITotal.Step = 1;
            this.pbDAITotal.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbDAITotal.TabIndex = 1;
            this.pbDAITotal.UseWaitCursor = true;
            // 
            // tpDAI_PB
            // 
            this.tpDAI_PB.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.tpDAI_PB.Location = new System.Drawing.Point(8, 33);
            this.tpDAI_PB.MarqueeAnimationSpeed = 20;
            this.tpDAI_PB.Name = "tpDAI_PB";
            this.tpDAI_PB.Size = new System.Drawing.Size(284, 28);
            this.tpDAI_PB.Step = 1;
            this.tpDAI_PB.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.tpDAI_PB.TabIndex = 1;
            this.tpDAI_PB.UseWaitCursor = true;
            // 
            // tpDAI_LBL
            // 
            this.tpDAI_LBL.AutoSize = true;
            this.tpDAI_LBL.Location = new System.Drawing.Point(6, 6);
            this.tpDAI_LBL.Name = "tpDAI_LBL";
            this.tpDAI_LBL.Size = new System.Drawing.Size(92, 16);
            this.tpDAI_LBL.TabIndex = 0;
            this.tpDAI_LBL.Text = "Downloading :";
            // 
            // tPageWsaInstall
            // 
            this.tPageWsaInstall.BackColor = System.Drawing.SystemColors.Control;
            this.tPageWsaInstall.Controls.Add(this.pbInstall);
            this.tPageWsaInstall.Controls.Add(this.lblInstall);
            this.tPageWsaInstall.Location = new System.Drawing.Point(4, 5);
            this.tPageWsaInstall.Name = "tPageWsaInstall";
            this.tPageWsaInstall.Size = new System.Drawing.Size(304, 290);
            this.tPageWsaInstall.TabIndex = 3;
            this.tPageWsaInstall.Text = "tabPage1";
            // 
            // pbInstall
            // 
            this.pbInstall.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.pbInstall.Location = new System.Drawing.Point(8, 33);
            this.pbInstall.MarqueeAnimationSpeed = 20;
            this.pbInstall.Name = "pbInstall";
            this.pbInstall.Size = new System.Drawing.Size(284, 28);
            this.pbInstall.Step = 1;
            this.pbInstall.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbInstall.TabIndex = 2;
            this.pbInstall.UseWaitCursor = true;
            // 
            // lblInstall
            // 
            this.lblInstall.AutoSize = true;
            this.lblInstall.Location = new System.Drawing.Point(6, 6);
            this.lblInstall.Name = "lblInstall";
            this.lblInstall.Size = new System.Drawing.Size(264, 16);
            this.lblInstall.TabIndex = 0;
            this.lblInstall.Text = "Installing Windows Subsystem for Android™️";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 347);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDAI);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = global::WsaInstaller.Properties.Resources.wsa_installer;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "WSA Installer";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.MainForm_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tPageGetWsaInfo.ResumeLayout(false);
            this.tPageGetWsaInfo.PerformLayout();
            this.tPageWsaInfo.ResumeLayout(false);
            this.tPageWsaDownload.ResumeLayout(false);
            this.tPageWsaDownload.PerformLayout();
            this.tPageWsaInstall.ResumeLayout(false);
            this.tPageWsaInstall.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDAI;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tPageGetWsaInfo;
        private System.Windows.Forms.TabPage tPageWsaInfo;
        private System.Windows.Forms.ProgressBar tpLC_PB;
        private System.Windows.Forms.Label tpCL_LBL;
        private System.Windows.Forms.RichTextBox rtbWsaLatestInfo;
        private System.Windows.Forms.TabPage tPageWsaDownload;
        private System.Windows.Forms.ProgressBar tpDAI_PB;
        private System.Windows.Forms.Label tpDAI_LBL;
        private System.Windows.Forms.Label lblDAIBytes;
        private System.Windows.Forms.Label lblDAIPercentage;
        private System.Windows.Forms.Label lblDAITotal;
        private System.Windows.Forms.ProgressBar pbDAITotal;
        private System.Windows.Forms.Label lblNowDownloadFileName;
        private System.Windows.Forms.Label lblDAITotalPercent;
        private System.Windows.Forms.Label lblDAITotalBytes;
        private System.Windows.Forms.TabPage tPageWsaInstall;
        private System.Windows.Forms.Label lblInstall;
        private System.Windows.Forms.ProgressBar pbInstall;
    }
}

