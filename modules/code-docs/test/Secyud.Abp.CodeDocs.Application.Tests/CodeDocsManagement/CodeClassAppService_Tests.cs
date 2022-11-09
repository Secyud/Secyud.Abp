using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Secyud.Abp.CodeDocsManagement;

public class CodeClassAppService_Tests : CodeDocsApplicationTestBase
{
    private readonly ICodeClassAppService _codeClassAppService;

    public CodeClassAppService_Tests()
    {
        _codeClassAppService = GetRequiredService<ICodeClassAppService>();
    }

    [Fact]
    public async Task CreateAsync()
    {
        var entityDto = await _codeClassAppService.CreateAsync(new CreateCodeClassInput
        {
            Name = "test class",
            Annotation = "test class annotation",
            Description = "this is a test class"
        });


        entityDto.Name.ShouldBe("test class");
        entityDto.Annotation.ShouldBe("test class annotation");
        entityDto.Description.ShouldBe("this is a test class");
    }
}