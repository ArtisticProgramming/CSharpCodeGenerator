using CSharpCodeGenerator.Core;
using CSharpCodeGenerator.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCodeGenerator.Infrastructure.Implementation
{
    public class CodeGeneration : ICodeGeneration
    {
        public string GenerateCode(Template template)
        {
            var tempalteText = template.Content;

            foreach (var item in template.Argument)
            {
                tempalteText = tempalteText.Replace(template.ArgumentStartSign+ item.Key+ template.ArgumentEndSign, item.Value);
            }

            var generatedCode = tempalteText;
            return generatedCode;
        }   
    }
}
