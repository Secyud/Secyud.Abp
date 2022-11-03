using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;
using Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Navigation;
using Secyud.Abp.AspNetCore.Components.Web.Theming.Layout;

namespace Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Components.ApplicationLayout.SideMenu.Navigation
{
    public partial class MainMenuItem 
    {
        [Parameter] public MenuViewModel Menu { get; set; }

        [Parameter] public MenuItemViewModel MenuItem { get; set; }

        protected virtual void ToggleMenu()
        {
            Menu.ToggleOpen(MenuItem);
        }

    }
}
