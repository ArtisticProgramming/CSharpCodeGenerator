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
    public class DotNetProjectManagment_v4 : DotNetProjectManagmentBase_v4, IDotNetProjectManagment
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
            var FullPath = GetFullPath(filePath);
            FileInfo realfile = new FileInfo(FullPath);
            var directoryName = filePath.Replace(realfile.Name, "");
            AddFolder(directoryName);

            Project.ReevaluateIfNecessary();

            CreateFile(FullPath, content);

            if (Project.Items.FirstOrDefault(i => i.EvaluatedInclude == FullPath) == null)
                Project.AddItem("Compile", filePath);
            Project.Save();
        }

        public void AddFolder(string projectFolderPath)
        {
            var projectFullPath = GetFullPath(projectFolderPath);
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

        public string GetFullPath(string path)
        {
            if (path.First() != '\\')
                path = @"\" + path;
            var fullPathProject = (Project.DirectoryPath + path).Replace(@"\\", @"\");

            return fullPathProject;
        }

        private void CreateFile(string fullPath, string content)
        {
            File.WriteAllText(fullPath, content);
        }

        private void CreateFolder(string projectFullPath)
        {
            Directory.CreateDirectory(projectFullPath);
        }

    }
}
