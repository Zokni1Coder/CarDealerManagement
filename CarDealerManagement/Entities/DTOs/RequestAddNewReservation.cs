using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RequestAddNewReservation
    {
        public DateTime ReservationDate { get; set; } = DateTime.Now;
        public Guid CustomerId { get; set; }
        public Guid CarId { get; set; }
        public decimal PaidAmount { get; set; }
        public Reservation ToReservation()
        {
            Reservation reservation = new Reservation();

            reservation.ReservationId = Guid.NewGuid();
            reservation.ReservationDate = ReservationDate;
            reservation.CustomerId = CustomerId;
            reservation.PaidAmount = PaidAmount;
            reservation.CarId = CarId;

            return reservation;
        }
    }
}
