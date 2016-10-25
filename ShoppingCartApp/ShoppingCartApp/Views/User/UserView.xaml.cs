

using ShoppingCartApp.Common;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using WindowsStore.Common.Storage;

namespace ShoppingCartApp.Views
{

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


        private void listBoxobj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxobj.SelectedIndex != -1)
            {

                Model.User listitem = listBoxobj.SelectedItem as Model.User;//Get slected listbox item contact ID 
                Frame.Navigate(typeof(UserFormDeleteUpdate), listitem);
            }
        }

        private void ReadAllData_Loaded(object sender, RoutedEventArgs e)
        {
            StorageManager storage = new StorageManager("dataPersistence", false);
            Model.User user = storage.Load<Model.User>("user");
            
            List<Model.User> userList = new List<Model.User>();
            userList.Add(user);
            listBoxobj.ItemsSource = userList;//Binding DB data to LISTBOX and Latest contact ID can Display first.  
            txbQuantity.Text = Convert.ToString(userList.Count);//Text should not be empty 
        }

    }
}
