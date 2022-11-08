using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Secyud.Abp.MongoDB;

[ConnectionStringName(CodeDocsDbProperties.ConnectionStringName)]
public interface ICodeDocsMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
