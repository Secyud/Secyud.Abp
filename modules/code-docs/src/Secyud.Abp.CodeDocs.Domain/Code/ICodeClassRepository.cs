using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SuperCreation.Abp.CodeDocs.Code;

public interface ICodeClassRepository : IRepository<CodeClass, Guid>
{
    Task<bool> CreateAsync(
           CodeClass codeClass,
           CancellationToken cancellationToken = default);

    Task<bool> UpdateAsync(
       CodeClass codeClass,
       CancellationToken cancellationToken = default);
}
