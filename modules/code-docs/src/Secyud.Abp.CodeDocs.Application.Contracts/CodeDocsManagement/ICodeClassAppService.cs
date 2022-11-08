using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Secyud.Abp.CodeDocsManagement;

public interface ICodeClassAppService :
    ICrudAppService<
        CodeClassDto,
        Guid,
        CodeClassGetListInput,
        CodeClassCreateInput,
        CodeClassUpdateInput>
{
    Task<List<NameValue<Guid>>> GetNameValueListAsync(CodeClassGetListInput input);
}
