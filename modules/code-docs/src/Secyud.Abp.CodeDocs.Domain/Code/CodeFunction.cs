using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace SuperCreation.Abp.CodeDocs.Code;

public sealed class CodeFunction : AggregateRoot<Guid>
{
    [NotNull] public string Name { get; set; } = "";
    public string Annotation { get; set; }
    public Guid ClassId { get; set; }
    public Guid? ReturnId { get; set; }
    public CodeClass Return { get; set; }
    public bool IsStatic { get; set; }
    public bool IsVirtual { get; set; }

    public List<FunctionParameter> Parameters { get; set; }
    public CodeFunction()
    {

    }

    public CodeFunction(
        Guid id,
        string name, string annotation, Guid classId,
        Guid? returnId, bool isStatic, bool isVirtual)
    {
        Check.NotNull(name, nameof(name));
        Id = id;
        Name = name;
        Annotation = annotation;
        ClassId = classId;
        ReturnId = returnId;
        IsStatic = isStatic;
        IsVirtual = isVirtual;
        Parameters = new();
    }
}