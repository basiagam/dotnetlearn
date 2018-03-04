using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCReflectionModel.Models
{
    public class TypeModel
    {
        public TypeModel(Type t)
        {
            Name = t.Name;
            Namespace = t.Namespace;
            ContainingAssembly = t.Assembly.GetName().Name;

            Methods = t.GetMethods().Select(m => m.Name).Distinct().ToList(); 
        }

        public string ContainingAssembly { get; private set; }
        public IList<string> Methods { get; private set; }
        public string Name { get; private set; }
        public string Namespace { get; private set; }
    }
}