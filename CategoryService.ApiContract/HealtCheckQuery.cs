using MediatR;

namespace CategoryService.ApiContract
{
    public class HealthCheckQuery : IRequest<Result<object>>
    {
    }
}
