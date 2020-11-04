using SharePostApp.DB.Entities.Concrete;
using SharePostApp.DB.Repositories.Abstract;

namespace SharePostApp.DB.Repositories.Concrete
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        private readonly SharePostContext context;

        public CommentRepository(SharePostContext context)
            : base(context)
        {
            this.context = context;
        }
    }
}