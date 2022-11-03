using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SuperCreation.Abp.CodeDocs.Code;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.DependencyInjection;
using Volo.Abp.Modularity;

namespace SuperCreation.Abp.CodeDocs.EntityFrameworkCore;

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
            options.AddDefaultRepositories<ICodeDocsDbContext>();
            options.AddRepository<CodeClass, EfCoreCodeClassRepository>();
            options.AddRepository<CodeFunction, EfCoreCodeFunctionRepository>();
            options.AddRepository<ClassParameter, EfCoreClassParameterRepository>();
            options.AddRepository<FunctionParameter, EfCoreFunctionParameterRepository>();
        });
        Configure<AbpEntityOptions>(options =>
        {
            options.Entity<CodeClass>(orderOptions =>
            {
                orderOptions.DefaultWithDetailsFunc = query => query.Include(o => o.Parent);
            });

            options.Entity<CodeFunction>(orderOptions =>
            {
                orderOptions.DefaultWithDetailsFunc = query => query.Include(o => o.Return).Include(o => o.Parameters);
            });

            options.Entity<FunctionParameter>(orderOptions =>
            {
                orderOptions.DefaultWithDetailsFunc = query => query.Include(o => o.Type);
            });

            options.Entity<ClassParameter>(orderOptions =>
            {
                orderOptions.DefaultWithDetailsFunc = query => query.Include(o => o.Type);
            });
        });
    }
}
