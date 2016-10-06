using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace UsingGridDesktopInWpf
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

        private void WindowsFormsHost_Loaded(object sender, RoutedEventArgs e)
        {
            // ExStart:UsingGridDesktopInWpf
            // The path to the documents directory.
            string dataDir = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            using (var stream = new MemoryStream(System.IO.File.ReadAllBytes(dataDir + "SampleBook.xlsx")))
            {
                this.grid.ImportExcelFile(stream);
                this.grid.ExportExcelFile(dataDir + "SampleOutput_out_.xlsx");
            }
            // ExEnd:UsingGridDesktopInWpf
        }
    }
}
