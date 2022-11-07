using Secyud.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace Secyud.Abp.PermissionManagement.Blazor.WebAssembly;

[DependsOn(
    typeof(AbpPermissionManagementBlazorModule),
    typeof(AbpPermissionManagementHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class AbpPermissionManagementBlazorWebAssemblyModule : AbpModule
{

}
