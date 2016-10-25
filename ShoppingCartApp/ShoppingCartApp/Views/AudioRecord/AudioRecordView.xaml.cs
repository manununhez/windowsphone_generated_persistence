using ShoppingCartApp.Common;
using System;
using System.Diagnostics;
using Windows.Media;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


namespace ShoppingCartApp.Views
{

    public sealed partial class AudioRecordView : Page
    {
        private NavigationHelper navigationHelper;

        private MediaCapture _mediaCaptureManager;
        private StorageFile _recordStorageFile;
        private bool _recording;
        private bool _userRequestedRaw;
        private bool _rawAudioSupported;

        public AudioRecordView()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;

            InitializeAudioRecording();
        }

        private async void InitializeAudioRecording()
        {

            _mediaCaptureManager = new MediaCapture();
            var settings = new MediaCaptureInitializationSettings();
            settings.StreamingCaptureMode = StreamingCaptureMode.Audio;
            settings.MediaCategory = MediaCategory.Other;
            settings.AudioProcessing = (_rawAudioSupported && _userRequestedRaw) ? AudioProcessing.Raw : AudioProcessing.Default;

            await _mediaCaptureManager.InitializeAsync(settings);

            Debug.WriteLine("Device initialised successfully");
        }

        private async void CaptureAudio()
        {
            try
            {
                Debug.WriteLine("Starting record");
                String fileName = "record.m4a";

                _recordStorageFile = await KnownFolders.VideosLibrary.CreateFileAsync(fileName, CreationCollisionOption.GenerateUniqueName);

                Debug.WriteLine("Create record file successfully");

                MediaEncodingProfile recordProfile = MediaEncodingProfile.CreateM4a(AudioEncodingQuality.Auto);
                await _mediaCaptureManager.StartRecordToStorageFileAsync(recordProfile, this._recordStorageFile);

                Debug.WriteLine("Start Record successful");

                _recording = true;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Failed to capture audio");
            }
        }

        private async void StopCapture()
        {

            if (_recording)
            {
                Debug.WriteLine("Stopping recording");
                await _mediaCaptureManager.StopRecordAsync();
                Debug.WriteLine("Stop recording successful");
                _recording = false;
            }

        }

        private async void PlayRecordedCapture()
        {
            if (!_recording)
            {
                var stream = await _recordStorageFile.OpenAsync(FileAccessMode.Read);
                Debug.WriteLine("Recording file opened");
                playbackElement1.AutoPlay = true;
                playbackElement1.SetSource(stream, _recordStorageFile.FileType);
                playbackElement1.Play();
            }
        }

        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        private void CaptureButton_Click(object sender, RoutedEventArgs e)
        {
            CaptureAudio();
        }

        private void StopCaptureButton_Click(object sender, RoutedEventArgs e)
        {
            StopCapture();
        }

        private void PlayRecordButton_Click(object sender, RoutedEventArgs e)
        {
            PlayRecordedCapture();
        }
    }
}
