using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Secyud.Abp.CodeDocsManagement;

public sealed class CodeFunction : AuditedAggregateRoot<Guid>
{
    private CodeFunction()
    {
    }

    public CodeFunction(
        Guid id,
        string name, string annotation, Guid classId,
        Guid returnId, bool isStatic, bool isVirtual)
    {
        Check.NotNull(name, nameof(name));
        Id = id;
        Name = name;
        Annotation = annotation;
        ClassId = classId;
        ReturnId = returnId;
        IsStatic = isStatic;
        IsVirtual = isVirtual;
        Parameters = new List<FunctionParameter>();
    }

    [NotNull] public string Name { get; set; }
    public string Annotation { get; set; }
    public Guid ClassId { get; set; }
    public Guid ReturnId { get; set; }
    public bool IsStatic { get; set; }
    public bool IsVirtual { get; set; }

    public List<FunctionParameter> Parameters { get; set; }

    public void AddParameter(string name, Guid type)
    {
        if (Parameters.Any(u => u.Name == name))
            throw new UserFriendlyException("Parameters' name in class shouldn't be repeated! ");

        Parameters.Add(new FunctionParameter(Id, name, type));
    }

    public FunctionParameter GetParameter(string name)
    {
        return Parameters.Find(u => u.Name == name);
    }

    public void RemoveParameter(string name)
    {
        var parameter = Parameters
            .Find(u => u.Name == name);
        Parameters.Remove(parameter);
    }

    public void UpdateParameter(string name, string annotation)
    {
        var parameter = Parameters
            .Find(u => u.Name == name);

        parameter.Annotation = annotation;
    }
}