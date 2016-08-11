using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartApp.Model
{
    class Product
    {
        //The Id property is marked as the Primary Key
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Precio { get; set; }
        public string Codigo { get; set; }
        public int IdProveedor { get; set; }
        public Product()
        {
        }

        public Product(int IdProducto, string Nombre,
                       string Precio, string Codigo, int IdProveedor)
        {
            this.IdProducto = IdProducto;
            this.Nombre = Nombre;
            this.Precio = Precio;
            this.Codigo = Codigo;
            this.IdProveedor = IdProveedor;
        }
    }
}
