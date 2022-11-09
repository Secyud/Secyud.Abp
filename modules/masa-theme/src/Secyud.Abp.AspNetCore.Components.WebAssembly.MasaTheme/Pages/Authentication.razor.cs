using Microsoft.AspNetCore.Components;
using Secyud.Abp.MasaTheme.Shared.Localization;

namespace Secyud.Abp.AspNetCore.Components.WebAssembly.MasaTheme.Pages;

public partial class Authentication
{
    public Authentication()
    {
        LocalizationResource = typeof(MasaResource);
    }

    [Parameter] public string Action { get; set; }
}