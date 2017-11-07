using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp._Workbook
{
    class ReadAndWriteExternalConnectionOfXLSBFile
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            //Load the source Excel Xlsb file
            Workbook wb = new Workbook(sourceDir + "sampleExternalConnection_XLSB.xlsb");

            //Read the first external connection which is actually a DB-Connection
            Aspose.Cells.ExternalConnections.DBConnection dbCon = wb.DataConnections[0] as Aspose.Cells.ExternalConnections.DBConnection;

            //Print the Name, Command and Connection Info of the DB-Connection
            Console.WriteLine("Connection Name: " + dbCon.Name);
            Console.WriteLine("Command: " + dbCon.Command);
            Console.WriteLine("Connection Info: " + dbCon.ConnectionInfo);

            //Modify the Connection Name
            dbCon.Name = "NewCust";

            //Save the Excel Xlsb file
            wb.Save(outputDir + "outputExternalConnection_XLSB.xlsb");

            Console.WriteLine("ReadAndWriteExternalConnectionOfXLSBFile executed successfully.\r\n");
        }
    }
}
