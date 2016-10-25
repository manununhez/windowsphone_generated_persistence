using ShoppingCartApp.Common;
using ShoppingCartApp.Model;
using ShoppingCartApp.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ShoppingCartApp.Views
{

    public sealed partial class ProductView : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableCollection<Product> dbProductList;
       
        private ProductDAO dbProducts = new ProductDAO();
        public ProductView()
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


        private void ReadAllProducts_Loaded(object sender, RoutedEventArgs e)
        {        
            dbProductList = dbProducts.ReadProducts();//Get all DB contacts  
            listBoxobj.ItemsSource = dbProductList.OrderByDescending(i => i.Id).ToList();//Binding DB data to LISTBOX and Latest contact ID can Display first.  
            element_count_loaded();
        }

        private void btnAddProduct_click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ProductFormNew));
        }

        private void listBoxobj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxobj.SelectedIndex != -1)
            {
                Product listitem = listBoxobj.SelectedItem as Product;//Get slected listbox item contact ID 
                Frame.Navigate(typeof(ProductFormDeleteUpdate), listitem);
            }
        }

        private void element_count_loaded()
        {
            txbQuantity.Text = Convert.ToString(dbProductList.Count);//Text should not be empty 
        }


    }
}
