using SuperCreation.Abp.CodeDocs.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SuperCreation.Abp.CodeDocs.Permissions;

public class CodeDocsPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(CodeDocsPermissions.GroupName, L("Permission:CodeDocs"));
        var basic = myGroup.AddPermission(CodeDocsPermissions.CodeDocsBasic.Default, L("Permission:CodeDocs:Basic"));
        basic.AddChild(CodeDocsPermissions.CodeDocsBasic.Browse, L("Permission:CodeDocs:Browse"));
        basic.AddChild(CodeDocsPermissions.CodeDocsBasic.Create, L("Permission:CodeDocs:Create"));
        basic.AddChild(CodeDocsPermissions.CodeDocsBasic.Update, L("Permission:CodeDocs:Update"));
        basic.AddChild(CodeDocsPermissions.CodeDocsBasic.Delete, L("Permission:CodeDocs:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CodeDocsResource>(name);
    }
}
