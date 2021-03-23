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
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, Unit>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        private dbEntities.Post _deletePost;

        public DeletePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            this._postRepository = postRepository;
            this._mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            _deletePost = await GetPost(request.Id);

            await _postRepository.DeleteAsync(_deletePost);

            return Unit.Value;
        }

        private Task<dbEntities.Post> GetPost(long id)
        {
            return _postRepository.GetAsync(id);
        }

        private void UpdatePost(UpdatePostCommand model, dbEntities.Post dbPost)
        {
            _mapper.Map(model, dbPost);
            dbPost.LastModifiedAt = DateTime.UtcNow;
        }
    }
}
