using System;
using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Modularity;
using Xunit;

namespace Secyud.Abp.CodeDocsManagement;

/* Write your custom repository tests like that, in this project, as abstract classes.
 * Then inherit these abstract classes from EF Core & MongoDB test projects.
 * In this way, both database providers are tests with the same set tests.
 */
public abstract class CodeClassRepository_Tests<TStartupModule> : CodeDocsTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly ICodeClassRepository _codeClassRepository;

    protected CodeClassRepository_Tests()
    {
        _codeClassRepository = GetRequiredService<ICodeClassRepository>();
    }

    [Fact]
    public async Task CreateAsync()
    {
        var entity = await _codeClassRepository.InsertAsync(new CodeClass(Guid.NewGuid(),"test class","this is a test class","test class annotation",Guid.Empty, true));
        
        
        entity.Name.ShouldBe("test class");
        entity.Annotation.ShouldBe("test class annotation");
        entity.Description.ShouldBe("this is a test class");
    }
}
