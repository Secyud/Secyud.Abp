using Secyud.Abp.MasaBlazorUi;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace Secyud.Abp.AspNetCore.Components.Web.Theming;

[DependsOn(
    typeof(AbpMasaBlazorUiModule),
    typeof(AbpUiNavigationModule)
    )]
public class AbpAspNetCoreComponentsWebThemingModule : AbpModule
{

}
