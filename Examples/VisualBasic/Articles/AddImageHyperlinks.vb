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
Imports Aspose.Cells.Drawing

Namespace Aspose.Cells.Examples.Articles
    Public Class AddImageHyperlinks
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            'Instantiate a new workbook
            Dim workbook As New Workbook()

            'Get the first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            'Insert a string value to a cell
            worksheet.Cells("C2").PutValue("Image Hyperlink")

            'Set the 4th row height
            worksheet.Cells.SetRowHeight(3, 100)

            'Set the C column width
            worksheet.Cells.SetColumnWidth(2, 21)

            'Add a picture to the C4 cell
            Dim index As Integer = worksheet.Pictures.Add(3, 2, 4, 3, dataDir & "aspose-logo.jpg")

            'Get the picture object
            Dim pic As Global.Aspose.Cells.Drawing.Picture = worksheet.Pictures(index)

            'Set the placement type
            pic.Placement = PlacementType.FreeFloating

            'Add an image hyperlink
            Dim hlink As Global.Aspose.Cells.Hyperlink = pic.AddHyperlink("http://www.aspose.com/")

            'Specify the screen tip
            hlink.ScreenTip = "Click to go to Aspose site"

            'Save the Excel file
            workbook.Save(dataDir & "ImageHyperlink.xls")


        End Sub
    End Class
End Namespace