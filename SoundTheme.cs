using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace SoundCycle
{
    [Serializable]
    class SoundTheme
        : ISerializable
    {
        string m_name = "UNKNOWN";
        List<string> m_ambient = new List<string>();
        List<string> m_sound = new List<string>();

        public SoundTheme()
        {
            m_name = name;
        }

        public SoundTheme(string name)
        {
            m_name = name;
        }

        public SoundTheme(SerializationInfo info, StreamingContext ctxt)
        {
            this.m_name = (string)info.GetValue("Name", typeof(string));
            this.m_sound = (List<string>)info.GetValue("Sounds", typeof(List<string>));
            this.m_ambient = (List<string>)info.GetValue("Ambient", typeof(List<string>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Name", this.m_name);
            info.AddValue("Sounds", this.m_sound);
            info.AddValue("Ambient", this.m_ambient);
        }

        public void AddAmbient(string file)
        {
            m_ambient.Add(file);
        }

        public void AddSound(string file)
        {
            m_sound.Add(file);
        }

        public string name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        public List<string> effect
        {
            get { return m_sound; }
        }

        public List<string> ambient
        {
            get { return m_ambient; }
        }

    }
}
