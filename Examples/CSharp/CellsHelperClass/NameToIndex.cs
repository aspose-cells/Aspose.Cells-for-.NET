using System;

namespace Aspose.Cells.Examples.CellsHelperClass
{
    public class NameToIndex
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            string name = "C4";
            int row;
            int column;
            Aspose.Cells.CellsHelper.CellNameToIndex(name, out row, out column);
            Console.WriteLine("Row: {0}, Column: {1}", row, column);
            //ExEnd:1

        }
    }
}
