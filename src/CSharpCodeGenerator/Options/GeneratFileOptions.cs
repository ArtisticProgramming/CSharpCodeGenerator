using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCodeGenerator.Options
{
    /// <summary>
    /// DOCUMENTS ADDRESSS : https://github.com/commandlineparser/commandline
    /// </summary>
    [Verb("gf", HelpText = "Generate File And Add to the Folder")]
    class GeneratFileOptions
    {

        [Option('f', "filename", Required = true, HelpText = "name of new file")]
        public string FileName { get; set; }

        [Option('t', "templatePath", Required = true, HelpText = "template file path")]
        public string TemplateFilePath { get; set; }

        [Option('p', "pojectFolder", Required = true, HelpText = "Project Folder path")]
        public string ProjectFolder { get; set; }

        [Option('a', "argument", Required = true, HelpText = "Tempate argument json text", Separator = ',')]
        public IEnumerable<string> argument { get; set; }

        [Option(Default = "@<", HelpText = "StartSign in the template that help program to find paramter in the template")]
        public string StartSign { get; set; }

        [Option(Default = ">", HelpText = "EndSign in the template that help program to find paramter in the template")]
        public string EndSign { get; set; }
    }
}
