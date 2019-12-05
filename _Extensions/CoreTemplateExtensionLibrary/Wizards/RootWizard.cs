using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.VisualStudio.TemplateWizard;
using System.Windows.Forms;
using CoreTemplateInstaller.UI;
using Thread = System.Threading.Thread;
using EnvDTE;
using CoreTemplateExtensionLibrary.Models;
using CoreTemplateExtensionLibrary.Components;
using CoreTemplateExtensionLibrary.UI;
using System.Threading;
using VSLangProj;

namespace CoreTemplateExtensionLibrary.Wizards
{
    public class RootWizard : IWizard
    {
        private RootWizardForm inputForm;
        // Use to communicate $saferootprojectname$ to ChildWizard
        public static Dictionary<string, string> GlobalDictionary = new Dictionary<string, string>();
        Dictionary<string, string> _replacementsDictionary;

        private EnvDTE.DTE _dte;
        private string _destinationDirectory;
        private string _solutiondirectory;
        string _vsixFilePath;

        public static WizarData WizarData;
        string commonProjectFolder;

        // Add global replacement parameters
        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            _replacementsDictionary = replacementsDictionary;
            GlobalDictionary["$saferootprojectname$"] = replacementsDictionary["$safeprojectname$"];
            GlobalDictionary["$custommessage$"] = "";

            if (replacementsDictionary["$solutiondirectory$"] != replacementsDictionary["$destinationdirectory$"])
            {

            }

            try
            {
                // Display a form to the user. The form collects 
                // input for the custom message.

                commonProjectFolder = Path.Combine(new DirectoryInfo(replacementsDictionary["$solutiondirectory$"]).Parent.FullName, "dotnet-core-common");

                inputForm = new RootWizardForm();
                inputForm.Display(commonProjectFolder);

                if (inputForm.IsCancelled)
                {
                    throw new WizardBackoutException();
                }

                commonProjectFolder = inputForm.GetCommonProjectPath();

                //foreach (var property in Settings.GetType().GetProperties())
                //{
                //    GlobalDictionary["$" + property.Name + "$"] = (property.GetValue(Settings) ?? "").ToString();
                //}

                _dte = automationObject as DTE;
                _destinationDirectory = replacementsDictionary["$destinationdirectory$"];
                _solutiondirectory = replacementsDictionary["$solutiondirectory$"];
                _vsixFilePath = Path.GetDirectoryName(customParams[0].ToString());

                InitWizardData(replacementsDictionary["$wizarddata$"]);
            }
            //catch (WizardCancelledException)
            //{
            //    throw;
            //}
            catch (Exception ex)
            {
                if (ex is WizardBackoutException)
                {
                    Cleanup(replacementsDictionary["$destinationdirectory$"]);
                    throw;
                }
                MessageBox.Show(ex + Environment.NewLine + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new WizardCancelledException("Wizard Exception", ex);
            }
        }

        public void RunFinished()
        {
            SolutionHelper.SetDTE(_dte);

            foreach (var staticProject in WizarData.StaticProjects)
            {
                var projectFile = "";
                if (staticProject.IsFramework)
                {
                    projectFile = commonProjectFolder;
                }
                else if (staticProject.IsTemplate)
                {
                    projectFile = _vsixFilePath;
                }

                projectFile = Path.Combine(projectFile, staticProject.Path);

                try
                {
                    var solutionFolder = SolutionHelper.GetSolutionFolder(staticProject.SolutionFolder);

                    Project project;
                    if (staticProject.IsTemplate)
                    {
                        staticProject.Name = Replace(staticProject.Name);
                        var projectDestinationFolderPath = Path.Combine(_solutiondirectory, staticProject.Folder, staticProject.Name);
                        
                        if (solutionFolder != null)
                            project = solutionFolder.AddFromTemplate(projectFile, projectDestinationFolderPath, staticProject.Name);
                        else
                            project = _dte.Solution.AddFromTemplate(projectFile, projectDestinationFolderPath, staticProject.Name);
                    }
                    else
                    {
                        if (solutionFolder != null)
                            project = solutionFolder.AddFromFile(projectFile);
                        else
                            project = _dte.Solution.AddFromFile(projectFile);
                    }
                    // TODO: fix project references
                    //VSProject vsProj = (VSProject)project.Object;
                    //vsProj.References.AddProject()
                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:!\n" + projectFile + " \n" + ex.Message);
                }
            }
            ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(Cleanup), _destinationDirectory);
        }

        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void ProjectFinishedGenerating(Project project)
        {
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            bool ok = true;
            return ok;
        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
        }

        private void InitWizardData(string wizardData)
        {
            WizarData = new WizarData();

            var xml = XElement.Parse(wizardData);
            foreach (XElement mapElem in xml.Elements().Where(x => x.Name.LocalName.Equals("StaticProject")))
            {
                WizarData.StaticProjects.Add(new WizarDataStaticProject
                {
                    Name = mapElem.Attribute("name")?.Value,
                    Folder = mapElem.Attribute("folder")?.Value,
                    SolutionFolder = mapElem.Attribute("solutionFolder")?.Value,
                    Path = mapElem.Attribute("path")?.Value,
                    IsFramework = Convert.ToBoolean(mapElem.Attribute("framework")?.Value),
                    IsTemplate = Convert.ToBoolean(mapElem.Attribute("template")?.Value),
                });
            }
        }

        private void Cleanup(object oDir)
        {
            System.Threading.Thread.Sleep(2000);

            var dir = (string)oDir;
            if (
                 Directory.Exists(dir) &&
                !Directory.EnumerateFileSystemEntries(dir).Any()
                )
            {
                Directory.Delete(dir);
            }
        }

        string Replace(string txt)
        {
            foreach (var item in _replacementsDictionary)
            {
                txt = txt.Replace(item.Key, item.Value);
            }
            return txt;
        }
    }
}
