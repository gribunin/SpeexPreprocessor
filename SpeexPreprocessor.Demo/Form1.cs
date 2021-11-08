using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NAudio.CoreAudioApi;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using NAudio.Utils;
using SpeexPreprocessor;

namespace SpeexPreprocessor.Demo
{
    public partial class MainForm : Form
    {
        private WasapiCapture _wasapiCapture;
        private WasapiOut _wasapiOut;
        private Preprocessor _preprocessor;
        private ISampleProvider _sampleProvider;
        private BufferedWaveProvider _bufferedWaveProvider;
        private IWaveProvider _wave16Provider; // speex preprocessor works with 16-bit samples, but NAudio provider 32-but float samples, so we need to convert
        private CircularBuffer _speexFeedBuffer = new CircularBuffer(1024);
        private int _speexFrameSizeInBytes;

        private BufferedWaveProvider _playbackWaveProvider;
        private WaveToSampleProvider _playbackWaveToSampleProvider;

        private byte[] _samplesBuffer = Array.Empty<byte>();
        private byte[] _speexFrameBuffer = Array.Empty<byte>();

        private const int PREPROCESSOR_FRAME_SIZE_MS = 20; // Speex preprocessor frame size in milliseconds

        public MainForm()
        {
            InitializeComponent();

            cbCapture.Items.AddRange(GetCaptureDevices().OrderByDescending(x => x.IsDefault).ToArray());
            cbPlayback.Items.AddRange(GetRenderDevices().OrderByDescending(x => x.IsDefault).ToArray());

            if (cbCapture.Items.Count > 0)
            {
                cbCapture.SelectedIndex = 0;
            }

            if (cbPlayback.Items.Count > 0)
            {
                cbPlayback.SelectedIndex = 0;
            }
        }

        private static AudioDeviceModel CreateAudioDeviceModel(MMDevice device, bool isDefault)
        {
            string text;
            try
            {
                text = device.FriendlyName;
            }
            catch (Exception)
            {
                text = "-- Cannot get device name -- ";
            }

            return new AudioDeviceModel
            {
                Device = device,
                Text = isDefault ? "Default (" + text + ")" : text,
                IsDefault = isDefault
            };
        }

        private IEnumerable<AudioDeviceModel> GetAudioDevices(DataFlow dataFlow)
        {
            using (var enumerator = new MMDeviceEnumerator())
            {
                var defaultDevice = enumerator.GetDefaultAudioEndpoint(dataFlow, Role.Communications);

                var audioEndPoints = enumerator.EnumerateAudioEndPoints(dataFlow, DeviceState.Active);
                foreach (var device in audioEndPoints)
                {
                    yield return CreateAudioDeviceModel(device, defaultDevice.ID == device.ID);
                }
            }
        }

        private IEnumerable<AudioDeviceModel> GetCaptureDevices()
        {
            return GetAudioDevices(DataFlow.Capture);
        }

        private IEnumerable<AudioDeviceModel> GetRenderDevices()
        {
            return GetAudioDevices(DataFlow.Render);
        }

        private void StartPlayback(MMDevice device, WaveFormat waveFormat)
        {
            _wasapiOut = new WasapiOut(device, AudioClientShareMode.Shared, true, 40);
            _playbackWaveProvider = new BufferedWaveProvider(new WaveFormat(waveFormat.SampleRate, 16, 1))
            {
                DiscardOnBufferOverflow = true,
                ReadFully = true
            };

            _playbackWaveToSampleProvider = new WaveToSampleProvider(new Wave16ToFloatProvider(_playbackWaveProvider));

            _wasapiOut.Init(_playbackWaveToSampleProvider, true);
            _wasapiOut.Play();
        }

        private void Start()
        {
            var captureDevice = (AudioDeviceModel)cbCapture.SelectedItem;
            var playbackDevice = (AudioDeviceModel)cbPlayback.SelectedItem;

            if (captureDevice == null)
            {
                MessageBox.Show(this, "Capture device is not selected", "Can't start capture", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (playbackDevice == null)
            {
                MessageBox.Show(this, "Playback device is not selected", "Can't start capture", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StartCapture(captureDevice.Device);
            StartPlayback(playbackDevice.Device, _wasapiCapture.WaveFormat);
        }

        private void StartCapture(MMDevice device)
        {
            _wasapiCapture = new WasapiCapture(device, true, 60);
            _wasapiCapture.DataAvailable += _wasapiCapture_DataAvailable;

            // create speex preprocessor
            _speexFrameSizeInBytes = _wasapiCapture.WaveFormat.SampleRate * PREPROCESSOR_FRAME_SIZE_MS / 1000;
            _speexFrameBuffer = new byte[_speexFrameSizeInBytes];
            _preprocessor = new Preprocessor(_speexFrameSizeInBytes / sizeof(short), _wasapiCapture.WaveFormat.SampleRate);

            // prepare processing providers
            _bufferedWaveProvider = new BufferedWaveProvider(_wasapiCapture.WaveFormat)
            {
                DiscardOnBufferOverflow = true,
                ReadFully = false
            };
            _sampleProvider = _wasapiCapture.WaveFormat.Channels == 2 ? new StereoToMonoSampleProvider(_bufferedWaveProvider.ToSampleProvider()) : _bufferedWaveProvider.ToSampleProvider();
            _wave16Provider = _sampleProvider.ToWaveProvider16();

            _wasapiCapture.StartRecording();
        }

        private void StopCapture()
        {
            _wasapiCapture.StopRecording();
            _wasapiCapture.Dispose();
            _wasapiCapture = null;
        }

        private void StopPlayback()
        {
            _wasapiOut.Stop();
            _wasapiOut.Dispose();
            _wasapiOut = null;
        }

        private void Stop()
        {
            StopCapture();
            StopPlayback();
        }

        private void _wasapiCapture_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (e.BytesRecorded > 0)
            {
                _bufferedWaveProvider?.AddSamples(e.Buffer, 0, e.BytesRecorded);

                int sampleCount = e.BytesRecorded / 4;
                if (_wasapiCapture?.WaveFormat.Channels == 2)
                {
                    sampleCount /= 2;
                }

                int byteCount16bit = sampleCount * sizeof(short);
                if (_samplesBuffer.Length < byteCount16bit)
                {
                    _samplesBuffer = new byte[byteCount16bit];
                }

                int read = _wave16Provider.Read(_samplesBuffer, 0, byteCount16bit);
                _speexFeedBuffer.Write(_samplesBuffer, 0, read);

                // feed speex preprocessor data with frame size chunks
                while (_speexFeedBuffer.Count >= _speexFrameSizeInBytes)
                {
                    _speexFeedBuffer.Read(_speexFrameBuffer, 0, _speexFrameSizeInBytes);
                    _preprocessor.Run(_speexFrameBuffer);

                    PlayProcessedBuffer(_speexFrameBuffer);
                }
            }
        }

        private void PlayProcessedBuffer(byte[] buffer)
        {
            _playbackWaveProvider.AddSamples(buffer, 0, buffer.Length);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_wasapiCapture == null)
            {
                Start();
            }
            else
            {
                Stop();
            }

            btnCapture.Text = _wasapiCapture == null ? "Start" : "Stop";
            cbCapture.Enabled = _wasapiCapture == null;
            cbPlayback.Enabled = _wasapiCapture == null;
        }
    }
}
