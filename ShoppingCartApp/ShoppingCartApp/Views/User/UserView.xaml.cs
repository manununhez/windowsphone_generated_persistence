using ShoppingCartApp.Common;
using ShoppingCartApp.Views.User;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public sealed partial class UserView : Page
    {
        private NavigationHelper navigationHelper;

        public UserView()
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

        private void new_click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(UserFormNew));
        }

        private void listBoxobj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ReadAllUsers_Loaded(object sender, RoutedEventArgs e)
        {
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Object user = localSettings.Values["user"];
            Object password = localSettings.Values["password"];

            Debug.WriteLine("User ="+user+" password ="+password);

            List<Model.User> userList = new List<Model.User>();
            userList.Add(new Model.User(Convert.ToString(user), Convert.ToString(password)));
            listBoxobj.ItemsSource = userList;//Binding DB data to LISTBOX and Latest contact ID can Display first.  
            txbQuantity.Text = Convert.ToString(userList.Count);//Text should not be empty 
        }

        private void element_count_loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
