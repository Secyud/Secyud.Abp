using JetBrains.Annotations;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace SuperCreation.Abp.CodeDocs.Code
{
    public class ClassParameter : Entity
    {
        [NotNull] public string Name { get; } = "";

        public Guid ClassId { get; }

        public Guid TypeId { get; set; }
        public CodeClass Type { get; set; }

        public string Annotation { get; set; }

        public bool IsPublic { get; set; }

        protected ClassParameter()
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
