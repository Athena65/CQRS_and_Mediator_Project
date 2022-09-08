using CQRS_and_Mediator_Project.Models;
using CQRS_and_Mediator_Project.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static CQRS_and_Mediator_Project.Commands.ProductCommand;
using static CQRS_and_Mediator_Project.Notifications.ProductNotifications;
using static CQRS_and_Mediator_Project.Queries.GetValuesQuery;

namespace CQRS_and_Mediator_Project.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts() //returns a value
        {
            try
            {
                var products = await _mediator.Send(new GetProductsQuery());

                return Ok(products);

            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }

        }

        [HttpGet("{id}",Name ="GetProductById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var product = await _mediator.Send(new GetProductByIdQuery(id));
                return Ok(product);
            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody]Product product)  //doesnt return a value
        {
            try
            {
                var productToReturn = await _mediator.Send(new AddProductCommand(product));
                await _mediator.Publish(new ProductAddedNotification(productToReturn));

                return CreatedAtRoute("GetProductById", new {id= productToReturn.Id},productToReturn);

            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = await _mediator.Send(new DeleteProductCommand(id));
                return CreatedAtRoute("GetProductById", new { id = product.Id },product.Name+ " deleted!");
            
            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody]Product product, int id)
        {
            try
            {
                var productToReturn = await _mediator.Send(new UpdateProductCommand(product,id));

                return CreatedAtRoute("GetProductById", new { id = productToReturn.Id }, productToReturn);

            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }


    }
}
