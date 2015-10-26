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
    Public Class ShowFormulasInsteadOfValues
        Public Shared Sub Main()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim filePath As String = dataDir & "source.xlsx"

            'Load the source workbook
            Dim workbook As New Workbook(filePath)

            'Access the first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            'Show formulas of the worksheet
            worksheet.ShowFormulas = True

            'Save the workbook
            workbook.Save(dataDir & ".out.xlsx")

        End Sub
    End Class
End Namespace