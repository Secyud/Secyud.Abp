using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace MasaDemoApp.EntityFrameworkCore;

[DependsOn(
    typeof(MasaDemoAppDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class MasaDemoAppEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<MasaDemoAppDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
        });
    }
}
