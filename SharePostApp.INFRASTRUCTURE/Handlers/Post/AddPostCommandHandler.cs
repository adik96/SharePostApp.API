using System;
using AutoMapper;
using MediatR;
using SharePostApp.DB.Repositories.Abstract;
using SharePostApp.INFRASTRUCTURE.Commands.PostCommands;
using System.Threading;
using System.Threading.Tasks;
using dbEntities = SharePostApp.DB.Entities.Concrete;

namespace SharePostApp.INFRASTRUCTURE.Handlers.Post
{
    public class AddPostCommandHandler : IRequestHandler<AddPostCommand, long>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        private dbEntities.Post _newPost;

        public AddPostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            this._postRepository = postRepository;
            this._mapper = mapper;
        }

        public async Task<long> Handle(AddPostCommand request, CancellationToken cancellationToken)
        {
            _newPost = CreateNewPost(request);

            await _postRepository.AddAsync(_newPost);
            await _postRepository.SaveChangesAsync();
            return _newPost.Id;
        }

        private dbEntities.Post CreateNewPost(AddPostCommand model)
        {
            var post = _mapper.Map<dbEntities.Post>(model);

            return post;
        }
    }
}
