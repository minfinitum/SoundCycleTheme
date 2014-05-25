using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Runtime.Serialization;

namespace SoundCycle
{
    [Serializable]
    class ThemesConfig
        : ISerializable
    {
        private Dictionary<string, SoundTheme> m_themes = new Dictionary<string, SoundTheme>();
        private int m_ambientVolume = 100;
        private int m_soundVolume = 100;

        public ThemesConfig()
        {
        }

        public ThemesConfig(SerializationInfo info, StreamingContext ctxt)
        {
            this.m_themes = (Dictionary<string, SoundTheme>)info.GetValue("themes", typeof(Dictionary<string, SoundTheme>));

            this.m_soundVolume = (int)info.GetValue("soundvolume", typeof(int));
            this.m_ambientVolume = (int)info.GetValue("ambientvolume", typeof(int));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("themes", this.m_themes);
            info.AddValue("soundvolume", this.m_soundVolume);
            info.AddValue("ambientvolume", this.m_ambientVolume);
        }

        public int AmbientVolume
        {
            get { return m_ambientVolume; }
            set { m_ambientVolume = value; }
        }

        public int SoundVolume
        {
            get { return m_soundVolume; }
            set { m_soundVolume = value; }
        }

        public Dictionary<string, SoundTheme> Themes()
        {
            return m_themes;
        }

        public SoundTheme this[string theme]
        {
            get
            {
                return m_themes[theme];
            }

            set
            {
                m_themes[theme] = value;
            }
        }
    }
}
