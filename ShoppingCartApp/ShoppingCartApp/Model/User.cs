
using System.Runtime.Serialization;

namespace ShoppingCartApp.Model
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public string password { get; set; }

        public User()
        {
        }

        public User(string nombre, string password)
        {
            this.nombre = nombre;
            this.password = password;
        }
    }
}
