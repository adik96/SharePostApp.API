using MediatR;

namespace SharePostApp.INFRASTRUCTURE.Commands.PostCommands
{
    public class DeletePostCommand : IRequest<Unit>
    {
        public long Id { get; set; }
    }
}
