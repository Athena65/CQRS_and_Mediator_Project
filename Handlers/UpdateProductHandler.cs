using CQRS_and_Mediator_Project.Models;
using MediatR;
using static CQRS_and_Mediator_Project.Commands.ProductCommand;

namespace CQRS_and_Mediator_Project.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly FakeDataStore _fakeDataStore;

        public UpdateProductHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }
        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await _fakeDataStore.UpdateProductById(request.Product, request.id);
            return request.Product;
        }
    }
}
