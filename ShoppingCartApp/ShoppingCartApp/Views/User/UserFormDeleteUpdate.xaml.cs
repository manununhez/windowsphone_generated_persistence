using ShoppingCartApp.Common;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using WindowsStore.Common.Storage;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace ShoppingCartApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UserFormDeleteUpdate : Page
    {
        private NavigationHelper navigationHelper;
        private Model.User selectedUser;

        public UserFormDeleteUpdate()
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
                selectedUser = e.Parameter as Model.User;
                if (selectedUser != null)
                {
                    NombreTbx.Text = selectedUser.nombre;
                    PasswordTbx.Text = selectedUser.password;
                }
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        private void btnDelete_click(object sender, RoutedEventArgs e)
        {
            Model.User user = new Model.User(NombreTbx.Text, PasswordTbx.Text);
            StorageManager storage = new StorageManager("dataPersistence", false);
            storage.Remove("user");
            Frame.Navigate(typeof(UserView));

        }

        private void btnUpdate_click(object sender, RoutedEventArgs e)
        {
            Model.User user = new Model.User(NombreTbx.Text, PasswordTbx.Text);
            StorageManager storage = new StorageManager("dataPersistence", false);
            storage.Save("user", user);
            Frame.Navigate(typeof(UserView));
        }

    }
}
