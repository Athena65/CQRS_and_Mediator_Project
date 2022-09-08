using CQRS_and_Mediator_Project.Models;
using MediatR;
using static CQRS_and_Mediator_Project.Queries.GetValuesQuery;

namespace CQRS_and_Mediator_Project.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly FakeDataStore _fakeDataStore;

        public GetProductByIdHandler(FakeDataStore fakeDataStore )
        {
            _fakeDataStore = fakeDataStore;
        }
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)=>
            await _fakeDataStore.GetProductById(request.Id);

    }
}
