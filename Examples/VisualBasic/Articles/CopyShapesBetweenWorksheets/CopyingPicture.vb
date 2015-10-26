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

Namespace Aspose.Cells.Examples.Articles.CopyShapesBetweenWorksheets
    Public Class CopyingPicture
        Public Shared Sub Main()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Create a workbook object
            'Open the template file
            Dim workbook As New Workbook(dataDir & "aspose-sample.xlsx")

            'Get the Picture from the "Picture" worksheet.
            Dim source As Global.Aspose.Cells.Drawing.Picture = workbook.Worksheets("Sheet1").Pictures(0)

            'Save Picture to Memory Stream
            Dim ms As New MemoryStream(source.Data)

            'Copy the picture to the Result Worksheet
            workbook.Worksheets("Sheet2").Pictures.Add(source.UpperLeftRow, source.UpperLeftColumn, ms, source.WidthScale, source.HeightScale)

            'Save the Worksheet
            workbook.Save(dataDir & "Shapes.xlsx")


        End Sub
    End Class
End Namespace