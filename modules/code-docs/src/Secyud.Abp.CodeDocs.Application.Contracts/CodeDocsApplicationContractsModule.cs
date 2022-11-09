using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace Secyud.Abp;

[DependsOn(
    typeof(CodeDocsDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
)]
public class CodeDocsApplicationContractsModule : AbpModule
{
}