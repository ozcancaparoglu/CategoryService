using CategoryService.ApiContract;
using CategoryService.ApiContract.Contracts;
using CategoryService.ApiContract.Requests.Commands;
using CategoryService.ApiContract.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        [ProducesResponseType(200, Type = typeof(Result<CategoryCreateUpdateResponse>))]
        public async Task<IActionResult> Create(CreateCategoryCommand request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("update")]
        [ProducesResponseType(200, Type = typeof(Result<CategoryCreateUpdateResponse>))]
        public async Task<IActionResult> Update(UpdateCategoryCommand request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete("delete")]
        [ProducesResponseType(200, Type = typeof(Result<object>))]
        public async Task<IActionResult> Delete([FromQuery] DeleteCategoryCommand request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("get-by-id")]
        [ProducesResponseType(200, Type = typeof(Result<CategoryGetByIdResponse>))]
        public async Task<IActionResult> GetById([FromQuery] GetByIdCategoryQuery request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("get-all")]
        [ProducesResponseType(200, Type = typeof(Result<List<CategoryResponse>>))]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCategoryQuery request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("get-with-attributes")]
        [ProducesResponseType(200, Type = typeof(Result<CategoryWithAttributesResponse>))]
        public async Task<IActionResult> GetWithAttributes([FromQuery] GetWithAttributesCategoryQuery request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }
    }
}
