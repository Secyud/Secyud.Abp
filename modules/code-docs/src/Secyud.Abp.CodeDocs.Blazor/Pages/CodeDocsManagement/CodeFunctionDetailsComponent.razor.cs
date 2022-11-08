using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorComponent;
using Microsoft.AspNetCore.Components;
using Secyud.Abp.CodeDocsManagement;

namespace Secyud.Abp.Pages.CodeDocsManagement;

public partial class CodeFunctionDetailsComponent
{
    [Inject] public ICodeFunctionAppService CodeFunctionAppService { get; set; }
    
    [Parameter] public Guid CodeFunctionId { get; set; }
    
    
    
    protected FunctionParameterDto EntityAddDto;
    protected bool AddModalVisible;

}
