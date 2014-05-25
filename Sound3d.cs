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
    class Sound3d : Sound
    {
        private DirectSound.BufferDescription m_description3d;
        private DirectSound.SecondaryBuffer m_secondaryBuffer;
        private DirectSound.Buffer3D m_buffer3d;
        private DirectSound.Notify m_notify;

        public Sound3d(string file, DirectSound.Device device)
        {
            m_description3d = new DirectSound.BufferDescription();
            m_description3d.ControlEffects = false;
            m_description3d.GlobalFocus = true;
            m_description3d.Control3D = true;
            m_description3d.ControlVolume = true;
            m_description3d.Guid3DAlgorithm = DirectSound.DSoundHelper.Guid3DAlgorithmHrtfFull;
            m_description3d.ControlPositionNotify = true;

            m_secondaryBuffer = new DirectSound.SecondaryBuffer(file, m_description3d, device);

            m_buffer3d = new DirectSound.Buffer3D(m_secondaryBuffer);
            m_buffer3d.Position = new SoundVector(0, 0, 1);
            m_buffer3d.Mode = DirectSound.Mode3D.Normal;

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
                    if (m_description3d != null)
                        m_description3d.Dispose();

                    if (m_secondaryBuffer != null)
                        m_secondaryBuffer.Dispose();

                    if (m_buffer3d != null)
                        m_buffer3d.Dispose();
                }

                m_description3d = null;
                m_secondaryBuffer = null;
                m_buffer3d = null;

                // Indicate that the instance has been disposed.
                m_disposed = true;
            }
        }

        public override void Play(SoundVector pos, bool loop, int volume)
        {
            Microsoft.DirectX.DirectSound.BufferPlayFlags flags = Microsoft.DirectX.DirectSound.BufferPlayFlags.Default;
            if (loop)
                flags = Microsoft.DirectX.DirectSound.BufferPlayFlags.Looping;

            UpdatePosition(pos);
            SetVolume(volume);

            m_secondaryBuffer.Play(0, flags);
        }

        public override void Play(SoundVector pos, bool loop, int volume, ref AutoResetEvent completedEvent)
        {
            // Set up two notification events, one at halfway, and one at the end of the buffer
            Microsoft.DirectX.DirectSound.BufferPositionNotify[] notifyCompleteEvent = new Microsoft.DirectX.DirectSound.BufferPositionNotify[1];

            notifyCompleteEvent[0].Offset = m_description3d.BufferBytes - 1;
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

        public void UpdatePosition(SoundVector pos)
        {
            m_buffer3d.Position = pos;
        }

    }
}
