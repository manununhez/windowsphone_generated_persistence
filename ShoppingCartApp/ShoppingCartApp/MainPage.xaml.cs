using ShoppingCartApp.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ShoppingCartApp
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.
        }

        private void btnUser_click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(UserView));
        }

        private void btnProduct_click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ProductView));
        }

        private void btnImageProduct_click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ProductImageView));
        }

        private void btnSensors_click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SensorsView));
        }

        private void btnRest_click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RestView));
        }
    }
}
