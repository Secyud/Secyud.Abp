using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace Secyud.Abp.CodeDocsManagement;

public interface ICodeClassAppService :
    ICrudAppService<
        CodeClassDto,
        Guid,
        GetCodeClassListInput,
        CreateCodeClassInput,
        UpdateCodeClassInput>
{
    Task<List<NameValue<Guid>>> GetNameValueListAsync(GetCodeClassListInput input);

    Task<CodeClassDto> AddParameterAsync(Guid id, string name, Guid typeId);

    Task<CodeClassDto> RemoveParameterAsync(Guid id, string name);

    Task<CodeClassDto> SetParameterAnnotationAsync(Guid id, string name, string annotation);

    Task<CodeClassDto> SetParameterPublicAsync(Guid id, string name);

    Task<CodeClassDto> SetParameterPrivateAsync(Guid id, string name);
}