using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Linq;

namespace MSNLogParser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string originalFilename;

        public MainWindow()
        {
            InitializeComponent();
            SaveButton.IsEnabled = false;
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog { DefaultExt = ".xml" };

            var result = dlg.ShowDialog();

            if (result == true)
            {
                originalFilename = dlg.FileName;
                
                // Cleanup!
                SaveButton.IsEnabled = true;
                this.Title = string.Format("MSN Log Parser - {0}", Path.GetFileName(originalFilename));
                OutputBox.Clear();
                
                // Parse XML
                var doc = XDocument.Load(originalFilename);
                var msgs = from msg in doc.Descendants("Message")
                           select msg;
                foreach (var msg in msgs)
                {
                    try
                    {
                        var dt = DateTime.Parse(msg.Attribute("DateTime").Value);
                        var user = msg.Element("From").Element("User").Attribute("FriendlyName").Value.Split(' ')[0];
                        var txt = msg.Element("Text").Value;

                        OutputBox.AppendText(String.Format("[{0}] <{1}> {2}\r\n", dt.ToString("yyyy-MM-dd H:mm:ss"), user, txt));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("Whoops! {0}", ex.Message));
                    }
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var isolatedFilename = Path.GetFileName(originalFilename);
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog
            {
                FileName = isolatedFilename.Substring(0, isolatedFilename.LastIndexOf(".")),
                DefaultExt = ".txt",
                Filter = "Text documents (.txt)|*.txt"
            };

            var result = dlg.ShowDialog();

            if (result == true)
            {
                var filename = dlg.FileName;
                File.WriteAllText(filename, OutputBox.Text);
                MessageBox.Show(string.Format("{0} saved!", filename));
            }
        }
    }
}
