using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Secyud.Abp.CodeDocsManagement;

public class ClassParameter : Entity
{
    private ClassParameter()
    {
    }

    public ClassParameter(
        Guid classId,
        string name,
        Guid typeId)
    {
        Check.NotNull(name, nameof(name));
        Name = name;
        ClassId = classId;
        TypeId = typeId;
    }

    public Guid ClassId { get; }
    [NotNull] public string Name { get; }
    public Guid TypeId { get; }
    public string Annotation { get; private set; }
    public bool IsPublic { get; private set; }

    public override object[] GetKeys()
    {
        return new object[] { ClassId, Name };
    }

    public void SetAnnotation(string annotation)
    {
        Annotation = annotation;
    }

    public void SetPrivate()
    {
        IsPublic = false;
    }

    public void SetPublic()
    {
        IsPublic = true;
    }
}