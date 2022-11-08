using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;

namespace Secyud.Abp.CodeDocsManagement;

public interface ICodeFunctionRepository : IBasicRepository<CodeFunction, Guid>
{
    Task<List<CodeFunction>> GetListAsync(
        string name = null,
        Guid classId = default,
        string sorting = null,
        int skipCount = 0,
        int maxResultCount = int.MaxValue,
        bool withDetails = false,
        CancellationToken cancellationToken = default);
    
    
    Task<List<NameValue<Guid>>> GetNameValueListAsync(
        string name = null,
        Guid classId = default,
        string sorting = null,
        int skipCount = 0,
        int maxResultCount = int.MaxValue,
        bool withDetails = false,
        CancellationToken cancellationToken = default);
}
