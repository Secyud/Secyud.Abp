using System;
using Volo.Abp.Application.Dtos;

namespace SuperCreation.Abp.CodeDocs.Code
{
    public class CodeClassSelectDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
