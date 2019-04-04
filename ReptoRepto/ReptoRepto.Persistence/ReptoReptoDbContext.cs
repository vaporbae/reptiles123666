using Microsoft.EntityFrameworkCore;
using ReptoRepto.Domain.Entities;

namespace ReptoRepto.Persistence
{
    public class ReptoReptoDbContext : DbContext
    {
        public ReptoReptoDbContext(DbContextOptions<ReptoReptoDbContext> options) : base(options)
        {
        }
        
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Source> Sources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReptoReptoDbContext).Assembly);
        }
    }
}
