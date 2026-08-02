using Entities.DTOs;
using RepositoryContracts;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        public async Task<ResponseCustomer> AddNewCustomer(RequestAddCustomer newCustomer)
        {
            ResponseCustomer? response = await this._customerRepository.AddNewCustomer(newCustomer.ToCustomer());

            return response;
        }

        public async Task<List<ResponseCustomer>?> GetAllCustomers()
        {
            List<ResponseCustomer>? response = await this._customerRepository.GetAllCustomers();

            return response;
        }

        public async Task<List<ResponseCustomer>?> SelectCustomerByFullName(string firstName, string lastName)
        {
            List<ResponseCustomer>? response = await this._customerRepository.GetCustomerByFullName(firstName, lastName);

            return response;
        }

        public async Task<ResponseCustomer> UpdateCustomer(UpdateCustomerRequest customer)
        {
            ResponseCustomer response = await this._customerRepository.UpdateCustomer(customer);

            return response;
        }
    }
}