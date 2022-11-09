using Volo.Abp.Modularity;

namespace Secyud.Abp;

[DependsOn(
    typeof(CodeDocsApplicationModule),
    typeof(CodeDocsDomainTestModule)
)]
public class CodeDocsApplicationTestModule : AbpModule
{
}