using MasaDemoApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace MasaDemoApp.Permissions;

public class MasaDemoAppPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(MasaDemoAppPermissions.GroupName, L("Permission:MasaDemoApp"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MasaDemoAppResource>(name);
    }
}
