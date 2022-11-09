using Secyud.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace Secyud.Abp;

[DependsOn(
    typeof(CodeDocsBlazorModule),
    typeof(CodeDocsHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
)]
public class CodeDocsBlazorWebAssemblyModule : AbpModule
{
}