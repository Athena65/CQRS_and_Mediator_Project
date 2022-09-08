using CQRS_and_Mediator_Project.Models;
using MediatR;
using static CQRS_and_Mediator_Project.Queries.GetValuesQuery;

namespace CQRS_and_Mediator_Project.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly FakeDataStore _fakeDataStore;

        public GetProductsHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }
        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
            =>await _fakeDataStore.GetAllProducts();

    }
}
