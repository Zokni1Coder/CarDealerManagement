using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using System.Runtime.CompilerServices;

namespace CarDealerManagement.Controllers
{
    public class MainController : Controller
    {
        private ICarService _CarService { get; set; }
        public MainController(ICarService carService)
        {
           this._CarService = carService; 
        }

        [HttpGet("/")]
        [HttpGet("[action]")]
        public async Task<IActionResult> Index()
        {
            List<CarResponse>? cars = await this._CarService.GetAllCars();
            return View(cars);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCarByIndex()
        {
            CarResponse? result = await this._CarService.GetCarById(Guid.Parse("11111111-1111-1111-1111-111111111111"));
            return View();
        }
    }
}
