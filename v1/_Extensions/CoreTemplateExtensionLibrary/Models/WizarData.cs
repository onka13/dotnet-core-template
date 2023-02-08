using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTemplateExtensionLibrary.Models
{
    public class WizarData
    {
        public List<WizarDataStaticProject> StaticProjects { get; set; }

        public WizarData()
        {
            StaticProjects = new List<WizarDataStaticProject>();
        }
    }

    public class WizarDataStaticProject
    {
        public bool IsFramework { get; set; }
        public bool IsTemplate { get; set; }
        public string SolutionFolder { get; set; }
        public string Folder { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
