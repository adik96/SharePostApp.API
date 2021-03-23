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
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, long>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        private dbEntities.Post _updatePost;

        public UpdatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            this._postRepository = postRepository;
            this._mapper = mapper;
        }

        public async Task<long> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            _updatePost = await GetPost(request.Id);
            UpdatePost(request, _updatePost);

            await _postRepository.UpdateAsync(_updatePost);
            await _postRepository.SaveChangesAsync();

            return _updatePost.Id;
        }

        private Task<dbEntities.Post> GetPost(long id)
        {
            return _postRepository.GetAsync(id);
        }

        private void UpdatePost(UpdatePostCommand model, dbEntities.Post dbPost)
        {
            _mapper.Map(model, dbPost);
        }
    }
}
