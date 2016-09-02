using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartApp.Model
{
    [DataContract]
    public class JsonResponse <T>
    {
        [DataMember]
        public Boolean success { get; set; }
        [DataMember]
        public T data { get; set; }

    public JsonResponse(){}
    }
}
