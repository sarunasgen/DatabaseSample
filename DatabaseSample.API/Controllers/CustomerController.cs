using DatabaseSample.Core.Contracts;
using DatabaseSample.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseSample.API.Controllers
{
    [ApiController]
    [Route("Klientai")]
    public class CustomerController : ControllerBase
    {
        private readonly IShopService _shopService;
        public CustomerController(IShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet("GetAllCustomers")]
        public List<Customer> Index()
        {
            return _shopService.GetAllCustomers();
        }

        [HttpGet("GetCustomerById")]
        public Customer GetCustomerById(int customerId)
        {
            return _shopService.GetCustomerById(customerId);
        }

        [HttpPost("CreateCustomer")]
        public void AddCustomer(Customer customer)
        {
            _shopService.AddCustomer(customer);
        }

        [HttpDelete("DeleteCustomer")]
        public void DeleteCustomer(int id)
        {
            _shopService.RemoveCustomerById(id);
        }
    }
}
