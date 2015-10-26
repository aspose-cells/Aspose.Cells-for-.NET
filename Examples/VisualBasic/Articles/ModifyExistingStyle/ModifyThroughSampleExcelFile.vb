'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Cells. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////

Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Drawing

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Articles.ModifyExistingStyle
    Public Class ModifyThroughSampleExcelFile
        Public Shared Sub Main()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Create a workbook.
            'Open a template file. 
            'In the book1.xls file, we have applied Ms Excel's 
            'Named style i.e., "Percent" to the range "A1:C8". 
            Dim workbook As New Workbook(dataDir & "book1.xlsx")

            'We get the Percent style and create a style object.
            Dim style As Style = workbook.Styles("Percent")

            'Change the number format to "0.00%".
            style.Number = 11

            'Set the font color.
            style.Font.Color = System.Drawing.Color.Red

            'Update the style. so, the style of range "A1:C8" will be changed too.
            style.Update()

            'Save the excel file.	
            workbook.Save(dataDir & "book2.xlsx")

        End Sub
    End Class
End Namespace