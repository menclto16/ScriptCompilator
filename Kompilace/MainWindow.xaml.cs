using System;
using System.Collections.Generic;
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
using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.Win32;

namespace Kompilace
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ScriptApp ScriptApp = new ScriptApp();
        private List<string> filenames = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRunScripts_Click(object sender, RoutedEventArgs e)
        {
            List<string> returnValues = ScriptApp.RunAll();

            foreach (var returnValue in returnValues)
            {
                lbScriptsReturnValues.Items.Add(System.IO.Path.GetFileName(returnValue));
            }
        }
        private void btnOpenScripts_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filename in openFileDialog.FileNames)
                {
                    filenames.Add(System.IO.Path.GetFileName(filename));
                    lbScripts.Items.Add(System.IO.Path.GetFileName(filename));
                }
            }

            ScriptApp.AddScriptFiles(filenames);
        }
    }
}
