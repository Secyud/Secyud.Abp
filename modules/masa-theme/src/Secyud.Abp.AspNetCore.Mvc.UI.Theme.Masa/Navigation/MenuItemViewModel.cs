using System.Collections.Generic;
using Volo.Abp.UI.Navigation;

namespace Secyud.Abp.AspNetCore.Mvc.UI.Theme.Masa.Navigation;

public class MenuItemViewModel
{
    public ApplicationMenuItem MenuItem { get; set; }

    public IList<MenuItemViewModel> Items { get; set; }

    public bool IsActive { get; set; }

    public bool IsInRoot { get; set; }
}
