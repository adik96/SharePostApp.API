using SharePostApp.DB.Entities.Abstract;
using System;

namespace SharePostApp.DB.Entities.Concrete
{
    public class Comment : Entity, ICreatedAt
    {
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        public long PostId { get; set; }
        public virtual Post Post { get; set; }

        public long UserId { get; set; }
        public virtual User User { get; set; }
    }
}
