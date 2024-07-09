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

namespace sticky_notes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class NewNoteDialog : Window
    {
        public string Text
        { get; private set; }
        public NewNoteDialog()
        {
            InitializeComponent();
        }

        public void CancelClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        public void NewClick(object sender, RoutedEventArgs e)
        {

            Text = NewNoteTextbox.Text;
            this.DialogResult = true;
            this.Close();
        }
    }
}
