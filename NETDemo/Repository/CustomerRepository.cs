using Microsoft.EntityFrameworkCore;
using NETDemo.Data.Models.DatabaseModels;
using NETDemo.Data.Models.ResponseModels;
using NETDemo.Data.Repository.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETDemo.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly TechnicalAssignmentContext _context;

        public CustomerRepository(TechnicalAssignmentContext context)
        {
            this._context = context;
        }
        public async Task<List<CustomerResponse>> GetAllCustomers()
        {
            //return await _context.Customers.ToListAsync();
            return await _context.Customers.Select(x => new CustomerResponse
            {
                CustomerId = x.customer_id,
                FirstName = x.first_name,
                LastName = x.last_name,
                CountryCode = x.country_code,
                ContactNo = x.contact_no
            }).ToListAsync();
        }

        public async Task<CustomerResponse> GetCustomer(int customerId)
        {
            Customer customer = await _context.Customers.FindAsync(customerId);
            if (customer == null) return null;
            return new CustomerResponse
            {
                CustomerId = customer.customer_id,
                FirstName = customer.first_name,
                LastName = customer.last_name,
                CountryCode = customer.country_code,
                ContactNo = customer.contact_no
            };
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            customer.created_at = System.DateTime.Now;

            // Add the new customer
            await _context.AddAsync(customer);

            // Save DB changes
            _context.SaveChanges();
            return customer;
        }

        public async Task<Customer> UpdateCustomer(int customerId, Customer customer)
        {
            Customer obj = await _context.Customers.FindAsync(customerId);
            if (obj != null)
            {
                // Update the relevant fields
                obj.first_name = customer.first_name;
                obj.last_name = customer.last_name;
                obj.country_code = customer.country_code;
                obj.contact_no = customer.contact_no;
                obj.updated_at = System.DateTime.Now;

                // Save DB changes
                _context.SaveChanges();
            }
            return obj;
        }

        public async Task<Customer> DeleteCustomer(int customerId)
        {
            Customer customer = await _context.Customers.FindAsync(customerId);
            if (customer != null)
            {
                // Delete the customer from the customer table
                _context.Remove(customer);

                // Save DB changes
                _context.SaveChanges();
            }
            return customer;
        }

    }
}