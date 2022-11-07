using Secyud.Abp.AspNetCore.Components.Web.Theming;
using Secyud.Abp.SettingManagement;
using Secyud.Abp.Settings;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Features;
using Volo.Abp.Modularity;

namespace Secyud.Abp;

[DependsOn(
    typeof(AbpAspNetCoreComponentsWebThemingModule),
    typeof(AbpFeatureManagementApplicationContractsModule),
    typeof(AbpFeaturesModule),
    typeof(AbpSettingManagementBlazorModule)
    )]
public class AbpFeatureManagementBlazorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<SettingManagementComponentOptions>(options =>
        {
            options.Contributors.Add(new FeatureSettingManagementComponentContributor());
        });
    }
}
