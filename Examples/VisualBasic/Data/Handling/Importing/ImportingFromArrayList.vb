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
Imports System.Collections

Namespace Aspose.Cells.Examples.Data.Handling.Importing
    Public Class ImportingFromArrayList
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            'Instantiating a Workbook object
            Dim workbook As New Workbook()

            'Obtaining the reference of the worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            'Instantiating an ArrayList object
            Dim list As New ArrayList()

            'Add few names to the list as string values
            list.Add("laurence chen")
            list.Add("roman korchagin")
            list.Add("kyle huang")
            list.Add("tommy wang")

            'Importing the contents of ArrayList to 1st row and first column vertically
            worksheet.Cells.ImportArrayList(list, 0, 0, True)

            'Saving the Excel file
            workbook.Save(dataDir & "DataImport.xls")

        End Sub
    End Class
End Namespace