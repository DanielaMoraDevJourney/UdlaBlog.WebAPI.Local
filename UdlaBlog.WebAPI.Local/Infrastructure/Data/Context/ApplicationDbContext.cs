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
            base.OnModelCreating(modelBuilder);

            // Elimina la configuración de Tags
        }
    }
}
