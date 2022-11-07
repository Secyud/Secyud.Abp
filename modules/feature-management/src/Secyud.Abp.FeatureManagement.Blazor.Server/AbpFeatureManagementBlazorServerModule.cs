using Secyud.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace Secyud.Abp;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(AbpFeatureManagementBlazorModule)
    )]
public class AbpFeatureManagementBlazorServerModule : AbpModule
{

}
