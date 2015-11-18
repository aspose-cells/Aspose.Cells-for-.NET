using System;

namespace Aspose.Cells.Examples.Articles
{
    class CheckVbaProjectSigned
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            Workbook workbook = new Workbook(dataDir + "Sample1.xlsx");
            Console.WriteLine("VBA Project is Signed: " + workbook.VbaProject.IsSigned);
        }
    }
}
