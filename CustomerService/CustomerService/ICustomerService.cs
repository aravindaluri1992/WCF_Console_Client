using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        bool AddCustomer(Customer customer);

        [OperationContract]
        Customer RetrieveCustomer(int customerId);

        [OperationContract]
        void DeleteCustomerWithThisId(int customerId);

        [OperationContract]
        List<Customer> RetrieveAllCustomers();
    }
}
