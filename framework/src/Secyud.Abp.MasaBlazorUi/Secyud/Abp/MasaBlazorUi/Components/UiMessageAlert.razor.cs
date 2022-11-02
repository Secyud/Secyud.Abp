using System;
using System.Text;
using System.Threading.Tasks;
using Masa.Blazor;
using Microsoft.AspNetCore.Components;
using Volo.Abp.AspNetCore.Components.Messages;

namespace Secyud.Abp.MasaBlazorUi.Components;

public partial class UiMessageAlert
{
    [Inject] protected MasaBlazorUiMessageService UiMessageService { get; set; }

    [Parameter] public UiMessageType MessageType { get; set; }

    [Parameter] public string Title { get; set; }

    [Parameter] public string Message { get; set; }

    [Parameter] public TaskCompletionSource<bool> Callback { get; set; }

    [Parameter] public UiMessageOptions Options { get; set; }

    [Parameter] public EventCallback Okayed { get; set; }

    [Parameter] public EventCallback Confirmed { get; set; }

    [Parameter] public EventCallback Canceled { get; set; }

    protected bool MessageVisible { get; set; }

    protected virtual bool IsConfirmation
        => MessageType == UiMessageType.Confirmation;

    protected virtual bool CenterMessage
        => Options?.CenterMessage ?? true;

    protected virtual bool ShowMessageIcon
        => Options?.ShowMessageIcon ?? true;

    protected virtual string MessageIcon => Options?.MessageIcon?.ToString() ?? MessageType switch
    {
        UiMessageType.Info => IconName.Info,
        UiMessageType.Success => IconName.Success,
        UiMessageType.Warning => IconName.Warning,
        UiMessageType.Error => IconName.Error,
        UiMessageType.Confirmation => IconName.Confirmation,
        _ => null,
    };

    protected virtual string MessageColor => MessageType switch
    {
        UiMessageType.Info => IconColor.Info,
        UiMessageType.Success => IconColor.Success,
        UiMessageType.Warning => IconColor.Warning,
        UiMessageType.Error => IconColor.Error,
        UiMessageType.Confirmation => IconColor.Confirmation,
        _ => null,
    };

    protected virtual string OkButtonText
        => Options?.OkButtonText ?? "OK";

    protected virtual string ConfirmButtonText
        => Options?.ConfirmButtonText ?? "Confirm";

    protected virtual string CancelButtonText
        => Options?.CancelButtonText ?? "Cancel";

    protected override void OnInitialized()
    {
        base.OnInitialized();

        UiMessageService.MessageReceived += OnMessageReceived;
    }

    private async void OnMessageReceived(object sender, UiMessageEventArgs e)
    {
        MessageType = e.MessageType;
        Message = e.Message;
        Title = e.Title;
        Options = e.Options;
        Callback = e.Callback;

        await ShowMessageAlert();
    }

    protected virtual async Task ShowMessageAlert()
    {
        await InvokeAsync(() => MessageVisible = true);
    }

    public void Dispose()
    {
        if (UiMessageService != null)
            UiMessageService.MessageReceived -= OnMessageReceived;
    }

    protected async Task OnOkClicked()
    {
        await InvokeAsync(async () =>
        {
            await Okayed.InvokeAsync(null);
            MessageVisible = false;
        });
    }

    protected async Task OnConfirmClicked()
    {
        await InvokeAsync(async () =>
        {
            MessageVisible = false;

            if (IsConfirmation && Callback != null)
                await InvokeAsync(() => Callback.SetResult(true));

            await Confirmed.InvokeAsync(null);
        });
    }

    protected async Task OnCancelClicked()
    {
        await InvokeAsync(async () =>
        {
            MessageVisible = false;

            if (IsConfirmation && Callback != null)
                await InvokeAsync(() => Callback.SetResult(false));

            await Canceled.InvokeAsync(null);
        });
    }
}