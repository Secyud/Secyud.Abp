using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SuperCreation.Abp.CodeDocs.Code;

public interface ICodeFunctionRepository : IRepository<CodeFunction, Guid>
{
    Task<List<CodeFunction>> GetListWithClassIdAsync(
          Guid classId,
          CancellationToken cancellationToken = default);

    Task<bool> CreateAsync(
           CodeFunction codeFunction,
           CancellationToken cancellationToken = default);

    Task<bool> UpdateAsync(
            CodeFunction codeFunction,
            CancellationToken cancellationToken = default);
}
