using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace MasaDemoApp;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(MasaDemoAppDomainSharedModule)
)]
public class MasaDemoAppDomainModule : AbpModule
{

}
