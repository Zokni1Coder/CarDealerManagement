using Entities.DTOs;
using Entities.Enums;
using Entities.Enums.Extensions;
using iTextSharp.tool.xml.html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceContracts;
using System.Net;
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

            ViewBag.transmissionTypes = Enum.GetValues(typeof(TransmissionType)).Cast<TransmissionType>().ToList();
            ViewBag.vehicleTypes = Enum.GetValues(typeof(VehicleType)).Cast<VehicleType>().ToList();
            ViewBag.fuelTypes = Enum.GetValues(typeof(FuelType)).Cast<FuelType>().Select(type => new SelectListItem
            {
                Value = type.ToString(),
                Text = type.GetDisplayName()
            });

            return View(cars);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCarByIndex()
        {
            CarResponse? result = await this._CarService.GetCarById(Guid.Parse("11111111-1111-1111-1111-111111111111"));
            return View();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> AddNewCar()
        {
            ViewBag.transmissionTypes = Enum.GetValues(typeof(TransmissionType)).Cast<TransmissionType>().ToList();
            ViewBag.vehicleTypes = Enum.GetValues(typeof(VehicleType)).Cast<VehicleType>().ToList();
            ViewBag.fuelTypes = Enum.GetValues(typeof(FuelType)).Cast<FuelType>().Select(type => new SelectListItem
            {
                Value = type.ToString(),
                Text = type.GetDisplayName()
            });
            
            return View();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddNewCar(AddCarRequest addCarRequest)
        {
            CarResponse carResponse = await this._CarService.AddCar(addCarRequest);

            if (carResponse is null)
            {
                ViewBag.Error = true;
                return View();
            }

            return RedirectToAction(nameof(Index) , "Main");
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SellCar(Guid id)
        {
           bool result = await this._CarService.DeleteCar(id);

            if (!result)
            {
                ViewBag.SellingError = true;
                return RedirectToAction(nameof(Index), "Main");
            }
            return RedirectToAction(nameof(Index), "Main");
        }
    }
}
