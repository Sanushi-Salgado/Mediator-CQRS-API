using MediatR;
using NETDemo.Data.Models.DatabaseModels;
using NETDemo.Data.Models.RequestModels;
using NETDemo.Data.Repository.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace NETDemo.Domain.Handlers.CommandHandlers
{
    public class CreateCustomerCommand : IRequest<Customer>
    {
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string CountryCode { get; set; }
        //public string ContactNo { get; set; }

        public AddCustomerModel Model { get; }

        public CreateCustomerCommand(AddCustomerModel model)
        {
            this.Model = model;
        }

        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
        {
            private readonly ICustomerRepository _repository; // Injecting 
            public CreateCustomerCommandHandler(ICustomerRepository repository)
            {
                this._repository = repository;
            }
            public async Task<Customer> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
            {
                Customer customer = new Customer();
                customer.first_name = command.Model.FirstName;
                customer.last_name = command.Model.LastName;
                customer.country_code = command.Model.CountryCode;
                customer.contact_no = command.Model.ContactNo;

                return await _repository.AddCustomer(customer);
            }
        }
    }
}
