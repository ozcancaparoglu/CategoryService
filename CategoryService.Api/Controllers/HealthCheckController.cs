using CategoryService.ApiContract;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CategoryService.Api.Controllers
{
    [Route("healthcheck")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private readonly IMediator mediator;

        public HealthCheckController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Result<object>))]
        public async Task<IActionResult> Index(HealthCheckQuery request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }
    }
}
