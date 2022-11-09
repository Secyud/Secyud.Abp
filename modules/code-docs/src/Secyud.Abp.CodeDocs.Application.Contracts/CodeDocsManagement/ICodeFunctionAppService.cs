using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace Secyud.Abp.CodeDocsManagement;

public interface ICodeFunctionAppService : 
    ICrudAppService<
        CodeFunctionDto,
        Guid,
        GetCodeFunctionListInput,
        CreateCodeFunctionInput,
        UpdateCodeFunctionInput>
{
    Task<List<NameValue<Guid>>> GetNameValueListAsync(GetCodeFunctionListInput input);
    
    Task<List<CodeFunctionDto>> GetListWithDetailsAsync(GetCodeFunctionListInput input);

    Task<CodeFunctionDto> AddParameterAsync(Guid id, string name, Guid typeId);

    Task<CodeFunctionDto> RemoveParameterAsync(Guid id, string name);
    
    Task<CodeFunctionDto> SetParameterAnnotationAsync(Guid id, string name, string annotation);
}
