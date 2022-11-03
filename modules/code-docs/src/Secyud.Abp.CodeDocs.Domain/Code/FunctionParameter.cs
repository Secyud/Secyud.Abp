using JetBrains.Annotations;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace SuperCreation.Abp.CodeDocs.Code
{
    public class FunctionParameter : Entity
    {
        [NotNull] public string Name { get; } = "";

        public Guid FunctionId { get; }

        public Guid TypeId { get; set; }

        public CodeClass Type { get; set; }

        public string Annotation { get; set; }

        protected FunctionParameter()
        {

        }
        public FunctionParameter(string name, Guid functionId, Guid typeId, string annotation)
        {
            Check.NotNull(name, nameof(name));
            Name = name;
            FunctionId = functionId;
            TypeId = typeId;
            Annotation = annotation;
        }

        public override object[] GetKeys()
        {
            return new object[] { Name, FunctionId };
        }
    }
}
