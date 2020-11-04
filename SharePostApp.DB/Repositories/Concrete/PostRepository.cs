using SharePostApp.DB.Entities.Concrete;
using SharePostApp.DB.Repositories.Abstract;

namespace SharePostApp.DB.Repositories.Concrete
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        private readonly SharePostContext context;

        public PostRepository(SharePostContext context)
            : base(context)
        {
            this.context = context;
        }
    }
}