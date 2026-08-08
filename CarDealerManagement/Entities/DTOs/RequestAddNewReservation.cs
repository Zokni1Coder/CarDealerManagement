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
        public DateTime ReservationDate { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public Guid CarId { get; set; }
        public Car Car { get; set; } = null!;
        public decimal PaidAmount { get; set; }
        public Reservation ToReservation()
        {
            Reservation reservation = new Reservation();

            reservation.ReservationId = Guid.NewGuid();
            reservation.ReservationDate = ReservationDate;
            reservation.CustomerId = CustomerId;
            reservation.Customer = Customer;
            reservation.Car = Car;
            reservation.PaidAmount = PaidAmount;

            return reservation;
        }
    }
}
