using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCodeGenerator.Core
{
    public class Template
    {
        public Template()
        {
            Argument = new Dictionary<string, string>();
        }
        public string Name { get; set; }
        public string StoragePath { get; set; }
        public string ArgumentStartSign { get; set; }
        public string ArgumentEndSign { get; set; }
        public Dictionary<string,string> Argument { get; set; }
        public string Content { get; set; }
    }
}


