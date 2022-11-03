using Microsoft.EntityFrameworkCore;
using SuperCreation.Abp.CodeDocs.Code;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace SuperCreation.Abp.CodeDocs.EntityFrameworkCore;

[ConnectionStringName(CodeDocsDbProperties.ConnectionStringName)]
public class CodeDocsDbContext : AbpDbContext<CodeDocsDbContext>, ICodeDocsDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public DbSet<CodeClass> CodeClass { get; set; }

    public DbSet<ClassParameter> ClassParameter { get; set; }

    public DbSet<CodeFunction> CodeFunction { get; set; }

    public DbSet<FunctionParameter> FunctionParameter { get; set; }

    public CodeDocsDbContext(DbContextOptions<CodeDocsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureCodeDocs();
    }
}
