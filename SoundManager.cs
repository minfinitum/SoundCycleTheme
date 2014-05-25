using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DirectSound = Microsoft.DirectX.DirectSound;
using DirectX = Microsoft.DirectX;
using SoundVector = Microsoft.DirectX.Vector3;

namespace SoundCycle
{
    class SoundManager : IDisposable
    {
        // directx devices
        private DirectSound.Device m_sounddevice;
        private bool m_disposed = false;

        private SoundListener3d m_listener;
        private Dictionary<string, Sound> m_soundlist = new Dictionary<string, Sound>();

        public SoundManager(System.Windows.Forms.Control owner)
        {
            m_sounddevice = new DirectSound.Device(Guid.Empty);
            m_sounddevice.SetCooperativeLevel(owner, DirectSound.CooperativeLevel.Normal);

            DirectSound.Speakers speakers = new DirectSound.Speakers();
            speakers.Surround = true;
            m_sounddevice.SpeakerConfig = speakers;

            m_listener = new SoundListener3d(m_sounddevice);
        }

        public void Dispose()
        {
            Dispose(true);

            // Use SupressFinalize in case a subclass
            // of this type implements a finalizer.
            GC.SuppressFinalize(this); 
        }

        protected virtual void Dispose(bool disposing)
        {
            // If you need thread safety, use a lock around these 
            // operations, as well as in your methods that use the resource.
            if (!m_disposed)
            {
                if (disposing)
                {
                    Unload();

                    if (m_sounddevice != null)
                    {
                        m_sounddevice.Dispose();
                    }
                }

                m_sounddevice = null;

                // Indicate that the instance has been disposed.
                m_disposed = true;
            }
        }

        public string GetSoundConfig()
        {
            return m_sounddevice.Caps.ToString();
        }

        public string GetSpeakerConfig()
        {
            return m_sounddevice.SpeakerConfig.ToString();
        }

        public void LoadSound(string file)
        {
            Sound2d sound = new Sound2d(file, m_sounddevice);
            lock (m_soundlist)
            {
                m_soundlist.Add(file, sound);
            }
        }

        public void LoadSound3D(string file)
        {
            Sound3d sound = new Sound3d(file, m_sounddevice);
            lock (m_soundlist)
            {
                m_soundlist.Add(file, sound);
            }
        }

        public void Unload(string file)
        {
            lock (m_soundlist)
            {
                if (m_soundlist.ContainsKey(file))
                {
                    m_soundlist[file].Stop();
                    m_soundlist[file].Dispose();
                    m_soundlist.Remove(file);
                }
            }
        }

        public void Unload()
        {
            lock (m_soundlist)
            {
                foreach (KeyValuePair<string, Sound> keyValue in m_soundlist)
                {
                    keyValue.Value.Dispose();
                }
                m_soundlist.Clear();
            }
        }

        public bool PlaySound(string file, bool loop, int volume)
        {
            bool retval = false;
            lock (m_soundlist)
            {
                if (m_soundlist.ContainsKey(file))
                {
                    m_soundlist[file].Play(loop, volume);
                    retval = true;
                }
            }
            return retval;
        }

        /// <summary>
        /// Play a mono sound in 3d
        /// </summary>
        /// <param name="file">file to be played</param>
        /// <param name="loop">loop file</param>
        public bool PlaySound3D(string file, SoundVector pos, bool loop, int volume)
        {
            bool retval = false;
            lock (m_soundlist)
            {
                if (m_soundlist.ContainsKey(file))
                {
                    m_soundlist[file].Play(pos, loop, volume);
                    retval = true;
                }
            }
            return retval;
        }

        public void SetVolume(string file, int volume)
        {
            lock (m_soundlist)
            {
                if (m_soundlist.ContainsKey(file))
                {
                    m_soundlist[file].SetVolume(volume);
                }
            }
        }

        public bool IsPlaying(string file)
        {
            bool retval = false;
            lock (m_soundlist)
            {
                if (m_soundlist.ContainsKey(file))
                {
                    retval = m_soundlist[file].IsPlaying();
                }
            }
            return retval;
        }

        public void StopPlay(string file)
        {
            lock (m_soundlist)
            {
                if (m_soundlist.ContainsKey(file))
                {
                    m_soundlist[file].Stop();
                }
            }
        }

        public void StopPlay()
        {
            lock (m_soundlist)
            {
                foreach (KeyValuePair<string, Sound> keyValue in m_soundlist)
                {
                    keyValue.Value.Stop();
                }
            }
        }

        public void UpdateSoundPosition(string file, SoundVector pos)
        {
            lock (m_soundlist)
            {
                if (m_soundlist.ContainsKey(file))
                {
                    if (m_soundlist[file].IsPlaying())
                    {
                        ((Sound3d)m_soundlist[file]).UpdatePosition(pos);
                    }
                }
            }
        }
    }
}
