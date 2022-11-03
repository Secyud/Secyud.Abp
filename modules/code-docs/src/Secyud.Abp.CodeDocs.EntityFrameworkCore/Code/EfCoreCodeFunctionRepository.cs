
using Microsoft.Extensions.Logging;
using SuperCreation.Abp.CodeDocs.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SuperCreation.Abp.CodeDocs.Code;

public class EfCoreCodeFunctionRepository :
    EfCoreRepository<ICodeDocsDbContext, CodeFunction, Guid>,
    ICodeFunctionRepository
{
    private readonly ILogger<EfCoreCodeFunctionRepository> _logger;

    public EfCoreCodeFunctionRepository(IDbContextProvider<ICodeDocsDbContext> dbContextProvider, ILogger<EfCoreCodeFunctionRepository> logger) : base(dbContextProvider)
    {
        _logger = logger;
    }
    public async Task<List<CodeFunction>> GetListWithClassIdAsync(
       Guid classId,
       CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        IQueryable<CodeFunction> query = await WithDetailsAsync(u=>u.Return);
        return query
            .Where(u => u.ClassId == classId)
            .OrderBy(u => u.Name)
            .ToList();
    }

    public async Task<bool> CreateAsync(
        CodeFunction codeFunction,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        Check.NotNull(codeFunction, nameof(codeFunction));

        await InsertAsync(codeFunction, true, cancellationToken);

        return true;
    }

    public async Task<bool> UpdateAsync(
        CodeFunction codeFunction,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        Check.NotNull(codeFunction, nameof(codeFunction));
        try
        {
            await UpdateAsync(codeFunction, true, cancellationToken);
        }
        catch (AbpDbConcurrencyException ex)
        {
            _logger.LogWarning(ex.ToString());
            return false;
        }

        return true;
    }
}
