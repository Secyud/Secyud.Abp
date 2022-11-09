using Secyud.Abp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Secyud.Abp.Permissions;

public class CodeDocsPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var codeDocsGroup = context.AddGroup(
            CodeDocsPermissions.GroupName,
            L("Permission:CodeDocs"));
        var codeClass = codeDocsGroup.AddPermission(
            CodeDocsPermissions.CodeClass.Default,
            L("Permission:CodeClass"));
        codeClass.AddChild(
            CodeDocsPermissions.CodeClass.Browse,
            L("Permission:CodeClass:Browse"));
        codeClass.AddChild(
            CodeDocsPermissions.CodeClass.Create,
            L("Permission:CodeClass:Create"));
        codeClass.AddChild(
            CodeDocsPermissions.CodeClass.Update,
            L("Permission:CodeClass:Update"));
        codeClass.AddChild(
            CodeDocsPermissions.CodeClass.Delete,
            L("Permission:CodeClass:Delete"));

        var codeFunction = codeDocsGroup.AddPermission(
            CodeDocsPermissions.CodeFunction.Default,
            L("Permission:CodeFunction"));
        codeFunction.AddChild(
            CodeDocsPermissions.CodeFunction.Browse,
            L("Permission:CodeFunction:Browse"));
        codeFunction.AddChild(
            CodeDocsPermissions.CodeFunction.Create,
            L("Permission:CodeFunction:Create"));
        codeFunction.AddChild(
            CodeDocsPermissions.CodeFunction.Update,
            L("Permission:CodeFunction:Update"));
        codeFunction.AddChild(
            CodeDocsPermissions.CodeFunction.Delete,
            L("Permission:CodeFunction:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CodeDocsResource>(name);
    }
}