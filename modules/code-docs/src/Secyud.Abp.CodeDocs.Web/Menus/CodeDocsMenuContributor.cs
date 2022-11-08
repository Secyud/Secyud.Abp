using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Secyud.Abp.CodeDocs.Web.Menus;

public class CodeDocsMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(CodeDocsMenus.Prefix, displayName: "CodeDocs", "~/CodeDocs", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
