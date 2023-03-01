import ExecuterModule as exe
import Utilities as util
from Config import *
def genarateDtoClass(BaseName, nameSpace):
    print(__name__)

    OutPutBasePath = ProjPathConfig.outPutBasePath
    TemplatePath = TemplateConfig.templatesBaseForlder+r"\DtoTempl.txt"

    OutPutPath = ProjPathConfig.DTOProjPath +'\\'+ nameSpace +'\\'+BaseName+".cs"

    paramArray = []
    paramArray.append(exe.MakeParam(
        "ns", exe.AppConfig.DtoBaseaPath+nameSpace))
    paramArray.append(exe.MakeParam("cl", BaseName))
    exe.executor(OutPutPath, TemplatePath, OutPutBasePath, paramArray)
    # exe.OpenFolder(OutPutBasePath+OutPutPath)

if (__name__ == "__main__"):
    dtoClass = "AcceeptSchema" + "Dto"
    genarateDtoClass(dtoClass,"");

