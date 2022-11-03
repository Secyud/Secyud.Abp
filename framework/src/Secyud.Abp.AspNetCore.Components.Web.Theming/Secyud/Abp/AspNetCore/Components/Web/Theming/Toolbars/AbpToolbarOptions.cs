using System.Collections.Generic;
using JetBrains.Annotations;

namespace Secyud.Abp.AspNetCore.Components.Web.Theming.Toolbars;

public class AbpToolbarOptions
{
    [NotNull]
    public List<IToolbarContributor> Contributors { get; }

    public AbpToolbarOptions()
    {
        Contributors = new List<IToolbarContributor>();
    }
}
