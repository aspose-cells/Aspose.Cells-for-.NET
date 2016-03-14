using System.IO;

using Aspose.Cells;
using System.Diagnostics;

namespace Aspose.Cells.Examples.Articles
{
    //ExStart:1
    public class GetWarningsForFontSubstitution : IWarningCallback
    {

        public void Warning(WarningInfo info)
        {
            if (info.WarningType == WarningType.FontSubstitution)
            {
                Debug.WriteLine("WARNING INFO: " + info.Description);
            }
        }




        static void Main()
        {
            Workbook workbook = new Workbook("F:\\AllExamples\\Aspose.Cells\\net\\TechnicalArticles\\Aspose.CellsGeneral\\GetWarningsForFontSubstitution\\Data\\source.xlsx");

            PdfSaveOptions options = new PdfSaveOptions();
            options.WarningCallback = new GetWarningsForFontSubstitution();

            workbook.Save("F:\\AllExamples\\Aspose.Cells\\net\\TechnicalArticles\\Aspose.CellsGeneral\\GetWarningsForFontSubstitution\\Data\\output.pdf", options);
       //ExEnd:1
        }

    }
}



            
      
