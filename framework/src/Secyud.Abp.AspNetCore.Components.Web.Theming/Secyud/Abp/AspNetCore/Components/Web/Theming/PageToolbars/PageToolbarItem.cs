using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Volo.Abp;

namespace Secyud.Abp.AspNetCore.Components.Web.Theming.PageToolbars;

public class PageToolbarItem
{
    public PageToolbarItem(
        [NotNull] Type componentType,
        [CanBeNull] Dictionary<string, object> arguments = null,
        int order = 0)
    {
        ComponentType = Check.NotNull(componentType, nameof(componentType));
        Arguments = arguments;
        Order = order;
    }

    [NotNull] public Type ComponentType { get; }

    [CanBeNull] public Dictionary<string, object> Arguments { get; set; }

    public int Order { get; set; }
}