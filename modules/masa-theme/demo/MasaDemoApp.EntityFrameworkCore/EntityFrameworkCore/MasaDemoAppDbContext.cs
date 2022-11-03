using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace MasaDemoApp.EntityFrameworkCore;

[ConnectionStringName(MasaDemoAppDbProperties.ConnectionStringName)]
public class MasaDemoAppDbContext : AbpDbContext<MasaDemoAppDbContext>, IMasaDemoAppDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public MasaDemoAppDbContext(DbContextOptions<MasaDemoAppDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureMasaDemoApp();
    }
}
