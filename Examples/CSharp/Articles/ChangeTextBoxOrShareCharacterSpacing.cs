using System.IO;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using System;
namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class ChangeTextBoxOrShareCharacterSpacing
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Load your excel file inside a workbook obect
            Workbook wb = new Workbook(dataDir + "character-spacing.xlsx");

            // Access your text box which is also a shape object from shapes collection
            Shape shape = wb.Worksheets[0].Shapes[0];

            // Access the first font setting object via GetCharacters() method
            FontSetting fs = (FontSetting)shape.GetCharacters()[0];
       
            // Save the workbook in xlsx format
            wb.Save(dataDir + "ChangeTextBoxOrShareCharacterSpacing_out.xlsx", SaveFormat.Xlsx);
            // ExEnd:1                                
            
        }
    }
}
