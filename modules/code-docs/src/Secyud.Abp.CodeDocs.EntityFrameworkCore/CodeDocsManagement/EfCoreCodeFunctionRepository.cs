﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Secyud.Abp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Secyud.Abp.CodeDocsManagement;

public class EfCoreCodeFunctionRepository :
    EfCoreRepository<ICodeDocsDbContext, CodeFunction, Guid>,
    ICodeFunctionRepository
{
    public EfCoreCodeFunctionRepository(IDbContextProvider<ICodeDocsDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }

    public virtual async Task<List<CodeFunction>> GetListAsync(
        string name = null,
        Guid classId = default,
        string sorting = null,
        int skipCount = 0,
        int maxResultCount = int.MaxValue,
        bool withDetails = false,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return
            (await (withDetails ? WithDetailsAsync() : GetQueryableAsync()))
            .ApplyFilter(name: name, classId: classId)
            .OrderBy(sorting.IsNullOrEmpty() ? nameof(CodeFunction.Name) : sorting)
            .PageBy(skipCount, maxResultCount)
            .ToList();
    }
}