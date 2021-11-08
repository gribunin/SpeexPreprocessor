using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAudio.CoreAudioApi;

namespace SpeexPreprocessor.Demo
{
    internal class AudioDeviceModel
    {
        public string Text { get; set; }
        public MMDevice Device { get; set; }

        public bool IsDefault { get; set; }
    }
}
