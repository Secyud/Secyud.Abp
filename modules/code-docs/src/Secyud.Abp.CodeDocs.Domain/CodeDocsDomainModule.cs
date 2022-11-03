using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace SuperCreation.Abp.CodeDocs;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(CodeDocsDomainSharedModule)
)]
public class CodeDocsDomainModule : AbpModule
{

}
