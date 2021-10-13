using MediatR;
using NETDemo.Data.Models.ResponseModels;
using NETDemo.Data.Repository.Abstractions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NETDemo.Domain.Handlers.QueryHandlers
{
    public class GetAllCustomersQuery : IRequest<List<CustomerResponse>>
    {
        public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, List<CustomerResponse>>
        {
            private readonly ICustomerRepository _repository;
            public GetAllCustomersQueryHandler(ICustomerRepository repository)
            {
               this._repository = repository;
            }

            public async Task<List<CustomerResponse>> Handle(GetAllCustomersQuery query, CancellationToken cancellationToken)
            {
                return await _repository.GetAllCustomers();
            }
        }
    }
}