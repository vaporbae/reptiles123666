using Microsoft.EntityFrameworkCore;
using ReptoRepto.Persistence.Infrastructure;

namespace ReptoRepto.Persistence
{
    public class ReptoReptoDbContextFactory : DesignTimeDbContextFactoryBase<ReptoReptoDbContext>
    {
        protected override ReptoReptoDbContext CreateNewInstance(DbContextOptions<ReptoReptoDbContext> options)
        {
            return new ReptoReptoDbContext(options);
        }
    }
}
