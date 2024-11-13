using DatabaseSample.Core.Contracts;
using DatabaseSample.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseSample.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ProductsController(IShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet("GetAllProducts")]
        public List<Product> GetAllProducts()
        {
            return _shopService.GetAllProducts();
        }
        [HttpPost("AddProduct")]
        public void AddProduct(Product newProduct)
        {
            _shopService.AddProduct(newProduct);
        }
        [HttpDelete("DeleteProductById")]
        public void DeleteProductById(int id)
        {
            _shopService.RemoveProductById(id);
        }
        [HttpDelete("DeleteProduct")]
        public void DeleteProductById(Product product)
        {
            _shopService.RemoveProductById(product.ProductId);
        }
    }
}
