using ShoppingCartApp.Common;
using ShoppingCartApp.Model;
using ShoppingCartApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace ShoppingCartApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProductFormDeleteUpdate : Page
    {
        private NavigationHelper navigationHelper;
        private ProductDAO productDAO = new ProductDAO();
        private Product selectedProduct;

        public ProductFormDeleteUpdate()
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
            if (e != null)
            {
                 selectedProduct = e.Parameter as Product;
                //currentcontact = productDAO.ReadContact(Selected_ContactId.Id);//Read selected DB contact 
                IdProductoTbx.Text = Convert.ToString(selectedProduct.idProduct);//get contact Name 
                IdProveedorTbx.Text = Convert.ToString(selectedProduct.idProvider);//get contact PhoneNumber
                NameTbx.Text = selectedProduct.name;
                PrecioTbx.Text = selectedProduct.price;
                CodigoTbx.Text = selectedProduct.code;
                DescriptionTbx.Text = selectedProduct.description; 
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        private void btnDelete_click(object sender, RoutedEventArgs e)
        {
            productDAO.DeleteProduct(selectedProduct.Id);//Delete selected DB contact Id. 
            Frame.Navigate(typeof(ProductView));
        }

        private void btnUpdate_click(object sender, RoutedEventArgs e)
        {
            Product currentProduct = new Product();
            currentProduct.Id = selectedProduct.Id;
            currentProduct.name = NameTbx.Text;
            currentProduct.price = PrecioTbx.Text;
            currentProduct.code = CodigoTbx.Text;
            currentProduct.description = DescriptionTbx.Text;
            currentProduct.idProduct = Convert.ToInt32(IdProductoTbx.Text);
            currentProduct.idProvider = Convert.ToInt32(IdProveedorTbx.Text);
            productDAO.UpdateProduct(currentProduct);//Update selected DB contact Id 
            Frame.Navigate(typeof(ProductView));
        }
    }
}
