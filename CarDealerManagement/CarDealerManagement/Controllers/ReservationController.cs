using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using System.Threading.Tasks;

namespace CarDealerManagement.Controllers
{
    [Route("[controller]")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly ICarService _carService;

        public ReservationController(IReservationService reservationService, ICarService carService)
        {
            this._reservationService = reservationService;
            this._carService = carService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> AddNewReservation(Guid CarId)
        {
            CarResponse? selectedCar = await this._carService.GetCarById(CarId);

            return View(selectedCar);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddNewReservation(RequestAddNewReservation newReservation)
        {
            ResponseReservation response = await this._reservationService.AddNewReservation(newReservation);

            ViewBag.ReservationState = "done";

            return Content("""
                <script>
                    alert('Reservation successfully created!');
                    window.close();
                </script>
                """, "text/html");
        }
    }
}
