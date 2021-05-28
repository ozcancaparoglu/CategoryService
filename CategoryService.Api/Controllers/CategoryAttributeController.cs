using CategoryService.ApiContract;
using CategoryService.ApiContract.Contracts;
using CategoryService.ApiContract.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CategoryService.Api.Controllers
{
    [Route("category-attribute")]
    [ApiController]
    public class CategoryAttributeController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoryAttributeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("create")]
        [ProducesResponseType(200, Type = typeof(Result<object>))]
        public async Task<IActionResult> Create(CreateCategoryAttributeCommand request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }

        //[HttpPut("update")]
        //[ProducesResponseType(200, Type = typeof(Result<CategoryCreateUpdateResponse>))]
        //public async Task<IActionResult> Update(UpdateCategoryCommand request)
        //{
        //    var result = await mediator.Send(request);
        //    return Ok(result);
        //}

        //[HttpDelete("delete")]
        //[ProducesResponseType(200, Type = typeof(Result<object>))]
        //public async Task<IActionResult> Delete([FromQuery] DeleteCategoryCommand request)
        //{
        //    var result = await mediator.Send(request);
        //    return Ok(result);
        //}
    }
}
