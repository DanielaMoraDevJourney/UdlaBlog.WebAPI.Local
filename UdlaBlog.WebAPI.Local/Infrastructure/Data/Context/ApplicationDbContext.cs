using Microsoft.EntityFrameworkCore;
using UdlaBlog.Domain.Entities;

namespace UdlaBlog.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<BlogFica> BlogFicas { get; set; }
        public DbSet<BlogNodo> BlogNodos { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogFica>()
                .HasMany(b => b.Comments)
                .WithOne(c => c.BlogFica)
                .HasForeignKey(c => c.BlogFicaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BlogNodo>()
                .HasMany(b => b.Comments)
                .WithOne(c => c.BlogNodo)
                .HasForeignKey(c => c.BlogNodoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
