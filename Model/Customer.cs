using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCfDemoApplication.Model
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public int CustomerId { get; set; }

        [DataMember]
        public string CustomerName { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string State { get; set; }
    }
}