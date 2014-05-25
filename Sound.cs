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
    public abstract class Sound : IDisposable 
    {
        protected bool m_disposed = false;

        public virtual void Play() { Play(false, 100); }
        public virtual void Play(bool loop, int volume) { }
        public virtual void Play(SoundVector pos, bool loop, int volume) { }
        public virtual void Play(SoundVector pos, bool loop, int volume, ref AutoResetEvent completedEvent) { }

        abstract public void SetVolume(int volume);
        abstract public void Stop();
        abstract public bool IsPlaying();
        abstract public void Dispose(bool disposing);

        public void Dispose()
        {
            Dispose(true);

            // Use SupressFinalize in case a subclass
            // of this type implements a finalizer.
            GC.SuppressFinalize(this);
        }
    }
}
