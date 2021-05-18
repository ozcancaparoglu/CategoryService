using CategoryService.ApiContract;
using CategoryService.ApiContract.Requests.Commands;
using CategoryService.ApiContract.Responses.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CategoryService.Api.Controllers
{
    [Route("category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("create")]
        [ProducesResponseType(200, Type = typeof(Result<CreateCategoryResponse>))]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("update")]
        [ProducesResponseType(200, Type = typeof(Result<UpdateCategoryResponse>))]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }
    }
}
