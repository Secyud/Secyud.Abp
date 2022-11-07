using System;
using System.Threading.Tasks;
using Localization.Resources.AbpUi;
using Microsoft.AspNetCore.Components;
using Volo.Abp.AspNetCore.Components.Messages;
using Volo.Abp.AspNetCore.Components.Web;
using Volo.Abp.AspNetCore.Components.Web.Configuration;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.SettingManagement;
using Volo.Abp.SettingManagement.Localization;

namespace Secyud.Abp.Pages.SettingManagement.EmailSettingGroup;

public partial class EmailSettingGroupViewComponent
{
    [Inject] protected IEmailSettingsAppService EmailSettingsAppService { get; set; }

    [Inject] protected IPermissionChecker PermissionChecker { get; set; }

    [Inject] private ICurrentApplicationConfigurationCacheResetService CurrentApplicationConfigurationCacheResetService { get; set; }

    [Inject] protected IUiMessageService UiMessageService { get; set; }

    protected UpdateEmailSettingsViewModel EmailSettings;

    protected SendTestEmailViewModel SendTestEmailInput;

    protected bool SendTestEmailModalVisible;
    protected bool HasSendTestEmailPermission { get; set; }


    public EmailSettingGroupViewComponent()
    {
        ObjectMapperContext = typeof(AbpSettingManagementBlazorModule);
        LocalizationResource = typeof(AbpSettingManagementResource);
    }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            EmailSettings = ObjectMapper.Map<EmailSettingsDto, UpdateEmailSettingsViewModel>(await EmailSettingsAppService.GetAsync());
            HasSendTestEmailPermission = await PermissionChecker.IsGrantedAsync(SettingManagementPermissions.EmailingTest);
            SendTestEmailInput = new SendTestEmailViewModel();
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(ex);
        }
    }

    protected virtual async Task UpdateSettingsAsync()
    {
        try
        {
            await EmailSettingsAppService.UpdateAsync(ObjectMapper.Map<UpdateEmailSettingsViewModel, UpdateEmailSettingsDto>(EmailSettings));

            await CurrentApplicationConfigurationCacheResetService.ResetAsync();

            await UiMessageService.Success(L["SuccessfullySaved"]);
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(ex);
        }
    }

    protected virtual async Task OpenSendTestEmailModalAsync()
    {
        try
        {
            var emailSettings = await EmailSettingsAppService.GetAsync();
            
            SendTestEmailInput = new SendTestEmailViewModel
            {
                SenderEmailAddress = emailSettings.DefaultFromAddress,
                TargetEmailAddress = CurrentUser.Email,
                Subject = L["TestEmailSubject", new Random().Next(1000, 9999)],
                Body = L["TestEmailBody"]
            };

            SendTestEmailModalVisible = true;
            await InvokeAsync(StateHasChanged);
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(ex);
        }
    }

    protected virtual async Task CloseSendTestEmailModalAsync()
    {
        SendTestEmailModalVisible = false;
        await InvokeAsync(StateHasChanged);
    }

    protected virtual async Task SendTestEmailAsync()
    {
        try
        {
            await EmailSettingsAppService.SendTestEmailAsync(ObjectMapper.Map<SendTestEmailViewModel, SendTestEmailInput>(SendTestEmailInput));

            await Notify.Success(L["SuccessfullySent"]);
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(ex);
        }
    }
}