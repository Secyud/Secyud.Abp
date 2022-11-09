using Microsoft.Extensions.DependencyInjection;
using Secyud.Abp.AspNetCore.Components.Web.Theming;
using Secyud.Abp.AspNetCore.Components.Web.Theming.Layout;
using Secyud.Abp.AspNetCore.Components.Web.Theming.Routing;
using Secyud.Abp.AspNetCore.Components.Web.Theming.Toolbars;
using Secyud.Abp.MasaTheme.Shared;
using Secyud.Abp.MasaTheme.Shared.Localization;
using Volo.Abp.AutoMapper;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Secyud.Abp.AspNetCore.Components.Web.MasaTheme;

[DependsOn(
    typeof(AbpAutoMapperModule),
    typeof(AbpAspNetCoreComponentsWebThemingModule),
    typeof(AbpAspNetCoreMasaSharedModule)
)]
public class AbpAspNetCoreComponentsWebMasaThemeModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<AbpAspNetCoreComponentsWebMasaThemeModule>();
        ConfigureToolbarOptions();
        ConfigureRouterOptions();
        ConfigurePageHeaderOptions();
        ConfigureMasaStyles();
    }

    private void ConfigureToolbarOptions()
    {
        Configure<AbpToolbarOptions>(options => { options.Contributors.Add(new MasaThemeWebToolbarContributor()); });
    }

    private void ConfigureRouterOptions()
    {
        Configure<AbpRouterOptions>(options => { options.AdditionalAssemblies.Add(typeof(AbpAspNetCoreComponentsWebMasaThemeModule).Assembly); });
    }

    private void ConfigureMasaStyles()
    {
        Configure<MasaThemeOptions>(o =>
        {
            o.Styles[MasaStyleNames.Light] =
                new MasaThemeStyle(L("Theme:" + MasaStyleNames.Light), "bi bi-sun-fill");

            o.Styles[MasaStyleNames.Dark] =
                new MasaThemeStyle(L("Theme:" + MasaStyleNames.Dark), "bi bi-moon-fill");
        });
    }

    private void ConfigurePageHeaderOptions()
    {
        Configure<PageHeaderOptions>(options =>
        {
            options.RenderPageTitle = false;
            options.RenderBreadcrumbs = false;
            options.RenderToolbar = false;
        });
    }

    private static LocalizableString L(string key)
    {
        return LocalizableString.Create<MasaResource>(key);
    }
}