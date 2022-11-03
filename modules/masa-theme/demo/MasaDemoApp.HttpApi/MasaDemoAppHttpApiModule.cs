using Localization.Resources.AbpUi;
using MasaDemoApp.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace MasaDemoApp;

[DependsOn(
    typeof(MasaDemoAppApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class MasaDemoAppHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(MasaDemoAppHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<MasaDemoAppResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
