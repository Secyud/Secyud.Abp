using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Secyud.Abp.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Secyud.Abp.CodeDocsManagement;

public class EfCoreCodeClassRepository :
    EfCoreRepository<ICodeDocsDbContext, CodeClass, Guid>,
    ICodeClassRepository
{
    public EfCoreCodeClassRepository(IDbContextProvider<ICodeDocsDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }

    public async Task<List<NameValue<Guid>>> GetNameValueListAsync(
        [CanBeNull] string name = null,
        [CanBeNull] bool? isVisible = null,
        [CanBeNull] string sorting = null,
        int skipCount = 0, 
        int maxResultCount = 2147483647,
        bool withDetails = false,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return
            (await (withDetails ? WithDetailsAsync() : GetQueryableAsync()))
            .ApplyFilter(name: name,isVisible:isVisible)
            .OrderBy(sorting.IsNullOrEmpty() ? nameof(CodeFunction.Name) : sorting)
            .PageBy(skipCount, maxResultCount)
            .Select(u=>new NameValue<Guid>(u.Name,u.Id))
            .ToList();
    }
}
