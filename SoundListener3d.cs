using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DirectSound = Microsoft.DirectX.DirectSound;
using DirectX = Microsoft.DirectX;

namespace SoundCycle
{
    class SoundListener3d : IDisposable
    {
        // 3d sound
        DirectSound.BufferDescription m_descriptionListener;
        private DirectSound.Buffer m_primary3d;
        private DirectSound.Listener3D m_listener3d;

        private bool m_disposed = false;

        public SoundListener3d(DirectSound.Device device)
        {
            // 3d setup
            m_descriptionListener = new DirectSound.BufferDescription();

            m_descriptionListener.ControlEffects = false;
            m_descriptionListener.Control3D = true;
            m_descriptionListener.ControlVolume = true;
            m_descriptionListener.PrimaryBuffer = true;

            m_primary3d = new DirectSound.Buffer(m_descriptionListener, device);
            m_listener3d = new DirectSound.Listener3D(m_primary3d);

            // default orientation
            DirectSound.Listener3DOrientation o = new DirectSound.Listener3DOrientation();
            o.Front = new Microsoft.DirectX.Vector3(0, 0, 1);   // facing forward
            o.Top = new Microsoft.DirectX.Vector3(0, 1, 0);     // standing upright

            m_listener3d.Orientation = o;
        }

        public void Dispose()
        {
            Dispose(true);

            // Use SupressFinalize in case a subclass
            // of this type implements a finalize.
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
                    if (m_descriptionListener != null)
                        m_descriptionListener.Dispose();

                    if (m_primary3d != null)
                        m_primary3d.Dispose();

                    if (m_listener3d != null)
                        m_listener3d.Dispose();
                }

                m_descriptionListener = null;
                m_primary3d = null;
                m_listener3d = null;

                // Indicate that the instance has been disposed.
                m_disposed = true;
            }
        }

        public void UpdateListenerPosition(Microsoft.DirectX.Vector3 pos)
        {
            m_listener3d.Position = pos;
            DirectSound.Listener3DOrientation orientation = new DirectSound.Listener3DOrientation();

            orientation.Front = new DirectX.Vector3((float)Math.Sin(pos.Z), (float)Math.Cos(pos.Z), (float)Math.Sin(pos.Y));
            orientation.Top = new DirectX.Vector3((float)Math.Sin(pos.Z), (float)Math.Sin(pos.X), (float)Math.Cos(pos.X));
            m_listener3d.Orientation = orientation;
            m_listener3d.CommitDeferredSettings();
        }

    }
}
