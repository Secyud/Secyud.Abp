using Microsoft.Extensions.DependencyInjection;
using Secyud.Abp.AspNetCore.Components.Web.MasaTheme;
using Secyud.Abp.AspNetCore.Components.Web.Theming.Routing;
using Secyud.Abp.AspNetCore.Components.Web.Theming.Toolbars;
using Secyud.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.AutoMapper;
using Volo.Abp.Http.Client.IdentityModel.WebAssembly;
using Volo.Abp.Modularity;

namespace Secyud.Abp.AspNetCore.Components.WebAssembly.MasaTheme
{
    [DependsOn(
        typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule),
        typeof(AbpAspNetCoreComponentsWebMasaThemeModule),
        typeof(AbpHttpClientIdentityModelWebAssemblyModule)
        )]
    public class AbpAspNetCoreComponentsWebAssemblyMasaThemeModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(AbpAspNetCoreComponentsWebAssemblyMasaThemeModule).Assembly);
            });

            context.Services.AddAutoMapperObjectMapper<AbpAspNetCoreComponentsWebAssemblyMasaThemeModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<AbpAspNetCoreComponentsWebAssemblyMasaThemeModule>();
            });
        }
    }
}
