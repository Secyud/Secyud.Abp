using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Secyud.Abp.CodeDocsManagement
{
    public class FunctionParameter : Entity
    {
        public string Name { get; set; } 

        public Guid FunctionId { get; set; }

        public Guid TypeId { get; set; }

        public string Annotation { get; set; }

        private FunctionParameter()
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
