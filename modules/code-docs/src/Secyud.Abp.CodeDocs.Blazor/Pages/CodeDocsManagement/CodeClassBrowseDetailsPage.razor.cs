using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Secyud.Abp.CodeDocsManagement;
using Volo.Abp;

namespace Secyud.Abp.Pages.CodeDocsManagement;

public partial class CodeClassBrowseDetailsPage
{
    [Inject] protected ICodeClassAppService AppService { get; set; }
    [Inject] protected ICodeFunctionAppService CodeFunctionAppService { get; set; }
    
    [Parameter] public Guid CodeClassId { get; set; }

    protected CodeClassDto CodeClassWithDetails;
    protected CodeClassDto CodeClassParent;
    protected List<CodeFunctionDto> CodeFunctionsWithDetails;
    protected List<NameValue<Guid>> CodeClassNameValueList;

    protected override async Task OnInitializedAsync()
    {
        CodeClassNameValueList = await AppService.GetNameValueListAsync(new()
        {
            MaxResultCount = int.MaxValue
        });
        
        CodeClassWithDetails = await AppService.GetAsync(CodeClassId);
        
        if (CodeClassWithDetails is not null && CodeClassWithDetails.ParentId != default)
            CodeClassParent = await AppService.GetAsync(CodeClassWithDetails.ParentId);
        
        CodeFunctionsWithDetails = await CodeFunctionAppService.GetListWithDetailsAsync(new()
        {
            MaxResultCount = int.MaxValue,
            ClassId = CodeClassId
        });
    }

    protected string NavUrl(Guid codeClassId) => $"code-docs/browse/{codeClassId}";
}