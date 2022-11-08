using Secyud.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace Secyud.Abp;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(CodeDocsBlazorModule)
    )]
public class CodeDocsBlazorServerModule : AbpModule
{

}
