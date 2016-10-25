using ShoppingCartApp.Common;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ShoppingCartApp.Views
{

    public sealed partial class ProductImageView : Page
    {
        private NavigationHelper navigationHelper;
        private string FILENAME = "prueba.txt";

        public ProductImageView()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
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

        private async void btnWriteFile_Click(object sender, RoutedEventArgs e)
        {
            String content = IdProductoImagenTbx.Text + "," + ImagenTbx.Text + "," + IdProductoTbx.Text + "," + Img_srcTbx.Text;
            await FileHelper.WriteTextFile(FILENAME, content);
        }

        private async void btnReadFile_Click(object sender, RoutedEventArgs e)
        {
            ResultTbx.Text = await FileHelper.ReadTextFile(FILENAME);
        }
    }
}
