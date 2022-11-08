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
        CodeFunctionGetListInput,
        CodeFunctionCreateInput,
        CodeFunctionUpdateInput>
{
    Task<List<NameValue<Guid>>> GetNameValueListAsync(CodeFunctionGetListInput input);
    
    Task<List<CodeFunctionDto>> GetListWithDetailsAsync(CodeFunctionGetListInput input);
}
