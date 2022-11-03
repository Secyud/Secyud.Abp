
using Microsoft.Extensions.Logging;
using SuperCreation.Abp.CodeDocs.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SuperCreation.Abp.CodeDocs.Code;

public class EfCoreCodeClassRepository :
    EfCoreRepository<ICodeDocsDbContext, CodeClass, Guid>,
    ICodeClassRepository
{
    private readonly ILogger<EfCoreCodeClassRepository> _logger;

    public EfCoreCodeClassRepository(IDbContextProvider<ICodeDocsDbContext> dbContextProvider, ILogger<EfCoreCodeClassRepository> logger) : base(dbContextProvider)
    {
        _logger = logger;
    }

    public async Task<bool> CreateAsync(
        CodeClass codeClass,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        Check.NotNull(codeClass, nameof(codeClass));

        await InsertAsync(codeClass, true, cancellationToken);

        return true;
    }

    public async Task<bool> UpdateAsync(
        CodeClass codeClass,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        Check.NotNull(codeClass, nameof(codeClass));
        try
        {
            await UpdateAsync(codeClass, true, cancellationToken);
        }
        catch (AbpDbConcurrencyException ex)
        {
            _logger.LogWarning(ex.ToString());
            return false;
        }

        return true;
    }
}
