using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Commands;
using Application.Queries;
namespace Day3HumaVolve.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductCommand create)
        {
            var product = _mediator.Send(new CreateProductCommand
            {
                Name = create.Name,
                Salary = create.Salary,
            });
            return Created();
        }
        [HttpGet]
        public IActionResult GetProduct(int id)
        {
            var product = _mediator.Send(new GetByIdProductQuery
            {
                id = id,
            });
            return Ok(product);
        }
    }
}
