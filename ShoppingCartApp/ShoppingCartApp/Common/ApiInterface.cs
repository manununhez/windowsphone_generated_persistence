using Kulman.WPA81.BaseRestService.Services.Abstract;
using ShoppingCartApp.Model;
using System.Threading.Tasks;

namespace ShoppingCartApp.Common
{
    class ApiInterface : BaseRestService
    {
        protected override string GetBaseUrl()
        {
            return "https://api.myjson.com/bins";
        }


        public Task<ProductResponse> GetProducts()
        {
            return Get<ProductResponse>("/1gvln");
        }

        public Task<ProductResponse> PostProducts(Product product)
        {
            return Post<ProductResponse>("user", product);
        }

    }
}
