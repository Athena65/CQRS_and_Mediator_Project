using CQRS_and_Mediator_Project.Models;
using MediatR;
using static CQRS_and_Mediator_Project.Commands.ProductCommand;

namespace CQRS_and_Mediator_Project.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Product>
    {
        private readonly FakeDataStore _fakeDataStore;

        public DeleteProductHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }

        public async Task<Product> Handle(DeleteProductCommand request, CancellationToken cancellationToken)=>
            await _fakeDataStore.DeleteProductById(request.id);
         
      
    }
}
