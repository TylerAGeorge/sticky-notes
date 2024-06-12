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
        public MainWindow()
        {
            InitializeComponent();
        }

        public void OpenFile(object sender, RoutedEventArgs e)
        {
            ChildWindow w = new ChildWindow();
            w.ShowDialog();
        }
        
        public void SaveFile(object sender, RoutedEventArgs e)
        {
            ChildWindow w = new ChildWindow();
            w.Show();
        }

        public void SaveAsFile(object sender, RoutedEventArgs e)
        {
            ChildWindow w = new ChildWindow();
            w.ShowDialog();
        }

        private void NewNote(object sender, RoutedEventArgs e)
        {
            ChildWindow w = new ChildWindow();
            w.Owner = this;
            w.ShowDialog();

        }
    }
}
