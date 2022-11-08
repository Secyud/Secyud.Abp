using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Secyud.Abp.MongoDB;

[ConnectionStringName(CodeDocsDbProperties.ConnectionStringName)]
public class CodeDocsMongoDbContext : AbpMongoDbContext, ICodeDocsMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureCodeDocs();
    }
}
