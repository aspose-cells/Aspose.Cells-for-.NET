//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;
using System.Diagnostics;

namespace Aspose.Cells.Examples.Articles
{
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
        }

    }
}



            
      
