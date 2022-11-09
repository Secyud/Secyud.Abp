using Secyud.Abp.CodeDocsManagement;
using Xunit;

namespace Secyud.Abp.MongoDB.CodeDocsManagement;

[Collection(MongoTestCollection.Name)]
public class CodeClassRepositoryTests : CodeClassRepository_Tests<CodeDocsMongoDbTestModule>
{
    /* Don't write custom repository tests here, instead write to
     * the base class.
     * One exception can be some specific tests related to MongoDB.
     */
}