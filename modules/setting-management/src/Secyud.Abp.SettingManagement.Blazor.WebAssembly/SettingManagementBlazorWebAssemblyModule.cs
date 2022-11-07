using Secyud.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement;

namespace Secyud.Abp;

[DependsOn(
    typeof(AbpSettingManagementBlazorModule),
    typeof(AbpSettingManagementHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
)]
public class SettingManagementBlazorWebAssemblyModule : AbpModule
{
}