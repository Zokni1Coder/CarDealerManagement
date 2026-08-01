using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace CarDealerManagement.Controllers
{
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> AddNewCustomer()
        {
            return View();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddNewCustomer(RequestAddCustomer newCustomer)
        {
            ResponseCustomer customer = await this._customerService.AddNewCustomer(newCustomer);
            
            return View();
        }
    }
}
