using Client.CustomerServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerServiceClient client = new CustomerServiceClient("BasicHttpBinding_ICustomerService");

            Console.WriteLine("This is a customer service\n Enter 1 for adding a customer\n Enter 2 for deleting your customer\n Enter 3 for retrieving a customer\n Enter 4 for retrieving all your customers\n");

            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    Console.WriteLine();
                    Customer newCustomer = new Customer();
                    Console.WriteLine("Enter new customer details as required\n");
                    Console.WriteLine("Enter the customer's First name and press an enter\n");
                    newCustomer.FirstName = Console.ReadLine();
                    Console.WriteLine("Enter the customer's Last name and press an enter\n");
                    newCustomer.LastName = Console.ReadLine();
                    Console.WriteLine("Enter the customer's Id and press an enter\n");
                    newCustomer.CustomerId = Convert.ToInt32(Console.ReadLine());
                    if (client.AddCustomer(newCustomer))
                    {
                        Console.WriteLine("you have added a new customer please check the updated list below\n");
                        DisplayUpdatedCustomers();
                    }
                    else
                    {
                        Console.WriteLine("\nyou have entered wrong data aborting");
                    }
                    break;

                case '2':
                    Console.WriteLine();
                    Console.WriteLine("Enter the customer id of the customer you want to delete");
                    int tempId = Convert.ToInt32(Console.ReadLine());
                    client.DeleteCustomerWithThisId(tempId);
                    Console.WriteLine("you have deleted a customer with the specified ID please check the updated list below\n");
                    DisplayUpdatedCustomers();
                    break;
                case '3':
                    Console.WriteLine();
                    Console.WriteLine("Enter the customer id of the customer you want to retrieve");
                    int tempCustId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("PFB for the required details");
                    Console.WriteLine("CustomerId\tFirstName\tLastName");
                    Customer customerRetrieved = client.RetrieveCustomer(tempCustId);
                    Console.WriteLine(customerRetrieved.CustomerId + "\t" + customerRetrieved.FirstName + "\t" + customerRetrieved.LastName);
                    break;
                case '4':
                    Console.WriteLine();
                    DisplayUpdatedCustomers();
                    break;
            }

            Console.WriteLine();

            void DisplayUpdatedCustomers()
            {
                List<Customer> customerList = client.RetrieveAllCustomers().ToList();
                Console.WriteLine("CustomerId\tFirstName\tLastName");
                foreach (Customer cust in customerList)
                {
                    Console.WriteLine(cust.CustomerId + "\t" + cust.FirstName + "\t" + cust.LastName);
                }

            }
            Console.WriteLine("\nThank you....bye bye\n press any key to exit");
            Console.ReadKey();
        }

         
    }
}
