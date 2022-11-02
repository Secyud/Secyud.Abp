﻿using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Volo.Abp.AspNetCore.Components.Notifications;

namespace Secyud.Abp.MasaBlazorUi.Components;

public partial class UiNotificationAlert
{
    [Inject] protected MasaBlazorUiNotificationService UiNotificationService { get; set; }
    
    [Inject] protected IStringLocalizerFactory StringLocalizerFactory { get; set; }
    [Parameter] public UiNotificationType NotificationType { get; set; }

    [Parameter] public string Message { get; set; }

    [Parameter] public string Title { get; set; }
    
    [Parameter] public UiNotificationOptions Options { get; set; }

    [Parameter] public EventCallback Okayed { get; set; }

    [Parameter] public EventCallback Closed { get; set; }
    
    protected bool NotificationVisible { get; set; }
    
    protected virtual string NotificationIcon => NotificationType switch
    {
        UiNotificationType.Info => IconName.Info,
        UiNotificationType.Success => IconName.Success,
        UiNotificationType.Warning => IconName.Warning,
        UiNotificationType.Error => IconName.Error,
        _ => null,
    };
    
    protected virtual string NotificationColor => NotificationType switch
    {
        UiNotificationType.Info => IconColor.Info,
        UiNotificationType.Success => IconColor.Success,
        UiNotificationType.Warning => IconColor.Warning,
        UiNotificationType.Error => IconColor.Error,
        _ => null,
    };
    
    protected virtual string OkButtonText
        =>Options?.OkButtonText?.Localize(StringLocalizerFactory);
    
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
        
        NotificationVisible = true;
        
        await InvokeAsync(StateHasChanged);
    }

    public virtual void Dispose()
    {
        if (UiNotificationService != null)
            UiNotificationService.NotificationReceived -= OnNotificationReceived;
    }
}