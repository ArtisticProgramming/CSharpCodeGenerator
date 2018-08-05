using CSharpCodeGenerator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCodeGenerator.Infrastructure.Interface
{
    public interface ITemplateManagement
    {
        Template CreateTemplate(string fileName, string templateFilePath, IEnumerable<string> argumentText,string argumentStartSign,string argumentEndSign);
        void CheckTempateValidation(string fileName, string templateFilePath, IEnumerable<string>  argumentText, string argumentStartSign, string argumentEndSign);
        Dictionary<string,string> ConvertToArgumentDictionary(IEnumerable<string> argumentText);
        bool IsTemplateExist(string templateFilePath);
        string[] GetTemplateArgumentsList(string templateFilePath, string templateStartSign, string templateEndSign);
        void CheckArgumentsValidation(string templateFilePath,IEnumerable<string> argumentText, string templateStartSign, string templateEndSign);
        string GetContent(string templateFilePath);
    }
}
