using System;
using Volo.Abp.Application.Dtos;

namespace SuperCreation.Abp.CodeDocs.Code;

public class CodeClassLookupDto : EntityDto<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Annotation { get; set; }
    public Guid? ParentId { get; set; }
    public string ParentName { get; set; }
    public bool IsVisible { get; set; }
}
