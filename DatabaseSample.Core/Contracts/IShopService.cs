using DatabaseSample.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSample.Core.Contracts
{
    public interface IShopService
    {
        //Products
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        void AddProduct(Product product);
        void RemoveProductById(int id);

        //Customers
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void AddCustomer(Customer customer);
        void RemoveCustomerById(int id);
    }
}
