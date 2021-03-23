using System;
using System.Collections.Generic;
using SharePostApp.DB.Entities.Abstract;

namespace SharePostApp.DB.Entities.Concrete
{
    public class User : Entity, ICreatedAt
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public User() { }

        public string FullName => this.FirstName + " " + this.LastName;
    }
}
