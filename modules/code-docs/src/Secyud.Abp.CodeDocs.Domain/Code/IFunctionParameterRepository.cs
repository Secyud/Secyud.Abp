using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SuperCreation.Abp.CodeDocs.Code;

public interface IFunctionParameterRepository : IRepository<FunctionParameter>
{
    Task<List<FunctionParameter>> GetListWithFunctionIdAsync(
            Guid functionId,
            CancellationToken cancellationToken = default);

    Task<bool> CreateAsync(
           FunctionParameter functionParameter,
           CancellationToken cancellationToken = default);

    Task<bool> UpdateAsync(
           FunctionParameter functionParameter,
           CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(
        Guid functionId,
        string name,
        CancellationToken cancellationToken = default);
}
