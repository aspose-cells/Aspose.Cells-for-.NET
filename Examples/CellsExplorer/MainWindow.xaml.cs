using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using Aspose.Cells.Charts;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.IO;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Microsoft.Win32;
using Aspose.Cells.Tables;
using Aspose.Cells.Pivot;

namespace CellsExplorer
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

        private void MenuItem_Open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Please Select File";
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            openFileDialog.Filter = "Excel file|*.xlsx;*.xlsm;*.xlsb;*.xls;";
            openFileDialog.Multiselect = false;

            openFileDialog.ValidateNames = false;
            openFileDialog.CheckFileExists = false;
            openFileDialog.CheckPathExists = true;             

            bool? result = openFileDialog.ShowDialog();
            if (result != true)
            {
                return;
            }
            else
            {
                string[] files = openFileDialog.FileNames;
                foreach (string file in files)
                {
                    LoadExcelFile(file);
                }
            }
        }
        
        

        private void LoadExcelFile(string fileName)
        {
            Workbook wb = new Workbook(fileName);

            CellsNode rootNode = new CellsNode();
            rootNode.NodeName = "Workbook";
            rootNode.NodeContent = wb.FileName;
            rootNode.NodeType = CellsNodeType.RootNode;
            rootNode.ChildList = new ObservableCollection<CellsNode>();

            WorksheetCollection sheets = wb.Worksheets;
            int sheetCount = sheets.Count;

            CellsNode sheetsNode = new CellsNode();
            sheetsNode.NodeName = "Worksheets";
            sheetsNode.NodeContent = "Worksheet count: " + sheetCount; ;
            sheetsNode.NodeType = CellsNodeType.RootNode;
            sheetsNode.ChildList = new ObservableCollection<CellsNode>();

            rootNode.AddChild(sheetsNode);
            
            for (int i = 0; i < sheetCount; i++)
            {
                AddWorksheetNodes(sheets[i], sheetsNode);
            }

            leftTree.ItemsSource = new ObservableCollection<CellsNode> { rootNode };
        }

        private void AddWorksheetNodes(Worksheet sheet, CellsNode parent)
        {
            CellsNode sheetNode = new CellsNode();
            sheetNode.NodeName = sheet.Name;
            sheetNode.NodeContent = CellsNodeContentUtil.GetWorksheetNodeContent(sheet);
            sheetNode.NodeType = CellsNodeType.StructureNode;
            sheetNode.ChildList = new ObservableCollection<CellsNode>();
            parent.AddChild(sheetNode);


            WorksheetUtil sheetUtil = new WorksheetUtil(sheet, sheetNode);
            sheetUtil.AddWorksheetNode();            
        }


        private void leftTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            CellsNode currItem = (CellsNode)e.NewValue;
            this.rightTextBlock.Text = currItem.NodeContent;
        }

        private void MenuItem_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_ExpandAll(object sender, RoutedEventArgs e)
        {
            if (this.leftTree.Items != null && this.leftTree.Items.Count > 0)
            {
                foreach (var item in this.leftTree.Items)
                {
                    DependencyObject dependencyObject = this.leftTree.ItemContainerGenerator.ContainerFromItem(item);
                    if (dependencyObject != null)
                    {
                        ((TreeViewItem)dependencyObject).ExpandSubtree();
                    }
                }
            }
        }

        private void MenuItem_CollapseAll(object sender, RoutedEventArgs e)
        {
            foreach (var item in this.leftTree.Items)
            {
                DependencyObject dObject = this.leftTree.ItemContainerGenerator.ContainerFromItem(item);
                CollapseTreeviewItems(((TreeViewItem)dObject));
            }

            this.leftTree.UpdateLayout();
        }

        private void CollapseTreeviewItems(TreeViewItem Item)
        {
            Item.IsExpanded = false;

            foreach (var item in Item.Items)
            {
                DependencyObject dObject = this.leftTree.ItemContainerGenerator.ContainerFromItem(item);

                if (dObject != null)
                {
                    ((TreeViewItem)dObject).IsExpanded = false;

                    if (((TreeViewItem)dObject).HasItems)
                    {
                        CollapseTreeviewItems(((TreeViewItem)dObject));
                    }
                }
            }
        }
        
    }
}
