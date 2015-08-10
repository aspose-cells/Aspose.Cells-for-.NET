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

Namespace Aspose.Cells.Examples.Articles
    Public Class CombineMultipleWorkbooksSingleWorkbook
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)


            'Define the first source
            'Open the first excel file.
            Dim SourceBook1 As New Workbook(dataDir & "SampleChart.xlsx")

            'Define the second source book.
            'Open the second excel file.
            Dim SourceBook2 As New Workbook(dataDir & "SampleImage.xlsx")

            'Combining the two workbooks
            SourceBook1.Combine(SourceBook2)

            'Save the target book file.
            SourceBook1.Save(dataDir & "Combined.xlsx")

        End Sub
    End Class
End Namespace