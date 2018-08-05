$fileName = "Mod\s\Product92e83339.cs"
$templateFileName= "G:\TMEP\temp1.txt"
$projectFile= "G:\GitProject\CSharpCodeGenerator\src\testProj\testProj.csproj"
$argument=" cn: produc,  in : IProduct ,mn: GetProduct"

G:\GitProject\CSharpCodeGenerator\src\CSharpCodeGenerator\bin\Debug\ccg.exe -f $fileName  -t $templateFileName -p $projectFile -a $argument

