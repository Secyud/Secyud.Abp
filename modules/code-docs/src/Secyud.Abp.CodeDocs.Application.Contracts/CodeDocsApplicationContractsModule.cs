using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace SuperCreation.Abp.CodeDocs;

[DependsOn(
    typeof(CodeDocsDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class CodeDocsApplicationContractsModule : AbpModule
{

}
