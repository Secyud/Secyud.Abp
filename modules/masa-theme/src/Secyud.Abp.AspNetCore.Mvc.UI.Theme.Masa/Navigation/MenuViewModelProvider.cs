using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Layout;
using Volo.Abp.DependencyInjection;
using Volo.Abp.ObjectMapping;
using Volo.Abp.UI.Navigation;

namespace Secyud.Abp.AspNetCore.Mvc.UI.Theme.Masa.Navigation;

public class MenuViewModelProvider : ITransientDependency
{
    protected IMenuManager MenuManager { get; }
    protected IPageLayout PageLayout { get; }
    protected IObjectMapper<AbpAspNetCoreMvcUiMasaThemeModule> ObjectMapper { get; }


    public MenuViewModelProvider(IMenuManager menuManager, IPageLayout pageLayout, IObjectMapper<AbpAspNetCoreMvcUiMasaThemeModule> objectMapper)
    {
        MenuManager = menuManager;
        PageLayout = pageLayout;
        ObjectMapper = objectMapper;
    }

    public async Task<MenuViewModel> GetMenuViewModelAsync()
    {
        var menu = await MenuManager.GetMainMenuAsync();
        var viewModel = ObjectMapper.Map<ApplicationMenu, MenuViewModel>(menu);

        if (!string.IsNullOrEmpty(PageLayout.Content.MenuItemName))
        {
            SetActiveMenuItems(viewModel.Items, PageLayout.Content.MenuItemName);
        }

        return viewModel;
    }

    protected virtual bool SetActiveMenuItems(IList<MenuItemViewModel> items, string activeMenuItemName)
    {
        foreach (var item in items)
        {
            if (item.MenuItem.Name == activeMenuItemName || SetActiveMenuItems(item.Items, activeMenuItemName))
            {
                item.IsActive = true;
                return true;
            }
        }

        return false;
    }
}
