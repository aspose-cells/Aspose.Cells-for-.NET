using Aspose.Cells;

namespace Aspose_Cells
{
    class Program
    {
        static void Main(string[] args)
        {
            //Specify the template excel file path.
            string myPath = "Book1.xls";

            //Instantiate a new Workbook.
            //Open the excel file.
            Workbook workbook = new Workbook(myPath);

            //Protect the workbook specifying a password with Structure and Windows attributes.
            workbook.Protect(ProtectionType.All, "007");

            //Unprotect the workbook specifying its password.
            workbook.Unprotect("007");

            //Save As the excel file.
            workbook.Save("MyBook.xls");
        }
    }
}
