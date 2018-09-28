using System.IO;
using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp._CellsHelper
{
    public class CreateSafeSheetNames
    {

        public static void Main()
        {
            // Long name will be truncated to 31 characters
            string name1 = CellsHelper.CreateSafeSheetName("this is first name which is created using CellsHelper.CreateSafeSheetName and truncated to 31 characters");

            // Any invalid character will be replaced with _
            string name2 = CellsHelper.CreateSafeSheetName(" <> + (adj.Private ? \" Private\" : \")", '_');//? shall be replaced with _

            // Display first name
            Console.WriteLine(name1);

            //Display second name
            Console.WriteLine(name2);

            Console.WriteLine("CreateSafeSheetNames executed successfully.");
        }
    }
}
