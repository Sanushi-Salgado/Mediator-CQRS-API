using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NETDemo.Data.Models.ResponseModels;
using NETDemo.Data.Repository.Abstractions;

namespace NETDemo.Domain.Handlers.QueryHandlers
{
    public class GetCustomerByIdQuery : IRequest<CustomerResponse>
    {
        public int CustomerId { get; set; }
        public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerResponse>
        {
            private readonly ICustomerRepository _repository;
            public GetCustomerByIdQueryHandler(ICustomerRepository repository)
            {
                this._repository = repository;
            }

            public async Task<CustomerResponse> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
            {
                return await _repository.GetCustomerById(query.CustomerId);
            }
        }
    }
}
