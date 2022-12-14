using Microsoft.Extensions.DependencyInjection;
using Secyud.Abp.AspNetCore.Components.Web.Theming.Routing;
using Secyud.Abp.Navigation;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.ObjectExtending.Modularity;
using Volo.Abp.TenantManagement;
using Volo.Abp.Threading;
using Volo.Abp.UI.Navigation;

namespace Secyud.Abp;

[DependsOn(
    typeof(AbpAutoMapperModule),
    typeof(AbpTenantManagementApplicationContractsModule),
    typeof(AbpFeatureManagementBlazorModule)
)]
public class AbpTenantManagementBlazorModule : AbpModule
{
    private static readonly OneTimeRunner OneTimeRunner = new();

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<AbpTenantManagementBlazorModule>();

        Configure<AbpAutoMapperOptions>(options => { options.AddProfile<AbpTenantManagementBlazorAutoMapperProfile>(true); });

        Configure<AbpNavigationOptions>(options => { options.MenuContributors.Add(new TenantManagementBlazorMenuContributor()); });

        Configure<AbpRouterOptions>(options => { options.AdditionalAssemblies.Add(typeof(AbpTenantManagementBlazorModule).Assembly); });
    }

    public override void PostConfigureServices(ServiceConfigurationContext context)
    {
        OneTimeRunner.Run(() =>
        {
            ModuleExtensionConfigurationHelper
                .ApplyEntityConfigurationToUi(
                    TenantManagementModuleExtensionConsts.ModuleName,
                    TenantManagementModuleExtensionConsts.EntityNames.Tenant,
                    new[] { typeof(TenantCreateDto) },
                    new[] { typeof(TenantUpdateDto) }
                );
        });
    }
}