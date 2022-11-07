using Secyud.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;

namespace Secyud.Abp;

[DependsOn(
    typeof(AbpFeatureManagementBlazorModule),
    typeof(AbpFeatureManagementHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class AbpFeatureManagementBlazorWebAssemblyModule : AbpModule
{

}
