using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorComponent;
using Microsoft.AspNetCore.Components.Web;
using Secyud.Abp.AspNetCore.Components.Web.Theming.PageToolbars;
using Secyud.Abp.CodeDocsManagement;
using Secyud.Abp.Localization;
using Secyud.Abp.MasaBlazorUi.Components;
using Secyud.Abp.Permissions;
using Volo.Abp;
using Volo.Abp.AspNetCore.Components.Web.Extensibility.EntityActions;

namespace Secyud.Abp.Pages.CodeDocsManagement;

public partial class CodeClassPage
{
    protected readonly PageToolbar Toolbar = new();

    protected List<NameValue<Guid>> CodeClassSelectList;

    public CodeClassPage()
    {
        LocalizationResource = typeof(CodeDocsResource);

        CreatePolicyName = CodeDocsPermissions.CodeClass.Create;
        UpdatePolicyName = CodeDocsPermissions.CodeClass.Update;
        DeletePolicyName = CodeDocsPermissions.CodeClass.Delete;
    }

    protected List<DataTableHeader<CodeClassDto>> CodeClassHeaders => TableHeaders.Get<CodeClassPage>();
    protected List<EntityAction> CodeClassEntityActions => EntityActions.Get<CodeClassPage>();

    protected override async Task GetEntitiesAsync()
    {
        CodeClassSelectList = await AppService.GetNameValueListAsync(new GetCodeClassListInput
        {
            MaxResultCount = int.MaxValue
        });
        await base.GetEntitiesAsync();
    }

    protected override ValueTask SetBreadcrumbItemsAsync()
    {
        BreadcrumbItems.AddRange(new BreadcrumbItem[]
        {
            new() { Text = L["CodeDocs"] },
            new() { Text = L["CodeClass"] }
        });

        return base.SetBreadcrumbItemsAsync();
    }

    protected override ValueTask SetTableHeadersAsync()
    {
        CodeClassHeaders.AddRange(new DataTableHeader<CodeClassDto>[]
        {
            new() { Text = L["Name"], Sortable = true, Value = nameof(CodeClassDto.Name), Filterable = true },
            new() { Text = L["Parent"], Sortable = true, Value = nameof(CodeClassDto.ParentId) },
            new() { Text = L["Description"], Sortable = true, Value = nameof(CodeClassDto.Description) },
            new() { Text = L["Annotation"], Sortable = true, Value = nameof(CodeClassDto.Annotation) },
            new() { Text = L["IsVisible"], Value = nameof(CodeClassDto.IsVisible) },
            new() { Text = "Actions", Value = ActionColName }
        });

        return base.SetTableHeadersAsync();
    }

    protected override ValueTask SetEntityActionsAsync()
    {
        CodeClassEntityActions.AddRange(new EntityAction[]
        {
            new()
            {
                Text = L["Update"],
                Icon = IconName.Update,
                Clicked = obj => OpenEditModalAsync(obj as CodeClassDto),
                Visible = _ => HasUpdatePermission
            },
            new()
            {
                Text = L["Delete"],
                Icon = IconName.Delete,
                Clicked = obj => DeleteEntityAsync(obj as CodeClassDto),
                Visible = _ => HasDeletePermission,
                ConfirmationMessage = _ => L["DeleteCodeClassConfirmationMessage"]
            }
        });
        return base.SetEntityActionsAsync();
    }

    protected override ValueTask SetToolbarItemsAsync()
    {
        Toolbar.AddButton(
            L["NewEntity"],
            OpenCreateModalAsync,
            IconName.Create,
            requiredPolicyName: CreatePolicyName);
        return base.SetToolbarItemsAsync();
    }

    protected virtual async Task OnSearchEnter(KeyboardEventArgs e)
    {
        if (e.Code is "Enter" or "NumpadEnter") await GetEntitiesAsync();
    }
}