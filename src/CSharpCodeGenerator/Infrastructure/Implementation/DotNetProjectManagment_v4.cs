using CSharpCodeGenerator.Infrastructure.Base;
using CSharpCodeGenerator.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCodeGenerator.Infrastructure.Implementation
{
    public class DotNetProjectManagment_v4 : DotNetProjectManagmentBase_v4, IProjectManagment
    {
        public DotNetProjectManagment_v4(string projectPath) : base(projectPath)
        {
            ProjectPath = projectPath;
        }
        public string ProjectPath
        {
            get; set;
        }

        public void AddFile(string filePath, string content)
        {
            var FullPath = GetFullPath(Project.DirectoryPath, filePath);
            FileInfo realfile = new FileInfo(FullPath);
            var directoryName = filePath.Replace(realfile.Name, "");
            AddFolder(directoryName);

            Project.ReevaluateIfNecessary();

            CreateFile(FullPath, content);

            if (Project.Items.FirstOrDefault(i => i.EvaluatedInclude == FullPath) == null)
                Project.AddItem("Compile", FullPath);
            Project.Save();
        }

        public void AddFolder(string projectFolderPath)
        {
            var projectFullPath = GetFullPath( Project.DirectoryPath , projectFolderPath);
            CreateFolder(projectFullPath);

            Project.ReevaluateIfNecessary();

            if (Project.Items.FirstOrDefault(i => i.EvaluatedInclude == projectFullPath) == null)
                Project.AddItem("Folder", projectFolderPath);
            Project.Save();
        }
        
        public void RemoveFile(string filePath)
        {
            throw new NotImplementedException();
        }

        public void RemoveFolder(string folderPath)
        {
            throw new NotImplementedException();
        }
    }
}
