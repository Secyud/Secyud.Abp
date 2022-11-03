using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace MasaDemoApp.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(MasaDemoAppBlazorModule)
    )]
public class MasaDemoAppBlazorServerModule : AbpModule
{

}
