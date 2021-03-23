using System;
using System.Collections.Generic;
using SharePostApp.DB.Entities.Abstract;

namespace SharePostApp.DB.Entities.Concrete
{
    public class Post : Entity, ICreatedAt, ILastModifiedAt
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastModifiedAt { get; set; }

        public long UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<PostCategory> PostCategories { get; set; }
    }
}
