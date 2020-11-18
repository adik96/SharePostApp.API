using MediatR;
using SharePostApp.INFRASTRUCTURE.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharePostApp.INFRASTRUCTURE.Queries
{
    public class GetPostsQuery : IRequest<ICollection<PostDTO>>
    {
        public GetPostsQuery(){}
    }
}
