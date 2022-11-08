using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Secyud.Abp.CodeDocsManagement;

public sealed class CodeClass : FullAuditedAggregateRoot<Guid>
{
    [NotNull] public string Name { get; set; } = "";
    public string Description { get; set; }
    public string Annotation { get; set; }
    public Guid ParentId { get; set; }
    public bool IsVisible { get; set; }
    
    public List<ClassParameter> Parameters { get; set; }
    
    private CodeClass()
    {
    }
    
    public CodeClass(Guid id, string name, string description, string annotation, Guid parentId, bool isVisible)
    {
        Check.NotNull(name, nameof(name));
        Id = id;
        Name = name;
        Description = description;
        Annotation = annotation;
        ParentId = parentId;
        IsVisible = isVisible;
        Parameters = new List<ClassParameter>();
    }
}
