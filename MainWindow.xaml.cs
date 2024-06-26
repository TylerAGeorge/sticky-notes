using System;
using System.Collections.Generic;
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
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sticky_notes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public string? OpenedFile
        { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            OpenedFile = null;
            
        }


        public void OpenFile(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Sticky Note Files (*.skn)|*.skn";

            bool? result = openFileDialog.ShowDialog();

            if(result == true)
            {
                OpenedFile = openFileDialog.FileName;
                ActuallyOpenFile();
            }
        }

        private void ActuallyOpenFile()
        {
            using (StreamReader oldStickyNote = File.OpenText(OpenedFile))
            {
                TestTextBox.Text = oldStickyNote.ReadToEnd();
            }
        }
        
        public void SaveFile(object sender, RoutedEventArgs e)
        {
            if(OpenedFile == null)
            {
                SaveAsFile(null, null);
            } else
            {
                using(var writer = new StreamWriter(OpenedFile))
                {
                    writer.Write(TestTextBox.Text);
                }
            }
        }

        public void SaveAsFile(object? sender, RoutedEventArgs? e)
        {
            var saveAsFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveAsFileDialog.Filter = "Sticky Note Files (*.skn)|*.skn";

            bool? result = saveAsFileDialog.ShowDialog();

            if(result == true)
            {
                OpenedFile = saveAsFileDialog.FileName;
                ActuallySaveFile();
            }
        }

        private void ActuallySaveFile()
        {
            using(var writer = new StreamWriter(OpenedFile, false))
            {
                writer.Write(TestTextBox.Text);
            }
        }

        private void NewNote(object sender, RoutedEventArgs e)
        {
            ChildWindow w = new ChildWindow();
            w.Owner = this;
            w.ShowDialog();

        }
    }
}
