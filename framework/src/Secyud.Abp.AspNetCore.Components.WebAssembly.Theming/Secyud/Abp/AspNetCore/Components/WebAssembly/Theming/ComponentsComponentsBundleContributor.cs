using Volo.Abp.Bundling;

namespace Secyud.Abp.AspNetCore.Components.WebAssembly.Theming;

public class ComponentsComponentsBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {
        context.Add("_content/Microsoft.AspNetCore.Components.WebAssembly.Authentication/AuthenticationService.js");
        context.Add("_content/Volo.Abp.AspNetCore.Components.Web/libs/abp/js/abp.js");
        context.Add("_content/Volo.Abp.AspNetCore.Components.Web/libs/abp/js/lang-utils.js");
    }

    public void AddStyles(BundleContext context)
    {
        context.Add("_content/Masa.Blazor/css/masa-blazor.min.css");
        context.Add("_content/Secyud.Abp.MasaBlazorUi/libs/fontawesome/css/font-awesome.min.css");
        context.Add("_content/Secyud.Abp.MasaBlazorUi/libs/@mdi/font/css/materialdesignicons.min.css");
        context.Add("_content/Secyud.Abp.MasaBlazorUi/libs/flag-icons/css/flag-icons.min.css");
    }
}