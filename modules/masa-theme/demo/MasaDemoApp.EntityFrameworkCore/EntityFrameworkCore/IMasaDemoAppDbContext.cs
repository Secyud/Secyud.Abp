using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace MasaDemoApp.EntityFrameworkCore;

[ConnectionStringName(MasaDemoAppDbProperties.ConnectionStringName)]
public interface IMasaDemoAppDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
