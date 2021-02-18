using MediatR;

namespace SharePostApp.INFRASTRUCTURE.Commands.PostCommands
{
    public class UpdatePostCommand : IRequest<long>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
