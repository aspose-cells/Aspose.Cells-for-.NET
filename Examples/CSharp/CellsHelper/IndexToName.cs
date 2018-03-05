using System;

namespace Aspose.Cells.Examples.CSharp._CellsHelper
{
    public class IndexToName
    {
        public static void Run()
        {
            int row = 3;
            int column = 5;
            string name = Aspose.Cells.CellsHelper.CellIndexToName(row, column);
            Console.WriteLine("Cell name: {0}", name);

            Console.WriteLine("IndexToName executed successfully.");
        }
    }
}
