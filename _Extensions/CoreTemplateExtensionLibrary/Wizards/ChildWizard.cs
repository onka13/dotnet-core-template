using System.Collections.Generic;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace CoreTemplateExtensionLibrary.Wizards
{
    public class ChildWizard : IWizard
    {
        // Retrieve global replacement parameters
        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            // Add custom parameters.
            replacementsDictionary.Add("$saferootprojectname$", RootWizard.GlobalDictionary["$saferootprojectname$"]);
            replacementsDictionary.Add("$custommessage$", RootWizard.GlobalDictionary["$custommessage$"]);

            //foreach (var property in RootWizard.Settings.GetType().GetProperties())
            //{
            //    replacementsDictionary.Add("$" + property.Name + "$", (property.GetValue(RootWizard.Settings) ?? "").ToString());
            //}
        }

        public void RunFinished()
        {
        }

        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void ProjectFinishedGenerating(Project project)
        {
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
        }
    }
}
