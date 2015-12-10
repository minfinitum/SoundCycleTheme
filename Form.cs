using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

using SoundVector = Microsoft.DirectX.Vector3;

namespace SoundCycle
{
    public partial class SoundCycleTheme : Form
    {
        enum AppMode {
            AM_NORMAL,
            AM_EDIT
        };

        AppMode m_mode = AppMode.AM_NORMAL;
        ThemeManager m_themeManager;

        bool m_paint = false;
        bool m_play = false;
        SoundVector m_soundVector = new SoundVector(0.0f, 0.0f, 0.0f);

        private delegate void AddListBoxItemDelegate(string item, params object[] variableArguments);

        const string EffectSoundVolumeFormat = "Effect Volume: {0}%";
        const string AmbientSoundVolumeFormat = "Ambient Volume: {0}%";

        bool m_allowClose = false;

        public SoundCycleTheme()
        {
            InitializeComponent();

            lbVersion.Text = "Version: " + Application.ProductVersion.ToString();

            m_themeManager = new ThemeManager(this);

            LoadThemes();
        }

        private void LoadThemes()
        {
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string[] themefiles = Directory.GetFiles(path, "*.tfg");
            if (themefiles == null && themefiles.Count() == 0)
            {
                path = Directory.GetCurrentDirectory();
                themefiles = Directory.GetFiles(path, "*.tfg");
            }

            if (themefiles != null && themefiles.Count() != 0)
            {
                m_themeManager.LoadThemes(themefiles[0]);

                foreach (KeyValuePair<string, SoundTheme> theme in m_themeManager.themes)
                {
                    cbTheme.Items.Add(theme.Key);
                }

                if (m_themeManager.themes.Count() != 0)
                {
                    SetTheme(m_themeManager.themes.Keys.First());
                }
            }
        }

        public void SoundEvent(SoundVector vec)
        {
            m_paint = true;
            m_soundVector = vec;
            pbImage.Invalidate();
        }

        private void btnSoundAdd_Click(object sender, EventArgs e)
        {
            AddSound(ref lbEffectSounds);
        }

        private void btnSoundRemove_Click(object sender, EventArgs e)
        {
            RemoveSound(ref lbEffectSounds);
        }

        private void btnAmbientAdd_Click(object sender, EventArgs e)
        {
            AddSound(ref lbAmbientSounds);
        }

        private void btnAmbientRemove_Click(object sender, EventArgs e)
        {
            RemoveSound(ref lbAmbientSounds);
        }

        private void SoundCycleTheme_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (AppMode.AM_NORMAL == m_mode)
                    m_mode = AppMode.AM_EDIT;
                else
                    m_mode = AppMode.AM_NORMAL;

                UpdateAppMode();
            }


            if( e.KeyCode == Keys.MediaPlayPause)
            {
                if (m_play)
                    Stop();
                else
                    Play();
            }

            if(e.KeyCode == Keys.MediaStop)
            {
                Stop();
            }
        }

        private void AddSound(ref ListBox lb)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);

            ofd.Title = "Select file to add to current theme";
            ofd.Multiselect = true;
            ofd.Filter = "Wav files (*.wav)|*.wav|All files (*.*)|*.*";

            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                foreach (string file in ofd.FileNames)
                {
                    lb.Items.Add(file);
                }
            }
        }

        private void RemoveSound(ref ListBox lb)
        {
            int selected = lb.SelectedIndex;
            if (-1 == selected)
                return;
            lb.Items.RemoveAt(selected);
        }

        private void UpdateAppMode()
        {
            bool enableEdit = (m_mode == AppMode.AM_EDIT);

            btnThemeLoad.Visible = enableEdit;
            btnThemeSave.Visible = enableEdit;

            btnThemeAdd.Visible = enableEdit;
            btnThemeRemove.Visible = enableEdit;

            if (enableEdit)
                cbTheme.DropDownStyle = ComboBoxStyle.DropDown;
            else
                cbTheme.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnThemeAdd_Click(object sender, EventArgs e)
        {
            newTheme ib = new newTheme();
            if(ib.ShowDialog(this) == DialogResult.OK) 
            {
                SoundTheme theme = ib.getTheme();
                if (null != theme)
                {
                    m_themeManager.AddTheme(ref theme);
                    cbTheme.SelectedIndex = cbTheme.Items.Add(theme.name);
                    SetTheme(theme.name);
                }
            }
        }

        private void btnThemeRemove_Click(object sender, EventArgs e)
        {
            int selected = cbTheme.SelectedIndex;
            if (-1 == selected)
                return;

            string theme = cbTheme.Items[selected].ToString();
            m_themeManager.RemoveTheme(theme);
            cbTheme.Items.RemoveAt(selected);

            // load previous item
            selected = cbTheme.SelectedIndex;
            if(-1 == selected)
                return;
            theme = cbTheme.Items[selected].ToString();
            SetTheme(theme);
        }

        private void btnThemeLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);

            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.Multiselect = false;
            ofd.Filter = "tfg files (*.tfg)|*.tfg";

            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                // load themes file
                m_themeManager.LoadThemes(ofd.FileName);

                if (m_themeManager.themes.Count() != 0)
                {
                    SetTheme(m_themeManager.themes.Keys.First());
                }
            }
        }

        private void btnThemeSave_Click(object sender, EventArgs e)
        {
            if (cbTheme.Items.Count == 0)
            {
                MessageBox.Show("Must contain at least a theme.", "Error", MessageBoxButtons.OK);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);

            sfd.CheckFileExists = false;
            sfd.CheckPathExists = true;
            sfd.Filter = "tfg files (*.tfg)|*.tfg";

            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                // save themes file
                m_themeManager.SaveThemes(sfd.FileName);
            }
        }

        private void SetTheme(string name)
        {
            SoundTheme theme = m_themeManager.themes[name];
            Log("Setting theme: {0}", name);

            lblEffectVolume.Text = string.Format(EffectSoundVolumeFormat, m_themeManager.EffectVolume);
            lblAmbientVolume.Text = string.Format(AmbientSoundVolumeFormat, m_themeManager.AmbientVolume);

            int themeidx = cbTheme.Items.IndexOf(theme.name);
            if (themeidx != -1)
            {
                // select previous item
                cbTheme.SelectedIndex = cbTheme.Items.IndexOf(theme.name);
            }
            else
            {
                // add new item
                int idx = cbTheme.Items.Add(theme.name);
                cbTheme.SelectedIndex = idx;
            }

            lbEffectSounds.Items.Clear();
            foreach (string sound in theme.effect)
                lbEffectSounds.Items.Add(sound);

            lbAmbientSounds.Items.Clear();
            foreach (string sound in theme.ambient)
                lbAmbientSounds.Items.Add(sound);

            tbEffectVolume.Value = m_themeManager.EffectVolume;
            lblEffectVolume.Text = string.Format(EffectSoundVolumeFormat, m_themeManager.EffectVolume);

            tbAmbientVolume.Value = m_themeManager.AmbientVolume;
            lblAmbientVolume.Text = string.Format(AmbientSoundVolumeFormat, m_themeManager.AmbientVolume);
        }

        private void Play()
        {
            m_play = true;
            int themeidx = cbTheme.SelectedIndex;
            if (themeidx != -1)
            {
                string theme = (string)cbTheme.Items[themeidx];
                Log("Playing theme: {0}", theme);

                m_soundVector = new SoundVector(0.0f, 0.0f, 0.0f);
                m_themeManager.PlayTheme(theme);
            }
            else
            {
                Log("No theme selected");
            }
        }

        private void Stop()
        {
            m_paint = false;
            m_play = false;
            m_themeManager.StopTheme();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Play();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Stop();
        }

        public void Log(string format,  params object[] variableArguments)
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendFormat(format, variableArguments);
                builder.Append("\r\n");

                if(lbLog.InvokeRequired)
                {
                    // This is a worker thread so delegate the task.
                    AddListBoxItemDelegate addItemDelegate = new AddListBoxItemDelegate(this.Log);
                    lbLog.Invoke(addItemDelegate, format, variableArguments);
                }
                else
                {
                    // This is the UI thread so perform the task.
                    int idx = lbLog.Items.Add(builder.ToString());
                    lbLog.SetSelected(idx, true);
                }
            }
            catch (Exception ex)
            {
                lbLog.Items.Add(String.Format("Caught exception: {0}", ex.Message));
            }
        }

        private void tbSoundVolume_Scroll(object sender, EventArgs e)
        {
            m_themeManager.EffectVolume = tbEffectVolume.Value;
            lblEffectVolume.Text = string.Format(EffectSoundVolumeFormat, m_themeManager.EffectVolume);
        }

        private void tbAmbientVolume_Scroll(object sender, EventArgs e)
        {
            m_themeManager.AmbientVolume = tbAmbientVolume.Value;
            lblAmbientVolume.Text = string.Format(AmbientSoundVolumeFormat, m_themeManager.AmbientVolume);
        }

        private void pbImage_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(pbImage.BackColor);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            int xmid = pbImage.Size.Width / 2;
            int ymid = pbImage.Size.Height / 2;

            Pen pen = new Pen(Brushes.White);
            pen.Width = 2;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;

            e.Graphics.DrawLine(pen, 0.0f, ymid, pbImage.Size.Width, ymid);
            e.Graphics.DrawLine(pen, xmid, 0.0f, xmid, pbImage.Size.Height);

            if (m_paint)
            {
                // x y axis -MaxDistance <-> +MaxDistance
                int soundunit = m_themeManager.MaxDistance * 2;
                int unitx = (pbImage.Size.Width / soundunit);
                int unity = (pbImage.Size.Height / soundunit);

                // x == left right
                int x = (int)m_soundVector.X;

                // z == forward backward
                int y = -(int)m_soundVector.Z;

                int posx = (unitx * (x + (soundunit / 2))) - soundunit;
                int posy = (unity * (y + (soundunit / 2))) - soundunit;

                e.Graphics.FillEllipse(Brushes.Yellow, posx, posy, 20, 20);
            }
        }

        private void pbImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                int soundunit = m_themeManager.MaxDistance * 2;
                int unitx = (pbImage.Size.Width / soundunit);
                int unity = (pbImage.Size.Height / soundunit);

                int posx = 0; // left right
                posx = (e.X / unitx) - (soundunit / 2);

                int posy = 0; // up down

                int posz = 0; // forward backward
                posz = (e.Y / unity) - (soundunit / 2);

                SoundVector vec = new SoundVector(posx, posy, -posz);

                int index = lbEffectSounds.SelectedIndex;
                if (index == -1)
                {
                    m_themeManager.PlaySound(0, vec);
                }
                else
                {
                    m_themeManager.PlaySound(index, vec);
                }
            }
        }

        private void HideUI()
        {
            this.ShowInTaskbar = false;
            this.Hide();
            notifyIcon.Visible = true;
        }

        private void ShowUI()
        {
            this.ShowInTaskbar = true;
            this.Show();
            this.Activate();

            notifyIcon.Visible = false;
        }

        private void SoundCycleTheme_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!m_allowClose)
            {
                HideUI();
                e.Cancel = !m_allowClose;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowUI();
        }

        private void niMenuItemExit_Click(object sender, EventArgs e)
        {
            m_allowClose = true;
            this.Close();
        }

        private void niMenuItemPlay_Click(object sender, EventArgs e)
        {
            Play();
        }

        private void niMenuItemStop_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void niMenuItemOpen_Click(object sender, EventArgs e)
        {
            ShowUI();
        }

        private void cbTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cbTheme.SelectedIndex;
            if(idx != -1 || idx < cbTheme.Items.Count)  
            {
                SetTheme(cbTheme.Items[idx].ToString());
            }
        }
    }
}

