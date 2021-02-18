using MediatR;

namespace SharePostApp.INFRASTRUCTURE.Commands.PostCommands
{
    public class AddPostCommand : AbstractAuthCommand, IRequest<long>
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
