using ShoppingCartApp.Common;
using ShoppingCartApp.Model;
using ShoppingCartApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.Popups;
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
            if (dbProductList.Count > 0)
            {
                //Btn_Delete.IsEnabled = true;
            }
            listBoxobj.ItemsSource = dbProductList.OrderByDescending(i => i.Id).ToList();//Binding DB data to LISTBOX and Latest contact ID can Display first.  
            txbQuantity.Text = Convert.ToString(dbProductList.Count);//Text should not be empty 
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

        private void element_count_loaded(object sender, RoutedEventArgs e)
        {
           // txbQuantity.Text = Convert.ToString(dbProducts.CountProducts());
        }

        private void btnDeleteAll_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
