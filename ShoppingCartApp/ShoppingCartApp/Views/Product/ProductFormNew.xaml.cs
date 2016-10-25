using ShoppingCartApp.Common;
using ShoppingCartApp.Model;
using ShoppingCartApp.ViewModels;
using System;
using System.Globalization;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


namespace ShoppingCartApp.Views
{

    public sealed partial class ProductFormNew : Page
    {
        private NavigationHelper navigationHelper;

        public ProductFormNew()
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

        private async void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductDAO productDAO = new ProductDAO();
            if (IdProductoTbx.Text != "" & NameTbx.Text != "" & PrecioTbx.Text != "" & CodigoTbx.Text != "" & IdProveedorTbx.Text != "")
            {
                productDAO.Insert(new Product(Int32.Parse(IdProductoTbx.Text), NameTbx.Text, PrecioTbx.Text, CodigoTbx.Text, Int32.Parse(IdProveedorTbx.Text), DescriptionTbx.Text)); 
                Frame.Navigate(typeof(ProductView));//after add contact redirect to product listbox page
            }
            else
            {
                var dialog = new MessageDialog("Please fill the fields");//Text should not be empty 
                await dialog.ShowAsync();
            }
        }
    }
}
