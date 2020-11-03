using Microsoft.EntityFrameworkCore;
using SharePostApp.DB.Entities.Concrete;

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
        public DbSet<PostCategory> ArticleCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
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
        }
    }
}