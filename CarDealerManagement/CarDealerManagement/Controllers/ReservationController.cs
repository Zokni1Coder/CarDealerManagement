using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CarDealerManagement.Controllers
{
    [Route("[controller]")]
    public class ReservationController : Controller
    {
        [HttpPost("[action]")]
        public IActionResult AddNewReservation(RequestAddNewReservation newReservation)
        {

            return View();
        }
    }
}
