//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;
using System.Diagnostics;

namespace GetWarningsForFontSubstitutionExample
{
    public class IWarningCallback : IWarningCallback
    {
       
        
            public void Warning(WarningInfo info)
    {
        if (info.WarningType == WarningType.FontSubstitution)
        {
            Debug.WriteLine("WARNING INFO: " + info.Description);
        }
    }
    }


            
        void Run()
        {
                Workbook workbook = new Workbook("F:\\AllExamples\\Aspose.Cells\\net\\TechnicalArticles\\Aspose.CellsGeneral\\GetWarningsForFontSubstitution\\Data\\source.xlsx");

                PdfSaveOptions options = new PdfSaveOptions();
                options.WarningCallback = new WarningCallback();

                workbook.Save("F:\\AllExamples\\Aspose.Cells\\net\\TechnicalArticles\\Aspose.CellsGeneral\\GetWarningsForFontSubstitution\\Data\\output.pdf", options);
            }
     



    






            
      
