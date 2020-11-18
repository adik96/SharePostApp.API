using Microsoft.EntityFrameworkCore;
using SharePostApp.DB.Entities.Concrete;
using System;
using BC = BCrypt.Net.BCrypt;

namespace SharePostApp.DB.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            //if (!System.Diagnostics.Debugger.IsAttached)
            //    System.Diagnostics.Debugger.Launch();

            var test = modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 30,
                    FirstName = "test",
                    LastName = "user",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    PasswordHash = BC.HashPassword("123456")
                }
            );

            //var testuser = Users.FirstOrDefault();

            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    Id = 30,
                    Title = "Post 1",
                    Content = "Content post 1",
                    CreatedAt = DateTime.UtcNow,
                    LastModifiedAt = DateTime.UtcNow,
                    UserId = 30
                }
            );
        }
    }
}
