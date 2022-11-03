using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.Localization;

namespace Secyud.Abp.AspNetCore.Mvc.UI.Theme.Masa.Bundling;

public class MasaGlobalStyleContributor : BundleContributor
{
    private const string RootPath = "/Themes/Masa/Global";
    public override Task ConfigureBundleAsync(BundleConfigurationContext context)
    {
        var options = context.ServiceProvider.GetRequiredService<IOptions<MasaThemeMvcOptions>>().Value;

        context.Files.Add($"{RootPath}/side-menu/libs/bootstrap-datepicker/css/bootstrap-datepicker.min.css");
        context.Files.Add($"{RootPath}/side-menu/libs/bootstrap-icons/font/bootstrap-icons.css");

        var rtlPostfix = CultureHelper.IsRtl ? ".rtl" : string.Empty;

        if (options.ApplicationLayout == MasaMvcLayouts.SideMenu)
        {
            context.Files.Add($"{RootPath}/side-menu/css/js-bundle{rtlPostfix}.css");
            context.Files.Add($"{RootPath}/side-menu/css/layout-bundle{rtlPostfix}.css");
            context.Files.Add($"{RootPath}/side-menu/css/abp-bundle{rtlPostfix}.css");
        }
        else if (options.ApplicationLayout == MasaMvcLayouts.TopMenu)
        {
            context.Files.Add($"{RootPath}/top-menu/css/js-bundle{rtlPostfix}.css");
            context.Files.Add($"{RootPath}/top-menu/css/layout-bundle{rtlPostfix}.css");
            context.Files.Add($"{RootPath}/top-menu/css/abp-bundle{rtlPostfix}.css");
        }

        context.Files.RemoveAll(x => x.EndsWith("bootstrap.css"));

        return Task.CompletedTask;
    }
}
