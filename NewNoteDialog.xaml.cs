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

        private Brush _brushColor;
        public string Text
        { get; private set; }

        public Brush BrushColor
        { get
        {
            if(_brushColor is Brush)
            {
                return _brushColor;
            }else{
                return new SolidColorBrush(Color.FromRgb(253, 255, 100));
            }
        }
         private set
         {
            _brushColor = value;
         } }

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

        public void SelectColor(object sender, RoutedEventArgs e)
        {
            RadioButton b = sender as RadioButton;
            if(b != null)
            {
                switch (b.Name[0])
                {
                    case 'Y':
                        BrushColor = new SolidColorBrush(Color.FromRgb(253, 255, 100));
                        break;
                    case 'P':
                        BrushColor = Brushes.Pink;
                        break;
                    case 'G':
                        BrushColor = new SolidColorBrush(Color.FromRgb(100, 255, 104));
                        break;
                    case 'O':
                        BrushColor = new SolidColorBrush(Color.FromRgb(255, 154, 50));
                        break;
                    case 'B':
                        BrushColor = new SolidColorBrush(Color.FromRgb(100, 197, 255));
                        break;
                }
            }
        }
    }
}
