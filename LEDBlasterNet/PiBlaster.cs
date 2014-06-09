using System.IO;
using System.Text;

namespace LEDBlasterNet
{
    public static class PiBlaster
    {
        private const string PiBlasterFile = "/dev/pi-blaster";
        private static readonly StreamWriter Writer;

        static PiBlaster()
        {
            var fileStream = new FileInfo(PiBlasterFile).OpenWrite();
            Writer = new StreamWriter(fileStream, Encoding.ASCII);
        }

        public static void Set(int channel, float value)
        {
            var command = string.Format("{0}={1}\n", channel, value);

            Writer.Write(command);
            Writer.Flush();
        }
    }
}
