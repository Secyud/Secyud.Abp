using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorComponent;
using Microsoft.AspNetCore.Authorization;
using Secyud.Abp.AspNetCore.Components.Web.Theming.PageToolbars;
using Secyud.Abp.Components.FeatureManagement;
using Volo.Abp.AspNetCore.Components.Web.Extensibility.EntityActions;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.Localization;

namespace Secyud.Abp.Pages.TenantManagement;

public partial class TenantManagement
{
    protected const string FeatureProviderName = "T";

    protected bool HasManageFeaturesPermission;
    protected readonly string ManageFeaturesPolicyName;

    protected FeatureManagementModal FeatureManagementModal;

    protected PageToolbar Toolbar { get; } = new();

    protected List<DataTableHeader<TenantDto>> TenantManagementTableHeaders => 
        TableHeaders.Get<TenantManagement>();
    
    protected List<EntityAction> TenantManagementEntityActions => 
        EntityActions.Get<TenantManagement>();

    private bool _createPasswordShow;

    public TenantManagement()
    {
        LocalizationResource = typeof(AbpTenantManagementResource);
        ObjectMapperContext = typeof(AbpTenantManagementBlazorModule);

        CreatePolicyName = TenantManagementPermissions.Tenants.Create;
        UpdatePolicyName = TenantManagementPermissions.Tenants.Update;
        DeletePolicyName = TenantManagementPermissions.Tenants.Delete;

        ManageFeaturesPolicyName = TenantManagementPermissions.Tenants.ManageFeatures;
    }

    protected override ValueTask SetBreadcrumbItemsAsync()
    {
        BreadcrumbItems.Add(new BreadcrumbItem {Text = L["Menu:TenantManagement"]});
        BreadcrumbItems.Add(new BreadcrumbItem {Text = L["Tenants"]});
        return base.SetBreadcrumbItemsAsync();
    }

    protected override async Task SetPermissionsAsync()
    {
        await base.SetPermissionsAsync();

        HasManageFeaturesPermission = await AuthorizationService.IsGrantedAsync(ManageFeaturesPolicyName);
    }

    protected override string GetDeleteConfirmationMessage(TenantDto entity)
    {
        return string.Format(L["TenantDeletionConfirmationMessage"], entity.Name);
    }

    protected override ValueTask SetToolbarItemsAsync()
    {
        Toolbar.AddButton(
            L["NewTenant"],
            OpenCreateModalAsync,
            "mdi-new-box",
            requiredPolicyName: CreatePolicyName);

        return base.SetToolbarItemsAsync();
    }

    protected override ValueTask SetEntityActionsAsync()
    {
        TenantManagementEntityActions
            .AddRange(new EntityAction[]
            {
                new()
                {
                    Text = L["Edit"],
                    Visible = _ => HasUpdatePermission,
                    Clicked = async (data) => { await OpenEditModalAsync(data.As<TenantDto>()); }
                },
                new()
                {
                    Text = L["Features"],
                    Visible = _ => HasManageFeaturesPermission,
                    Clicked = async (data) =>
                    {
                        var tenant = data.As<TenantDto>();
                        await FeatureManagementModal.OpenAsync(FeatureProviderName, tenant.Id.ToString());
                    }
                },
                new()
                {
                    Text = L["Delete"],
                    Visible = _ => HasDeletePermission,
                    Clicked = async (data) => await DeleteEntityAsync(data.As<TenantDto>()),
                    ConfirmationMessage = (data) => GetDeleteConfirmationMessage(data.As<TenantDto>())
                }
            });

        return base.SetEntityActionsAsync();
    }

    protected override ValueTask SetTableHeadersAsync()
    {
        TenantManagementTableHeaders
            .Add(new DataTableHeader<TenantDto>
            {
                Text = L["Actions"], 
                Value = "actions"
            });
        TenantManagementTableHeaders
            .Add(new DataTableHeader<TenantDto>
            {
                Text = L["TenantName"], 
                Value = "TenantName", 
                Sortable = true
            });
        
        // TODO(Secyud): add extension table columns.
        // TenantManagementTableHeaders.AddRange(GetExtensionTableColumns(
        //     TenantManagementModuleExtensionConsts.ModuleName,
        //     TenantManagementModuleExtensionConsts.EntityNames.Tenant));

        return base.SetTableHeadersAsync();
    }
}
