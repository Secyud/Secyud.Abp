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
        var menuItem = new ApplicationMenuItem(MasaThemeDemoMenus.Components.Root, "Components",icon:"mdi-folder-outline");

        var items = new List<ApplicationMenuItem>()
        {
            new(MasaThemeDemoMenus.Components.Alerts, "Alerts", url: "/Components/Alerts"),
            new(MasaThemeDemoMenus.Components.Badges, "Badges", url: "/Components/Badges"),
            new(MasaThemeDemoMenus.Components.Borders, "Borders", url: "/Components/Borders"),
            new(MasaThemeDemoMenus.Components.Breadcrumbs, "Breadcrumbs", url: "/Components/Breadcrumbs"),
            new(MasaThemeDemoMenus.Components.Buttons, "Buttons", url: "/Components/Buttons"),
            new(MasaThemeDemoMenus.Components.ButtonGroups, "Button Groups", url: "/Components/ButtonGroups"),
            new(MasaThemeDemoMenus.Components.Cards, "Cards", url: "/Components/Cards"),
            new(MasaThemeDemoMenus.Components.Carousel, "Carousel", url: "/Components/Carousel"),
            new(MasaThemeDemoMenus.Components.Collapse, "Collapse", url: "/Components/Collapse"),
            new(MasaThemeDemoMenus.Components.Dropdowns, "Dropdowns", url: "/Components/Dropdowns"),
            new(MasaThemeDemoMenus.Components.DynamicForms, "Dynamic Forms", url: "/Components/DynamicForms"),
            new(MasaThemeDemoMenus.Components.FormElements, "Form Elements", url: "/Components/FormElements"),
            new(MasaThemeDemoMenus.Components.Grids, "Grids", url: "/Components/Grids"),
            new(MasaThemeDemoMenus.Components.ListGroups, "List Groups", url: "/Components/ListGroups"),
            new(MasaThemeDemoMenus.Components.Modals, "Modals", url: "/Components/Modals"),
            new(MasaThemeDemoMenus.Components.Navs, "Navs", url: "/Components/Navs"),
            new(MasaThemeDemoMenus.Components.Navbars, "Navbars", url: "/Components/Navbars"),
            new(MasaThemeDemoMenus.Components.Paginator, "Paginator", url: "/Components/Paginator"),
            new(MasaThemeDemoMenus.Components.Popovers, "Popovers", url: "/Components/Popovers"),
            new(MasaThemeDemoMenus.Components.ProgressBars, "Progress Bars", url: "/Components/ProgressBars"),
            new(MasaThemeDemoMenus.Components.Tables, "Tables", url: "/Components/Tables"),
            new(MasaThemeDemoMenus.Components.Tabs, "Tabs", url: "/Components/Tabs"),
            new(MasaThemeDemoMenus.Components.Tooltips, "Tooltips", url: "/Components/Tooltips")
        };

        items.OrderBy(x => x.Name)
            .ToList()
            .ForEach(x => menuItem.AddItem(x));

        context.Menu.AddItem(menuItem);
    }
}