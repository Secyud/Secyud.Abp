using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Secyud.Abp.CodeDocsManagement
{
    public class ClassParameter : Entity
    {
        [NotNull] public string Name { get; set; }
        public Guid ClassId { get; set; }
        public Guid TypeId { get; set; }
        public string Annotation { get; set; }
        public bool IsPublic { get; set; }

        private ClassParameter()
        {

        }
        public ClassParameter(
            string name, Guid classId,
            Guid typeId, string annotation, bool isPublic)
        {
            Check.NotNull(name, nameof(name));
            Name = name;
            ClassId = classId;
            TypeId = typeId;
            Annotation = annotation;
            IsPublic = isPublic;
        }

        public override object[] GetKeys()
        {
            return new object[] { Name, ClassId };
        }
    }
}
