using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SharePostApp.API.Controllers
{
    [Route("api")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public abstract class BaseController : ControllerBase
    {
        private readonly IMediator mediatr;

        protected BaseController(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        protected async Task<T> Handle<T>(IRequest<T> request)
        {
            return await mediatr.Send(request);
        }
    }
}