using MediatR;
using Microsoft.AspNetCore.Mvc;
using RekrutacjaTerg.Application.Common.DTOs;
using RekrutacjaTerg.Application.Handlers.Commands;
using RekrutacjaTerg.Application.Handlers.Queries;

namespace RekrutacjaTerg.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ISender sender;

        public ProductController(ISender sender)
        {
            this.sender = sender;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedList<ProductDTO>))]
        public async Task<IActionResult> GetAll([FromQuery] GetProductsQuery request)
        {
            return Ok(await sender.Send(request));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand request)
        {
            var response = await sender.Send(request);
            return Created($"{HttpContext.Request.Path}/{response}", response);
        }
    }
}
