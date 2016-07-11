using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MVCReflectionModel.Models
{
    public class ModelSource
    {
        public static Dictionary<string, Assembly> AvailableAssemblies
        { get; private set; }
        static ModelSource()
        {
            AvailableAssemblies = AppDomain.CurrentDomain.GetAssemblies()
            .GroupBy(a => a.GetName().Name)
            .ToDictionary(g => g.Key, g => g.First());
        }
        public static AssemblyModel FromName(string name)
        {
            Assembly asm;
            if (!AvailableAssemblies.TryGetValue(name, out asm))
            {
                return null;
            }
            return new AssemblyModel(asm);
        }
    }
}