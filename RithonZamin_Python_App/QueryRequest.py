import os
import sys
sys.path.append(os.path.join(os.path.dirname(__file__), "Tools"))
from Config import *
import ExecuterModule as exe
import Utilities as util
from Config import *

def generate_query_request_class(baseFolderName, class_name, namespace, return_dto):
    """Generates a query_request class file based on a template."""
    print(__name__)

    output_path = (
        f"{ProjPathConfig.RquestResponseLayerPath}\\{namespace}\\Queries\\{baseFolderName}\\{class_name}.cs"
    )

    print("outputPath:"+output_path)
    template_path = f"{TemplateConfig.templatesBaseForlder}\\query\\QueryRequestTmpl.txt"

    param_array = [
        exe.MakeParam("ns", exe.AppConfig.RequestResponse + namespace) ,
        exe.MakeParam("cl", class_name),
        exe.MakeParam("returndto", return_dto)
    ]

    exe.executor(output_path, template_path, ProjPathConfig.RquestResponseLayerPath, param_array)

if __name__ == "__main__":
    dto_class = ""
    generate_query_request_class(dto_class, "","")
