using Microsoft.Extensions.DependencyInjection;
using Secyud.Abp.AspNetCore.Mvc.UI.Theme.Masa.Bundling;
using Secyud.Abp.AspNetCore.Mvc.UI.Theme.Masa.ObjectMapping;
using Secyud.Abp.AspNetCore.Mvc.UI.Theme.Masa.Toolbars;
using Secyud.Abp.MasaTheme.Shared;
using Secyud.Abp.MasaTheme.Shared.Localization;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.AutoMapper;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Secyud.Abp.AspNetCore.Mvc.UI.Theme.Masa;

[DependsOn(
    typeof(AbpAspNetCoreMasaSharedModule),
    typeof(AbpAspNetCoreMvcUiMultiTenancyModule),
    typeof(AbpAutoMapperModule)
)]
public class AbpAspNetCoreMvcUiMasaThemeModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(AbpAspNetCoreMvcUiMasaThemeModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureMasaStyles();

        Configure<AbpThemingOptions>(options =>
        {
            options.Themes.Add<MasaTheme>();

            if (options.DefaultThemeName == null)
            {
                options.DefaultThemeName = MasaTheme.Name;
            }
        });

        Configure<AbpErrorPageOptions>(options =>
        {
            options.ErrorViewUrls.Add("401", "~/Views/Error/401.cshtml");
            options.ErrorViewUrls.Add("403", "~/Views/Error/403.cshtml");
            options.ErrorViewUrls.Add("404", "~/Views/Error/404.cshtml");
            options.ErrorViewUrls.Add("500", "~/Views/Error/500.cshtml");
        });

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpAspNetCoreMvcUiMasaThemeModule>();
        });

        Configure<AbpToolbarOptions>(options =>
        {
            options.Contributors.Add(new MasaThemeMainTopToolbarContributor());
        });

        Configure<AbpBundlingOptions>(options =>
        {
            options
                .StyleBundles
                .Add(MasaThemeBundles.Styles.Global, bundle =>
                {
                    bundle
                        .AddBaseBundles(StandardBundles.Styles.Global)
                        .AddContributors(typeof(MasaGlobalStyleContributor));
                });

            options
                .ScriptBundles
                .Add(MasaThemeBundles.Scripts.Global, bundle =>
                {
                    bundle
                        .AddBaseBundles(StandardBundles.Scripts.Global)
                        .AddContributors(typeof(MasaGlobalScriptContributor));
                });
        });

        context.Services.AddAutoMapperObjectMapper<AbpAspNetCoreMvcUiMasaThemeModule>();

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddProfile<MasaThemeAutoMapperProfile>(validate: true);
        });
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        
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

    private static LocalizableString L(string key)
    {
        return LocalizableString.Create<MasaResource>(key);
    }
}