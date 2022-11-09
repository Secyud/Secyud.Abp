using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Secyud.Abp.AspNetCore.Components.Server.MasaTheme.Demo.Menus;

public class MasaThemeDemoMenuContributor : IMenuContributor
{
    public Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            AddMainMenuItems(context);
        }

        return Task.CompletedTask;
    }

    private void AddMainMenuItems(MenuConfigurationContext context)
    {
        var menuItem = new ApplicationMenuItem(MasaThemeDemoMenus.Components.Root, "Components", icon: "mdi-folder-outline");

        var items = new List<ApplicationMenuItem>
        {
            new(MasaThemeDemoMenus.Components.Alerts, "Alerts", "/Components/Alerts", "mdi-alert"),
            new(MasaThemeDemoMenus.Components.Badges, "Badges", "/Components/Badges"),
            new(MasaThemeDemoMenus.Components.Borders, "Borders", "/Components/Borders"),
            new(MasaThemeDemoMenus.Components.Breadcrumbs, "Breadcrumbs", "/Components/Breadcrumbs"),
            new(MasaThemeDemoMenus.Components.Buttons, "Buttons", "/Components/Buttons"),
            new(MasaThemeDemoMenus.Components.ButtonGroups, "Button Groups", "/Components/ButtonGroups"),
            new(MasaThemeDemoMenus.Components.Cards, "Cards", "/Components/Cards"),
            new(MasaThemeDemoMenus.Components.Carousel, "Carousel", "/Components/Carousel"),
            new(MasaThemeDemoMenus.Components.Collapse, "Collapse", "/Components/Collapse"),
            new(MasaThemeDemoMenus.Components.Dropdowns, "Dropdowns", "/Components/Dropdowns"),
            new(MasaThemeDemoMenus.Components.DynamicForms, "Dynamic Forms", "/Components/DynamicForms"),
            new(MasaThemeDemoMenus.Components.FormElements, "Form Elements", "/Components/FormElements"),
            new(MasaThemeDemoMenus.Components.Grids, "Grids", "/Components/Grids"),
            new(MasaThemeDemoMenus.Components.ListGroups, "List Groups", "/Components/ListGroups"),
            new(MasaThemeDemoMenus.Components.Modals, "Modals", "/Components/Modals"),
            new(MasaThemeDemoMenus.Components.Navs, "Navs", "/Components/Navs"),
            new(MasaThemeDemoMenus.Components.Navbars, "Navbars", "/Components/Navbars"),
            new(MasaThemeDemoMenus.Components.Paginator, "Paginator", "/Components/Paginator"),
            new(MasaThemeDemoMenus.Components.Popovers, "Popovers", "/Components/Popovers"),
            new(MasaThemeDemoMenus.Components.ProgressBars, "Progress Bars", "/Components/ProgressBars"),
            new(MasaThemeDemoMenus.Components.Tables, "Tables", "/Components/Tables"),
            new(MasaThemeDemoMenus.Components.Tabs, "Tabs", "/Components/Tabs"),
            new(MasaThemeDemoMenus.Components.Tooltips, "Tooltips", "/Components/Tooltips")
        };

        items.OrderBy(x => x.Name)
            .ToList()
            .ForEach(x => menuItem.AddItem(x));

        context.Menu.AddItem(menuItem);
    }
}