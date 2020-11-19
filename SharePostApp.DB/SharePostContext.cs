using System;
using Microsoft.EntityFrameworkCore;
using SharePostApp.DB.Entities.Concrete;
using SharePostApp.DB.Extensions;
using BC = BCrypt.Net.BCrypt;

namespace SharePostApp.DB
{
    public class SharePostContext : DbContext
    {
        public SharePostContext(DbContextOptions<SharePostContext> opts) : base(opts)
        {
            //this.Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .HasOne(u => u.User)
                .WithMany(u => u.Comments)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Comments)
                .WithOne(u => u.User)
                .OnDelete(DeleteBehavior.NoAction);

            //seed test data
            modelBuilder.SeedData();
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            if (!System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Launch();

            var test = modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 30,
                    FirstName = "test",
                    LastName = "user",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    PasswordHash =  BC.HashPassword("123456")
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