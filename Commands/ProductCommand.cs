using CQRS_and_Mediator_Project.Models;
using MediatR;

namespace CQRS_and_Mediator_Project.Commands
{
    public class ProductCommand
    {
        public record AddProductCommand(Product Product):IRequest<Product>;
        public record UpdateProductCommand(Product Product,int id):IRequest<Product>;  
        public record DeleteProductCommand(int id):IRequest<Product>;
    }
}
