Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System.Data

Namespace Aspose.Cells.Examples.AdvancedTopics.SmartMarkers
    Public Class GroupingData
        Public Shared Sub Main(ByVal args() As String)

            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Create a connection object, specify the provider info and set the data source.
            Dim con As New OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=d:\test\Northwind.mdb")

            'Open the connection object.
            con.Open()

            'Create a command object and specify the SQL query.
            Dim cmd As New OleDbCommand("Select * from [Order Details]", con)

            'Create a data adapter object.
            Dim da As New OleDbDataAdapter()

            'Specify the command.
            da.SelectCommand = cmd

            'Create a dataset object.
            Dim ds As New DataSet()

            'Fill the dataset with the table records.
            da.Fill(ds, "Order Details")

            'Create a datatable with respect to dataset table.
            Dim dt As DataTable = ds.Tables("Order Details")

            'Create WorkbookDesigner object.
            Dim wd As New WorkbookDesigner()

            'Open the template file (which contains smart markers).
            wd.Workbook = New Workbook(dataDir & "TestSmartMarkers.xlsx")

            'Set the datatable as the data source.
            wd.SetDataSource(dt)

            'Process the smart markers to fill the data into the worksheets.
            wd.Process(True)

            'Save the excel file.
            wd.Workbook.Save(dataDir & "outSmartMarker_Designer.output.xlsx")
            'ExEnd:1


        End Sub
    End Class
    Friend Class OleDbCommand
        Private p As String
        Private con As OleDbConnection

        Public Sub New(ByVal p As String, ByVal con As OleDbConnection)
            ' TODO: Complete member initialization
            Me.p = p
            Me.con = con
        End Sub
    End Class
    Friend Class OleDbConnection
        Private p As String

        Public Sub New(ByVal p As String)
            ' TODO: Complete member initialization
            Me.p = p
        End Sub

        Friend Sub Open()

        End Sub
    End Class
    Friend Class OleDbDataAdapter
        Private privateSelectCommand As OleDbCommand
        Public Property SelectCommand() As OleDbCommand
            Get
                Return privateSelectCommand
            End Get
            Set(ByVal value As OleDbCommand)
                privateSelectCommand = value
            End Set
        End Property

        Friend Sub Fill(ByVal ds As System.Data.DataSet, ByVal p As String)

        End Sub
    End Class

End Namespace