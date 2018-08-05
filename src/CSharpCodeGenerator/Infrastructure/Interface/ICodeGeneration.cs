using CSharpCodeGenerator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCodeGenerator.Infrastructure.Interface
{
    public interface ICodeGeneration
    {
        string GenerateCode(Template template);
    }
}
