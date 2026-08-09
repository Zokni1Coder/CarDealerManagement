using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ResponseReservation
    {
        public Guid ReservationId { get; set; }
        public DateTime ReservationDate { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CarId { get; set; }
        public decimal PaidAmount { get; set; }
    }

    public static class ReservationExtension
    {
        public static ResponseReservation ToResponseReservation(this Reservation reservation)
        {
           ResponseReservation response = new ResponseReservation();

            response.ReservationId = reservation.ReservationId;
            response.ReservationDate = reservation.ReservationDate;
            response.CustomerId = reservation.CustomerId;
            response.CarId = reservation.CarId;
            response.PaidAmount = reservation.PaidAmount;

            return response;
        }
    }
}
