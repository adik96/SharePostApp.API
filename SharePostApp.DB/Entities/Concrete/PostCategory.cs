using SharePostApp.DB.Entities.Abstract;

namespace SharePostApp.DB.Entities.Concrete
{
    public class PostCategory : Entity
    {
        public long PostId { get; set; }
        public virtual Post Post { get; set; }
        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}