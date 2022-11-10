using System;
using System.Collections.Generic;
using Volo.Abp.DependencyInjection;

namespace Secyud.Abp.SettingManagement;

public class SettingComponentCreationContext : IServiceProviderAccessor
{
    public SettingComponentCreationContext(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;

        Groups = new List<SettingComponentGroup>();
    }

    public List<SettingComponentGroup> Groups { get; }
    public IServiceProvider ServiceProvider { get; }
}