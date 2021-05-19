using CategoryService.ApiContract;
using CategoryService.ApiContract.Requests.Commands;
using CategoryService.ApiContract.Requests.Queries;
using CategoryService.ApiContract.Responses.Commands;
using CategoryService.ApiContract.Responses.Queries;
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
        public async Task<IActionResult> Create(CreateCategoryCommand request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("update")]
        [ProducesResponseType(200, Type = typeof(Result<UpdateCategoryResponse>))]
        public async Task<IActionResult> Update(UpdateCategoryCommand request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("getbyid")]
        [ProducesResponseType(200, Type = typeof(Result<GetByIdCategoryResponse>))]
        public async Task<IActionResult> GetById([FromQuery] GetByIdCategoryQuery request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }
    }
}
