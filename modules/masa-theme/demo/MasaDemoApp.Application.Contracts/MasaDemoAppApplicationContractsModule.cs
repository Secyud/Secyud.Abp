using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace MasaDemoApp;

[DependsOn(
    typeof(MasaDemoAppDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class MasaDemoAppApplicationContractsModule : AbpModule
{

}
