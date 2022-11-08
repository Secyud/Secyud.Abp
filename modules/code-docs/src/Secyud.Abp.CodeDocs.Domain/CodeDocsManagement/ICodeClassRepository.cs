using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Secyud.Abp.CodeDocsManagement;

public interface ICodeClassRepository : IBasicRepository<CodeClass, Guid>
{
    
}
