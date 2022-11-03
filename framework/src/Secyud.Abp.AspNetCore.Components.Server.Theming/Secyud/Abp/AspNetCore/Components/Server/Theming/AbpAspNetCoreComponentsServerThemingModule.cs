using Secyud.Abp.AspNetCore.Components.Server.Theming.Bundling;
using Secyud.Abp.AspNetCore.Components.Web.Theming;
using Volo.Abp.AspNetCore.Components.Server;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Packages;
using Volo.Abp.Modularity;

namespace Secyud.Abp.AspNetCore.Components.Server.Theming;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerModule),
    typeof(AbpAspNetCoreMvcUiPackagesModule),
    typeof(AbpAspNetCoreComponentsWebThemingModule),
    typeof(AbpAspNetCoreMvcUiBundlingModule)
    )]
public class AbpAspNetCoreComponentsServerThemingModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBundlingOptions>(options =>
        {
            options
                .StyleBundles
                .Add(BlazorStandardBundles.Styles.Global, bundle =>
                {
                    bundle.AddContributors(typeof(BlazorGlobalStyleContributor));
                });

            options
                .ScriptBundles
                .Add(BlazorStandardBundles.Scripts.Global, bundle =>
                {
                    bundle.AddContributors(typeof(BlazorGlobalScriptContributor));
                });
        });
    }
}
