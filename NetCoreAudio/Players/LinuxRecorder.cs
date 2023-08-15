using NetCoreAudio.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace NetCoreAudio.Players
{
    internal class LinuxRecorder : UnixPlayerBase, IRecorder
    {
        protected override string GetBashCommand(string fileName)
        {
            if (Path.GetExtension(fileName).ToLower().Equals(".mp3"))
            {
                return "mpg123 -q";
            }
            else
            {
                return "arecord -q";
            }
        }

        public override Task SetVolume(byte percent)
        {
            if (percent > 100)
                throw new ArgumentOutOfRangeException(nameof(percent), "Percent can't exceed 100");

            var tempProcess = StartBashProcess($"amixer -M set 'Master' {percent}%");
            tempProcess.WaitForExit();

            return Task.CompletedTask;
        }
    }
}
