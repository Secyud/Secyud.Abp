using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Secyud.Abp;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CodeDocsHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
)]
public class CodeDocsConsoleApiClientModule : AbpModule
{
}