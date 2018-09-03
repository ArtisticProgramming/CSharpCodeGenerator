#-------config variables--------------------------------------------------------------------------------------------------
$BaseName = "PolicyExceptionOpinion"
$BasedirctoryName="PolicyException"

#---DTO---

$DTOBasedirctoryName="PolicyException"
$ReturnDTOFileName="PolicyExceptionOpinionCardTabDto"
$EntryDTOFileName="PolicyExceptionOpinionQueryDto"
# ###################################################################################################################################

#--------------------------------------------------------------APLICATION START---------------------------------------------
$projectFile= "C:\Users\jafar\Source\Repos\BCMLogic core\BcmWebExtension\Model\Model.csproj"
#"C:\Users\jafar\Documents\visual studio 2015\Projects\ConsoleApplication3\ConsoleApplication3\ConsoleApplication3.csproj"
$tmplateBasePath = "D:\DeveloperAssistant\ccgTemplate\"
$baseNameSpace ="Model."
#------------------------------------------------------------------------------------------------------------------------
$QueryInterface_tempName="QueriesInterfaceTmpl"
$QueryImplementation_tempName="QueriesImplementationTmpl"
$returnDto_tempName="DtoTempl"
$entryDto_tempName="DtoTempl"
# -------------------------------------------Rerturn DTO MODEL----------------------------------------------------------

$returnDto_dirctoryName = $DTOBasedirctoryName
$returnDto_fileDirectoryPath="\DTO\Models\"+ $returnDto_dirctoryName +"\"
$returnDto_fileName=$ReturnDTOFileName+"Dto"
#--------argument-----------
$returnDto_ns =  $baseNameSpace +"DTO.Models."+$BasedirctoryName
$returnDto_cl =$returnDto_fileName

#---------------------------------------------Entry DTO MODEL-----------------------------------------------------------------

$entryDto_dirctoryName = $DTOBasedirctoryName
$entryDto_fileDirectoryPath="\DTO\Models\"+ $entryDto_dirctoryName +"\"
$entryDto_fileName=$EntryDTOFileName+"Dto"
# ----------argument----------
$entryDto_ns = $baseNameSpace +"DTO.Models."+$BasedirctoryName
$entryDto_cl =$entryDto_fileName

# ----------------------------------------  Queries Interfaces ----------------------------------------------------------------

$QueryInterface_dirctoryName =$BasedirctoryName
$QueryInterface_fileDirectoryPath="\Queries\Interfaces\"+ $QueryInterface_dirctoryName +"\"
$QueryInterface_fileName="IGet"+$BaseName+"Query"

# ----------argument-----------

$QueryInterface_ns = $baseNameSpace +"Queries.Interfaces."+$QueryInterface_dirctoryName 
$QueryInterface_in =$QueryInterface_fileName
$QueryInterface_returnDto =$returnDto_ns+"."+$returnDto_fileName
$QueryInterface_entryDto =$entryDto_ns+"."+$entryDto_fileName

# ---------------------------------------  Queries Implementation ---------------------------------------------------------------

$QueryImplementation_dirctoryName =$BasedirctoryName
$QueryImplementation_fileDirectoryPath="\Queries\Implementation\"+ $QueryImplementation_dirctoryName +"\"
$QueryImplementation_fileName="Get"+$BaseName+"Query"

# ----------argument-----------

$QueryImplementation_ns = $baseNameSpace +"Queries.Implementation."+$QueryImplementation_dirctoryName 
$QueryImplementation_cl =$QueryImplementation_fileName
$QueryImplementation_in =$QueryInterface_ns+"."+ $QueryInterface_fileName
$QueryImplementation_returnDto =$QueryInterface_returnDto
#using Model.DTO.Models.Shared;
$QueryImplementation_entryDto =$QueryInterface_entryDto

# ###################################################################################################################################
# -----------------------------------------------------------ARGUMENTS---------------------------------------------------------------

$QueryInterface_argument="ns:" + $QueryInterface_ns +
  ",in: " + $QueryInterface_in                      +
  ",returndto: " + $QueryInterface_returnDto        +
  ",entrydto: " + $QueryInterface_entryDto 

# -----------------------------

$QueryImplementation_argument="ns:" + $QueryImplementation_ns+
   ",cl:" + $QueryImplementation_cl                          +
   ",in:" + $QueryImplementation_in                          +
   ",returndto:" + $QueryImplementation_returnDto            +
   ",entrydto:" + $QueryImplementation_entryDto 

# -----------------------------

$returnDto_argument="ns:" + $returnDto_ns + 
 ",cl:" + $returnDto_cl

# -----------------------------
$entryDto_argument="ns:" + $entryDto_ns + 
 ",cl:" + $entryDto_cl

# ###################################################################################################################################

$QueryInterface_fileFullName = $QueryInterface_fileDirectoryPath + $QueryInterface_fileName+".cs"
$QueryInterface_templateFileName= $tmplateBasePath + $QueryInterface_tempName +".txt"
#---------------

$QueryImplementation_fileFullName = $QueryImplementation_fileDirectoryPath + $QueryImplementation_fileName+".cs"
$QueryImplementation_templateFileName= $tmplateBasePath + $QueryImplementation_tempName +".txt"

#---------------

$returnDto_fileFullName = $returnDto_fileDirectoryPath + $returnDto_fileName+".cs"
$returnDto_templateFileName= $tmplateBasePath + $returnDto_tempName +".txt"

#---------------

$entryDto_fileFullName = $entryDto_fileDirectoryPath + $entryDto_fileName+".cs"
$entryDto_templateFileName= $tmplateBasePath + $entryDto_tempName +".txt"

# -----------------------------------------------------------------------------------------------------

 d:\GitProjects\src\csharpcodegenerator\bin\debug\ccg.exe gdf -f $returndto_filefullname  -t $returndto_templatefilename -p $projectfile -a $returndto_argument
 d:\GitProjects\src\csharpcodegenerator\bin\debug\ccg.exe gdf -f $entrydto_filefullname  -t $entrydto_templatefilename -p $projectfile -a $entrydto_argument
 d:\GitProjects\src\csharpcodegenerator\bin\debug\ccg.exe gdf -f $QueryInterface_filefullname  -t $Queryinterface_templatefilename -p $projectfile -a $Queryinterface_argument
 d:\GitProjects\src\csharpcodegenerator\bin\debug\ccg.exe gdf -f $Queryimplementation_filefullname  -t $Queryimplementation_templatefilename -p $projectfile -a $Queryimplementation_argument
