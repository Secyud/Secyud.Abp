using Microsoft.Extensions.DependencyInjection;
using SuperCreation.Abp.AspNetCore.Components.Web.Theming;
using SuperCreation.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace SuperCreation.Abp.CodeDocs.Blazor;

[DependsOn(
    typeof(AbpAspNetCoreComponentsWebThemingModule),
    typeof(CodeDocsApplicationContractsModule),
    typeof(AbpAutoMapperModule)
    )]
public class CodeDocsBlazorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<CodeDocsBlazorModule>();

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddProfile<CodeDocsBlazorAutoMapperProfile>(validate: true);
        });

        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new CodeDocsMenuContributor());
        });

        Configure<AbpRouterOptions>(options =>
        {
            options.AdditionalAssemblies.Add(typeof(CodeDocsBlazorModule).Assembly);
        });
    }
}
