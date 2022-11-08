using Microsoft.EntityFrameworkCore;
using Secyud.Abp.CodeDocsManagement;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Secyud.Abp.EntityFrameworkCore;

[ConnectionStringName(CodeDocsDbProperties.ConnectionStringName)]
public interface ICodeDocsDbContext: IEfCoreDbContext
{
    DbSet<CodeClass> CodeClass { get; }
    DbSet<CodeFunction> CodeFunction { get; }
}