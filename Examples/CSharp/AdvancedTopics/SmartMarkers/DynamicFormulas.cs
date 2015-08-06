//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.AdvancedTopics.SmartMarkers
{
    public class DynamicFormulas
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);


            //Instantiating a WorkbookDesigner object
            WorkbookDesigner designer = new WorkbookDesigner();

            //Open a designer spreadsheet containing smart markers
            designer.Workbook = new Workbook(designerFile);

            //Set the data source for the designer spreadsheet
            designer.SetDataSource(dataset);

            //Process the smart markers
            designer.Process();
            
            
        }

        public static Stream designerFile { get; set; }

        public static System.Data.SqlClient.SqlConnection dataset { get; set; }
    }
}