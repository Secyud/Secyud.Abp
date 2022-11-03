using Volo.Abp.Reflection;

namespace SuperCreation.Abp.CodeDocs.Permissions;

public static class CodeDocsPermissions
{
    public const string GroupName = "CodeDocs";

    public static class CodeDocsBasic
    {
        public const string Default = GroupName + ".Basic";
        public const string Browse = GroupName + ".Browse";
        public const string Create = GroupName + ".Create";
        public const string Update = GroupName + ".Update";
        public const string Delete = GroupName + ".Delete";
    }

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(CodeDocsPermissions));
    }
}
