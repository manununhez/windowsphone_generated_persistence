using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartApp.Model
{
    class ProductResponse
    {
        public Boolean success { get; set; }

        public List<Product> data { get; set; }

    }
}
