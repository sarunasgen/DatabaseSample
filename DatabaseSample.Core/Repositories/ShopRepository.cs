using Dapper;
using DatabaseSample.Core.Contracts;
using DatabaseSample.Core.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSample.Core.Repositories
{
    public class ShopRepository : IShopRepository
    {
        private readonly string _connectionString;
        public ShopRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                connection.Execute("INSERT INTO Customers (FirstName, LastName) VALUES (@FirstName, @LastName)", customer);
            }
        }

        public void AddProduct(Product product)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                connection.Execute("INSERT INTO Products (ProductName, ProductPrice, Category) VALUES (@ProductName, @ProductPrice, @Category)", product);
            }
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> result = new List<Customer>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                result = connection.Query<Customer>("SELECT * FROM Customers").ToList();
            }
            return result;
        }

        public List<Product> GetAllProducts()
        {
            List<Product> result = new List<Product>();
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                result = connection.Query<Product>("SELECT * FROM Products").ToList();
            }
            return result;
        }

        public Customer GetCustomerById(int id)
        {
            Customer result = null;//new Product();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                try
                {
                    result = connection.QueryFirst<Customer>("SELECT * FROM Customers WHERE CustomerId = @customerId", new { customerId = id });
                }
                catch (Exception e)
                {
                    Console.WriteLine("Could not find product by id " + id);
                }


            }
            return result;
        }

        public Product GetProductById(int id)
        {
            Product result = null;//new Product();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                try
                {
                    result = connection.QueryFirst<Product>("SELECT * FROM Products WHERE ProductId = @productId", new { productId = id });
                }
                catch(Exception e)
                {
                    Console.WriteLine("Could not find product by id " + id);
                }

                
            }
            return result;
        }

        public void RemoveCustomerById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                connection.Execute("DELETE FROM Customers WHERE CustomerId = @id", new { id });
            }
        }

        public void RemoveProductById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                connection.Execute("DELETE FROM Products WHERE ProductId = @id", new { id });
            }
        }
    }
}
