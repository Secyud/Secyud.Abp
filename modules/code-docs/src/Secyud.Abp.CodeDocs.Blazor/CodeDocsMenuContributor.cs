using SuperCreation.Abp.CodeDocs.Localization;
using SuperCreation.Abp.CodeDocs.Permissions;
using System.Threading.Tasks;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.UI.Navigation;

namespace SuperCreation.Abp.CodeDocs.Blazor;

public class CodeDocsMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    protected virtual Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<CodeDocsResource>();
        var codeDocsMenu = new ApplicationMenuItem(
            CodeDocsMenusNames.GroupName,
            l["Menu:CodeDocs"],
            icon: "fa fa-file-alt"
        );
        context.Menu.AddItem(codeDocsMenu);
        codeDocsMenu.AddItem(
                     new ApplicationMenuItem(
                     CodeDocsMenusNames.CodeDocsManage,
                     l["Menu:CodeDocsManager"],
                     "code-docs/management"
                 )
                .RequirePermissions(CodeDocsPermissions.CodeDocsBasic.Default));

        codeDocsMenu.AddItem(
                     new ApplicationMenuItem(
                     CodeDocsMenusNames.CodeDocsBrowse,
                     l["Menu:CodeDocsBrowse"],
                     "code-docs/browse"
                 ));
        return Task.CompletedTask;
    }
}
