using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService
{
    class CustomerService : ICustomerService
    {
        public static List<Customer> customerDefaultList = new List<Customer>() {
                                                                new Customer() { FirstName="Aravind", LastName="Aluri", CustomerId=1},
                                                                new Customer(){FirstName="Gautham", LastName="Aluri", CustomerId=2},
                                                                new Customer() { FirstName="Aravind", LastName="Aluri", CustomerId=3}};

        /// <summary>
        /// Adds a customer into the existing list
        /// </summary>
        /// <param name="customer">customer</param>
        public bool AddCustomer(Customer customer)
        {
            if(!string.IsNullOrEmpty(customer.FirstName)&& !string.IsNullOrEmpty(customer.LastName)&& !string.IsNullOrEmpty(customer.CustomerId.ToString()))

            {
                customerDefaultList.Add(customer);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Deletes a particular customer from the list with the specified ID
        /// </summary>
        /// <param name="customerId"></param>
        public void DeleteCustomerWithThisId(int customerId)
        {
            if (customerDefaultList.Any(x => x.CustomerId.Equals(customerId)))
            {
                customerDefaultList.Remove(customerDefaultList.FirstOrDefault(x => x.CustomerId.Equals(customerId)));
            }

            else
            {
                Console.WriteLine("No customer with this ID exists");
            }
        }


        /// <summary>
        /// Retrieves the list of customers
        /// </summary>
        /// <returns></returns>
        public List<Customer> RetrieveAllCustomers()
        {
            return customerDefaultList;
        }


        /// <summary>
        /// Retrieve a particular customer based on the customer ID we pass
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public Customer RetrieveCustomer(int customerId)
        {
            if (!string.IsNullOrEmpty(customerId.ToString()))
            {
                return customerDefaultList.FirstOrDefault(x => x.CustomerId.Equals(customerId));
            }
            else
            {
                return new Customer();
            }
        }
    }
}
