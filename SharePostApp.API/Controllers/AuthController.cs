using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharePostApp.API.Controllers;
using SharePostApp.INFRASTRUCTURE.Queries;
using SharePostApp.INFRASTRUCTURE.Queries.User;

namespace SimpulBlog.API.Controllers
{
    [Route("api/auth")]
    public class AuthController : BaseController
    {
        public AuthController(IMediator mediator) : base(mediator) { }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody] AuthQuery query)
            => Ok(await Handle(query));
    }
}