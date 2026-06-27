using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using System.Runtime.CompilerServices;

namespace CarDealerManagement.Controllers
{
    public class MainController : Controller
    {
        private ICarService CarService { get; set; }
        public MainController(ICarService carService)
        {
           this.CarService = carService; 
        }

        [HttpGet("/")]
        [HttpGet("[action]")]
        public async Task<IActionResult> Index()
        {
            List<CarResponse>? cars = await this.CarService.GetAllCars();
            return View(cars);
        }
    }
}
