using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RequestAddCustomer
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public DateTime birthDate { get; set; }
        public string? address { get; set; }
        public string? phoneNumber { get; set; }
        public string? email { get; set; }

        public Customer ToCustomer()
        {
            Customer customer = new Customer()
            {
                id = Guid.NewGuid(),
                firstName = firstName,
                lastName = lastName,
                birthDate = birthDate,
                address = address,
                phoneNumber = phoneNumber,
                email = email
            };
            return customer;
        }
    }
}
