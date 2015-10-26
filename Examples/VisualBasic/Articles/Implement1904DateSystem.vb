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
    Public Class Implement1904DateSystem
        Public Shared Sub Main()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            'Initialize a new Workbook
            'Open an excel file
            Dim workbook As New Workbook(dataDir & "book1.xlsx")

            'Implement 1904 date system
            workbook.Settings.Date1904 = True

            'Save the excel file
            workbook.Save(dataDir & "Mybook.xlsx")



        End Sub
    End Class
End Namespace