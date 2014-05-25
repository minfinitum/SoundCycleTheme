using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using System.IO;

namespace SoundCycle
{
    partial class newTheme : Form
    {
        SoundTheme m_theme = null;

        public newTheme()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // need to validate text
            if (tbValue.Text.Length == 0)
            {
                MessageBox.Show(this, "theme name must not be empty", "error");
                return;
            }

            if (lbEffects.Items.Count == 0)
            {
                MessageBox.Show(this, "must be atleast one sound", "error");
                return;
            }

            if (lbAmbient.Items.Count == 0)
            {
                MessageBox.Show(this, "must be atleast one ambient sound", "error");
                return;
            }

            m_theme = new SoundTheme(tbValue.Text);
            foreach (string sound in lbEffects.Items)
                m_theme.AddSound(sound);

            foreach (string sound in lbAmbient.Items)
                m_theme.AddAmbient(sound);

            DialogResult = DialogResult.OK;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_theme = null;

            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public SoundTheme getTheme()
        {
            return m_theme;
        }

        private void addSound(ref ListBox lb)
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
                    // use relative directories if possible
                    if (file.Length > ofd.InitialDirectory.Length && string.Compare(file.Substring(0, ofd.InitialDirectory.Length), ofd.InitialDirectory, true) == 0)
                    {
                        lb.Items.Add(file.Substring(ofd.InitialDirectory.Length + 1));
                    }
                    else
                    {
                        lb.Items.Add(file);
                    }
                }
            }
        }

        private void removeSound(ref ListBox lb)
        {
            int selected = lb.SelectedIndex;
            if (-1 == selected)
                return;
            lb.Items.RemoveAt(selected);
        }

        private void btnSoundAdd_Click(object sender, EventArgs e)
        {
            addSound(ref lbEffects);
        }

        private void btnSoundRemove_Click(object sender, EventArgs e)
        {
            removeSound(ref lbEffects);
        }

        private void btnAmbientAdd_Click(object sender, EventArgs e)
        {
            addSound(ref lbAmbient);
        }

        private void btnAmbientRemove_Click(object sender, EventArgs e)
        {
            removeSound(ref lbAmbient);
        }


    }
}
