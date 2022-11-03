using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace MasaDemoApp.Blazor.WebAssembly;

[DependsOn(
    typeof(MasaDemoAppBlazorModule),
    typeof(MasaDemoAppHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class MasaDemoAppBlazorWebAssemblyModule : AbpModule
{

}
