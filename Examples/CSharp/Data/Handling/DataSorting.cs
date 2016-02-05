using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Data.Handling
{
    public class DataSorting
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Instantiate a new Workbook object.
            //Load a template file.
            Workbook workbook = new Workbook(dataDir + "book1.xls");

            //Get the workbook datasorter object.
            DataSorter sorter = workbook.DataSorter;

            //Set the first order for datasorter object.
            sorter.Order1 = Aspose.Cells.SortOrder.Descending;

            //Define the first key.
            sorter.Key1 = 0;

            //Set the second order for datasorter object.
            sorter.Order2 = Aspose.Cells.SortOrder.Ascending;

            //Define the second key.
            sorter.Key2 = 1;

            //Create a cells area (range).
            CellArea ca = new CellArea();

            //Specify the start row index.
            ca.StartRow = 0;

            //Specify the start column index.
            ca.StartColumn = 0;

            //Specify the last row index.
            ca.EndRow = 13;

            //Specify the last column index.
            ca.EndColumn = 1;

            //Sort data in the specified data range (A1:B14)
            sorter.Sort(workbook.Worksheets[0].Cells, ca);

            //Save the excel file.
            workbook.Save(dataDir + "output.out.xls");

            
        }
    }
}