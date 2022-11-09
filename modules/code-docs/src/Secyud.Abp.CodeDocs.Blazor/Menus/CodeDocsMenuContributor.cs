using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Secyud.Abp.Menus;

public class CodeDocsMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main) await ConfigureMainMenuAsync(context);
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(CodeDocsMenus.Prefix, "CodeDocs", "/CodeDocs", "fa fa-globe"));

        return Task.CompletedTask;
    }
}