namespace SoundCycle
{
    partial class SoundCycleTheme
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoundCycleTheme));
            this.cbTheme = new System.Windows.Forms.ComboBox();
            this.lblTheme = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblEffectSounds = new System.Windows.Forms.Label();
            this.lbEffectSounds = new System.Windows.Forms.ListBox();
            this.lbAmbientSounds = new System.Windows.Forms.ListBox();
            this.lblAmbientSounds = new System.Windows.Forms.Label();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.pbline = new System.Windows.Forms.PictureBox();
            this.btnThemeRemove = new System.Windows.Forms.Button();
            this.btnThemeAdd = new System.Windows.Forms.Button();
            this.btnThemeSave = new System.Windows.Forms.Button();
            this.btnThemeLoad = new System.Windows.Forms.Button();
            this.tbEffectVolume = new System.Windows.Forms.TrackBar();
            this.tbAmbientVolume = new System.Windows.Forms.TrackBar();
            this.lblAmbientVolume = new System.Windows.Forms.Label();
            this.lblEffectVolume = new System.Windows.Forms.Label();
            this.lbVersion = new System.Windows.Forms.Label();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.niMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.niMenuItemPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.niMenuItemStop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.niMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbEffectVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAmbientVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.notifyIconContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbTheme
            // 
            this.cbTheme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTheme.FormattingEnabled = true;
            this.cbTheme.Location = new System.Drawing.Point(9, 22);
            this.cbTheme.Name = "cbTheme";
            this.cbTheme.Size = new System.Drawing.Size(300, 21);
            this.cbTheme.TabIndex = 1;
            this.cbTheme.SelectedIndexChanged += new System.EventHandler(this.cbTheme_SelectedIndexChanged);
            // 
            // lblTheme
            // 
            this.lblTheme.AutoSize = true;
            this.lblTheme.Location = new System.Drawing.Point(9, 4);
            this.lblTheme.Name = "lblTheme";
            this.lblTheme.Size = new System.Drawing.Size(40, 13);
            this.lblTheme.TabIndex = 4;
            this.lblTheme.Text = "Theme";
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlay.Location = new System.Drawing.Point(534, 307);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 15;
            this.btnPlay.Text = "&Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Location = new System.Drawing.Point(534, 336);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 16;
            this.btnStop.Text = "&Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblEffectSounds
            // 
            this.lblEffectSounds.AutoSize = true;
            this.lblEffectSounds.Location = new System.Drawing.Point(6, 56);
            this.lblEffectSounds.Name = "lblEffectSounds";
            this.lblEffectSounds.Size = new System.Drawing.Size(74, 13);
            this.lblEffectSounds.TabIndex = 6;
            this.lblEffectSounds.Text = "Effect Sounds";
            // 
            // lbEffectSounds
            // 
            this.lbEffectSounds.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbEffectSounds.FormattingEnabled = true;
            this.lbEffectSounds.Location = new System.Drawing.Point(9, 72);
            this.lbEffectSounds.Name = "lbEffectSounds";
            this.lbEffectSounds.Size = new System.Drawing.Size(300, 95);
            this.lbEffectSounds.TabIndex = 7;
            // 
            // lbAmbientSounds
            // 
            this.lbAmbientSounds.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAmbientSounds.FormattingEnabled = true;
            this.lbAmbientSounds.Location = new System.Drawing.Point(315, 72);
            this.lbAmbientSounds.Name = "lbAmbientSounds";
            this.lbAmbientSounds.Size = new System.Drawing.Size(297, 95);
            this.lbAmbientSounds.TabIndex = 12;
            // 
            // lblAmbientSounds
            // 
            this.lblAmbientSounds.AutoSize = true;
            this.lblAmbientSounds.Location = new System.Drawing.Point(309, 56);
            this.lblAmbientSounds.Name = "lblAmbientSounds";
            this.lblAmbientSounds.Size = new System.Drawing.Size(84, 13);
            this.lblAmbientSounds.TabIndex = 10;
            this.lblAmbientSounds.Text = "Ambient Sounds";
            // 
            // lbLog
            // 
            this.lbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLog.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbLog.FormattingEnabled = true;
            this.lbLog.Location = new System.Drawing.Point(9, 365);
            this.lbLog.Name = "lbLog";
            this.lbLog.ScrollAlwaysVisible = true;
            this.lbLog.Size = new System.Drawing.Size(603, 69);
            this.lbLog.TabIndex = 17;
            // 
            // pbline
            // 
            this.pbline.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbline.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbline.Location = new System.Drawing.Point(9, 52);
            this.pbline.Name = "pbline";
            this.pbline.Size = new System.Drawing.Size(600, 1);
            this.pbline.TabIndex = 11;
            this.pbline.TabStop = false;
            // 
            // btnThemeRemove
            // 
            this.btnThemeRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemeRemove.Location = new System.Drawing.Point(337, 20);
            this.btnThemeRemove.Name = "btnThemeRemove";
            this.btnThemeRemove.Size = new System.Drawing.Size(19, 24);
            this.btnThemeRemove.TabIndex = 3;
            this.btnThemeRemove.Text = "-";
            this.btnThemeRemove.UseVisualStyleBackColor = true;
            this.btnThemeRemove.Visible = false;
            this.btnThemeRemove.Click += new System.EventHandler(this.btnThemeRemove_Click);
            // 
            // btnThemeAdd
            // 
            this.btnThemeAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemeAdd.Location = new System.Drawing.Point(312, 20);
            this.btnThemeAdd.Name = "btnThemeAdd";
            this.btnThemeAdd.Size = new System.Drawing.Size(19, 24);
            this.btnThemeAdd.TabIndex = 2;
            this.btnThemeAdd.Text = "+";
            this.btnThemeAdd.UseVisualStyleBackColor = true;
            this.btnThemeAdd.Visible = false;
            this.btnThemeAdd.Click += new System.EventHandler(this.btnThemeAdd_Click);
            // 
            // btnThemeSave
            // 
            this.btnThemeSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemeSave.Location = new System.Drawing.Point(593, 20);
            this.btnThemeSave.Name = "btnThemeSave";
            this.btnThemeSave.Size = new System.Drawing.Size(19, 24);
            this.btnThemeSave.TabIndex = 5;
            this.btnThemeSave.Text = "-";
            this.btnThemeSave.UseVisualStyleBackColor = true;
            this.btnThemeSave.Visible = false;
            this.btnThemeSave.Click += new System.EventHandler(this.btnThemeSave_Click);
            // 
            // btnThemeLoad
            // 
            this.btnThemeLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemeLoad.Location = new System.Drawing.Point(568, 20);
            this.btnThemeLoad.Name = "btnThemeLoad";
            this.btnThemeLoad.Size = new System.Drawing.Size(19, 24);
            this.btnThemeLoad.TabIndex = 4;
            this.btnThemeLoad.Text = "+";
            this.btnThemeLoad.UseVisualStyleBackColor = true;
            this.btnThemeLoad.Visible = false;
            this.btnThemeLoad.Click += new System.EventHandler(this.btnThemeLoad_Click);
            // 
            // tbEffectVolume
            // 
            this.tbEffectVolume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEffectVolume.AutoSize = false;
            this.tbEffectVolume.Location = new System.Drawing.Point(9, 186);
            this.tbEffectVolume.Maximum = 100;
            this.tbEffectVolume.Name = "tbEffectVolume";
            this.tbEffectVolume.Size = new System.Drawing.Size(300, 29);
            this.tbEffectVolume.TabIndex = 9;
            this.tbEffectVolume.TickFrequency = 20;
            this.tbEffectVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbEffectVolume.Value = 100;
            this.tbEffectVolume.Scroll += new System.EventHandler(this.tbSoundVolume_Scroll);
            // 
            // tbAmbientVolume
            // 
            this.tbAmbientVolume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAmbientVolume.AutoSize = false;
            this.tbAmbientVolume.Location = new System.Drawing.Point(312, 186);
            this.tbAmbientVolume.Maximum = 100;
            this.tbAmbientVolume.Name = "tbAmbientVolume";
            this.tbAmbientVolume.Size = new System.Drawing.Size(300, 29);
            this.tbAmbientVolume.TabIndex = 14;
            this.tbAmbientVolume.TickFrequency = 20;
            this.tbAmbientVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAmbientVolume.Value = 100;
            this.tbAmbientVolume.Scroll += new System.EventHandler(this.tbAmbientVolume_Scroll);
            // 
            // lblAmbientVolume
            // 
            this.lblAmbientVolume.AutoSize = true;
            this.lblAmbientVolume.Location = new System.Drawing.Point(309, 170);
            this.lblAmbientVolume.Name = "lblAmbientVolume";
            this.lblAmbientVolume.Size = new System.Drawing.Size(83, 13);
            this.lblAmbientVolume.TabIndex = 13;
            this.lblAmbientVolume.Text = "Ambient Volume";
            // 
            // lblEffectVolume
            // 
            this.lblEffectVolume.AutoSize = true;
            this.lblEffectVolume.Location = new System.Drawing.Point(6, 170);
            this.lblEffectVolume.Name = "lblEffectVolume";
            this.lblEffectVolume.Size = new System.Drawing.Size(73, 13);
            this.lblEffectVolume.TabIndex = 8;
            this.lblEffectVolume.Text = "Effect Volume";
            // 
            // lbVersion
            // 
            this.lbVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbVersion.Location = new System.Drawing.Point(459, 4);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(153, 13);
            this.lbVersion.TabIndex = 0;
            this.lbVersion.Text = "Version: 0000.0000.0000.0000";
            this.lbVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pbImage
            // 
            this.pbImage.BackColor = System.Drawing.Color.Black;
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage.Location = new System.Drawing.Point(207, 214);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(210, 140);
            this.pbImage.TabIndex = 24;
            this.pbImage.TabStop = false;
            this.pbImage.Paint += new System.Windows.Forms.PaintEventHandler(this.pbImage_Paint);
            this.pbImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbImage_MouseUp);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyIconContextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // notifyIconContextMenuStrip
            // 
            this.notifyIconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.niMenuItemOpen,
            this.niMenuItemPlay,
            this.niMenuItemStop,
            this.toolStripSeparator1,
            this.niMenuItemExit});
            this.notifyIconContextMenuStrip.Name = "notifyIconContextMenuStrip";
            this.notifyIconContextMenuStrip.Size = new System.Drawing.Size(104, 98);
            // 
            // niMenuItemOpen
            // 
            this.niMenuItemOpen.Name = "niMenuItemOpen";
            this.niMenuItemOpen.Size = new System.Drawing.Size(103, 22);
            this.niMenuItemOpen.Text = "&Open";
            this.niMenuItemOpen.Click += new System.EventHandler(this.niMenuItemOpen_Click);
            // 
            // niMenuItemPlay
            // 
            this.niMenuItemPlay.Name = "niMenuItemPlay";
            this.niMenuItemPlay.Size = new System.Drawing.Size(103, 22);
            this.niMenuItemPlay.Text = "&Play";
            this.niMenuItemPlay.Click += new System.EventHandler(this.niMenuItemPlay_Click);
            // 
            // niMenuItemStop
            // 
            this.niMenuItemStop.Name = "niMenuItemStop";
            this.niMenuItemStop.Size = new System.Drawing.Size(103, 22);
            this.niMenuItemStop.Text = "&Stop";
            this.niMenuItemStop.Click += new System.EventHandler(this.niMenuItemStop_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(100, 6);
            // 
            // niMenuItemExit
            // 
            this.niMenuItemExit.Name = "niMenuItemExit";
            this.niMenuItemExit.Size = new System.Drawing.Size(103, 22);
            this.niMenuItemExit.Text = "E&xit";
            this.niMenuItemExit.Click += new System.EventHandler(this.niMenuItemExit_Click);
            // 
            // SoundCycleTheme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.lbVersion);
            this.Controls.Add(this.lblEffectVolume);
            this.Controls.Add(this.lblAmbientVolume);
            this.Controls.Add(this.tbAmbientVolume);
            this.Controls.Add(this.tbEffectVolume);
            this.Controls.Add(this.btnThemeSave);
            this.Controls.Add(this.btnThemeLoad);
            this.Controls.Add(this.btnThemeRemove);
            this.Controls.Add(this.btnThemeAdd);
            this.Controls.Add(this.pbline);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.lblAmbientSounds);
            this.Controls.Add(this.lbAmbientSounds);
            this.Controls.Add(this.lbEffectSounds);
            this.Controls.Add(this.lblEffectSounds);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.lblTheme);
            this.Controls.Add(this.cbTheme);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "SoundCycleTheme";
            this.Text = "SoundCycleTheme";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SoundCycleTheme_FormClosing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SoundCycleTheme_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbEffectVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAmbientVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.notifyIconContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTheme;
        private System.Windows.Forms.Label lblTheme;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblEffectSounds;
        private System.Windows.Forms.ListBox lbEffectSounds;
        private System.Windows.Forms.ListBox lbAmbientSounds;
        private System.Windows.Forms.Label lblAmbientSounds;
        private System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.PictureBox pbline;
        private System.Windows.Forms.Button btnThemeRemove;
        private System.Windows.Forms.Button btnThemeAdd;
        private System.Windows.Forms.Button btnThemeSave;
        private System.Windows.Forms.Button btnThemeLoad;
        private System.Windows.Forms.TrackBar tbEffectVolume;
        private System.Windows.Forms.TrackBar tbAmbientVolume;
        private System.Windows.Forms.Label lblAmbientVolume;
        private System.Windows.Forms.Label lblEffectVolume;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyIconContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem niMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem niMenuItemPlay;
        private System.Windows.Forms.ToolStripMenuItem niMenuItemStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem niMenuItemOpen;

    }
}

