using Kulman.WPA81.BaseRestService.Services.Exceptions;
using ShoppingCartApp.Common;
using ShoppingCartApp.Model;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


namespace ShoppingCartApp.Views
{

    public sealed partial class RestView : Page
    {
        private NavigationHelper navigationHelper;
        private ApiInterface apiInterface = new ApiInterface();

        public RestView()
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

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            //string responseBodyAsText = "";
            //OutputView.Text = "";
            getProducts();
            



            /*try
            {
               

                HttpResponseMessage response = await httpClient.GetAsync(InputAddress.Text);
                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();
               
               

                JsonResponse<List<Product>> childlist = new JsonResponse<List<Product>>();
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(content));
                DataContractJsonSerializer ser = new DataContractJsonSerializer(childlist.GetType());
                childlist = ser.ReadObject(ms) as JsonResponse<List<Product>>;
                System.Diagnostics.Debug.WriteLine("content=" + content);
                foreach (Product element in childlist.data)
                {
                    System.Diagnostics.Debug.WriteLine("element=" + element.idProduct);
                }
       
            }
            catch (HttpRequestException hre)
            {
                System.Diagnostics.Debug.WriteLine(hre.ToString());
            }
            catch (Exception ex)
            {
                // For debugging
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }*/
        }

        private async void getProducts() {
            try
            {
                ProductResponse list = await apiInterface.GetProducts();
                //TODO completar
                /*foreach (Product element in list.data)
                {
                    responseBodyAsText += "element=" + element.name+"\n";
                }*/
                OutputView.Text = list.ToString();
            }
            catch (DeserializationException d)
            {
                System.Diagnostics.Debug.WriteLine(d.ToString());
            }
        }

    }

}
