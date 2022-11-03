using Secyud.Abp.AspNetCore.Components.Server.MasaTheme.Bundling;
using Secyud.Abp.AspNetCore.Components.Server.Theming;
using Secyud.Abp.AspNetCore.Components.Server.Theming.Bundling;
using Secyud.Abp.AspNetCore.Components.Web.MasaTheme;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.Modularity;

namespace Secyud.Abp.AspNetCore.Components.Server.MasaTheme
{
    [DependsOn(
        typeof(AbpAspNetCoreComponentsWebMasaThemeModule),
        typeof(AbpAspNetCoreComponentsServerThemingModule)
    )]
    public class AbpAspNetCoreComponentsServerMasaThemeModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBundlingOptions>(options =>
            {
                options
                    .StyleBundles
                    .Add(MasaBlazorThemeBundles.Styles.Global, bundle =>
                    {
                        bundle
                            .AddBaseBundles(BlazorStandardBundles.Styles.Global)
                            .AddContributors(typeof(MasaBlazorThemeStyleContributor));
                    });

                options
                    .ScriptBundles
                    .Add(MasaBlazorThemeBundles.Scripts.Global, bundle =>
                    {
                        bundle
                            .AddBaseBundles(BlazorStandardBundles.Scripts.Global)
                            .AddContributors(typeof(MasaBlazorThemeScriptContributor));
                    });
            });
        }
    }
}