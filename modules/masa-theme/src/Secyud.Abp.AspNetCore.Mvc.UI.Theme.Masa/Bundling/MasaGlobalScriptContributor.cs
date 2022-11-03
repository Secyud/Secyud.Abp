using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.Modularity;

namespace Secyud.Abp.AspNetCore.Mvc.UI.Theme.Masa.Bundling
{
    [DependsOn(
        typeof(SharedThemeGlobalScriptContributor)
    )]
    public class MasaGlobalScriptContributor : BundleContributor
    {
        private const string RootPath = "/Themes/Masa/Global";
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            var options = context.ServiceProvider.GetRequiredService<IOptions<MasaThemeMvcOptions>>().Value;

            if (options.ApplicationLayout == MasaMvcLayouts.SideMenu)
            {
                context.Files.Add($"{RootPath}/side-menu/js/lepton-x.bundle.min.js");
            }
            else if (options.ApplicationLayout == MasaMvcLayouts.TopMenu)
            {
                context.Files.Add($"{RootPath}/top-menu/js/lepton-x.bundle.min.js");
            }


            context.Files.AddIfNotContains($"{RootPath}/scripts/style-initializer.js");
        }
    }
}