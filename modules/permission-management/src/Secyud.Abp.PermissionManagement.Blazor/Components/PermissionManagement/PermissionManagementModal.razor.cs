using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorComponent;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Volo.Abp.AspNetCore.Components.Web.Configuration;
using Volo.Abp.Localization;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.Localization;

namespace Secyud.Abp.Pages.PermissionManagement;

public partial class PermissionManagementModal
{
    protected readonly List<PermissionGrantInfoDto> DisabledPermissions = new();

    protected readonly UpdatePermissionsDto UpdateDto = new();

    protected string EntityDisplayName;
    protected List<PermissionGroupDto> Groups;

    protected bool ModalVisible;

    protected int NotGrantedPermissionCount;
    protected string ProviderKey;

    protected string ProviderName;

    protected StringNumber SelectedTabName;

    public PermissionManagementModal()
    {
        LocalizationResource = typeof(AbpPermissionManagementResource);
    }

    [Inject] protected IPermissionAppService AppService { get; set; }
    [Inject] protected ICurrentApplicationConfigurationCacheResetService CurrentApplicationConfigurationCacheResetService { get; set; }

    [Inject] protected IOptions<AbpLocalizationOptions> LocalizationOptions { get; set; }

    protected bool GrantAll
    {
        get => NotGrantedPermissionCount == 0;
        set
        {
            if (Groups == null)
                return;

            NotGrantedPermissionCount = 0;

            foreach (var permission in
                     Groups
                         .SelectMany(x => x.Permissions)
                         .Where(u => !IsDisabledPermission(u)))
            {
                permission.IsGranted = value;
                if (!value)
                    NotGrantedPermissionCount++;
            }
        }
    }

    public virtual async Task OpenAsync(string providerName, string providerKey, string entityDisplayName = null)
    {
        try
        {
            ProviderName = providerName;
            ProviderKey = providerKey;

            var result = await AppService.GetAsync(ProviderName, ProviderKey);

            EntityDisplayName = entityDisplayName ?? result.EntityDisplayName;
            Groups = result.Groups;

            NotGrantedPermissionCount = 0;
            foreach (var permission in Groups.SelectMany(x => x.Permissions))
            {
                if (permission.IsGranted &&
                    permission.GrantedProviders.All(x => x.ProviderName != ProviderName))
                {
                    DisabledPermissions.Add(permission);
                    continue;
                }

                if (!permission.IsGranted)
                    NotGrantedPermissionCount++;
            }

            SelectedTabName = GetNormalizedGroupName(Groups.First().Name);

            ModalVisible = true;
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(ex);
        }
    }

    protected Task CloseModal()
    {
        return InvokeAsync(() => ModalVisible = false);
    }

    protected virtual async Task SaveAsync()
    {
        try
        {
            UpdateDto.Permissions = Groups
                .SelectMany(g => g.Permissions)
                .Select(p =>
                    new UpdatePermissionDto
                    {
                        IsGranted = p.IsGranted,
                        Name = p.Name
                    })
                .ToArray();

            if (!UpdateDto.Permissions.Any(x => x.IsGranted) &&
                !await Message.Confirm(L["SaveWithoutAnyPermissionsWarningMessage"]))
                return;

            await AppService.UpdateAsync(ProviderName, ProviderKey, UpdateDto);

            await CurrentApplicationConfigurationCacheResetService.ResetAsync();

            await CloseModal();
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(ex);
        }
    }

    protected virtual string GetNormalizedGroupName(string name)
    {
        return "PermissionGroup_" + name.Replace(".", "_");
    }

    protected virtual void GroupGrantAllChanged(bool value, PermissionGroupDto permissionGroup)
    {
        foreach (var permission in
                 permissionGroup
                     .Permissions
                     .Where(permission =>
                         !IsDisabledPermission(permission)))
            SetPermissionGrant(permission, value);
    }

    protected virtual void Changed(bool value, PermissionGroupDto permissionGroup, PermissionGrantInfoDto permission)
    {
        SetPermissionGrant(permission, value);

        if (!value)
        {
            var childPermissions = GetChildPermissions(permissionGroup, permission);

            foreach (var childPermission in childPermissions)
                SetPermissionGrant(childPermission, false);
        }
        else if (permission.ParentName != null)
        {
            var parentPermission = GetParentPermission(permissionGroup, permission);

            SetPermissionGrant(parentPermission, true);
        }
    }

    private void SetPermissionGrant(PermissionGrantInfoDto permission, bool value)
    {
        if (permission.IsGranted == value)
            return;

        if (value)
            NotGrantedPermissionCount--;
        else
            NotGrantedPermissionCount++;

        permission.IsGranted = value;
    }

    protected PermissionGrantInfoDto GetParentPermission(PermissionGroupDto permissionGroup, PermissionGrantInfoDto permission)
    {
        return permissionGroup
            .Permissions
            .First(x =>
                x.Name == permission.ParentName);
    }

    protected List<PermissionGrantInfoDto> GetChildPermissions(PermissionGroupDto permissionGroup, PermissionGrantInfoDto permission)
    {
        return permissionGroup
            .Permissions
            .Where(x =>
                x.Name.StartsWith(permission.Name))
            .ToList();
    }

    protected bool IsDisabledPermission(PermissionGrantInfoDto permissionGrantInfo)
    {
        return DisabledPermissions
            .Any(x => x == permissionGrantInfo);
    }

    protected virtual string GetShownName(PermissionGrantInfoDto permissionGrantInfo)
    {
        if (!IsDisabledPermission(permissionGrantInfo))
            return permissionGrantInfo.DisplayName;

        var providers = permissionGrantInfo.GrantedProviders
            .Where(p => p.ProviderName != ProviderName)
            .Select(p => p.ProviderName)
            .JoinAsString(", ");

        return $"{permissionGrantInfo.DisplayName} ({providers})";
    }
}