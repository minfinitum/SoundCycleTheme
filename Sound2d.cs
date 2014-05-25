using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;

using DirectSound = Microsoft.DirectX.DirectSound;
using DirectX = Microsoft.DirectX;
using SoundVector = Microsoft.DirectX.Vector3;

namespace SoundCycle
{
    class Sound2d : Sound
    {
        // 2d sound
        private DirectSound.BufferDescription m_description2d;
        private DirectSound.SecondaryBuffer m_secondaryBuffer;
        private DirectSound.Notify m_notify;

        public Sound2d(string file, DirectSound.Device device)
        {
            // 2d setup
            m_description2d = new DirectSound.BufferDescription();
            m_description2d.ControlEffects = false;
            m_description2d.ControlVolume = true;
            m_description2d.GlobalFocus = true;
            m_description2d.ControlPositionNotify = true;

            m_secondaryBuffer = new DirectSound.SecondaryBuffer(file, m_description2d, device);

            m_notify = new DirectSound.Notify(m_secondaryBuffer);
        }

        override public void Dispose(bool disposing)
        {
            // If you need thread safety, use a lock around these 
            // operations, as well as in your methods that use the resource.
            if (!m_disposed)
            {
                if (disposing)
                {
                    if (m_description2d != null)
                        m_description2d.Dispose();

                    if (m_secondaryBuffer != null)
                        m_secondaryBuffer.Dispose();
                }

                m_description2d = null;
                m_secondaryBuffer = null;

                // Indicate that the instance has been disposed.
                m_disposed = true;
            }
        }

        /// <summary>
        /// play sound
        /// </summary>
        /// <param name="loop"></param>
        /// <param name="volume"></param>
        public override void Play(bool loop, int volume)
        {
            Microsoft.DirectX.DirectSound.BufferPlayFlags flags = Microsoft.DirectX.DirectSound.BufferPlayFlags.Default;
            if (loop)
                flags = Microsoft.DirectX.DirectSound.BufferPlayFlags.Looping;

            SetVolume(volume);
            m_secondaryBuffer.Play(0, flags);
        }

        public override void Play(SoundVector pos, bool loop, int volume, ref AutoResetEvent completedEvent)
        {
            // Set up two notification events, one at halfway, and one at the end of the buffer
            Microsoft.DirectX.DirectSound.BufferPositionNotify[] notifyCompleteEvent = new Microsoft.DirectX.DirectSound.BufferPositionNotify[1];

            notifyCompleteEvent[0].Offset = m_description2d.BufferBytes - 1;
            notifyCompleteEvent[0].EventNotifyHandle = completedEvent.SafeWaitHandle.DangerousGetHandle();
            m_notify.SetNotificationPositions(notifyCompleteEvent);

            Play(pos, loop, volume);
        }

        public override void SetVolume(int volume)
        {
            m_secondaryBuffer.Volume = -5000 - (volume * -50);
        }

        public override void Stop()
        {
            m_secondaryBuffer.Stop();
        }

        public override bool IsPlaying()
        {
            return m_secondaryBuffer.Status.Playing;
        }
    }
}
