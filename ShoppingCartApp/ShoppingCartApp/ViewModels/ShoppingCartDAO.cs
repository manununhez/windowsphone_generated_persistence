using ShoppingCartApp.Common;
using ShoppingCartApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartApp.ViewModels
{
    class ShoppingCartDAO
    {
        private SQLiteConnection dbConn = new SQLiteConnection(App.DB_PATH);

        // Retrieve the specific shoppingcart from the database. 
        public ShoppingCart ReadShoppingCart(int shoppingcartid)
        {
            using (dbConn)
            {
                var existingshoppingcart = dbConn.Query<ShoppingCart>("select * from ShoppingCart where Id =" + shoppingcartid).FirstOrDefault();
                return existingshoppingcart;
            }
        }

        // Retrieve the all ShoppingCart List from the database. 
        public ObservableCollection<ShoppingCart> ReadShoppingCarts()
        {
            using (dbConn)
            {
                List<ShoppingCart> myCollection = dbConn.Table<ShoppingCart>().ToList<ShoppingCart>();
                ObservableCollection<ShoppingCart> ShoppingCartList = new ObservableCollection<ShoppingCart>(myCollection);
                return ShoppingCartList;
            }
        }

        //Update existing ShoppingCart 
        public void UpdateShoppingCart(ShoppingCart shoppingCart)
        {
            using (dbConn)
            {
                var existingshoppingcart = dbConn.Query<ShoppingCart>("select * from ShoppingCart where Id =" + shoppingCart.Id).FirstOrDefault();
                if (existingshoppingcart != null)
                {
                    existingshoppingcart.IdProducto = shoppingCart.IdProducto;
                    existingshoppingcart.Descripcion = shoppingCart.Descripcion;
                    existingshoppingcart.IdProveedor = shoppingCart.IdProveedor;
                    existingshoppingcart.Marca = shoppingCart.Marca;
                    existingshoppingcart.Porcentaje_impuesto = shoppingCart.Porcentaje_impuesto;
                    existingshoppingcart.Precio = shoppingCart.Precio;
                    existingshoppingcart.Unidad_minima_venta = shoppingCart.Unidad_minima_venta;
                    existingshoppingcart.Cantidad_producto = shoppingCart.Cantidad_producto;
                    existingshoppingcart.Sync_time = shoppingCart.Sync_time;

                    dbConn.RunInTransaction(() =>
                    {
                        dbConn.Update(existingshoppingcart);
                    });
                }
            }
        }

        // Insert the new contact in the Contacts table. 
        public void Insert(ShoppingCart shoppingCart)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.RunInTransaction(() =>
                {
                    dbConn.Insert(shoppingCart);
                });
            }
        }

        //Delete specific contact 
        public void DeleteContact(int Id)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingshoppingcart = dbConn.Query<ShoppingCart>("select * from ShoppingCart where Id =" + Id).FirstOrDefault();
                if (existingshoppingcart != null)
                {
                    dbConn.RunInTransaction(() =>
                    {
                        dbConn.Delete(existingshoppingcart);
                    });
                }
            }
        }
        //Delete all contactlist or delete Contacts table 
        public void DeleteAllShoppingCart()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                //dbConn.RunInTransaction(() => 
                //   { 
                dbConn.DropTable<ShoppingCart>();
                dbConn.CreateTable<ShoppingCart>();
                dbConn.Dispose();
                dbConn.Close();
                //}); 
            }
        }
    }
}
