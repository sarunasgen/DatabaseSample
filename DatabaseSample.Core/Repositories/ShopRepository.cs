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
        public void AddProduct(Product product)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                connection.Execute("INSERT INTO Products (ProductName, ProductPrice, Category) VALUES (@ProductName, @ProductPrice, @Category)", product);
            }
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

        public Product GetProductById(int id)
        {
            Product result = new Product();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                result = connection.QueryFirst<Product>("SELECT * FROM Products WHERE ProductId = @productId" , new { productId = id });
            }
            return result;
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
