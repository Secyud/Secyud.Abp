using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Secyud.Abp;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(CodeDocsDomainSharedModule)
)]
public class CodeDocsDomainModule : AbpModule
{
}