using System;
using System.Threading.Tasks;
using BlazorComponent;
using Masa.Blazor;
using Masa.Blazor.Popup.Components;
using Masa.Blazor.Presets;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Volo.Abp.AspNetCore.Components.Notifications;

namespace Secyud.Abp.MasaBlazorUi.Components;

public partial class UiNotificationAlert
{
    [Inject] protected MasaBlazorUiNotificationService UiNotificationService { get; set; }
    
    protected PToast ToastRef { get; set; }

    [Parameter] public UiNotificationType NotificationType { get; set; }

    [Parameter] public string Message { get; set; }

    [Parameter] public string Title { get; set; }
    
    [Parameter] public UiNotificationOptions Options { get; set; }

    [Parameter] public EventCallback Okayed { get; set; }

    [Parameter] public EventCallback Closed { get; set; }
    
    protected virtual string NotificationColor => NotificationType switch
    {
        UiNotificationType.Info => IconColor.Info,
        UiNotificationType.Success => IconColor.Success,
        UiNotificationType.Warning => IconColor.Warning,
        UiNotificationType.Error => IconColor.Error,
        _ => null,
    };
    
    protected virtual AlertTypes AlertType => NotificationType switch
    {
        UiNotificationType.Info => AlertTypes.Info,
        UiNotificationType.Success => AlertTypes.Success,
        UiNotificationType.Warning => AlertTypes.Warning,
        UiNotificationType.Error => AlertTypes.Error,
        _ => AlertTypes.None,
    };

    protected override void OnInitialized()
    {
        base.OnInitialized();

        UiNotificationService.NotificationReceived += OnNotificationReceived;
    }

    protected virtual async void OnNotificationReceived(object sender, UiNotificationEventArgs e)
    {
        NotificationType = e.NotificationType;
        Message = e.Message;
        Title = e.Title;
        Options = e.Options;
        
        var config = new ToastConfig
        {
            Type = AlertType,
            Color = NotificationColor,
            Dark = true,
            Title = Title,
            Content = Message,
            Duration = 4096
        };

        await ToastRef.AddToast(config);
    }

    public virtual void Dispose()
    {
        if (UiNotificationService != null)
            UiNotificationService.NotificationReceived -= OnNotificationReceived;
    }
}
