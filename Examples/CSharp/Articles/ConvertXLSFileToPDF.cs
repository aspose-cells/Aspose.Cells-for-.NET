//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System;
using System.IO;
using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles
{
    public class ConvertXLSFileToPDF
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


            try
            {

                //Get the template excel file path.
                string designerFile = dataDir + "SampleInput.xlsx";
                //Specify the pdf file path.
                string pdfFile = dataDir + "Output.pdf";
                //Create a new Workbook.
                //Open the template excel file which you have to
                Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook(designerFile);
                //Save the pdf file.
                wb.Save(pdfFile, SaveFormat.Pdf);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();

            }
        }

    }
}
