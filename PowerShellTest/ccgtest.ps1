$fileName = "Mod\s\Product92e83339.cs"

$tmplateBasePath = "D:\DeveloperAssistant\ccgTemplate\"

$templateFileName= $tmplateBasePath + ""
$projectFile= "D:\GitProjects\CSharpCodeGenerator\src\testProj\testProj.csproj"
$argument=" cn: produc,  in : IProduct ,mn: GetProduct"


#-------config variables--------------------------------------------------------------------------------------------------

$BaseName = "PolicyExceptionReason"
$BasedirctoryName="PolicyException"
#---DTO---
$DTOBasedirctoryName="PolicyException"
$ReturnDTOFileName="PolicyExceptionReasonCardTabDto"
$EntryDTOFileName="PolicyExceptionReasonQueryDto"

#--------------------------------------------------------------APLICATION START---------------------------------------------

$projectFile= "D:\GitProjects\CSharpCodeGenerator\src\testProj\testProj.csproj"

$tmplateBasePath = "D:\DeveloperAssistant\ccgTemplate\"

$baseNameSpace ="testProj."

#------------------------------------------------------------------------------------------------------------------------

$returnDto_dirctoryName = $DTOBasedirctoryName
$returnDto_fileDirectoryPath="\DTO\Models\"+ $returnDto_dirctoryName +"\"
$returnDto_fileName=$ReturnDTOFileName+"Dto"
#--------argument-----------
$returnDto_ns =  $baseNameSpace +"DTO.Models."+$BasedirctoryName
$returnDto_cl =$returnDto_fileName

$returnDto_argument="ns:" + $returnDto_ns + 
 ",cl:" + $returnDto_cl

$returnDto_fileFullName = $returnDto_fileDirectoryPath + $returnDto_fileName+".cs"
$returnDto_templateFileName= $tmplateBasePath + $returnDto_tempName +".txt"

$argsss="gdf" +  " -f " + $fileName + " -t " +$templateFileName +" -p " +$projectFile +" a "+ $argument
write-output $argsss

 
 D:\GitProjects\CSharpCodeGenerator\src\CSharpCodeGenerator\bin\Debug\ccg.exe gdf -f $fileName  -t $templateFileName -p $projectFile -a $argument

