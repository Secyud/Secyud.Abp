using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SuperCreation.Abp.CodeDocs.Code;

public interface IFunctionParameterAppService : IApplicationService
{
    Task<List<FunctionParameterDto>> GetAllWithFunctionIdAsync(Guid functionId);
    Task<bool> CreateAsync(FunctionParameterCreateUpdateDto input);
    Task<bool> UpdateAsync(FunctionParameterCreateUpdateDto input);
    Task DeleteAsync(Guid functionId, string name);
}
