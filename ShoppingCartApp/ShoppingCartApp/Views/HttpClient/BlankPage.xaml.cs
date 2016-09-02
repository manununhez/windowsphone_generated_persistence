using ShoppingCartApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace ShoppingCartApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage : Page
    {
        private HttpClient httpClient;

        public BlankPage()
        {
            this.InitializeComponent();
            httpClient = new HttpClient();
            // Limit the max buffer size for the response so we don't get overwhelmed
            httpClient.MaxResponseContentBufferSize = 256000;
            httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");
        }


        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void Start_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string responseBodyAsText;
                OutputView.Text = "";
                StatusText.Text = "Waiting for response ...";

                HttpResponseMessage response = await httpClient.GetAsync(InputAddress.Text);
                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();
                //JsonObject obj = JsonObject.Parse(content);
                //JsonObject data = obj.GetNamedObject("data");
                
                //List<Product> productList = (List<Product>)obj["data"];
                //OutputView.Text = await Task.Run(()=> JsonObject.Parse(content));
               

                JsonResponse<List<Product>> childlist = new JsonResponse<List<Product>>();
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(content));
                DataContractJsonSerializer ser = new DataContractJsonSerializer(childlist.GetType());
                childlist = ser.ReadObject(ms) as JsonResponse<List<Product>>;
                System.Diagnostics.Debug.WriteLine("content=" + content);
                foreach (Product element in childlist.data)
                {
                    System.Diagnostics.Debug.WriteLine("element=" + element.idProduct);
                }
               //OutputView.Text = string.Join<Product>(",", childlist.data.ToArray<P);
                /* StatusText.Text = response.StatusCode + " " + response.ReasonPhrase + Environment.NewLine;
                 responseBodyAsText = await response.Content.ReadAsStringAsync();
                 responseBodyAsText = responseBodyAsText.Replace("<br>", Environment.NewLine); // Insert new lines
                 OutputView.Text = responseBodyAsText;*/
            }
            catch (HttpRequestException hre)
            {
                System.Diagnostics.Debug.WriteLine(hre.ToString());
            }
            catch (Exception ex)
            {
                // For debugging
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
    }
}
