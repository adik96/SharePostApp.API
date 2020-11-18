using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharePostApp.INFRASTRUCTURE.DTOs;
using SharePostApp.INFRASTRUCTURE.Queries;

namespace SharePostApp.API.Controllers
{
    [ApiController]
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
    }
}
