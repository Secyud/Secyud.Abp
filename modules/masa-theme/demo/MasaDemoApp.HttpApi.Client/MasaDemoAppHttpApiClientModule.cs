using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace MasaDemoApp;

[DependsOn(
    typeof(MasaDemoAppApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class MasaDemoAppHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(MasaDemoAppApplicationContractsModule).Assembly,
            MasaDemoAppRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<MasaDemoAppHttpApiClientModule>();
        });

    }
}
