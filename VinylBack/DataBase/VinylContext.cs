using VinylBack.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace VinylBack.DataBase
{
    public class VinylContext : DbContext
    {
        public VinylContext(DbContextOptions<VinylContext> context) : base(context)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasMany(x => x.Comments)
                .WithOne(x => x.Post);
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> Comments { get; set; }
    }
}
