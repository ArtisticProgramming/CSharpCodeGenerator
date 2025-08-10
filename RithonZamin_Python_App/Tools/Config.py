import pathlib


class CodeGeneratorConfig:
    ccgPath = r"C:\Users\World\Documents\GitHub\CSharpCodeGenerator\src\CSharpCodeGenerator\bin\Debug\ccg.exe"


class TemplateConfig:
    templatesBaseForlder = (
        str(pathlib.Path("ExecuterModule.py").parent.resolve()) + r"\Templates"
    )


class AppConfig:
    ProjectBaseNamespace = "MiniBlog.Core."
    ApplicationService = ProjectBaseNamespace + "ApplicationService"
    RequestResponse = ProjectBaseNamespace + "RequestResponse."


class ProjPathConfig:
    ApplicationLayerPath = r"C:\Users\World\Documents\GitHub\Zamin\Onion\sample\1.Core\Miniblog.Core.ApplicationService"
    RquestResponseLayerPath = r"C:\Users\World\Documents\GitHub\Zamin\Onion\sample\1.Core\MiniBlog.Core.RequestResponse"
