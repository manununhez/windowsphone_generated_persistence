using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartApp.Model
{
    class ShoppingCart
    {
        //The Id property is marked as the Primary Key
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id { get; set; }
        public string IdProducto { get; set; }
        public string Descripcion { get; set; }
        public string IdProveedor { get; set; }
        public string Marca { get; set; }
        public string Porcentaje_impuesto { get; set; }
        public string Precio { get; set; }
        public string Unidad_minima_venta { get; set; }
        public string Cantidad_producto { get; set; }
        public string Sync_time { get; set; }

        public ShoppingCart()
        {
        }

        public ShoppingCart(string IdProducto, string Descripcion,
                       string IdProveedor, string Marca, string Porcentaje_impuesto,
                       string Precio, string Unidad_minima_venta, string Cantidad_producto, string Sync_time)
        {
            this.IdProducto = IdProducto;
            this.Descripcion = Descripcion;
            this.IdProveedor = IdProveedor;
            this.Marca = Marca;
            this.Porcentaje_impuesto = Porcentaje_impuesto;
            this.Precio = Precio;
            this.Unidad_minima_venta = Unidad_minima_venta;
            this.Cantidad_producto = Cantidad_producto;
            this.Sync_time = Sync_time;
        }
    }
}
