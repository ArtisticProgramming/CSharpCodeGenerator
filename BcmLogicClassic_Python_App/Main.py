
import Command
import Query

def CommandGenrator():
    baseName = "AddAcceeptSchemaTest"
    baseNameNS = "AcceeptSchema"
    dtoClass = "AcceeptSchema" + "Dto"
    Command.CreateCommand(baseName, baseNameNS, dtoClass)

def QueryGenrator():
    baseName = "AcceptSchemaApi"
    baseNameNS = "AcceptSchema"
    dtoClass = "AcceptSchemaApi" + "RequstDto"
    returndto = "AcceptSchemaApi" + "ResponseDto"
    Query.CreateQuery(baseName, baseNameNS, dtoClass, returndto)


if (__name__ == "__main__"):
    
    #CommandGenrator()
    
    #QueryGenrator()

    print("----------------------END--------------------")