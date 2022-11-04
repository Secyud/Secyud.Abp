using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Navigation;
using Secyud.Abp.MasaTheme.Shared;
using Volo.Abp.AspNetCore.Components.Web;

namespace Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Components.ApplicationLayout;

public partial class SideMenuLayout
{
    [Inject] protected IAbpUtilsService UtilsService { get; set; }

    [Inject] protected IOptions<MasaThemeOptions> Options { get; set; }
        
    [Inject] protected MasaThemeManager ThemeManager { get; set; }
    
    public bool CascadingIsDark { get; set; }

    public const int HeaderHeight = 48;
    protected override Task OnInitializedAsync()
    {
        ThemeManager.ThemeChangeEvent += ChangeTheme;

        return base.OnInitializedAsync();
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
