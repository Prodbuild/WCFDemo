using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCfDemoApplication.Faults;
using WCfDemoApplication.Model;

namespace WCfDemoApplication
{
    [ServiceContract]
    public interface ICustomerService
    {

        [OperationContract]
        Customer GetCustomer(int customerId);

        [FaultContract(typeof(InvalidCustomerEntry))]
        [OperationContract]
        int AddCustomer(Customer customerInstance);

    }
}
