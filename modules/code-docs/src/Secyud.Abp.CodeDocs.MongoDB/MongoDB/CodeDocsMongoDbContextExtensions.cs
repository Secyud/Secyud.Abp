using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Secyud.Abp.MongoDB;

public static class CodeDocsMongoDbContextExtensions
{
    public static void ConfigureCodeDocs(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
