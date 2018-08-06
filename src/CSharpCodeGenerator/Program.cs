using CommandLine;
using CSharpCodeGenerator.Infrastructure.Implementation;
using CSharpCodeGenerator.Infrastructure.Interface;
using System;
using System.Collections.Generic;

namespace CSharpCodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(opts => RunOptionsAndReturnExitCode(opts))
                .WithNotParsed<Options>((errs) => HandleParseError(errs));
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

            Console.WriteLine("The opration was successfull :)");
        }
    }
}

