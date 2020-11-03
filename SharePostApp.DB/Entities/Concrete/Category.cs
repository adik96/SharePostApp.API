using System.Collections.Generic;
using SharePostApp.DB.Entities.Abstract;

namespace SharePostApp.DB.Entities.Concrete
{
    public class Category : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<PostCategory> PostCategories { get; set; }
    }
}