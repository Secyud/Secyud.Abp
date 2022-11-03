using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SuperCreation.Abp.CodeDocs.Code;

public interface IClassParameterRepository : IRepository<ClassParameter>
{
    Task<List<ClassParameter>> GetListWithClassIdAsync(
         Guid classId,
         CancellationToken cancellationToken = default);

    Task<bool> CreateAsync(
        ClassParameter classParameter,
        CancellationToken cancellationToken = default);

    Task<bool> UpdateAsync(
    ClassParameter classParameter,
    CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(
        Guid classId,
        string name,
        CancellationToken cancellationToken = default);
}
