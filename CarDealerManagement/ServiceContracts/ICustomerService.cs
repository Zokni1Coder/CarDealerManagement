using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface ICustomerService
    {
        Task<ResponseCustomer> AddNewCustomer(RequestAddCustomer newCustomer);
        Task<ResponseCustomer> UpdateCustomer(UpdateCustomerRequest customer);
        Task<List<ResponseCustomer>?> SelectCustomerByFullName(string firstName, string lastName);
        Task<List<ResponseCustomer>?> GetAllCustomers();
        Task<ResponseCustomer> GetCustomerById(Guid customerId);
    }
}
