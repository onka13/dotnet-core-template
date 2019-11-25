using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WF = System.Windows.Forms;

namespace CoreTemplateExtensionLibrary.UI
{
    /// <summary>
    /// Interaction logic for RootWizardForm.xaml
    /// </summary>
    public partial class RootWizardForm : UserControl
    {
        Window _window;
        public bool IsCancelled { get; set; } = false;

        public RootWizardForm()
        {
            InitializeComponent();
        }

        public void Display(string commonProjectPath)
        {
            xCommonProject.Text = commonProjectPath;
            Window window = new Window
            {
                Content = this,
                ResizeMode = ResizeMode.NoResize,
                WindowStyle = WindowStyle.None
            };
            _window = window;
            window.ShowDialog();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            IsCancelled = true;
            _window.Close();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            var dataProjectPath = System.IO.Path.Combine(xCommonProject.Text, "CoreCommon.Data.Domain");
            if (!Directory.Exists(dataProjectPath))
            {
                WF.MessageBox.Show("Common project not found");
                return;
            }
            _window.Close();
        }

        private void CommonProjectDialog_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new WF.FolderBrowserDialog();
            //dialog.RootFolder = Environment.SpecialFolder.Desktop;
            dialog.SelectedPath = xCommonProject.Text;
            if (dialog.ShowDialog() != WF.DialogResult.OK) return;
            xCommonProject.Text = dialog.SelectedPath;
        }

        public string GetCommonProjectPath()
        {
            return xCommonProject.Text;
        }

        private void CommonProject_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void CommonProjectClone_Click(object sender, RoutedEventArgs e)
        {
            var dir = new DirectoryInfo(xCommonProject.Text).Parent.FullName;
            if (!Directory.Exists(dir))
            {
                WF.MessageBox.Show("Directory not found");
                return;
            }

            var startInfo = new ProcessStartInfo
            {
                WorkingDirectory = dir,
                FileName = "cmd.exe",
                Arguments = "/K git clone https://github.com/onka13/dotnet-core-common"
            };
            Process.Start(startInfo);
        }

        private void Header_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                _window.DragMove();
        }
    }
}
