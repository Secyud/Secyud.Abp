using System.Threading.Tasks;
using Localization.Resources.AbpUi;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Secyud.Abp.MasaBlazorUi.Components;

public partial class SubmitButton
{
    [Inject] protected IStringLocalizer<AbpUiResource> StringLocalizer { get; set; }

    [Parameter] public string Form { get; set; }

    [Parameter] public string Color { get; set; } = "primary";

    [Parameter] public bool Block { get; set; }

    [Parameter] public bool Disabled { get; set; }

    [Parameter] public string Text { get; set; } = "Save";

    [Parameter] public EventCallback OnClick { get; set; }

    [Parameter] public RenderFragment ChildContent { get; set; }

    protected bool Submiting { get; set; }

    protected bool IsDisabled => Disabled || Submiting;

    protected bool IsLoading => Submiting;

    protected string SaveString => StringLocalizer[Text];

    protected virtual async Task OnClickedHandler()
    {
        try
        {
            Submiting = true;
            await OnClick.InvokeAsync(null);
        }
        finally
        {
            Submiting = false;
            await InvokeAsync(StateHasChanged);
        }
    }
}