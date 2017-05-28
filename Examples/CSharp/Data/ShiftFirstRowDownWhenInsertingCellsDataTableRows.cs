using System;
using System.IO;

using Aspose.Cells;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Data
{
    public class ShiftFirstRowDownWhenInsertingCellsDataTableRows
    {
        //Implement ICellsDataTable interface 
        class CellsDataTable : ICellsDataTable
        {
            //This is the current row index
            int m_index = -1;

            //These are your column names
            static String[] colsNames = new String[] { "Pet", "Fruit", "Country", "Color" };

            //These are the data of each column
            static String[] col0data = new String[] { "Dog", "Cat", "Duck" };
            static String[] col1data = new String[] { "Apple", "Pear", "Banana" };
            static String[] col2data = new String[] { "UK", "USA", "China" };
            static String[] col3data = new String[] { "Red", "Green", "Blue" };

            //Combine all of the data into a single two dimensional array
            static String[][] colsData = new String[][] { col0data, col1data, col2data, col3data };

            //Leave this unimplemented because we do not need it
            public object this[string columnName]
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            //It will return the current item data of given column
            object ICellsDataTable.this[int columnIndex]
            {
                get
                {
                    Object o = null;
                    o = colsData[columnIndex][m_index];
                    return o;
                }
            }

            //It will return names of all the columns
            string[] ICellsDataTable.Columns
            {
                get
                {
                    return colsNames;
                }
            }

            //It will return the count of all the items
            int ICellsDataTable.Count
            {
                get
                {
                    return col0data.Length;
                }
            }

            //Set it -1
            void ICellsDataTable.BeforeFirst()
            {
                m_index = -1;
            }

            //Increase the row index by 1
            bool ICellsDataTable.Next()
            {
                m_index++;

                return true;
            }
        }

        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            //Create the instance of Cells Data Table
            CellsDataTable cellsDataTable = new CellsDataTable();

            //Load the sample workbook
            Workbook wb = new Workbook(sourceDir + "sampleImportTableOptionsShiftFirstRowDown.xlsx");

            //Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            //Import data table options
            ImportTableOptions opts = new ImportTableOptions();

            //We do now want to shift the first row down when inserting rows. 
            opts.ShiftFirstRowDown = false;

            //Import cells data table 
            ws.Cells.ImportData(cellsDataTable, 2, 2, opts);

            //Save the workbook
            wb.Save(outputDir + "outputImportTableOptionsShiftFirstRowDown-False.xlsx");
        }
    }
}