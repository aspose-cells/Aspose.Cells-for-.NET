Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.ExternalConnections

Namespace Articles.ManageDatabaseConnection
    Public Class ModifyingExistingDataConnection
        Public Shared Sub Run()
            ' ExStart:ModifyingExistingDataConnection
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object
            Dim workbook As New Workbook(dataDir & Convert.ToString("DataConnection.xlsx"))

            ' Access first Data Connection
            Dim conn As ExternalConnection = workbook.DataConnections(0)

            ' Change the Data Connection Name and Odc file
            conn.Name = "MyConnectionName"
            conn.OdcFile = "C:\Users\MyDefaulConnection.odc"

            ' Change the Command Type, Command and Connection String
            Dim dbConn As DBConnection = TryCast(conn, DBConnection)
            dbConn.CommandType = OLEDBCommandType.SqlStatement
            dbConn.Command = "Select * from AdminTable"
            dbConn.ConnectionInfo = "Server=myServerAddress;Database=myDataBase;User ID=myUsername;Password=myPassword;Trusted_Connection=False"

            ' Save the workbook
            workbook.Save(dataDir & Convert.ToString("output_out.xlsx"))
            ' ExEnd:ModifyingExistingDataConnection
        End Sub
    End Class
End Namespace