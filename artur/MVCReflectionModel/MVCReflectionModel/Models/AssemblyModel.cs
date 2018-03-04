using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;


namespace MVCReflectionModel.Models
{
    public class AssemblyModel
    {
        private readonly Assembly _asm;
        public AssemblyModel(Assembly asm)
        {
            _asm = asm;
            AssemblyName name = asm.GetName();
            SimpleName = name.Name;
            Version = name.Version.ToString();
            byte[] keyToken = name.GetPublicKeyToken();
            PublicKeyToken = keyToken == null ? "" :
            string.Concat(keyToken.Select(b => b.ToString("X2")));
            Types = asm.GetTypes().Select(t => t.FullName).ToList();
        }
        public string SimpleName { get; private set; }
        public string Version { get; private set; }
        public string PublicKeyToken { get; private set; }
        public IList<string> Types { get; private set; }
    }
}