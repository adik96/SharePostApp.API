using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharePostApp.API.Controllers;
using SharePostApp.INFRASTRUCTURE.Commands.UserCommands;

namespace SimpulBlog.API.Controllers
{
    [Route("api/user")]
    public class UserController : BaseController
    {
        public UserController(IMediator mediator) : base(mediator) { }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterUserCommand command)
            => Ok(await Handle(command));
    }
}