using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;

namespace Secyud.Abp.CodeDocsManagement;

public interface ICodeClassRepository : IBasicRepository<CodeClass, Guid>
{
    Task<List<NameValue<Guid>>> GetNameValueListAsync(
        string name = null,
        bool? isVisible = null,
        string sorting = null,
        int skipCount = 0,
        int maxResultCount = int.MaxValue,
        bool withDetails = false,
        CancellationToken cancellationToken = default);
}