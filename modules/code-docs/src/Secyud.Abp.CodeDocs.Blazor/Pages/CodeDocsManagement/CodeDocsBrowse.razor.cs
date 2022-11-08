using System;
using Microsoft.AspNetCore.Components;
using SuperCreation.Abp.CodeDocs.Code;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SuperCreation.Abp.CodeDocs.Blazor.Pages
{
    public partial class CodeDocsBrowse
    {
        [Inject] public ICodeClassAppService CodeClassAppService { get; set; }
        protected List<CodeClassSelectDto> AllLinks { get; set; }

        protected override async Task OnInitializedAsync()
        {
            AllLinks = await CodeClassAppService.GetBrowseListAsync();
        }

        string GetClassLink(Guid id) => $"/code-docs/browse/{id}";
    }
}
