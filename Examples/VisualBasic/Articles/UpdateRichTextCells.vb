'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Cells. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////

Imports System.IO
Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Articles
    Public Class UpdateRichTextCells
        Shared Sub Main()
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            Dim inputPath As String = dataDir & "Sample.xlsx"
            Dim outputPath As String = dataDir & "Output.xlsx"

            Dim workbook As Workbook = New Workbook(inputPath)

            Dim worksheet As Worksheet = workbook.Worksheets(0)

            Dim cell As Cell = worksheet.Cells("A1")

            Console.WriteLine("Before updating the font settings....")
            Dim fnts As FontSetting() = cell.GetCharacters

            For i As Integer = 0 To fnts.Length - 1
                Console.WriteLine(fnts(i).Font.Name)
            Next

            'Modify the first FontSetting Font Name
            fnts(0).Font.Name = "Arial"

            'And update it using SetCharacters() method
            cell.SetCharacters(fnts)

            Console.WriteLine()

            Console.WriteLine("After updating the font settings....")

            fnts = cell.GetCharacters()
            For i As Integer = 0 To fnts.Length - 1
                Console.WriteLine(fnts(i).Font.Name)
            Next

            'Save workbook
            workbook.Save(outputPath)
        End Sub
    End Class
End Namespace
