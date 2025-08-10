using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCodeGenerator.Infrastructure.Base
{
    public abstract class BaseProjectMangment
    {
        protected string GetFullPath(string ProjectDirectoryPath, string path)
        {
            if (path.First() != '\\')
                path = @"\" + path;

            var fullPathProject = (ProjectDirectoryPath + path).Replace(@"\\", @"\");
            return fullPathProject;            
        }

        protected void CreateFile(string fullPath, string content)
        {
            if (File.Exists(fullPath) == false)
            {
                File.WriteAllText(fullPath, content);
            }
        }


        protected void CreateFolder(string projectFullPath)
        {
            if (string.IsNullOrWhiteSpace(projectFullPath))
                throw new ArgumentException("projectFullPath cannot be null or empty", nameof(projectFullPath));

            string fullPath = Path.IsPathRooted(projectFullPath)
                ? Path.GetFullPath(projectFullPath)
                : Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, projectFullPath));

            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }
        }
    }
}
