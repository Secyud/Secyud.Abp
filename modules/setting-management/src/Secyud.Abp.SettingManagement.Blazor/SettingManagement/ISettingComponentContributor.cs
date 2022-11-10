using System.Threading.Tasks;

namespace Secyud.Abp.SettingManagement;

public interface ISettingComponentContributor
{
    Task ConfigureAsync(SettingComponentCreationContext context);

    Task<bool> CheckPermissionsAsync(SettingComponentCreationContext context);
}