import os
import sys
sys.path.append(os.path.join(os.path.dirname(__file__), "Tools"))

import QueryRequest as request
import QueryResponse as response
import QueryHandler as handler

def QueryGenrator():
    baseName = "CustomerById"
    namespace = "Customer"
    baseFolderName = "Get" + baseName
    req = "Get" + baseName + "Query"
    res = baseName + "Qr"
    hand = "Get" + baseName + "Handler"
    create_query(baseFolderName, namespace, req, res, hand)  # Call local function, not module function

def create_query(base_folder_name, namespace, req, res, hand):
    handler.generate_handler_class(base_folder_name, hand, namespace, req, res)
    request.generate_query_request_class(base_folder_name, req, namespace, res)
    response.generate_query_response_class(base_folder_name, res, namespace)

if __name__ == "__main__":
    QueryGenrator()
    print("----------------------END---------------------")
