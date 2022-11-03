using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using SuperCreation.Abp.CodeDocs.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace SuperCreation.Abp.CodeDocs;

[DependsOn(
    typeof(CodeDocsApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class CodeDocsHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(CodeDocsHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<CodeDocsResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
