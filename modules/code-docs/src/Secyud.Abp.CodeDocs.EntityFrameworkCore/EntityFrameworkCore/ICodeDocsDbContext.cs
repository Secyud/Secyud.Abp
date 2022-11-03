using Microsoft.EntityFrameworkCore;
using SuperCreation.Abp.CodeDocs.Code;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace SuperCreation.Abp.CodeDocs.EntityFrameworkCore;

[ConnectionStringName(CodeDocsDbProperties.ConnectionStringName)]
public interface ICodeDocsDbContext: IEfCoreDbContext
{
    DbSet<CodeClass> CodeClass { get; set; }

    DbSet<ClassParameter> ClassParameter { get; set; }

    DbSet<CodeFunction> CodeFunction { get; set; }

    DbSet<FunctionParameter> FunctionParameter { get; set; }
}