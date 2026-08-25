using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Reservation
    {
        [Key]
        public Guid ReservationId { get; set; }
        public DateTime ReservationDate { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public Guid CarId { get; set; }
        public Car Car { get; set; } = null!;
        public decimal PaidAmount { get; set; }
        [Required]
        public ReservationStatus Status { get; set; }
        public void CheckExpiration()
        {
            if (ReservationDate < DateTime.Now.AddDays(-7))
            {
                this.Status = ReservationStatus.expired;
            }
        }
    }
}
