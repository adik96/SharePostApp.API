using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SharePostApp.INFRASTRUCTURE.Commands;
using SharePostApp.INFRASTRUCTURE.Queries;

namespace SharePostApp.API.Controllers
{
    [Route("api")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public abstract class BaseController : ControllerBase
    {
        private readonly IMediator mediatr;

        private long _userId => GetLoggedUserId();

        protected BaseController(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        protected async Task<T> Handle<T>(IRequest<T> request)
        {
            if (request is AbstractAuthQuery)
            {
                (request as AbstractAuthQuery).UserId = _userId;
            }

            if (request is AbstractAuthCommand)
            {
                (request as AbstractAuthCommand).UserId = _userId;
            }

            return await mediatr.Send(request);
        }

        private long GetLoggedUserId()
        {
            if (User?.Identity?.IsAuthenticated == true)
            { 
                var userIdString = this.User.Identity.Name;
                if (long.TryParse(userIdString, out long userId))
                {
                    return userId;
                }
            }

            return -1;
        }
    }
}