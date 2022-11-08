using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Secyud.Abp.CodeDocsManagement;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.DependencyInjection;
using Volo.Abp.Modularity;

namespace Secyud.Abp.EntityFrameworkCore;

[DependsOn(
    typeof(CodeDocsDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class CodeDocsEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<CodeDocsDbContext>(options =>
        {
            options.AddRepository<CodeClass, EfCoreCodeClassRepository>();
            options.AddRepository<CodeFunction, EfCoreCodeFunctionRepository>();
            options.AddDefaultRepositories<ICodeDocsDbContext>();
        });
        Configure<AbpEntityOptions>(options =>
        {
            options.Entity<CodeClass>(orderOptions =>
            {
                orderOptions.DefaultWithDetailsFunc = query => query
                    .Include(u => u.Parameters);
            });

            options.Entity<CodeFunction>(orderOptions =>
            {
                orderOptions.DefaultWithDetailsFunc = query => query
                    .Include(u => u.Parameters);
            });
        });
    }
}
