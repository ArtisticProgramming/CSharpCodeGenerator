using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCodeGenerator.Infrastructure.Base
{
    public class DotNetProjectManagmentBase_v4 :BaseProjectMangment
    {
        public DotNetProjectManagmentBase_v4(string projectPath)
        {
            GetProject(projectPath);
        }

        public Microsoft.Build.Evaluation.Project Project { get; set; }

        public void GetProject(string ProjectPath)
        {
            try
            {
                if (Project == null)
                {
                    if (string.IsNullOrEmpty(ProjectPath))
                    {
                        throw new ArgumentNullException("Project Path is not defined");
                    }

                    Project = new Microsoft.Build.Evaluation.Project(ProjectPath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
