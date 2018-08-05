using CommandLine;
using CSharpCodeGenerator.Infrastructure.Implementation;
using CSharpCodeGenerator.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCodeGenerator
{
    class Options
    {
        [Option('f', "filename", Required = true, HelpText = "name of new file")]
        public string FileName { get; set; }

        [Option('t', "templatePath", Required = true, HelpText = "template file path")]
        public string TemplateFilePath { get; set; }

        [Option('p', "pojectfile", Required = true, HelpText = "csproj file and path")]
        public string ProjectFile { get; set; }

        [Option('a', "argument", Required = true, HelpText = "Tempate argument json text", Separator = ',')]
        public IEnumerable<string> argument { get; set; }

        [Option(Default = "@<", HelpText = "StartSign in the template that help program to find paramter in the template")]
        public string StartSign { get; set; }

        [Option(Default = ">", HelpText = "EndSign in the template that help program to find paramter in the template")]
        public string EndSign { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(opts => RunOptionsAndReturnExitCode(opts))
                .WithNotParsed<Options>((errs) => HandleParseError(errs));

            //var options = new Options();
            //if (CommandLine.Parser.Default.ParseArguments(args, options))
            //{
            //    // Values are available here
            //    if (options.Verbose) Console.WriteLine("Filename: {0}", options.InputFile);
            //}

            //args = new string[1];
            //foreach (var item in args)
            //{
            //    Console.WriteLine(item);
            //}
            //args[0] = "{ \"cn\":\"product\",\"in\":\"IProduct\" ,\"mn\":\"GetProduct\"}"; ;
            //var sSign = "@<";
            //var eSign = ">";
            //var fileName = "Product.cs";
            //var temPath = @"G:\TMEP\temp1.txt";
            //var argumentText = args.FirstOrDefault();
            //var ProjectPath = @"G:\GitProject\CSharpCodeGenerator\src\testProj\testProj.csproj";

            //ITemplateManagement templateManagment = new TemplateManagement();
            //var template =templateManagment.CreateTemplate(fileName,temPath,argumentText,sSign,eSign);

            //ICodeGeneration generation = new CodeGeneration();
            //var generatedCode = generation.GenerateCode(template);

            //IDotNetProjectManagment projectManagment = new DotNetProjectManagment_v4(ProjectPath);
            //projectManagment.AddFile(@"Model\"+ template.Name, generatedCode);
        }

        private static void HandleParseError(IEnumerable<Error> errs)
        {
            foreach (var item in errs)
                Console.WriteLine(item);
            
        }

        private static void RunOptionsAndReturnExitCode(Options opts)
        {

            ITemplateManagement templateManagment = new TemplateManagement();
            var template = templateManagment.CreateTemplate(opts.FileName, opts.TemplateFilePath, opts.argument, opts.StartSign, opts.EndSign);

            ICodeGeneration generation = new CodeGeneration();
            var generatedCode = generation.GenerateCode(template);

            IDotNetProjectManagment projectManagment = new DotNetProjectManagment_v4(opts.ProjectFile);
            projectManagment.AddFile(template.Name, generatedCode);

            Console.WriteLine("Opration was successfull :)");
        }
    }
}

