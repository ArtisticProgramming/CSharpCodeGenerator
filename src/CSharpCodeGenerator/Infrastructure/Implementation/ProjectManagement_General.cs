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

    class ProjectManagement_General : BaseProjectMangment, IProjectManagment
    {
        public ProjectManagement_General(string projectFolder)
        {
            ProjectPath = projectFolder;
        }
        public string ProjectPath { get; set; }

        public void AddFile(string filePath, string content)
        {
            string fullPath = Path.IsPathRooted(filePath)
                                ? filePath
                                : GetFullPath(ProjectPath, filePath);
            FileInfo realfile = new FileInfo(fullPath);
            var directoryName = filePath.Replace(realfile.Name, "");
            AddFolder(directoryName);
            CreateFile(fullPath, content);
        }

        public void AddFolder(string path)
        {
            string fullPath = Path.IsPathRooted(path)
                              ? path
                              : GetFullPath(ProjectPath, path);
            CreateFolder(fullPath);
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
