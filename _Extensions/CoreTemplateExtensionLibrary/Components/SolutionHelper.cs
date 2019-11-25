using System;
using System.Collections.Generic;
using System.Linq;
using EnvDTE;
using EnvDTE80;
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;
using Newtonsoft.Json.Linq;

namespace CoreTemplateExtensionLibrary.Components
{
    public class SolutionHelper
    {
        private static DTE _dteObj;
        private static List<Project> allProjects;
        private static List<SolutionFolder> allFolders;
        static string vsProjectKindSolutionFolder = "{66A26720-8FB5-11D2-AA7E-00C04F688DDE}";

        public static void SetDTE(EnvDTE.DTE dte)
        {
            _dteObj = dte;
        }

        public static void Clear()
        {
            allProjects = null;
            allFolders = null;
        }

        public static Solution GetSolution()
        {
            return _dteObj?.Solution ?? new Solution();
        }

        public static Project GetProject(string projectName)
        {
            foreach (Project project in IterateCustomProjects())
            {
                //Console.WriteLine(project.Name + " " + project.FileName);
                if (project.Name == projectName)
                {
                    return project;
                }
            }
            return null;
        }

        public static Project[] IterateCustomProjects()
        {
            if (allProjects != null)
            {
                return allProjects.ToArray();
            }
            allProjects = GetAllProjects();

            return allProjects.ToArray();
        }

        public static Project[] IterateCustomProjects(ProjectItems projectItems)
        {
            List<Project> projects = new List<Project>();
            try
            {
                foreach (ProjectItem item in projectItems)
                {
                    if (item.Kind.Equals(vsProjectKindSolutionFolder, StringComparison.OrdinalIgnoreCase))
                    {
                        var items = IterateCustomProjects(item.ProjectItems);
                        if (items.Count() > 0)
                            projects.AddRange(items);
                    }
                    else
                    {
                        if (item.Object is Project)
                        {
                            projects.Add((Project)item.Object);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("hata:" + ex.Message);
            }
            return projects.ToArray();
        }

        public static List<ProjectItem> GetProjectItems(ProjectItems projectItems)
        {
            List<ProjectItem> response = new List<ProjectItem>();

            if (projectItems == null)
                return null;

            foreach (ProjectItem projectItem in projectItems)
            {
                if (projectItem.ProjectItems == null || projectItem.ProjectItems.Count == 0)
                {
                    response.Add(projectItem);
                }
                else
                {
                    response.AddRange(GetProjectItems(projectItem.ProjectItems));
                }
            }

            return response;
        }

        public static List<CodeClass> GetClasses(Project project)
        {
            var items = new List<CodeClass>();
            foreach (CodeElement element in project.CodeModel.CodeElements)
            {
                if (element.Kind == vsCMElement.vsCMElementClass)
                {
                    var myClass = (CodeClass)element;
                    items.Add(myClass);
                }
            }
            return items;
        }

        public static CodeElement GetElement(Project project, vsCMElement type, string itemName)
        {
            var item = GetSolution().FindProjectItem(itemName);
            if (item == null)
            {
                return null;
            }
            foreach (CodeElement element in item.FileCodeModel.CodeElements)
            {
                var codeElement = GetCodeElement(element, type, itemName);
                if (codeElement != null)
                {
                    return codeElement;
                }
            }
            return null;
        }

        public static CodeElement GetCodeElement(CodeElement codeElement, vsCMElement type, string itemName)
        {
            if (codeElement == null)
            {
                return null;
            }
            if (codeElement.Kind == type && codeElement.Name == itemName.Replace(".cs", ""))
            {
                return codeElement;
            }

            CodeElements colCodeElements = null;
            if (codeElement.Kind == vsCMElement.vsCMElementFunction)
            {
                var objCodeFunction = (CodeFunction)codeElement;
                colCodeElements = (objCodeFunction.Parameters);
            }
            else if (codeElement.Kind == vsCMElement.vsCMElementNamespace)
            {
                var objCodeNamespace = (CodeNamespace)codeElement;
                colCodeElements = objCodeNamespace.Members;
            }
            else if (codeElement is CodeType)
            {
                var objCodeType = (CodeType)codeElement;
                colCodeElements = (objCodeType.Members);
            }

            if (colCodeElements != null)
            {
                foreach (CodeElement element in colCodeElements)
                {
                    var item = GetCodeElement(element, type, itemName);
                    if (item != null)
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        public static void SaveFile(string projectFolder, string fileName, string output, bool dontOverride = false)
        {
            var folderPath = projectFolder;

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (!Path.HasExtension(fileName))
                fileName += ".cs";

            if (dontOverride && File.Exists(folderPath + "\\" + fileName))
                return;

            File.WriteAllText(folderPath + "\\" + fileName, output, System.Text.Encoding.UTF8);
        }

        public static void SaveFile(Project project, string subFolder, string fileName, string output, bool dontOverride = false)
        {
            string projectFolder = Path.GetDirectoryName(project.FileName);
            var folderPath = projectFolder;

            if (!string.IsNullOrEmpty(subFolder))
            {
                folderPath += "\\" + subFolder;
            }

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (!Path.HasExtension(fileName))
                fileName += ".cs";

            if (dontOverride && File.Exists(folderPath + "\\" + fileName))
                return;

            File.WriteAllText(folderPath + "\\" + fileName, output, System.Text.Encoding.UTF8);

            project.ProjectItems.AddFromFile(folderPath + "\\" + fileName);
        }

        public static string FindConfigFile(Project project)
        {
            foreach (ProjectItem item in project?.ProjectItems)
            {
                if (Regex.IsMatch(item.Name, "(app|web).config", RegexOptions.IgnoreCase))
                    return item.get_FileNames(0);
            }
            return null;
        }

        public static string FindConfigJsonFile(Project project)
        {
            foreach (ProjectItem item in project?.ProjectItems)
            {
                if (Regex.IsMatch(item.Name, "(appsettings|settings).json", RegexOptions.IgnoreCase))
                    return item.get_FileNames(0);
            }
            return null;
        }

        public static Dictionary<string, string> GetConfigJson(Project project)
        {
            var connectionStrings = new Dictionary<string, string>();

            var configFilePath = FindConfigJsonFile(project);

            if (configFilePath == null)
                return null;

            var json = File.ReadAllText(configFilePath);

            var config = JObject.Parse(json);

            foreach (var prop in (config["ConnectionStrings"] as JObject).Properties())
            {
                var provider = config["AppSettings"][prop.Name + "Provider"];
                var value = config["ConnectionStrings"][prop.Name].ToString();
                connectionStrings.Add(prop.Name + "-" + provider, value);
            }

            return connectionStrings;
        }

        public static List<Project> GetAllProjects()
        {
            Projects projects = GetSolution().Projects;
            List<Project> list = new List<Project>();
            var item = projects.GetEnumerator();
            while (item.MoveNext())
            {
                var project = item.Current as Project;
                if (project == null)
                {
                    continue;
                }

                if (project.Kind == vsProjectKindSolutionFolder)
                {
                    list.AddRange(GetSolutionFolderProjects(project));
                }
                else
                {
                    if (project.Name == "Miscellaneous Files")
                    {
                        continue;
                    }
                    list.Add(project);
                }
            }

            return list;
        }

        private static IEnumerable<Project> GetSolutionFolderProjects(Project solutionFolder)
        {
            List<Project> list = new List<Project>();
            for (var i = 1; i <= solutionFolder.ProjectItems.Count; i++)
            {
                var subProject = solutionFolder.ProjectItems.Item(i).SubProject;
                if (subProject == null)
                {
                    continue;
                }

                // If this is another solution folder, do a recursive call, otherwise add
                if (subProject.Kind == vsProjectKindSolutionFolder)
                {
                    list.AddRange(GetSolutionFolderProjects(subProject));
                }
                else
                {
                    list.Add(subProject);
                }
            }
            return list;
        }

        public static IList<SolutionFolder> GetAllProjectSolutionFolders()
        {
            if (allFolders != null)
                return allFolders;
            allFolders = new List<SolutionFolder>();
            foreach (Project childProject in GetSolution().Projects)
            {
                try
                {
                    if (string.IsNullOrEmpty(childProject.FileName))
                    {
                        var solutionFolder = (SolutionFolder)childProject.Object;

                        allFolders.Add(solutionFolder);
                        var subList = GetSolutionFolders(childProject);
                        if (subList.Count() > 0) allFolders.AddRange(subList);
                    }
                }
                catch (Exception ex)
                {
                }
            }

            return allFolders;
        }

        public static SolutionFolder GetSolutionFolder(string folderName)
        {
            if (string.IsNullOrEmpty(folderName)) return null;
            return GetAllProjectSolutionFolders().FirstOrDefault(x => x.Parent.Name == folderName);
        }

        private static IEnumerable<SolutionFolder> GetSolutionFolders(Project project)
        {
            List<SolutionFolder> list = new List<SolutionFolder>();
            for (var i = 1; i <= project.ProjectItems.Count; i++)
            {
                var subProject = project.ProjectItems.Item(i).SubProject;
                if (subProject == null)
                {
                    continue;
                }

                if (string.IsNullOrEmpty(subProject.FileName))
                {
                    var solutionFolder = (SolutionFolder)subProject.Object;
                    list.Add(solutionFolder);
                    var subList = GetSolutionFolders(subProject);
                    if (subList.Count() > 0) list.AddRange(subList);
                }
            }
            return list;
        }
    }
}
