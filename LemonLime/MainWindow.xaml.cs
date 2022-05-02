using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace LemonLime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            SizeChanged += OnWindowSizeChanged;
        }


        private void OnWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            double newWindowHeight = e.NewSize.Height;
            double newWindowWidth = e.NewSize.Width;
            MainTextEditor.Height = newWindowHeight-35;
            MainTextEditor.Width = newWindowWidth;
        }

        private (string, string) openNewFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
                return (File.ReadAllText(openFileDialog.FileName), Path.GetFileName(openFileDialog.FileName));
            return (null, null);
        }
        
        private void NewFileHead(string filename)
        {
            Header.Children.Remove(AddNewButton);
            Button dynamicFileButton = new Button
            {
                Width = 70,
                Height = 30,
                Content = filename,
                HorizontalAlignment = HorizontalAlignment.Left,
            };
            dynamicFileButton.Click += DynamicFile_OnClick;
            Header.Children.Add(dynamicFileButton);
            Header.Children.Add(AddNewButton);
        }
        private void AddNewButton_OnClick(object sender, RoutedEventArgs e)
        {
            (string, string) fileData = openNewFile();
            NewFileHead(fileData.Item2);
            MainTextEditor.Text = fileData.Item1;
        }

        private void DynamicFile_OnClick(object sender, RoutedEventArgs e)
        {
            MainTextEditor.Text = "works";
        } 
    }
}