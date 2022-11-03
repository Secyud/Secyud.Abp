using Volo.Abp.Reflection;

namespace MasaDemoApp.Permissions;

public class MasaDemoAppPermissions
{
    public const string GroupName = "MasaDemoApp";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(MasaDemoAppPermissions));
    }
}
