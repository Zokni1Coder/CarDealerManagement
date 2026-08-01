using Entities;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CarDealerDbContext _carDealerDbContext;

        public CustomerRepository(CarDealerDbContext carsDBContext)
        {
            this._carDealerDbContext = carsDBContext;
        }

        public async Task<ResponseCustomer> AddNewCustomer(Customer newCustomer)
        {
            this._carDealerDbContext.Customers.Add(newCustomer);
            await this._carDealerDbContext.SaveChangesAsync();
            return newCustomer.ToResponseCustomer();
        }

        public async Task<ResponseCustomer> GetCustomerByFullName(string firstName, string lastName)
        {
            Customer? temp = await this._carDealerDbContext.Customers.Where(c => c.firstName.ToLower().Equals(firstName.ToLower()) && c.lastName.ToLower().Equals(lastName.ToLower())).FirstOrDefaultAsync();

            return temp.ToResponseCustomer();
        }

        public async Task<ResponseCustomer> UpdateCustomer(UpdateCustomerRequest updateCustomerRequest)
        {
            Customer? temp = await this._carDealerDbContext.Customers.FirstOrDefaultAsync(c => c.id == updateCustomerRequest.id);

            if (temp == null)
            {
                temp = null as Customer;
            }

            temp.firstName = updateCustomerRequest.firstName;
            temp.lastName = updateCustomerRequest.lastName;
            temp.phoneNumber = updateCustomerRequest.phoneNumber;
            temp.email = updateCustomerRequest.email;
            temp.address = updateCustomerRequest.address;
            temp.birthDate = updateCustomerRequest.birthDate;

            await this._carDealerDbContext.SaveChangesAsync();

            return temp.ToResponseCustomer();
        }
    }
}
