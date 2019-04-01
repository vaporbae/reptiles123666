using Microsoft.EntityFrameworkCore;
using ReptoRepto.Domain.Entities;

namespace ReptoRepto.Persistence
{
    public class ReptoReptoDbContext : DbContext
    {
        public ReptoReptoDbContext(DbContextOptions<ReptoReptoDbContext> options) : base(options)
        {
        }

        //public virtual DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReptoReptoDbContext).Assembly);
        }
    }
}
