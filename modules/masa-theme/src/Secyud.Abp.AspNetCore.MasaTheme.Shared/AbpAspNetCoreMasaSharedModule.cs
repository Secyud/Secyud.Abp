using Secyud.Abp.MasaTheme.Shared.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Secyud.Abp.MasaTheme.Shared;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class AbpAspNetCoreMasaSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpAspNetCoreMasaSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<MasaResource>("en")
                .AddVirtualJson("/Localization/Masa");
        });
    }
}
