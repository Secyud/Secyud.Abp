using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Navigation;
using Secyud.Abp.MasaTheme.Shared;
using Volo.Abp.AspNetCore.Components.Web;

namespace Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Components.ApplicationLayout;

public partial class MasaSideMenuLayout
{
    [Inject] protected IAbpUtilsService UtilsService { get; set; }

    [Inject] protected IOptions<MasaThemeOptions> Options { get; set; }
        
    [Inject] protected MasaThemeManager ThemeManager { get; set; }

    
    private bool CascadingIsDark { get; set; }
    
    private bool NavBarCollapsed { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        if (await ThemeManager.GetCookiesThemeAsync() == MasaStyleNames.Dark)
        {
            CascadingIsDark = true;
        }

        ThemeManager.ThemeChangeEvent += ChangeTheme;

        await base.OnInitializedAsync();
    }

    public void ChangeTheme(object sender, ThemeChangeEventArgs args)
    {
        CascadingIsDark = args.ThemeName == MasaStyleNames.Dark;
        StateHasChanged();
    }
    
    public void Dispose()
    {
        ThemeManager.ThemeChangeEvent -= ChangeTheme;
    }
}
