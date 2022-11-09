using Microsoft.Extensions.DependencyInjection;
using Secyud.Abp.AspNetCore.Components.Web.Theming;
using Secyud.Abp.AspNetCore.Components.Web.Theming.Routing;
using Secyud.Abp.Menus;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace Secyud.Abp;

[DependsOn(
    typeof(CodeDocsApplicationContractsModule),
    typeof(AbpAspNetCoreComponentsWebThemingModule),
    typeof(AbpAutoMapperModule)
)]
public class CodeDocsBlazorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<CodeDocsBlazorModule>();

        Configure<AbpAutoMapperOptions>(options => { options.AddProfile<CodeDocsBlazorAutoMapperProfile>(true); });

        Configure<AbpNavigationOptions>(options => { options.MenuContributors.Add(new CodeDocsMenuContributor()); });

        Configure<AbpRouterOptions>(options => { options.AdditionalAssemblies.Add(typeof(CodeDocsBlazorModule).Assembly); });
    }
}