using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SuperCreation.Abp.CodeDocs.Code;

public interface ICodeFunctionAppService : IApplicationService
{
    Task<List<CodeFunctionDto>> GetAllWithClassIdAsync(Guid classId);
    Task<CodeFunctionDto> GetWithDetailsAsync(Guid id);
    Task<bool> CreateAsync(CodeFunctionCreateUpdateDto input);
    Task<bool> UpdateAsync(CodeFunctionCreateUpdateDto input);
    Task DeleteAsync(Guid id);
}
