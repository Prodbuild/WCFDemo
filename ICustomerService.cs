using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCfDemoApplication.Faults;
using WCfDemoApplication.Model;

//C:\Program Files\Microsoft SDKs\Windows\v6.0\Bin
//C:\Program Files (x86)\Microsoft SDKs\Windows\v8.1A\bin\NETFX 4.5.1 Tools

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
