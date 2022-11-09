using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Secyud.Abp.AspNetCore.Components.Server.Theming.Bundling;

public class BlazorGlobalStyleContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.AddIfNotContains("/_content/Masa.Blazor/css/masa-blazor.min.css");
        context.Files.AddIfNotContains("/_content/Secyud.Abp.MasaBlazorUi/libs/font-awesome/css/font-awesome.min.css");
        context.Files.AddIfNotContains("/_content/Secyud.Abp.MasaBlazorUi/libs/@mdi/font/css/materialdesignicons.min.css");
        context.Files.AddIfNotContains("/_content/Secyud.Abp.MasaBlazorUi/libs/flag-icons/css/flag-icons.min.css");
    }
}