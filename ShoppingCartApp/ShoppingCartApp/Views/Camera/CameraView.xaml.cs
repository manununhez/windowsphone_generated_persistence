using System;
using Windows.Media.Capture;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

using Windows.Media.MediaProperties;    //For Encoding Image in JPEG format
using Windows.Storage;                  //For storing Capture Image in App storage or in Picture Library
using Windows.UI.Xaml.Media.Imaging;    //For BitmapImage. for showing image on screen we need BitmapImage format.
using ShoppingCartApp.Common;


namespace ShoppingCartApp.Views
{

    public sealed partial class CameraView : Page
    {
        private NavigationHelper navigationHelper;

        public CameraView()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);

        }

        //Declare MediaCapture object globally
        MediaCapture captureManager;


        async private void Start_Capture_Preview_Click(object sender, RoutedEventArgs e)
        {
            captureManager = new MediaCapture();        //Define MediaCapture object
            await captureManager.InitializeAsync();     //Initialize MediaCapture and 
            capturePreview.Source = captureManager;     //Start preiving on CaptureElement
            await captureManager.StartPreviewAsync();   //Start camera capturing 
        }

        async private void Stop_Capture_Preview_Click(object sender, RoutedEventArgs e)
        {
            await captureManager.StopPreviewAsync();    //stop camera capturing
        }

        async private void Capture_Photo_Click(object sender, RoutedEventArgs e)
        {
            //Create JPEG image Encoding format for storing image in JPEG type
            ImageEncodingProperties imgFormat = ImageEncodingProperties.CreateJpeg();

            // create storage file in local app storage
            StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync("Photo.jpg", CreationCollisionOption.ReplaceExisting);

            // take photo and store it on file location.
            await captureManager.CapturePhotoToStorageFileAsync(imgFormat, file);

            //// create storage file in Picture Library
            //StorageFile file = await KnownFolders.PicturesLibrary.CreateFileAsync("Photo.jpg",CreationCollisionOption.GenerateUniqueName);

            // Get photo as a BitmapImage using storage file path.
            BitmapImage bmpImage = new BitmapImage(new Uri(file.Path));

            // show captured image on Image UIElement.
            imagePreivew.Source = bmpImage;

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

    }
}

