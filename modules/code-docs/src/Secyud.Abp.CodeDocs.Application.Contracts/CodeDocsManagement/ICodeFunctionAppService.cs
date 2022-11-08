using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
}
