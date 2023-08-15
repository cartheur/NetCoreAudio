using System;
using System.Threading.Tasks;

namespace NetCoreAudio.Interfaces
{
    public interface IRecorder
    {
        event EventHandler PlaybackFinished;

        bool Recording { get; }
        bool Paused { get; }

        Task Record(string fileName);
        Task Pause();
        Task Resume();
        Task Stop();
        Task SetVolume(byte percent);
    }
}
