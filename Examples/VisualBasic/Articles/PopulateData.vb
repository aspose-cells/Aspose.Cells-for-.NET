'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Cells. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////

Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Articles
    Public Class PopulateData
        Public Shared Sub Main()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            Dim workbook As New Workbook()
            Dim cells As Global.Aspose.Cells.Cells = workbook.Worksheets(0).Cells
            cells("A1").PutValue("data1")
            cells("B1").PutValue("data2")
            cells("A2").PutValue("data3")
            cells("B2").PutValue("data4")
            workbook.Save(dataDir & "book1.xlsx")


        End Sub
    End Class
End Namespace