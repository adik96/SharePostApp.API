using System;
using System.Collections.Generic;
using SharePostApp.DB.Entities.Abstract;

namespace SharePostApp.DB.Entities.Concrete
{
    public class User : Entity, ICreatedAt
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public byte[] Salt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public User() { }

        public User(string email, string firstname, string lastname, string hash, byte[] salt, DateTime createdAt)
        {
            SetEmail(email);
            SetFirstName(firstname);
            SetLastName(lastname);
            SetPassword(hash, salt);
            SetCreatedAt(createdAt);
            SetActive(true);
        }

        public void ChangePassword(string hash, byte[] salt)
        {
            SetPassword(hash, salt);
        }

        private void SetPassword(string hash, byte[] salt)
        {
            if (string.IsNullOrEmpty(hash))
                throw new Exception("Password is wrong");

            PasswordHash = hash;
            Salt = salt;
        }

        private void SetEmail(string email)
        {
            Email = email;
        }

        private void SetFirstName(string firstname)
        {
            FirstName = firstname;
        }

        private void SetLastName(string lastname)
        {
            LastName = lastname;
        }

        private void SetCreatedAt(DateTime createdAt)
        {
            CreatedAt = createdAt;
        }

        public void SetActive(bool isActive) => this.IsActive = isActive;
    }
}
