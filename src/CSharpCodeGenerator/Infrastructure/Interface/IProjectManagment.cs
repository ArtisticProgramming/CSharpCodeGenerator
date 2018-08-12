using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCodeGenerator.Infrastructure.Interface
{
    public interface IProjectManagment
    {

        /// <summary>
        /// csproj file path
        /// </summary>
        string ProjectPath { get; set; }
        /// <summary>
        /// Adding file to project with updating csproj file list
        /// </summary>
        /// <param name="filePath">The path of project that new file will be added</param>
        /// <param name="content">file content</param>
        void AddFile(string filePath, string content);
        /// <summary>
        /// removing file from project
        /// </summary>
        /// <param name="filePath">New file name</param>
        void RemoveFile(string filePath);
        /// <summary>
        /// Adding folder to project with updating csproj file list
        /// </summary>
        /// <param name="path">The path of project that new folder will be added</param>
        /// <param name="folderName">New folder name </param>
        void AddFolder(string path);
        /// <summary>
        /// delete folder from project 
        /// </summary>
        /// <param name="folderPath">folder name</param>
        void RemoveFolder(string folderPath);
    }
}
