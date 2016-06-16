using System;

namespace Aspose.Cells.Examples.CSharp.CellsHelperClass
{
    public class IndexToName
    {
        public static void Run()
        {
            // ExStart:1
            int row = 3;
            int column = 5;
            string name = Aspose.Cells.CellsHelper.CellIndexToName(row, column);
            Console.WriteLine("Cell name: {0}", name);
            // ExEnd:1
        }
    }
}
