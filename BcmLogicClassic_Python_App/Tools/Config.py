import pathlib


class CodeGeneratorConfig:
    ccgPath = r"C:\Users\RED\Documents\GitHub\CSharpCodeGenerator\src\CSharpCodeGenerator\bin\Debug\ccg.exe"

class TemplateConfig:
    templatesBaseForlder = str(pathlib.Path(
        'ExecuterModule.py').parent.resolve()) + r"\Templates"

class AppConfig:
    ModelProjectBaseNamespace = "Model."
    # Command
    ModelCommandInterfaceBaseaPath = ModelProjectBaseNamespace+"Commands.Interfaces."
    ModelCommandClassBaseaPath = ModelProjectBaseNamespace+"Commands.Implementation."
    # Queries
    ModelQueryInterfaceBaseaPath = ModelProjectBaseNamespace+"Queries.Interfaces."
    ModelQueryClassBaseaPath = ModelProjectBaseNamespace+"Queries.Implementation."
    DtoBaseaPath = ModelProjectBaseNamespace+"DTO."


class ProjPathConfig:
    outPutProjBasePath = r"C:\Users\RED\source\repos\BCMLogicCore\BcmWebExtension\Model"
    outPutBasePath = outPutProjBasePath+r"\Model.csproj"

    QueryClassProjPath =  r"\Queries\Implementation"
    QueryInterfaceProjPath = r"\Queries\Interface"
    
    CommandClassProjPath =  r"\Commands\Implementation"
    CommandInterfaceProjPath = r"\Commands\Interface"

    DTOProjPath =  r"\DTO"
