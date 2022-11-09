using System.Collections.Generic;
using JetBrains.Annotations;

namespace Secyud.Abp.AspNetCore.Components.Web.Theming.Toolbars;

public class AbpToolbarOptions
{
    public AbpToolbarOptions()
    {
        Contributors = new List<IToolbarContributor>();
    }

    [NotNull] public List<IToolbarContributor> Contributors { get; }
}