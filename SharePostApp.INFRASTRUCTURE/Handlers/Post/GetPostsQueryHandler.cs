using AutoMapper;
using MediatR;
using SharePostApp.DB.Repositories.Abstract;
using SharePostApp.INFRASTRUCTURE.DTOs;
using SharePostApp.INFRASTRUCTURE.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using dbEntities = SharePostApp.DB.Entities.Concrete;

namespace SharePostApp.INFRASTRUCTURE.Handlers.Post
{
    public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, ICollection<PostDTO>>
    {
        private readonly IPostRepository _postRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper mapper;

        private IQueryable<dbEntities.Post> posts;

        public GetPostsQueryHandler(IPostRepository postRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            this._postRepository = postRepository;
            this._categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<ICollection<PostDTO>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            GetPosts();
            return GetDtoResponse();
        }

        private void GetPosts()
        {
            posts = _postRepository.GetQueryable();
        }

        private ICollection<PostDTO> GetDtoResponse()
        {
            return mapper.Map<ICollection<PostDTO>>(posts);
        }
    }
}
