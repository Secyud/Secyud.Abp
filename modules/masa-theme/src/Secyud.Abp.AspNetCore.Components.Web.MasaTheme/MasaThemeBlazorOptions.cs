using System;
using System.Collections.Generic;
using System.Linq;
using Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Navigation;

namespace Secyud.Abp.AspNetCore.Components.Web.MasaTheme;
public class MasaThemeBlazorOptions
{
    public Type Layout { get; set; } = MasaBlazorLayouts.SideMenu;
}
