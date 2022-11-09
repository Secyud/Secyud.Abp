using Volo.Abp.Reflection;

namespace Secyud.Abp.Permissions;

public static class CodeDocsPermissions
{
    public const string GroupName = "CodeDocs";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(CodeDocsPermissions));
    }

    public static class CodeClass
    {
        public const string Default = GroupName + ".Basic";
        public const string Browse = GroupName + ".Browse";
        public const string Create = GroupName + ".Create";
        public const string Update = GroupName + ".Update";
        public const string Delete = GroupName + ".Delete";
    }

    public static class CodeFunction
    {
        public const string Default = GroupName + ".Basic";
        public const string Browse = GroupName + ".Browse";
        public const string Create = GroupName + ".Create";
        public const string Update = GroupName + ".Update";
        public const string Delete = GroupName + ".Delete";
    }
}