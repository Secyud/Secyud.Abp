using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.FlagIconCss;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Secyud.Abp.AspNetCore.Components.Server.MasaTheme.Bundling
{
    [DependsOn(typeof(FlagIconCssStyleContributor))]
    public class MasaBlazorThemeStyleContributor : BundleContributor
    {
        private const string RootPath = "/_content/Secyud.Abp.AspNetCore.Components.Web.MasaTheme";
        public override Task ConfigureBundleAsync(BundleConfigurationContext context)
        {
            

            return Task.CompletedTask;
        }
    }
}