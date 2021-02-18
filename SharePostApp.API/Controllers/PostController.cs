using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharePostApp.INFRASTRUCTURE.Commands.PostCommands;
using SharePostApp.INFRASTRUCTURE.DTOs;
using SharePostApp.INFRASTRUCTURE.Queries;

namespace SharePostApp.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PostController : BaseController
    {
        public PostController(IMediator mediatr) : base(mediatr) { }

        [HttpGet]
        public async Task<ActionResult<ICollection<PostDTO>>> GetAll()
        {
            var response = await Handle(new GetPostsQuery());
            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<ActionResult<long>> Post([FromBody] AddPostCommand command)
            => Ok(await Handle(command));

        [HttpPost("update")]
        public async Task<ActionResult<long>> Update([FromBody] UpdatePostCommand command)
            => Ok(await Handle(command));

        [HttpPost("delete")]
        public async Task<ActionResult> Delete([FromBody] DeletePostCommand command)
            => Ok(await Handle(command));
    }
}
