using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NETDemo.Data.Models.RequestModels;
using NETDemo.Data.Models.DatabaseModels;
using NETDemo.Data.Repository.Abstractions;

namespace NETDemo.Domain.Handlers.CommandHandlers
{
    public class UpdateCustomerCommand : IRequest<Customer>
    {
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string CountryCode { get; set; }
        //public string ContactNo { get; set; }

        public int CustomerId { get; set; }
        public UpdateCustomerModel Model { get; }

        public UpdateCustomerCommand(int customerId, UpdateCustomerModel model)
        {
            this.CustomerId = customerId;
            this.Model = model;
        }

        public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Customer>
        {
            private readonly ICustomerRepository _repository;
            public UpdateCustomerCommandHandler(ICustomerRepository repository)
            {
                this._repository = repository;
            }
            public async Task<Customer> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
            {
                Customer customer = new Customer();
                customer.first_name = command.Model.FirstName;
                customer.last_name = command.Model.LastName;
                customer.country_code = command.Model.CountryCode;
                customer.contact_no = command.Model.ContactNo;

                return await _repository.UpdateCustomer(command.CustomerId, customer);
            }
        }
    }
}
