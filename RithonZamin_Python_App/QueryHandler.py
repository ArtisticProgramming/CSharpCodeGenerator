import os
import sys
from Config import *
import ExecuterModule as exe

def generate_handler_class(
    base_folder_name, class_name, namespace, query_dto, return_dto
):
    output_path = f"{ProjPathConfig.ApplicationLayerPath}\\{namespace}\\Queries\\{base_folder_name}\\{class_name}.cs"

    print("outputPath:" + output_path)
    template_path = (
        f"{TemplateConfig.templatesBaseForlder}\\query\\QueryHandlerTmpl.txt"
    )

    param_array = [
        exe.MakeParam("ns", AppConfig.ApplicationService + namespace),
        exe.MakeParam("cl", class_name),
        exe.MakeParam("querydto", query_dto),
        exe.MakeParam("returndto", return_dto),
    ]

    exe.executor(
        output_path, template_path, ProjPathConfig.ApplicationLayerPath, param_array
    )


