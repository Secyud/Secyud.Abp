using Secyud.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace Secyud.Abp.PermissionManagement.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(AbpPermissionManagementBlazorModule)
)]
public class AbpPermissionManagementBlazorServerModule : AbpModule
{
}