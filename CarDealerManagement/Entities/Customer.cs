using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Customer
    {
        [Key]
        public Guid id { get; set; }
        [StringLength(20)]
        [Required]
        public string? firstName { get; set; }
        [StringLength(20)]
        [Required]
        public string? lastName { get; set; }
        [Required]
        public DateTime birthDate { get; set; }
        [StringLength(55)]
        [Required]
        public string? address { get; set; }
        [Required]
        [Phone]
        [StringLength(30)]
        public string? phoneNumber { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(30)]
        public string? email { get; set; }
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

        public override bool Equals(object? obj)
        {
            if (obj is not Customer)
            {
                return false;
            }
            Customer? temp = obj as Customer;

            return temp?.id == id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
