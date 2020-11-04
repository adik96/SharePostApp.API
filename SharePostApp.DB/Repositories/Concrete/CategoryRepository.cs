using SharePostApp.DB.Entities.Concrete;
using SharePostApp.DB.Repositories.Abstract;

namespace SharePostApp.DB.Repositories.Concrete
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly SharePostContext context;

        public CategoryRepository(SharePostContext context)
            : base(context)
        {
            this.context = context;
        }
    }
}