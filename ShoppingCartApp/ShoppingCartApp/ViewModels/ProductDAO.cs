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
    class ProductDAO
    {
        private SQLiteConnection dbConn = new SQLiteConnection(App.DB_PATH);

        // Retrieve the specific shoppingcart from the database. 
        public Product ReadProduct(int productid)
        {
            using (dbConn)
            {
                var existingproduct = dbConn.Query<Product>("select * from Product where Id =" + productid).FirstOrDefault();
                return existingproduct;
            }
        }

        // Retrieve the all Product List from the database. 
        public ObservableCollection<Product> ReadProducts()
        {
            using (dbConn)
            {
                List<Product> myCollection = dbConn.Table<Product>().ToList<Product>();
                ObservableCollection<Product> ProductList = new ObservableCollection<Product>(myCollection);
                return ProductList;
            }
        }

        // Retrieve the all Product List from the database and get the Total Rows. 
        public int CountProducts()
        {
            using (dbConn)
            {
                List<Product> myCollection = dbConn.Table<Product>().ToList<Product>();
                ObservableCollection<Product> ProductList = new ObservableCollection<Product>(myCollection);
                return ProductList.Count;
            }
        }

        //Update existing Product 
        public void UpdateProduct(Product product)
        {
            using (dbConn)
            {
                var existingproduct = dbConn.Query<Product>("select * from Product where Id =" + product.Id).FirstOrDefault();
                if (existingproduct != null)
                {
                    existingproduct.IdProducto = product.IdProducto;
                    existingproduct.Nombre = product.Nombre;
                    existingproduct.Precio = product.Precio;
                    existingproduct.Codigo = product.Codigo;
                    existingproduct.IdProveedor = product.IdProveedor;
                    

                    dbConn.RunInTransaction(() =>
                    {
                        dbConn.Update(existingproduct);
                    });
                }
            }
        }

        // Insert the new product in the Products table. 
        public void Insert(Product product)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.RunInTransaction(() =>
                {
                    dbConn.Insert(product);
                });
            }
        }

        //Delete specific product 
        public void DeleteProduct(int Id)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingproduct = dbConn.Query<Product>("select * from Product where Id =" + Id).FirstOrDefault();
                if (existingproduct != null)
                {
                    dbConn.RunInTransaction(() =>
                    {
                        dbConn.Delete(existingproduct);
                    });
                }
            }
        }
        //Delete all productList or delete Products table 
        public void DeleteAllProduct()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                //dbConn.RunInTransaction(() => 
                //   { 
                dbConn.DropTable<Product>();
                dbConn.CreateTable<Product>();
                dbConn.Dispose();
                dbConn.Close();
                //}); 
            }
        }
    }

}
