using Secyud.Abp.FeatureManagement.Blazor.WebAssembly;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;

namespace Secyud.Abp;

[DependsOn(
    typeof(AbpTenantManagementBlazorModule),
    typeof(AbpFeatureManagementBlazorWebAssemblyModule),
    typeof(AbpTenantManagementHttpApiClientModule)
    )]
public class AbpTenantManagementBlazorWebAssemblyModule : AbpModule
{

}
