
using System.Runtime.Serialization;

namespace ShoppingCartApp.Model
{
    [DataContract]
    class Product 
    {
        //The Id property is marked as the Primary Key
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int idProduct { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string price { get; set; }

        [DataMember]
        public string code { get; set; }

        [DataMember]
        public int idProvider { get; set; }

        [DataMember]
        public string description { get; set; }

        public Product()
        {
        }

        public Product(int idProduct, string name,
                       string price, string code, int idProvider, string description)
        {
            this.idProduct = idProduct;
            this.name = name;
            this.price = price;
            this.code = code;
            this.idProvider = idProvider;
            this.description = description;
        }
    }
}
