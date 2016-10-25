using ShoppingCartApp.Common;
using ShoppingCartApp.Model;
using ShoppingCartApp.ViewModels;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


namespace ShoppingCartApp.Views
{

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
                IdProductoTbx.Text = Convert.ToString(selectedProduct.idProduct);
                IdProveedorTbx.Text = Convert.ToString(selectedProduct.idProvider);
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
