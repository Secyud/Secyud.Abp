using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace MasaDemoApp.MongoDB;

[ConnectionStringName(MasaDemoAppDbProperties.ConnectionStringName)]
public class MasaDemoAppMongoDbContext : AbpMongoDbContext, IMasaDemoAppMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureMasaDemoApp();
    }
}
