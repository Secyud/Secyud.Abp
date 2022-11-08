using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorComponent;
using Microsoft.AspNetCore.Components;
using Secyud.Abp.AspNetCore.Components.Web.Theming.PageToolbars;
using Secyud.Abp.CodeDocsManagement;
using Secyud.Abp.Localization;
using Secyud.Abp.Permissions;
using Volo.Abp;
using Volo.Abp.AspNetCore.Components.Web.Extensibility.EntityActions;

namespace Secyud.Abp.Pages.CodeDocsManagement;

public partial class CodeFunctionComponent
{
    [Inject] protected ICodeClassAppService CodeClassAppService { get; set; }
    
    [Parameter] public Guid CodeClassId { get; set; }

    protected readonly PageToolbar Toolbar = new();
    
    protected List<DataTableHeader<CodeFunctionDto>> CodeFunctionHeaders => TableHeaders.Get<CodeFunctionDto>();
    protected List<EntityAction> CodeFunctionEntityActions => EntityActions.Get<CodeClassPage>();

    protected List<NameValue<Guid>> CodeClassNameValueList;
    
    public CodeFunctionComponent()
    {
        LocalizationResource = typeof(CodeDocsResource);

        CreatePolicyName = CodeDocsPermissions.CodeFunction.Create;
        UpdatePolicyName = CodeDocsPermissions.CodeFunction.Update;
        DeletePolicyName = CodeDocsPermissions.CodeFunction.Delete;
        
    }

    protected override async Task OnInitializedAsync()
    {
        GetListInput.ClassId = CodeClassId;
        
        CodeClassNameValueList = await CodeClassAppService.GetNameValueListAsync(new CodeClassGetListInput()
        {
            MaxResultCount = int.MaxValue
        });
        
        await base.OnInitializedAsync();
    }

    protected override ValueTask SetTableHeadersAsync()
    {
        CodeFunctionHeaders.AddRange(new DataTableHeader<CodeFunctionDto>[]
        {
            new() { Text = L["Name"], Sortable = true, Value = nameof(CodeFunctionDto.Name), Filterable = true },
            new() { Text = L["Return"], Sortable = true, Value = nameof(CodeFunctionDto.ReturnId) },
            new() { Text = L["Annotation"], Sortable = true, Value = nameof(CodeFunctionDto.Annotation) },
            new() { Text = L["IsStatic"], Value = nameof(CodeFunctionDto.IsStatic) },
            new() { Text = L["IsVirtual"], Value = nameof(CodeFunctionDto.IsVirtual) },
            new() { Text = "Actions", Value = ActionColName }
        });

        return base.SetTableHeadersAsync();
    }

    protected override ValueTask SetEntityActionsAsync()
    {
        CodeFunctionEntityActions.AddRange(new EntityAction[]
        {
            new() 
            { 
                Text = L["Update"] ,
                Icon = "mdi-pencil", 
                Clicked = obj => OpenEditModalAsync(obj as CodeFunctionDto),
                Visible = _ => HasUpdatePermission
            },
            new()
            {
                Text = L["Delete"],
                Icon = "mdi-delete",
                Clicked = obj => DeleteEntityAsync(obj as CodeFunctionDto),
                Visible = _ => HasDeletePermission,
                ConfirmationMessage = _ => L["DeleteCodeFunctionConfirmationMessage"]
            },
        });
        return base.SetEntityActionsAsync();
    }
    
    protected override ValueTask SetToolbarItemsAsync()
    {
        Toolbar.AddButton(
            text: L["NewEntity"],
            onclick: OpenCreateModalAsync,
            icon: "mdi-new-box",
            requiredPolicyName: CreatePolicyName);
        return base.SetToolbarItemsAsync();
    }
}