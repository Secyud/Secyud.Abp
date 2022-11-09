using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Secyud.Abp;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
)]
public class CodeDocsInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options => { options.FileSets.AddEmbedded<CodeDocsInstallerModule>(); });
    }
}