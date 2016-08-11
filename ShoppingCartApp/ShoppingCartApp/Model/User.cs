using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartApp.Model
{
    class User
    {
        public string Nombre { get; set; }
        public string Password { get; set; }

        public User()
        {
        }

        public User(string Nombre, string Password)
        {
            this.Nombre = Nombre;
            this.Password = Password;
        }
    }
}
