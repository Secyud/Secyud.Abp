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

public class EfCoreFunctionParameterRepository :
    EfCoreRepository<ICodeDocsDbContext, FunctionParameter>,
    IFunctionParameterRepository
{
    private readonly ILogger<EfCoreFunctionParameterRepository> _logger;
    public EfCoreFunctionParameterRepository(
        IDbContextProvider<ICodeDocsDbContext> dbContextProvider,
        ILogger<EfCoreFunctionParameterRepository> logger) : base(dbContextProvider)
    {
        _logger = logger;
    }

    public async Task<List<FunctionParameter>> GetListWithFunctionIdAsync(
        Guid functionId,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        IQueryable<FunctionParameter> query =
            await WithDetailsAsync(u => u.Type);

        return query
            .Where(u => u.FunctionId == functionId)
            .OrderBy(u => u.Name)
            .ToList();
    }

    public async Task<bool> CreateAsync(
        FunctionParameter functionParameter,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        Check.NotNull(functionParameter, nameof(functionParameter));

        await InsertAsync(functionParameter, true, cancellationToken);

        return true;
    }

    public async Task<bool> UpdateAsync(
        FunctionParameter functionParameter,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        Check.NotNull(functionParameter, nameof(functionParameter));
        try
        {
            await UpdateAsync(functionParameter, true, cancellationToken);
        }
        catch (AbpDbConcurrencyException ex)
        {
            _logger.LogWarning(ex.ToString());
            return false;
        }

        return true;
    }

    public async Task<bool> DeleteAsync(
        Guid functionId,
        string name,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        Check.NotNull(name, nameof(name));
        try
        {
            await DeleteAsync(
                await GetAsync(u => u.FunctionId == functionId && u.Name == name),
                true, cancellationToken);
        }
        catch (AbpDbConcurrencyException ex)
        {
            _logger.LogWarning(ex.ToString());
            return false;
        }
        return true;
    }
}
