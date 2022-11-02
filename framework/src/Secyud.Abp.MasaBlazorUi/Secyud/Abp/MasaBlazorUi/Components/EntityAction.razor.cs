using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Volo.Abp.AspNetCore.Components.Messages;

namespace Secyud.Abp.MasaBlazorUi.Components;

public sealed partial class EntityAction<TItem> : ComponentBase
{
    [Inject] private IAuthorizationService AuthorizationService { get; set; }

    [Inject] private IUiMessageService UiMessageService { get; set; }
    
    [Parameter] public bool Visible { get; set; } = true;

    [Parameter] public bool Disabled { get; set; }

    [Parameter] public string Text { get; set; }

    [Parameter] public EventCallback<TItem> Clicked { get; set; }

    [Parameter] public string Color { get; set; } = StyleColor.Primary;

    [Parameter] public Func<string> ConfirmationMessage { get; set; }

    [Parameter] public string Icon { get; set; }

    [CascadingParameter]
    public EntityActions<TItem> ParentActions { get; set; }
    
    internal async Task ActionClickedAsync()
    {
        if (ConfirmationMessage == null ||
            await UiMessageService.Confirm(ConfirmationMessage()))
            await InvokeAsync(async () => await Clicked.InvokeAsync(ParentActions.Item));
    }
}
