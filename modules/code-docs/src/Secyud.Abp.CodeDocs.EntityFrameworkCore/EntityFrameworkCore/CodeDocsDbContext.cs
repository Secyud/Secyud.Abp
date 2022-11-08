using Microsoft.EntityFrameworkCore;
using Secyud.Abp.CodeDocsManagement;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Secyud.Abp.EntityFrameworkCore;

[ConnectionStringName(CodeDocsDbProperties.ConnectionStringName)]
public class CodeDocsDbContext : AbpDbContext<CodeDocsDbContext>, ICodeDocsDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public DbSet<CodeClass> CodeClass { get; set; }

    public DbSet<CodeFunction> CodeFunction { get; set; }

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
