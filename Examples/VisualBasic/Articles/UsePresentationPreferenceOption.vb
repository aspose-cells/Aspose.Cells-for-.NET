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
    Public Class UsePresentationPreferenceOption
        Public Shared Sub Main()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            'Instantiate the Workbook
            'Load an Excel file
            Dim workbook As New Workbook(dataDir & "sample.xlsx")

            'Create HtmlSaveOptions object
            Dim options As New HtmlSaveOptions()
            'Set the Presenation preference option
            options.PresentationPreference = True

            'Save the Excel file to HTML with specified option
            workbook.Save(dataDir & "outPresentationlayout1.html", options)


        End Sub
    End Class
End Namespace