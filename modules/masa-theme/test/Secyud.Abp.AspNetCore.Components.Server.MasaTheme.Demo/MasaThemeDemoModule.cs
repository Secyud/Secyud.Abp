using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Secyud.Abp.AspNetCore.Components.Server.MasaTheme.Bundling;
using Secyud.Abp.AspNetCore.Components.Server.MasaTheme.Demo.Menus;
using Secyud.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;
using Volo.Abp.UI.Navigation;
using Volo.Abp.UI.Navigation.Urls;

namespace Secyud.Abp.AspNetCore.Components.Server.MasaTheme.Demo;

[DependsOn(
    typeof(AbpSwashbuckleModule),
    typeof(AbpAutofacModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpAspNetCoreComponentsServerMasaThemeModule)
)]
public class MasaThemeDemoModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();

        Configure<AppUrlOptions>(options => { options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"]; });

        Configure<AbpNavigationOptions>(options => { options.MenuContributors.Add(new MasaThemeDemoMenuContributor()); });

        Configure<AbpRouterOptions>(options => { options.AppAssembly = typeof(MasaThemeDemoModule).Assembly; });


        Configure<AbpBundlingOptions>(options =>
        {
            // Blazor UI
            options.StyleBundles.Configure(
                MasaBlazorThemeBundles.Styles.Global,
                bundle => { bundle.AddFiles("/blazor-global-styles.css"); }
            );
        });


        context.Services.AddAbpSwaggerGen(
            options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Aps API", Version = "v1" });
                options.DocInclusionPredicate((_, _) => true);
                options.CustomSchemaIds(type => type.FullName);
            }
        );

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Languages.Add(new LanguageInfo(
                    "en", 
                    "en", 
                    "English",
                    "us"));
            
            options.Languages.Add(new LanguageInfo(
                "zh-Hans", 
                "zh-Hans", 
                "简体中文",
                "cn"));
        });
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        app.Use((ctx, next) =>
        {
            ctx.Request.Scheme = "http";
            return next();
        });

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseAbpRequestLocalization();


        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
        });

        app.UseCookiePolicy();

        app.UseCorrelationId();
        app.UseAbpSecurityHeaders();
        app.UseStaticFiles();
        app.UseRouting();

        app.UseAbpSerilogEnrichers();
        app.UseSwagger();
        app.UseAbpSwaggerUI(options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", "Aps API"); });
        app.UseConfiguredEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}