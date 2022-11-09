using Secyud.Abp.AspNetCore.Components.Web.Theming;
using Volo.Abp.AspNetCore.Components.WebAssembly;
using Volo.Abp.Modularity;

namespace Secyud.Abp.AspNetCore.Components.WebAssembly.Theming;

[DependsOn(
    typeof(AbpAspNetCoreComponentsWebThemingModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyModule)
)]
public class AbpAspNetCoreComponentsWebAssemblyThemingModule : AbpModule
{
}