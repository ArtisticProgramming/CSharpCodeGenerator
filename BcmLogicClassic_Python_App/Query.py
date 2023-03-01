from Config import *
import ExecuterModule as exe
import Utilities as util
import DTO as dto


def genarateClass(BaseName, nameSpace, entrydto, returndto):
    print(__name__)

    OutPutPath = ProjPathConfig.QueryClassProjPath  +'\\'+ nameSpace+'\\'+"Get"+BaseName+"Query"+".cs"
    OutPutBasePath = ProjPathConfig.outPutBasePath

    TemplatePath = GlobalConfig.templatesBaseForlder + \
        r"\QueriesImplementationTmpl.txt"


    paramArray = []
    paramArray.append(exe.MakeParam(
        "ns", AppConfig.ModelQueryClassBaseaPath+nameSpace))
    paramArray.append(exe.MakeParam("cl", "Get" + BaseName+"Query"))
    paramArray.append(exe.MakeParam("in", "IGet" + BaseName+"Query"))
    paramArray.append(exe.MakeParam("entrydto", entrydto))
    paramArray.append(exe.MakeParam("returndto", returndto))
    exe.executor(OutPutPath, TemplatePath, OutPutBasePath, paramArray)
    # exe.OpenFolder(OutPutBasePath+OutPutPath)


def genarateInerface(BaseName, nameSpace, entrydto, returndto):
    print(__name__)

    OutPutBasePath =ProjPathConfig.outPutBasePath
    TemplatePath = GlobalConfig.templatesBaseForlder+r"\QueriesInterfaceTmpl.txt"

    OutPutPath =   ProjPathConfig.QueryInterfaceProjPath +'\\'+ nameSpace + '\\'+"IGet"+BaseName+"Query"+".cs"

    paramArray = []
    paramArray.append(exe.MakeParam(
        "ns", AppConfig.ModelQueryInterfaceBaseaPath+nameSpace))
    paramArray.append(exe.MakeParam("in", "IGet"+BaseName+"Query"))
    paramArray.append(exe.MakeParam("entrydto", entrydto))
    paramArray.append(exe.MakeParam("returndto", returndto))
    exe.executor(OutPutPath, TemplatePath, OutPutBasePath, paramArray)


def CreateQuery(baseName, nameSpace, dtoClass, returndto):
    genarateClass(baseName, nameSpace, dtoClass, returndto)
    genarateInerface(baseName, nameSpace, dtoClass, returndto)
    dto.genarateDtoClass(dtoClass, nameSpace)
    dto.genarateDtoClass(returndto, nameSpace)


if (__name__ == "__main__"):
    baseName = "AcceptSchemaApi"
    baseNameNS = "AcceptSchema"
    dtoClass = "AcceptSchemaApi" + "RequstDto"
    returndto = "AcceptSchemaApi" + "ResponseDto"
    CreateQuery(baseName, baseNameNS, dtoClass, returndto)
