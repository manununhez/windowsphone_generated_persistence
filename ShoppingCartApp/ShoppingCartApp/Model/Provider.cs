using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartApp.Model
{
    class Provider
    {
        //The Id property is marked as the Primary Key
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id { get; set; }
        private int IdProveedor { get; set; }
        private string Descripcion_local { get; set; }
        private string Proveedor { get; set; }
        private string Ruc { get; set; }

        public Provider()
        {
        }

        public Provider(int IdProveedor, string Proveedor, string Descripcion_local, string Ruc)
        {
            this.Ruc = Ruc;
            this.Descripcion_local = Descripcion_local;
            this.Proveedor = Proveedor;
            this.IdProveedor = IdProveedor;
        }
    }
}
