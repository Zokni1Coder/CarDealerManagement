using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryContracts
{
    public interface ICustomerRepository
    {
        Task<ResponseCustomer> AddNewCustomer(Customer newCustomer);

        Task<ResponseCustomer> GetCustomerByFullName(string firstName, string lastName);

        Task<ResponseCustomer> UpdateCustomer(UpdateCustomerRequest updateCustomerRequest);
    }
}
