using NETDemo.Data.Models.DatabaseModels;
using NETDemo.Data.Models.ResponseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NETDemo.Data.Repository.Abstractions
{
    public interface ICustomerRepository
    {
        Task<List<CustomerResponse>> GetAllCustomers();
        Task<CustomerResponse> GetCustomer(int customerId);

        Task<Customer> AddCustomer(Customer customer);

        Task<Customer> UpdateCustomer(int customerId, Customer customer);

        Task<Customer> DeleteCustomer(int customerId);
    }
}
