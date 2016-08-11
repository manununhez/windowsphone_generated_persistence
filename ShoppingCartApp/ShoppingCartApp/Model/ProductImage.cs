using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartApp.Model
{
    class ProductImage
    {
        
        private string IdProductoImagen { get; set; }
        private string Imagen { get; set; }
        private string IdProducto { get; set; }
        private string Img_src { get; set; }


        public ProductImage()
        {
        }

        public ProductImage(string IdProductoImagen, string Imagen, string IdProducto, string Img_src)
        {
            this.IdProductoImagen = IdProductoImagen;
            this.Imagen = Imagen;
            this.IdProducto = IdProducto;
            this.Img_src = Img_src;
        }
    }
}
