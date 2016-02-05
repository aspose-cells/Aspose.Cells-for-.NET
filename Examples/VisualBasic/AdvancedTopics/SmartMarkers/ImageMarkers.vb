'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Cells. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////

Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System.Data

Namespace Aspose.Cells.Examples.AdvancedTopics.SmartMarkers
    Public Class ImageMarkers
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Get the image data.
            Dim imageData() As Byte = File.ReadAllBytes(dataDir & "aspose-logo.jpg")
            'Create a datatable.
            Dim t As New DataTable("Table1")
            'Add a column to save pictures.
            Dim dc As DataColumn = t.Columns.Add("Picture")
            'Set its data type.
            dc.DataType = GetType(Object)

            'Add a new new record to it.
            Dim row As DataRow = t.NewRow()
            row(0) = imageData
            t.Rows.Add(row)

            'Add another record (having picture) to it.
            imageData = File.ReadAllBytes(dataDir & "image2.jpg")
            row = t.NewRow()
            row(0) = imageData
            t.Rows.Add(row)

            'Create WorkbookDesigner object.
            Dim designer As New WorkbookDesigner()
            'Open the template Excel file.
            designer.Workbook = New Workbook(dataDir & "TestSmartMarkers.xls")
            'Set the datasource.
            designer.SetDataSource(t)
            'Process the markers.
            designer.Process()
            'Save the Excel file.
            designer.Workbook.Save(dataDir & "out_SmartBook.out.xls")


        End Sub
    End Class
End Namespace