using System;
using JetBrains.Annotations;
using Volo.Abp;

namespace Secyud.Abp.SettingManagement;

public class SettingComponentGroup
{
    private Type _componentType;
    private string _displayName;
    private string _id;

    public SettingComponentGroup([NotNull] string id, [NotNull] string displayName, [NotNull] Type componentType, object parameter = null)
    {
        Id = id;
        DisplayName = displayName;
        ComponentType = componentType;
        Parameter = parameter;
    }

    public string Id
    {
        get => _id;
        set => _id = Check.NotNullOrWhiteSpace(value, nameof(Id));
    }

    public string DisplayName
    {
        get => _displayName;
        set => _displayName = Check.NotNullOrWhiteSpace(value, nameof(DisplayName));
    }

    public Type ComponentType
    {
        get => _componentType;
        set => _componentType = Check.NotNull(value, nameof(ComponentType));
    }

    public object Parameter { get; set; }
}