using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace MasaDemoApp.MongoDB;

[ConnectionStringName(MasaDemoAppDbProperties.ConnectionStringName)]
public interface IMasaDemoAppMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
