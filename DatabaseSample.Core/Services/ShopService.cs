using DatabaseSample.Core.Contracts;
using DatabaseSample.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSample.Core.Services
{
    public class ShopService : IShopService
    {
        private readonly IShopRepository _shopRepository;

        public ShopService(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        public void AddProduct(Product product)
        {
            _shopRepository.AddProduct(product);
        }

        public List<Product> GetAllProducts()
        {
            return _shopRepository.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return _shopRepository.GetProductById(id);
        }

        public void RemoveProductById(int id)
        {
            _shopRepository.RemoveProductById(id);
        }
    }
}
