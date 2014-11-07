//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace LoadSpecificSheetsExample
{
    public class Program
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");
            //Define a new Workbook.
            Workbook workbook;

            //Set the load data option with selected sheet(s).
            LoadDataOption dataOption = new LoadDataOption();
            dataOption.SheetNames = new string[] { "Sheet2" };

            //Load the workbook with the spcified worksheet only.
            LoadOptions loadOptions = new LoadOptions(LoadFormat.Xlsx);
            loadOptions.LoadDataOptions = dataOption;
            loadOptions.LoadDataAndFormatting = true;

            //Creat the workbook.
            workbook = new Workbook(dataDir+ "TestData.xlsx", loadOptions);

            //Perform your desired task.

            //Save the workbook.
            workbook.Save(dataDir+ "outputFile.xlsx");
            
            
        }
    }
}