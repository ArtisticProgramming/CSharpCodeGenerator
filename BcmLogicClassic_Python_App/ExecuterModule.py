import subprocess
import os
from Config import *


print(__name__)
# class Untility:
#     @staticmethod
#     def MakeParam(key , value):
#         return key +":"+value

sep = ","


def executor(OutPutPath, TemplatePath, OutPutBasePath, paramArray):
    param = sep.join(paramArray)
    command = GlobalConfig.ccgPath+" gdf -f "+OutPutPath + \
        " -t "+TemplatePath+" -p "+OutPutBasePath+" -a " + param
    print("command ===> "+command)
    process = subprocess.Popen(["powershell", command], stdout=subprocess.PIPE)
    result = process.communicate()[0]
    print(result)


def MakeParam(key, value):
    return key + ":"+value


def OpenFolder(path):
    path = os.path.realpath(path)
    os.startfile(path)


def createParamtersString(dictionaryParam):
    paramArray = []
    for x in dictionaryParam:
        paramArray.append(MakeParam(x, dictionaryParam[x]))
    Param = sep.join(paramArray)
    return Param


