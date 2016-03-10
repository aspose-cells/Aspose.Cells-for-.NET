using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Tables
{
    public class CreatingListObject
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Create a Workbook object.
            //Open a template excel file.
            Workbook workbook = new Workbook(dataDir + "book1.xls");

            //Get the List objects collection in the first worksheet.
            Aspose.Cells.Tables.ListObjectCollection listObjects = workbook.Worksheets[0].ListObjects;

            //Add a List based on the data source range with headers on.
            listObjects.Add(1, 1, 7, 5, true);

            //Show the total row for the List.
            listObjects[0].ShowTotals = true;

            //Calculate the total of the last (5th ) list column.

            listObjects[0].ListColumns[4].TotalsCalculation = Aspose.Cells.Tables.TotalsCalculation.Sum;

            //Save the excel file.
            workbook.Save(dataDir + "ouput.out.xls");
            //ExEnd:1

        }
    }
}
