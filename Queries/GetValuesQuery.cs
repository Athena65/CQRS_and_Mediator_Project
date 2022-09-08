using CQRS_and_Mediator_Project.Models;
using MediatR;

namespace CQRS_and_Mediator_Project.Queries
{
    public class GetValuesQuery
    {
        public record GetProductsQuery ():IRequest<IEnumerable<Product>>;
        public record GetProductByIdQuery(int Id): IRequest<Product>;
    }
}
