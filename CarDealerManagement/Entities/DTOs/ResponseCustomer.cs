using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ResponseCustomer
    {
        public Guid id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public DateTime birthDate { get; set; }
        public string? address { get; set; }
        public string? phoneNumber { get; set; }
        public string? email { get; set; }
    }

    public static class CustomerExtension
    {
        public static ResponseCustomer ToResponseCustomer(this Customer customer)
        {
            ResponseCustomer responseCustomer = new ResponseCustomer();

            responseCustomer.id = customer.id;
            responseCustomer.firstName = customer.firstName;
            responseCustomer.lastName = customer.lastName;
            responseCustomer.address = customer.address;
            responseCustomer.phoneNumber = customer.phoneNumber;
            responseCustomer.birthDate = customer.birthDate;
            responseCustomer.email = customer.email;

            return responseCustomer;
        }
    }
}
