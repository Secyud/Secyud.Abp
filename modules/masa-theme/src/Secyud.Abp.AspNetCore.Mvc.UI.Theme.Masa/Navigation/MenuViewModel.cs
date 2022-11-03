using System.Collections.Generic;
using Volo.Abp.UI.Navigation;

namespace Secyud.Abp.AspNetCore.Mvc.UI.Theme.Masa.Navigation;

public class MenuViewModel
{
    public ApplicationMenu Menu { get; set; }

    public List<MenuItemViewModel> Items { get; set; }
}
