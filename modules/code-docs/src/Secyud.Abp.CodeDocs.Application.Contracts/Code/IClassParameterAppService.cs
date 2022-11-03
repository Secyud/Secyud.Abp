using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SuperCreation.Abp.CodeDocs.Code;

public interface IClassParameterAppService : IApplicationService
{
    Task<List<ClassParameterDto>> GetAllWithClassIdAsync(Guid classId);
    Task<bool> CreateAsync(ClassParameterCreateUpdateDto input);
    Task<bool> UpdateAsync(ClassParameterCreateUpdateDto input);
    Task DeleteAsync(Guid classId, string name);
}
