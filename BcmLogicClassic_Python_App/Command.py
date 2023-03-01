# import ExecuterModule as exe
# import DTO as dto
# from Config import *

# def genarateCommandClass(BaseName, nameSpace, entrydto):
#     print(__name__)

#     OutPutBasePath = TemplateConfig.outPutBasePath
#     TemplatePath = TemplateConfig.templatesBaseForlder + \
#         r"\CommandsImplementationTmpl.txt"

#     OutPutPath = '\\'+BaseName+"Command"+".cs"

#     paramArray = []
#     paramArray.append(exe.MakeParam(
#         "ns", AppConfig.ModelCommandClassBaseaPath+nameSpace))
#     paramArray.append(exe.MakeParam("cl", BaseName+"Command"))
#     paramArray.append(exe.MakeParam("in", BaseName+"Command"))
#     paramArray.append(exe.MakeParam("entrydto", entrydto))
#     exe.executor(OutPutPath, TemplatePath, OutPutBasePath, paramArray)
#     # exe.OpenFolder(OutPutBasePath+OutPutPath)

# def genarateCommandInerface(BaseName, nameSpace, entrydto):
#     print(__name__)

#     OutPutBasePath = TemplateConfig.outPutBasePath
#     TemplatePath = TemplateConfig.templatesBaseForlder+r"\CommandsInterfaceTmpl.txt"

#     OutPutPath = '\\'+"I"+BaseName+"Command"+".cs"

#     paramArray = []
#     paramArray.append(exe.MakeParam(
#         "ns", AppConfig.ModelCommandInterfaceBaseaPath+nameSpace))
#     paramArray.append(exe.MakeParam("in", "I"+BaseName+"Command"))
#     paramArray.append(exe.MakeParam("entrydto", entrydto))
#     exe.executor(OutPutPath, TemplatePath, OutPutBasePath, paramArray)


from Config import *
import ExecuterModule as exe
import Utilities as util
import DTO as dto


def genarateClass(BaseName, nameSpace, entrydto, returndto):
    print(__name__)

    OutPutPath = ProjPathConfig.CommandClassProjPath  +'\\'+ nameSpace+'\\'+BaseName+"Command"+".cs"
    OutPutBasePath = ProjPathConfig.outPutBasePath

    TemplatePath = TemplateConfig.templatesBaseForlder + \
        r"\QueriesImplementationTmpl.txt"


    paramArray = []
    paramArray.append(exe.MakeParam(
        "ns", AppConfig.ModelCommandClassBaseaPath+nameSpace))
    paramArray.append(exe.MakeParam("cl", "" + BaseName+"Command"))
    paramArray.append(exe.MakeParam("in", "I" + BaseName+"Command"))
    paramArray.append(exe.MakeParam("entrydto", entrydto))
    exe.executor(OutPutPath, TemplatePath, OutPutBasePath, paramArray)
    # exe.OpenFolder(OutPutBasePath+OutPutPath)


def genarateInerface(BaseName, nameSpace, entrydto, returndto):
    print(__name__)

    OutPutBasePath =ProjPathConfig.outPutBasePath
    TemplatePath = TemplateConfig.templatesBaseForlder+r"\QueriesInterfaceTmpl.txt"

    OutPutPath =   ProjPathConfig.CommandInterfaceProjPath +'\\'+ nameSpace + '\\'+"I"+BaseName+"Command"+".cs"

    paramArray = []
    paramArray.append(exe.MakeParam(
        "ns", AppConfig.ModelCommandInterfaceBaseaPath+nameSpace))
    paramArray.append(exe.MakeParam("in", "I"+BaseName+"Command"))
    paramArray.append(exe.MakeParam("entrydto", entrydto))
    exe.executor(OutPutPath, TemplatePath, OutPutBasePath, paramArray)


def CreateCommand(baseName,nameSpace, dtoClass):
    genarateClass(baseName, nameSpace, dtoClass)
    genarateInerface(baseName, nameSpace, dtoClass)
    dto.genarateDtoClass(dtoClass, "")  

if (__name__ == "__main__"):
    baseName = "AddAcceeptSchemaTest"
    baseNameNS = "AcceeptSchema"
    dtoClass = "AcceeptSchema" + "Dto"
    CreateCommand(baseName,baseNameNS ,dtoClass)

