using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCReflectionModel.Models
{
    public class ReflectionModel
    {
        private IList<string> Assemblies;

        public ReflectionModel(IEnumerable<string> assemblyNames)
        {
            Assemblies = assemblyNames.ToList();
        }

    }

}