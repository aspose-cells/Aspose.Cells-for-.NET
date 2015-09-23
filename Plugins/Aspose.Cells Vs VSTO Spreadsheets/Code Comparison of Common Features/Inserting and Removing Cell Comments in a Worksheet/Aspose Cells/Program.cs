using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            //Add a Comment to A1 cell.
            int commentIndex = workbook.Worksheets[0].Comments.Add("A1");

            //Accessing the newly added comment
            Comment comment = workbook.Worksheets[0].Comments[commentIndex];

            //Setting the comment note
            comment.Note = "This is my comment";

            workbook.Worksheets[0].Comments.RemoveAt("A1");
            //Save As the excel file.
            workbook.Save("Book1.xls");
        }
    }
}
