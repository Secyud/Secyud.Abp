using Volo.Abp.Modularity;

namespace Secyud.Abp;

[DependsOn(
    typeof(AbpTenantManagementBlazorModule),
    typeof(AbpFeatureManagementBlazorServerModule)
)]
public class AbpTenantManagementBlazorServerModule : AbpModule
{
}