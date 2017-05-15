using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public int CustomerId { get; set; }

        [DataMember]
        public string LastName { get; set; }

    }
}
