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
    public class CustomerService : ICustomerService
    {
        #region private collection
        private List<Customer> customerCollection = new List<Customer>{
                       new Customer{
                           CustomerId = 101,
                           CustomerName = "Anish",
                           City = "Kolkata",
                           State = "West Bengal"
                       },
                       new Customer{
                           CustomerId = 102,
                           CustomerName = "Shamajit",
                           City = "Kolkata",
                           State = "West Bengal"
                       },
                       new Customer{
                           CustomerId = 190,
                           CustomerName = "Bashir",
                           City = "Ahmedabad",
                           State = "Gujrat"
                       },
                       new Customer{
                           CustomerId = 120,
                           CustomerName = "Damini",
                           City = "Noida",
                           State = "Uttar Pradesh"
                       }
        };
        #endregion

        public Customer GetCustomer(int customerId)
        {
            Customer cust = null;
            try
            {
                cust = this.customerCollection.Find(x => x.CustomerId == customerId);

            }
            catch (Exception)
            {
                throw;
            }

            return cust;
        }

        public int AddCustomer(Customer customerInstance)
        {
            int indexEntry = -1;

            try
            {
                if ((customerInstance != null && customerInstance.CustomerId > 0) &&
                    this.customerCollection.Find(x => x.CustomerId == customerInstance.CustomerId) != null)
                {
                    throw new ArgumentException("Invalid customer argument for insertion");
                }

                this.customerCollection.Add(customerInstance);
                indexEntry = this.customerCollection.Count - 1;
            }

            // -- using normal Exception
            //catch (Exception)
            //{

            //    throw;
            //}

            // -- using Fault Exception
            //catch (Exception ex)
            //{
            //    throw new FaultException(ex.Message);
            //}

            // -- using Fault Contract
            catch (Exception)
            {
                var invalidEntry = new InvalidCustomerEntry
                {
                    ErrorCode = -908,
                    ErrorMessage = "Invalid Customer Entry"
                };
                throw new FaultException<InvalidCustomerEntry>(invalidEntry);
            }

            return indexEntry;
        }
    }
}























