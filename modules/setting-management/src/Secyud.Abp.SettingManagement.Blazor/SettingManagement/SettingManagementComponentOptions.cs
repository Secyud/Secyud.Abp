using System.Collections.Generic;

namespace Secyud.Abp.SettingManagement;

public class SettingManagementComponentOptions
{
    public SettingManagementComponentOptions()
    {
        Contributors = new List<ISettingComponentContributor>();
    }

    public List<ISettingComponentContributor> Contributors { get; }
}