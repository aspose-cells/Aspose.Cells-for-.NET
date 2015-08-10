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
Imports System.Drawing

Namespace Aspose.Cells.Examples.Data.AddOn.NamedRanges
    Public Class IntersectionofRanges
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Instantiate a workbook object.
            'Open an existing excel file.
            Dim workbook As New Workbook(dataDir & "book1.xls")

            'Get the named ranges.
            Dim ranges() As Range = workbook.Worksheets.GetNamedRanges()

            'Check whether the first range intersect the second range.
            Dim isintersect As Boolean = ranges(0).IsIntersect(ranges(1))

            'Create a style object.
            Dim style As Style = workbook.Styles(workbook.Styles.Add())

            'Set the shading color with solid pattern type.
            style.ForegroundColor = Color.Yellow
            style.Pattern = BackgroundType.Solid

            'Create a styleflag object.
            Dim flag As New StyleFlag()

            'Apply the cellshading.
            flag.CellShading = True

            'If first range intersects second range.
            If isintersect Then
                'Create a range by getting the intersection.
                Dim intersection As Range = ranges(0).Intersect(ranges(1))

                'Name the range.
                intersection.Name = "Intersection"

                'Apply the style to the range.
                intersection.ApplyStyle(style, flag)

            End If

            'Save the excel file.
            workbook.Save(dataDir & "rngIntersection.xls")
        End Sub
    End Class
End Namespace