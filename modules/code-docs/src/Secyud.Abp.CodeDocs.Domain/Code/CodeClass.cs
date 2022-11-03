using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace SuperCreation.Abp.CodeDocs.Code;

public sealed class CodeClass : AuditedAggregateRoot<Guid>
{
    [NotNull]
    public string Name { get; set; } = "";

    public string Description { get; set; }

    public string Annotation { get; set; }

    public Guid? ParentId { get; set; }
    public CodeClass Parent { get; set; }
    public bool IsVisible { get; set; }
    public List<ClassParameter> Parameters { get; set; }
    public List<CodeFunction> Functions { get; set; }
    public CodeClass()
    {
    }
    public CodeClass(Guid id, string name, string description, string annotation, Guid? parentId, bool isVisible)
    {
        Check.NotNull(name, nameof(name));
        Id = id;
        Name = name;
        Description = description;
        Annotation = annotation;
        ParentId = parentId;
        IsVisible = isVisible;
        Parameters = new();
        Functions = new();
    }
}
