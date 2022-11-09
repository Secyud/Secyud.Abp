using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.ObjectMapping;
using Volo.Abp.UI.Navigation;

namespace Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Navigation;

public class MainMenuProvider : IScopedDependency
{
    private readonly IMenuManager _menuManager;
    private readonly IObjectMapper<AbpAspNetCoreComponentsWebMasaThemeModule> _objectMapper;

    public MainMenuProvider(
        IMenuManager menuManager,
        IObjectMapper<AbpAspNetCoreComponentsWebMasaThemeModule> objectMapper)
    {
        _menuManager = menuManager;
        _objectMapper = objectMapper;
    }

    private MenuViewModel Menu { get; set; }

    public async Task<MenuViewModel> GetMenuAsync()
    {
        if (Menu == null)
        {
            var menu = await _menuManager.GetMainMenuAsync();

            Menu = new MenuViewModel
            {
                Menu = menu,
                Items = menu.Items.Select(CreateMenuItemViewModel).ToList()
            };
            Menu.SetParents();
        }

        return Menu;
    }

    private MenuItemViewModel CreateMenuItemViewModel(ApplicationMenuItem applicationMenuItem)
    {
        var viewModel = new MenuItemViewModel
        {
            MenuItem = applicationMenuItem
        };

        viewModel.Items = new List<MenuItemViewModel>();

        foreach (var item in applicationMenuItem.Items)
        {
            viewModel.Items.Add(CreateMenuItemViewModel(item));
        }

        return viewModel;
    }
}