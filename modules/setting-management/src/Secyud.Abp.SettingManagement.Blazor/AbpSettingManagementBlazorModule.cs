using Microsoft.Extensions.DependencyInjection;
using Secyud.Abp.AspNetCore.Components.Web.Theming;
using Secyud.Abp.AspNetCore.Components.Web.Theming.Routing;
using Secyud.Abp.Menus;
using Secyud.Abp.SettingManagement;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement;
using Volo.Abp.UI.Navigation;

namespace Secyud.Abp;

[DependsOn(
    typeof(AbpSettingManagementApplicationContractsModule),
    typeof(AbpAspNetCoreComponentsWebThemingModule),
    typeof(AbpAutoMapperModule)
)]
public class AbpSettingManagementBlazorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<AbpSettingManagementBlazorModule>();

        Configure<AbpAutoMapperOptions>(options => { options.AddProfile<SettingManagementBlazorAutoMapperProfile>(true); });

        Configure<AbpNavigationOptions>(options => { options.MenuContributors.Add(new SettingManagementMenuContributor()); });

        Configure<AbpRouterOptions>(options => { options.AdditionalAssemblies.Add(typeof(AbpSettingManagementBlazorModule).Assembly); });
    }
}