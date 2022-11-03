using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Secyud.Abp.AspNetCore.Components.Web.Theming;

public class AbpDynamicLayoutComponentOptions
{
    [NotNull]
    public Dictionary<Type, IDictionary<string,object>> Components { get; set; }

    public AbpDynamicLayoutComponentOptions()
    {
        Components = new Dictionary<Type, IDictionary<string, object>>();
    }
}