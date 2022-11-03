
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

public class EfCoreClassParameterRepository :
    EfCoreRepository<ICodeDocsDbContext, ClassParameter>,
    IClassParameterRepository
{
    readonly ILogger<EfCoreClassParameterRepository> _logger;
    public EfCoreClassParameterRepository(IDbContextProvider<ICodeDocsDbContext> dbContextProvider, ILogger<EfCoreClassParameterRepository> logger) : base(dbContextProvider)
    {
        _logger = logger;
    }

    public async Task<bool> CreateAsync(ClassParameter classParameter, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        Check.NotNull(classParameter, nameof(classParameter));

        await InsertAsync(classParameter, true, cancellationToken);

        return true;
    }

    public async Task<bool> DeleteAsync(Guid classId, string name, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        Check.NotNull(name, nameof(name));
        try
        {
            await DeleteAsync(
                await GetAsync(u => u.ClassId == classId && u.Name == name, cancellationToken: cancellationToken),
                true, cancellationToken);
        }
        catch (AbpDbConcurrencyException ex)
        {
            _logger.LogWarning(ex.ToString());
            return false;
        }
        return true;
    }

    public async Task<List<ClassParameter>> GetListWithClassIdAsync(Guid classId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        IQueryable<ClassParameter> query =
            await WithDetailsAsync(u => u.Type);

        return query
            .Where(u => u.ClassId == classId)
            .OrderBy(u => u.Name)
            .ToList();
    }

    public async Task<bool> UpdateAsync(ClassParameter classParameter, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        Check.NotNull(classParameter, nameof(classParameter));
        try
        {
            await UpdateAsync(classParameter, true, cancellationToken);
        }
        catch (AbpDbConcurrencyException ex)
        {
            _logger.LogWarning(ex.ToString()); //Trigger some AbpHandledException event
            return false;
        }

        return true;
    }
}
