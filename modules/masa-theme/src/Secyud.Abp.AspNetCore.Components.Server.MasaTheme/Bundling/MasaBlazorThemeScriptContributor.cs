using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Secyud.Abp.AspNetCore.Components.Server.MasaTheme.Bundling;

public class MasaBlazorThemeScriptContributor : BundleContributor
{
    private const string RootPath = "/_content/Secyud.Abp.AspNetCore.Components.Web.MasaTheme";

    public override void ConfigureBundle(BundleConfigurationContext context)
    {
    }
}