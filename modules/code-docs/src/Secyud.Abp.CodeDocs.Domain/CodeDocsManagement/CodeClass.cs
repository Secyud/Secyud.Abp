using System;
using System.Collections.Generic;
using System.Linq;
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

    public ClassParameter GetParameter(string name)
    {
        return Parameters.Find(u => u.Name == name);
    }
    
    public void AddParameter(string name, Guid type)
    {
        if (Parameters.Any(u => u.Name == name))
            throw new UserFriendlyException("Parameters' name in class shouldn't be repeated! ");

        Parameters.Add(new ClassParameter(Id, name, type));
    }

    public void RemoveParameter(string name)
    {
        Parameters.Remove(GetParameter(name));
    }

    
}
