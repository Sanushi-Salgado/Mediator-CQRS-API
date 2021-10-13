using NETDemo.Data.Models.DatabaseModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using NETDemo.Data.Repository.Abstractions;

namespace NETDemo.Domain.Handlers.CommandHandlers
{
    public class DeleteCustomerCommand : IRequest<Customer>
    {
        public int CustomerId { get; set; }

        public DeleteCustomerCommand(int customerId)
        {
            CustomerId = customerId;
        }

        public class DeleteCustomersQueryHandler : IRequestHandler<DeleteCustomerCommand, Customer>
        {
            private readonly ICustomerRepository _repository;
            public DeleteCustomersQueryHandler(ICustomerRepository repository)
            {
                this._repository = repository;
            }

            public async Task<Customer> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
            {
                return await _repository.DeleteCustomer(command.CustomerId);
            }
        }
    }
}
