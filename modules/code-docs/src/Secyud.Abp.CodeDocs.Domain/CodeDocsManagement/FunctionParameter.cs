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

        public FunctionParameter(
            Guid functionId,
            string name,
            Guid typeId)
        {
            Check.NotNull(name, nameof(name));
            Name = name;
            FunctionId = functionId;
            TypeId = typeId;
        }

        public override object[] GetKeys()
        {
            return new object[] { FunctionId, Name };
        }
        
        public void SetAnnotation(string annotation)
        {
            Annotation = annotation;
        }
    }
}