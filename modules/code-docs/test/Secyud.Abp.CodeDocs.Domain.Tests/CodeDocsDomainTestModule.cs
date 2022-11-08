using Secyud.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Secyud.Abp;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(CodeDocsEntityFrameworkCoreTestModule)
    )]
public class CodeDocsDomainTestModule : AbpModule
{

}
