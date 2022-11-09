using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Secyud.Abp.AspNetCore.Components.Server.MasaTheme.Bundling;

public class MasaBlazorThemeStyleContributor : BundleContributor
{
    private const string RootPath = "/_content/Secyud.Abp.AspNetCore.Components.Web.MasaTheme";

    public override Task ConfigureBundleAsync(BundleConfigurationContext context)
    {
        context.Files.Add($"{RootPath}/css/global-style.css");

        return Task.CompletedTask;
    }
}