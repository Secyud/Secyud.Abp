using Volo.Abp;
using Volo.Abp.MongoDB;

namespace MasaDemoApp.MongoDB;

public static class MasaDemoAppMongoDbContextExtensions
{
    public static void ConfigureMasaDemoApp(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
