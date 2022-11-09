using Microsoft.AspNetCore.Components;
using Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Navigation;

namespace Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Components.ApplicationLayout.SideMenu.Navigation;

public partial class MainMenuItem
{
    [Parameter] public MenuViewModel Menu { get; set; }

    [Parameter] public MenuItemViewModel MenuItem { get; set; }

    protected virtual void ToggleMenu()
    {
        Menu.ToggleOpen(MenuItem);
    }
}