using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Secyud.Abp.MasaBlazorUi.Components;

public partial class ToolbarButton
{
    [Parameter] public string Color { get; set; }

    [Parameter] public string Icon { get; set; }

    [Parameter] public string Text { get; set; }

    [Parameter] public Func<Task> OnClick { get; set; }

    [Parameter] public bool Disabled { get; set; }
}