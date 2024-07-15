using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
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
using System.Diagnostics;

namespace sticky_notes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private Point _lastMousePosition;
        public string? OpenedFile
        { get; private set; }
        public MainWindow()
        { 
            InitializeComponent();
            OpenedFile = null;
        }

        public void CheckKeyStrokes(object sender, KeyEventArgs e)
        {
            if(((Keyboard.GetKeyStates(Key.LeftCtrl) & KeyStates.Down) > 0) || ((Keyboard.GetKeyStates(Key.RightCtrl) & KeyStates.Down) > 0))
            {
                
                if((Keyboard.GetKeyStates(Key.O) & KeyStates.Down) > 0)
                {
                    ActuallyOpenFile();
                } else if((Keyboard.GetKeyStates(Key.S) & KeyStates.Down) > 0)
                {
                    if((Keyboard.GetKeyStates(Key.LeftShift) & KeyStates.Down) > 0 || (Keyboard.GetKeyStates(Key.RightShift) & KeyStates.Down) > 0 )
                    {
                        SaveAsFile(null, null);
                    } else{
                        SaveFile(null, null);
                    }
                } 
            }
        }
        public void OpenFile(object sender, RoutedEventArgs e)
        {
            ActuallyOpenFile();
        }

        
        private void ActuallyOpenFile()
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Sticky Note Files (*.skn)|*.skn";

            bool? result = openFileDialog.ShowDialog();

            if(result == true)
            {
                OpenedFile = openFileDialog.FileName;
                using (StreamReader oldStickyNote = File.OpenText(OpenedFile))
                {
                    // TestTextBox.Text = oldStickyNote.ReadToEnd();
                }
            } 
        }
        
        public void SaveFile(object? sender, RoutedEventArgs? e)
        {
            if(OpenedFile == null)
            {
                SaveAsFile(null, null);
            } else
            {
                using(var writer = new StreamWriter(OpenedFile))
                {
                    // writer.Write(TestTextBox.Text);
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
                // writer.Write(TestTextBox.Text);
            }
        }

        private void NewNote(object sender, RoutedEventArgs e)
        {
            NewNoteDialog w = new NewNoteDialog();
            w.Owner = this;
            bool? success = w.ShowDialog();
            if(success == true)
            {
                Grid newNote = new Grid();
                newNote.Height = 150;
                newNote.Width = 150;
                newNote.Background = PickBrush();
                RowDefinition r0 = new RowDefinition();
                RowDefinition r1 = new RowDefinition();
                newNote.RowDefinitions.Add(r0);
                newNote.RowDefinitions.Add(r1);
                r0.Height = new GridLength(15);
                r1.Height = new GridLength(newNote.Height-10);
                newNote.MouseMove += new MouseEventHandler(MoveNote);
                newNote.MouseDown += new MouseButtonEventHandler(ClickNote);
                Canvas.SetTop(newNote, 0);
                Canvas.SetLeft(newNote, 0);
                NotesCanvas.Children.Add(newNote);

                TextBlock text = new TextBlock();
                text.Text = w.Text;
                text.Width = 150;
                text.Height = newNote.Height - 10;
                text.TextWrapping = TextWrapping.Wrap;
                text.TextAlignment = TextAlignment.Center;
                Grid.SetRow(text, 1);
                newNote.Children.Add(text);

                Grid topRow = new Grid();
                ColumnDefinition c0 = new ColumnDefinition();
                ColumnDefinition c1 = new ColumnDefinition();
                c1.Width = r0.Height;
                topRow.ColumnDefinitions.Add(c0);
                topRow.ColumnDefinitions.Add(c1);
                Grid.SetRow(topRow, 0);
                newNote.Children.Add(topRow);

                Button deleteButton = new Button();
                deleteButton.Click += new RoutedEventHandler(DeleteNote);
                deleteButton.Content = "X";
                deleteButton.Width = deleteButton.Height;
                deleteButton.Background = Brushes.DarkRed;
                deleteButton.FontSize = 9;
                deleteButton.Foreground = Brushes.White;
                Grid.SetColumn(deleteButton, 1);
                topRow.Children.Add(deleteButton);
            }
        }

        private void ClickNote(object sender, MouseEventArgs e)
        {
            Grid c = sender as Grid;
            if(c != null)
            {
                _lastMousePosition = Mouse.GetPosition(NotesCanvas);
            }
        }
        private void MoveNote(object sender, MouseEventArgs e)
        {
            Grid c = sender as Grid;
            if(c != null)
            {
                if(Mouse.LeftButton == MouseButtonState.Pressed)
                {
                    Point p = Mouse.GetPosition(NotesCanvas);
                    double top = Canvas.GetTop(c);
                    double left = Canvas.GetLeft(c);
                    Canvas.SetTop(c, Math.Max(0, top + (p.Y - _lastMousePosition.Y)));
                    Canvas.SetLeft(c, left + (p.X - _lastMousePosition.X));
                    _lastMousePosition = p;
                }
            }
        }

        private Brush PickBrush()
{
            Brush result = Brushes.Transparent;

            Random rnd = new Random();

            Type brushesType = typeof(Brushes);

            PropertyInfo[] properties = brushesType.GetProperties();

            int random = rnd.Next(properties.Length);
            result = (Brush)properties[random].GetValue(null, null);

            return result;
        }

        private void DeleteNote(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            if(b != null)
            {
                FrameworkElement row = b.Parent as FrameworkElement;
                if(row != null)
                {
                    UIElement note = row.Parent as UIElement;
                    if(note != null)
                    {
                        NotesCanvas.Children.Remove(note);
                    }
                    
                }
            }
        }
    }
}
