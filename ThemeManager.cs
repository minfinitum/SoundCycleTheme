using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

using System.Windows.Forms;
using System.Runtime.Serialization;

using SoundVector = Microsoft.DirectX.Vector3;

namespace SoundCycle
{
    class ThemeManager
    {
        SoundCycleTheme m_owner = null;
        SoundManager m_soundManager = null;

        ThemesConfig m_themes = new ThemesConfig();

        private SoundTheme m_activeTheme = new SoundTheme();
        private Random m_randAction = new Random();

        private int m_ambientIndex = 0;         // last ambient played
        private int m_effectIndex = 0;          // last effect played

        private System.Timers.Timer m_effectTimer = new System.Timers.Timer();
        private int m_minRandInterval = 5000;
        private int m_maxRandInterval = 20000;
        private int m_distance = 5;

        public int MaxDistance { get { return m_distance; } set { m_distance = value; } }
        public int MinRandInterval { get { return m_minRandInterval; } set { m_minRandInterval = value; } }
        public int MaxRandInterval { get { return m_maxRandInterval; } set { m_maxRandInterval = value; } }

        public ThemeManager(SoundCycleTheme owner)
        {
            m_owner = owner;
            m_soundManager = new SoundManager(m_owner);

            string[] soundOptions = m_soundManager.GetSoundConfig().Split(new char[] { '\n' });
            m_owner.Log("Sound Config");
            foreach (string option in soundOptions)
                m_owner.Log("\t" + option);

            string[] speakerOptions = m_soundManager.GetSpeakerConfig().Split(new char[] { '\n' });
            m_owner.Log("Speaker Config");
            foreach (string option in speakerOptions)
                m_owner.Log("\t" + option);

            m_effectTimer.Elapsed += new ElapsedEventHandler(EffectTimerEvent);
        }

        public void LoadThemes(string file)
        {
            FileSerializer<ThemesConfig> fs = new FileSerializer<ThemesConfig>();
            try
            {
                m_themes = fs.DeSerializeObject(file);                
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message, "exception");
            }
        }

        public void SaveThemes(string file)
        {
            FileSerializer<ThemesConfig> fs = new FileSerializer<ThemesConfig>();
            try
            {
                fs.SerializeObject(file, this.m_themes);
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message, "exception");
            }
        }

        public void AddTheme(ref SoundTheme theme)
        {
            m_themes[theme.name] = theme;
        }

        public void RemoveTheme(string theme)
        {
            if (m_themes.Themes().ContainsKey(theme))
            {
                m_themes.Themes().Remove(theme);
            }
        }

        public Dictionary<string, SoundTheme> themes
        {
            get { return m_themes.Themes(); }
        }

        public void PlayTheme(string theme)
        {
            if (!m_themes.Themes().ContainsKey(theme))
            {
                m_owner.Log("ERROR: Theme not found!");
                return;
            }

            lock (m_activeTheme)
            {
                m_owner.Log("Starting theme...");

                // set theme to active
                m_activeTheme = m_themes[theme];

                // load sounds
                foreach (string soundFile in m_activeTheme.effect)
                {
                    m_owner.Log("loading sound: {0}", soundFile);
                    m_soundManager.LoadSound3D(soundFile);
                }

                // load ambient sounds
                foreach (string soundFile in m_activeTheme.ambient)
                {
                    m_owner.Log("loading ambient sound: {0}", soundFile);
                    m_soundManager.LoadSound(soundFile);
                }

                // play ambient
                m_ambientIndex = 0;
                bool success = m_soundManager.PlaySound(m_activeTheme.ambient[m_ambientIndex], true, m_themes.AmbientVolume);

                // set timer for sounds
                m_effectIndex = 0;
                m_effectTimer.Interval = m_minRandInterval + (m_randAction.Next() % m_maxRandInterval);
                m_owner.Log("play sound: next interval in {0} second/s", m_effectTimer.Interval);
                m_effectTimer.Enabled = true;

                m_owner.Log("Started!");
            }
        }

        public void StopTheme()
        {
            m_owner.Log("Stopping theme...");

            // stop any effects
            m_effectTimer.Enabled = false;

            lock (m_activeTheme)
            {
                m_soundManager.StopPlay();
                m_soundManager.Unload();
            }

            m_owner.Log("Stopped!");
        }

        public void EffectTimerEvent(object source, ElapsedEventArgs e)
        {
            if (m_soundManager.IsPlaying(m_activeTheme.effect[m_effectIndex]))
                return;

            int newSoundIndex = m_randAction.Next() % m_activeTheme.effect.Count();
            SoundVector vec;
            
            // left handed coordinate system
            // x == left right
            vec.X = (m_randAction.Next(0, 1000) * 0.01f) - m_distance;

            // y == up down
            vec.Y = 0; // (m_randAction.Next(0, 1000) * 0.01f) - m_distance;

            // z == forward backward
            vec.Z = (m_randAction.Next(0, 1000) * 0.01f) - m_distance;

            PlaySound(newSoundIndex, vec);

            m_effectIndex = newSoundIndex;

            // reset interval amount
            m_effectTimer.Interval = m_minRandInterval + (m_randAction.Next() % m_maxRandInterval);
            m_owner.Log("play effect: next interval in {0} second/s", m_effectTimer.Interval);
        }

        public void updateVolume()
        {
            if (m_activeTheme.effect.Count == 0 || m_activeTheme.ambient.Count == 0)
            {
                return;
            }

            lock (m_activeTheme)
            {
                m_soundManager.SetVolume(m_activeTheme.effect[m_effectIndex], m_themes.SoundVolume);
                m_soundManager.SetVolume(m_activeTheme.ambient[m_ambientIndex], m_themes.AmbientVolume);
            }
        }

        public int AmbientVolume
        {
            get 
            {
                return m_themes.AmbientVolume; 
            }
            set 
            {
                m_themes.AmbientVolume = value;
                updateVolume();
            }
        }

        public int EffectVolume
        {
            get 
            {
                return m_themes.SoundVolume; 
            }
            set 
            {
                m_themes.SoundVolume = value;
                updateVolume();
            }
        }

        public bool PlaySound(int idx, SoundVector vec)
        {
            if (m_activeTheme.effect.Count == 0)
            {
                return false;
            }

            bool success = m_soundManager.PlaySound3D(m_activeTheme.effect[idx], vec, false, m_themes.SoundVolume);
            m_owner.Log("play effect: {0} pos:{1}:{2}:{3} - {4}", m_activeTheme.effect[idx], vec.X, vec.Y, vec.Z, success);
            m_owner.SoundEvent(vec);
            return success;
        }
    }
}
