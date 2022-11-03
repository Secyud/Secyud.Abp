using Microsoft.AspNetCore.Components;
using SuperCreation.Abp.CodeDocs.Code;
using System;
using System.Threading.Tasks;


namespace SuperCreation.Abp.CodeDocs.Blazor.Pages;

public partial class CodeDocsBrowseClass
{
    [Inject] public ICodeClassAppService CodeClassAppService { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }

    [Parameter] public Guid Id { get; set; }
    protected CodeClassDto CodeClassDto { get; set; }
    protected override async Task OnInitializedAsync()
    {
        CodeClassDto = await CodeClassAppService.GetWithDetailsAsync(Id);
    }
    void NavigateTo(Guid id) => NavigationManager.NavigateTo($"code-docs/browse/{id}",true);
}

