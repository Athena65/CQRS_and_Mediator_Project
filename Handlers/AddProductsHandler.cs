using CQRS_and_Mediator_Project.Models;
using MediatR;
using static CQRS_and_Mediator_Project.Commands.ProductCommand;

namespace CQRS_and_Mediator_Project.Handlers
{
    public class AddProductsHandler:IRequestHandler<AddProductCommand, Product>
    {
        private readonly FakeDataStore _fakeDataStore;

        public AddProductsHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }

        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await _fakeDataStore.AddProduct(request.Product);

            return request.Product; //void bos dondurur

        }
    }
}
