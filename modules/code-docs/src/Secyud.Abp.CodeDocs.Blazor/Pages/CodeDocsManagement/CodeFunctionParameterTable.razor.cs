using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorComponent;
using Microsoft.AspNetCore.Components;
using Secyud.Abp.CodeDocsManagement;
using Volo.Abp.AspNetCore.Components.Web.Extensibility.EntityActions;

namespace Secyud.Abp.Pages.CodeDocsManagement;

public partial class CodeFunctionParameterTable
{
    protected readonly List<EntityAction> EntityActions = new();

    protected readonly List<DataTableHeader<FunctionParameterDto>> TableHeaders = new();

    protected bool AddModalVisible;

    protected FunctionParameterDto EntityAddDto = new();

    protected CodeFunctionDto FunctionDto;
    [Inject] public ICodeFunctionAppService CodeFunctionAppService { get; set; }

    [Parameter] public Guid CodeFunctionId { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await GetEntitiesAsync();
    }

    protected virtual ValueTask SetTableHeadersAsync()
    {
        TableHeaders.AddRange(new DataTableHeader<FunctionParameterDto>[]
        {
        });
        return ValueTask.CompletedTask;
    }

    protected virtual async Task GetEntitiesAsync()
    {
        FunctionDto = await CodeFunctionAppService.GetAsync(CodeFunctionId);
    }

    protected virtual async Task OnOpenAddModalAsync()
    {
        EntityAddDto = new FunctionParameterDto
        {
            FunctionId = CodeFunctionId
        };

        AddModalVisible = true;

        await Task.CompletedTask;
    }


    protected virtual async Task AddFunctionParameterAsync()
    {
        
    }

    protected virtual async Task RemoveFunctionParameterAsync(string name)
    {
        FunctionDto = await CodeFunctionAppService.RemoveParameterAsync(CodeFunctionId, name);
    }
}