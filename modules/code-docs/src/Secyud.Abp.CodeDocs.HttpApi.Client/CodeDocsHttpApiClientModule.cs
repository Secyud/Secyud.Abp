using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Secyud.Abp;

[DependsOn(
    typeof(CodeDocsApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class CodeDocsHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(CodeDocsApplicationContractsModule).Assembly,
            CodeDocsRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options => { options.FileSets.AddEmbedded<CodeDocsHttpApiClientModule>(); });
    }
}