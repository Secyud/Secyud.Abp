using System;
using System.Threading.Tasks;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Volo.Abp.AspNetCore.Components.Messages;
using Volo.Abp.DependencyInjection;

namespace Secyud.Abp.MasaBlazorUi;

[Dependency(ReplaceServices = true)]
public class MasaBlazorUiMessageService : IUiMessageService, IScopedDependency
{
    private readonly IStringLocalizer<AbpUiResource> _localizer;

    public MasaBlazorUiMessageService(
        IStringLocalizer<AbpUiResource> localizer)
    {
        _localizer = localizer;

        Logger = NullLogger<MasaBlazorUiMessageService>.Instance;
    }

    public ILogger<MasaBlazorUiMessageService> Logger { get; set; }

    public Task Info(string message, string title = null, Action<UiMessageOptions> options = null)
    {
        var uiMessageOptions = CreateDefaultOptions();
        options?.Invoke(uiMessageOptions);

        MessageReceived?.Invoke(this, new UiMessageEventArgs(UiMessageType.Info, message, title, uiMessageOptions));

        return Task.CompletedTask;
    }

    public Task Success(string message, string title = null, Action<UiMessageOptions> options = null)
    {
        var uiMessageOptions = CreateDefaultOptions();
        options?.Invoke(uiMessageOptions);

        MessageReceived?.Invoke(this, new UiMessageEventArgs(UiMessageType.Success, message, title, uiMessageOptions));

        return Task.CompletedTask;
    }

    public Task Warn(string message, string title = null, Action<UiMessageOptions> options = null)
    {
        var uiMessageOptions = CreateDefaultOptions();
        options?.Invoke(uiMessageOptions);

        MessageReceived?.Invoke(this, new UiMessageEventArgs(UiMessageType.Warning, message, title, uiMessageOptions));

        return Task.CompletedTask;
    }

    public Task Error(string message, string title = null, Action<UiMessageOptions> options = null)
    {
        var uiMessageOptions = CreateDefaultOptions();
        options?.Invoke(uiMessageOptions);

        MessageReceived?.Invoke(this, new UiMessageEventArgs(UiMessageType.Error, message, title, uiMessageOptions));

        return Task.CompletedTask;
    }

    public Task<bool> Confirm(string message, string title = null, Action<UiMessageOptions> options = null)
    {
        var uiMessageOptions = CreateDefaultOptions();
        options?.Invoke(uiMessageOptions);

        var callback = new TaskCompletionSource<bool>();

        MessageReceived?.Invoke(this, new UiMessageEventArgs(UiMessageType.Confirmation, message, title, uiMessageOptions, callback));

        return callback.Task;
    }

    /// <summary>
    ///     An event raised after the message is received. Used to notify the message dialog.
    /// </summary>
    public event EventHandler<UiMessageEventArgs> MessageReceived;

    protected virtual UiMessageOptions CreateDefaultOptions()
    {
        return new UiMessageOptions
        {
            CenterMessage = true,
            ShowMessageIcon = true,
            OkButtonText = _localizer["Ok"],
            CancelButtonText = _localizer["Cancel"],
            ConfirmButtonText = _localizer["Yes"]
        };
    }
}