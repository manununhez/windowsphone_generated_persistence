using ShoppingCartApp.Common;
using System;
using Windows.Devices.Geolocation;
using Windows.Devices.Sensors;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ShoppingCartApp.Views
{

    public sealed partial class SensorsView : Page
    {
        private NavigationHelper navigationHelper;

        public Accelerometer accelerometer { get; set; }
        public Gyrometer gyrometer { get; set; }
        public Compass compass { get; set; }
        public LightSensor lightSensor { get; set; }

        //Use for get efficient signal intervals between accelerometer responses
        private uint desiredReportInterval { get; set; }
        public SensorsView()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;

            accelerometer = Accelerometer.GetDefault();
            gyrometer = Gyrometer.GetDefault();
            compass = Compass.GetDefault();
            lightSensor = LightSensor.GetDefault();

            if (accelerometer != null && gyrometer != null)
            {
                // Select a report interval that is both suitable for the purposes of the app and supported by the sensor.
                // This value will be used later to activate the sensor.
                uint minReportInterval = accelerometer.MinimumReportInterval;
                desiredReportInterval = minReportInterval > 16 ? minReportInterval : 16;


                accelerometer.ReportInterval = desiredReportInterval;
                gyrometer.ReportInterval = desiredReportInterval;
                compass.ReportInterval = desiredReportInterval;
                lightSensor.ReportInterval = desiredReportInterval;
                
                //add event for accelerometer readings
                accelerometer.ReadingChanged += new TypedEventHandler<Accelerometer, AccelerometerReadingChangedEventArgs>(ReadingChanged);
                gyrometer.ReadingChanged += new TypedEventHandler<Gyrometer, GyrometerReadingChangedEventArgs>(ReadingChanged);
                compass.ReadingChanged += new TypedEventHandler<Compass, CompassReadingChangedEventArgs>(ReadingChanged);
                lightSensor.ReadingChanged += new TypedEventHandler<LightSensor, LightSensorReadingChangedEventArgs>(ReadingChanged);

            }
            else
            {
                MessageDialog ms = new MessageDialog("No accelerometer Found");
                ms.ShowAsync();
            }

            this.NavigationCacheMode = NavigationCacheMode.Required;
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

        /// <summary>
        /// reading accelerometer changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private async void ReadingChanged(Accelerometer sender, AccelerometerReadingChangedEventArgs args)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                AccelerometerReading reading = args.Reading;
                tbxAccelerometer.Text = reading.AccelerationX+","+ reading.AccelerationY+","+ reading.AccelerationZ;
                /*corX.Text = String.Format("{0,5:0.00}", reading.AccelerationX);
                corY.Text = String.Format("{0,5:0.00}", reading.AccelerationY);
                corZ.Text = String.Format("{0,5:0.00}", reading.AccelerationZ);*/
            });
        }

        /// <summary>
        /// reading accelerometer changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private async void ReadingChanged(Compass sender, CompassReadingChangedEventArgs args)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                CompassReading reading = args.Reading;
                tbxCompass.Text = reading.HeadingAccuracy+","+reading.HeadingMagneticNorth+","+reading.HeadingTrueNorth;
               /* corX.Text = String.Format("{0,5:0.00}", reading.HeadingAccuracy);
                corY.Text = String.Format("{0,5:0.00}", reading.HeadingMagneticNorth);
                corZ.Text = String.Format("{0,5:0.00}", reading.HeadingTrueNorth);*/
            });
        }


        /// <summary>
        /// reading accelerometer changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private async void ReadingChanged(LightSensor sender, LightSensorReadingChangedEventArgs args)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                LightSensorReading reading = args.Reading;
                tbxLightSensor.Text = reading.IlluminanceInLux+"/"+reading.Timestamp;
                /*corX.Text = String.Format("{0,5:0.00}", reading.AccelerationX);
                corY.Text = String.Format("{0,5:0.00}", reading.AccelerationY);
                corZ.Text = String.Format("{0,5:0.00}", reading.AccelerationZ);*/
            });
        }


        /// <summary>
        /// reading accelerometer changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private async void ReadingChanged(Gyrometer sender, GyrometerReadingChangedEventArgs args)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                GyrometerReading reading = args.Reading;
                tbxGyrometer.Text = reading.AngularVelocityX+","+reading.AngularVelocityY+","+reading.AngularVelocityZ;
                /*velX.Text = String.Format("{0,5:0.00}", reading.AngularVelocityX);
                velY.Text = String.Format("{0,5:0.00}", reading.AngularVelocityY);
                velZ.Text = String.Format("{0,5:0.00}", reading.AngularVelocityZ);*/
            });
        }

        private async void btnGPS_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;

            try
            {
                Geoposition geoposition = await geolocator.GetGeopositionAsync(
                     maximumAge: TimeSpan.FromMinutes(5),
                     timeout: TimeSpan.FromSeconds(10)
                    );

                //With this 2 lines of code, the app is able to write on a Text Label the Latitude and the Longitude, given by {{Icode|geoposition}}
                tbxGps.Text = "GPS:" + geoposition.Coordinate.Point.Position.Latitude.ToString("0.00") + ", " + geoposition.Coordinate.Point.Position.Longitude.ToString("0.00");
            }
            //If an error is catch 2 are the main causes: the first is that you forgot to include ID_CAP_LOCATION in your app manifest. 
            //The second is that the user doesn't turned on the Location Services
            catch (Exception ex)
            {
                //exception
            }
        }

        private void btnAudio_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AudioRecordView));
        }
    

        private void btnCamera_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CameraView));
        }
    }
}
