using System;
using Secyud.Abp.EntityFrameworkCore;
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
}
