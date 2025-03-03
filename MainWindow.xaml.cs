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

        private UIElement? LastInteractedNote;

        public MainWindow()
        { 
            InitializeComponent();
            OpenedFile = null;
            LastInteractedNote = null;
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
            
            if(result == true && File.Exists(openFileDialog.FileName))
            {
                NotesCanvas.Children.Clear();
                OpenedFile = openFileDialog.FileName;
                using (StreamReader oldStickyNote = File.OpenText(OpenedFile))
                {
                    string allNotes = oldStickyNote.ReadToEnd();
                    if(allNotes.Length > 0)
                    {
                        string[] splittedNotes = allNotes.Split("#", allNotes.Length, StringSplitOptions.TrimEntries);
                        for(int i = 1; i < splittedNotes.Length; i  += 4 )
                        {
                            byte[] argb = StringToByteArray(splittedNotes[i]);                            double left, top;
                            double.TryParse(splittedNotes[i+2], out top);
                            double.TryParse(splittedNotes[i+1], out left);
                            AddNote(new SolidColorBrush(System.Windows.Media.Color.FromArgb(argb[0], argb[1], argb[2], argb[3])) , splittedNotes[i+3], left, top);
                        }
                    }
                }
            } 
        }
        
        public static byte[] StringToByteArray(string hex) 
        {
            return Enumerable.Range(0, hex.Length)
                            .Where(x => x % 2 == 0)
                            .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                            .ToArray();
        }
        public void SaveFile(object? sender, RoutedEventArgs? e)
        {
            if(OpenedFile == null)
            {
                SaveAsFile(sender, e);
            } else
            {
                ActuallySaveFile();
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
            if(File.Exists(OpenedFile))
            {
                using(StreamWriter writer = new StreamWriter(OpenedFile, false))
                {
                    string toBeSaved = "";
                    foreach(UIElement note in NotesCanvas.Children)
                    {
                        Grid? next = note as Grid;
                        if(next != null)
                        {
                            string temp = ((SolidColorBrush)next.Background).Color.ToString();
                            foreach(UIElement child in next.Children)
                            {
                                if(child is TextBlock)
                                {
                                    double left, top;
                                    left = Canvas.GetLeft(next);
                                    top = Canvas.GetTop(next);
                                    temp = temp +  "#" + left.ToString() + "#" + top.ToString() + "#" + ((TextBlock)child).Text;
                                    break;
                                }
                            }
                            toBeSaved += temp;
                        }
                    }
                    writer.Write(toBeSaved);
                }
            }
        }

        private void NewNote(object sender, RoutedEventArgs e)
        {
            NewNoteDialog w = new NewNoteDialog();
            w.Owner = this;
            bool? success = w.ShowDialog();
            if(success == true)
            {
                AddNote(w.BrushColor, w.Text.Replace('#', ' '), 0, 0);
            }
        }

        private void ClickNote(object sender, MouseEventArgs e)
        {
            Grid? c = sender as Grid;
            if(c != null)
            {
                LastInteractedNote = c;
                _lastMousePosition = Mouse.GetPosition(NotesCanvas);
                int oldZPos = Canvas.GetZIndex(c);
                Canvas.SetZIndex(c, Canvas.GetZIndex(LastInteractedNote));
                Canvas.SetZIndex(LastInteractedNote, Canvas.GetZIndex(LastInteractedNote) - 1);
                foreach ( UIElement child in NotesCanvas.Children )
                {
                    if(Canvas.GetZIndex(child) >= oldZPos && child != c)
                    {
                        Canvas.SetZIndex(child, Canvas.GetZIndex(child) - 1);
                    }
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if(LastInteractedNote is Panel)
            {
                if(Mouse.LeftButton == MouseButtonState.Pressed)
                {
                    Point p = Mouse.GetPosition(NotesCanvas);
                    double top = Canvas.GetTop(LastInteractedNote);
                    double left = Canvas.GetLeft(LastInteractedNote);
                    Canvas.SetTop(LastInteractedNote, Math.Max(0, top + (p.Y - _lastMousePosition.Y)));
                    Canvas.SetLeft(LastInteractedNote, left + (p.X - _lastMousePosition.X));
                    _lastMousePosition = p;
                }
            }
        }



        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            LastInteractedNote = null;
        }

        //         private Brush PickBrush()
        // {
        //             Brush result = Brushes.Transparent;

        //             Random rnd = new Random();

        //             Type brushesType = typeof(Brushes);

        //             PropertyInfo[] properties = brushesType.GetProperties();

        //             int random = rnd.Next(properties.Length);
        //             result = (Brush)properties[random].GetValue(null, null);

        //             return result;
        //         }

        private void DeleteNote(object sender, RoutedEventArgs e)
        {
            Button? b = sender as Button;
            if(b != null)
            {
                FrameworkElement? row = b.Parent as FrameworkElement;
                if(row != null)
                {
                    UIElement? note = row.Parent as UIElement;
                    if(note != null)
                    {
                        NotesCanvas.Children.Remove(note);
                    }
                    
                }
            }
        }

        private void AddNote(Brush b, string s, double left, double top)
        {
            Grid newNote = new Grid();
            newNote.Height = 150;
            newNote.Width = 150;
            newNote.Background = b;
            RowDefinition r0 = new RowDefinition();
            RowDefinition r1 = new RowDefinition();
            newNote.RowDefinitions.Add(r0);
            newNote.RowDefinitions.Add(r1);
            r0.Height = new GridLength(15);
            r1.Height = new GridLength(newNote.Height-10);
           newNote.MouseDown += new MouseButtonEventHandler(ClickNote);
            Canvas.SetTop(newNote, top);
            Canvas.SetLeft(newNote, left);
            try 
            {
                Canvas.SetZIndex(newNote, Canvas.GetZIndex(LastInteractedNote) + 1);
            } catch (System.ArgumentNullException ex)
            {
                Canvas.SetZIndex(newNote, 1);
            }
            NotesCanvas.Children.Add(newNote);

            TextBlock text = new TextBlock();
            text.Text = s;
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

            LastInteractedNote = newNote;
        }
    }
}
