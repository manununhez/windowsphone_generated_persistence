using System;
using System.Collections.Generic;
using System.Text;
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.DataTransfer.ShareTarget;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace ShoppingCartApp.Views
{
    public sealed partial class ShareTargetPageView : Page
    {
        ShareOperation operation = null;

        public ShareTargetPageView()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            operation = (ShareOperation)e.Parameter;

            //TextBlockTitle.Text = operation.Data.Properties.Title;
           // TextBlockDescription.Text = operation.Data.Properties.Description;

            if (operation.Data.Contains(StandardDataFormats.WebLink)) //URI
            {
                var uri = await operation.Data.GetWebLinkAsync();
                if (uri != null)
                {
                    MessageDialog ms = new MessageDialog("WebLink: " + uri.AbsoluteUri);
                    await ms.ShowAsync();
                   // TextBlockText.Text = "WebLink: "+ uri.AbsoluteUri;
                }
            }

            if (operation.Data.Contains(StandardDataFormats.Text))//Text
            {
                MessageDialog ms = new MessageDialog("Text:" + await operation.Data.GetTextAsync());
                await ms.ShowAsync();
                //TextBlockText.Text = TextBlockText.Text + "\nText:" + await operation.Data.GetTextAsync();
            }

            if (operation.Data.Contains(StandardDataFormats.Bitmap)) { //Image
                IRandomAccessStreamReference sharedBitmapStream = await operation.Data.GetBitmapAsync();
                IRandomAccessStreamWithContentType bitmapStream = await sharedBitmapStream.OpenReadAsync();
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.SetSource(bitmapStream);
               // ImagePhoto.Source = bitmapImage;
                MessageDialog ms = new MessageDialog("Image:" + bitmapStream);
                await ms.ShowAsync();
            }

            if (operation.Data.Contains(StandardDataFormats.StorageItems)) //Files being shared
            {
                IReadOnlyList<IStorageItem> sharedStorageItems = await operation.Data.GetStorageItemsAsync();
                StringBuilder fileNames = new StringBuilder();
                for (int index = 0; index < sharedStorageItems.Count; index++)
                {
                    fileNames.Append(sharedStorageItems[index].Name);
                    if (index < sharedStorageItems.Count - 1)
                    {
                        fileNames.Append(", ");
                    }
                }
                fileNames.Append(".");

                MessageDialog ms = new MessageDialog("StorageItems: " + fileNames.ToString());
                await ms.ShowAsync();
                //TextBlockText.Text = TextBlockText.Text + "\nStorageItems: " + fileNames.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            operation.ReportCompleted();
        }
    }
}
