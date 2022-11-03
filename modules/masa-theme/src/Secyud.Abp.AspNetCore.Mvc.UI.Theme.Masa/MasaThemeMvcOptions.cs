using System;
using System.Collections.Generic;
using System.Linq;
using Secyud.Abp.AspNetCore.Mvc.UI.Theme.Masa.Navigation;

namespace Secyud.Abp.AspNetCore.Mvc.UI.Theme.Masa;

public class MasaThemeMvcOptions
{
    /// <summary>
    /// Determines layout of application. Default value is <see cref="MasaMvcLayouts.SideMenu"/>
    /// </summary>
    public string ApplicationLayout { get; set; } = MasaMvcLayouts.SideMenu;

    /// <summary>
    /// A selector that defines which menu items will be displayed at mobile layout.
    /// </summary>
    public Func<IReadOnlyList<MenuItemViewModel>, IEnumerable<MenuItemViewModel>> MobileMenuSelector { get; set; } = (menuItems) => menuItems.Where(x => x.Items.IsNullOrEmpty());
}
