using CommandLine;
using CSharpCodeGenerator.Infrastructure.Implementation;
using CSharpCodeGenerator.Infrastructure.Interface;
using CSharpCodeGenerator.Options;
using System;
using System.Collections.Generic;

namespace CSharpCodeGenerator
{
    class Program
    {

        static void Main(string[] args)
        {
            DIRegistration();
            var result = CommandLine.Parser.Default.ParseArguments<GeneratFileOptions, GeneratFileDotNetProjOptions>(args)
                .WithNotParsed(errs => HandleParseError(errs))
                .MapResult(
                  (GeneratFileOptions opts) => RunGeneratFileOptionsAddAndReturnExitCode(opts),
                  (GeneratFileDotNetProjOptions opts) => RunGeneratFileDotNetProjOptionsAndReturnExitCode(opts),
                   errs => 1);
        
        }

        private static void DIRegistration()
        {
            throw new NotImplementedException();
        }

        private static int RunGeneratFileDotNetProjOptionsAndReturnExitCode(GeneratFileDotNetProjOptions opts)
        {

            ITemplateManagement templateManagment = new TemplateManagement();
            var template = templateManagment.CreateTemplate(opts.FileName, opts.TemplateFilePath, opts.argument, opts.StartSign, opts.EndSign);

            ICodeGeneration generation = new CodeGeneration();
            var generatedCode = generation.GenerateCode(template);

            IProjectManagment projectManagment = new DotNetProjectManagment_v4(opts.ProjectFile);
            projectManagment.AddFile(template.Name, generatedCode);

            Console.WriteLine("The opration was successfull :)");
            return 2;
        }

        private static int RunGeneratFileOptionsAddAndReturnExitCode(GeneratFileOptions opts)
        {

            ITemplateManagement templateManagment = new TemplateManagement();
            var template = templateManagment.CreateTemplate(opts.FileName, opts.TemplateFilePath, opts.argument, opts.StartSign, opts.EndSign);

            ICodeGeneration generation = new CodeGeneration();
            var generatedCode = generation.GenerateCode(template);

            IProjectManagment projectManagment = new ProjectManagement_General(opts.ProjectFolder);
            projectManagment.AddFile(template.Name, generatedCode);

            Console.WriteLine("The opration was successfull :)");
            return 2;
        }

        private static void HandleParseError(IEnumerable<Error> errs)
        {
            foreach (var item in errs)
                Console.WriteLine(item);
        }
    }
}

