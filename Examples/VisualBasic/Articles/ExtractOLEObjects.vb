Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports Aspose.Cells.Drawing

Namespace Aspose.Cells.Examples.Articles
    Public Class ExtractOLEObjects
        Public Shared Sub Main()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Instantiating a Workbook object
            'Open the template file.
            Dim workbook As Workbook = New Workbook(dataDir & "oleFile.xlsx")

            'Get the OleObject Collection in the first worksheet.
            Dim oles As Global.Aspose.Cells.Drawing.OleObjectCollection = workbook.Worksheets(0).OleObjects

            'Loop through all the oleobjects and extract each object in the worksheet.
            Dim i As Integer = 0
            Do While i < oles.Count
                Dim ole As Global.Aspose.Cells.Drawing.OleObject = oles(i)
                'Specify the output filename.
                Dim fileName As String = dataDir & "outOle" & i & "."
                'Specify each file format based on the oleobject format type.
                Select Case ole.FileFormatType
                    Case FileFormatType.Doc
                        fileName &= "doc"
                    Case FileFormatType.Excel97To2003
                        fileName &= "Xlsx"
                    Case FileFormatType.Ppt
                        fileName &= "Ppt"
                    Case FileFormatType.Pdf
                        fileName &= "Pdf"
                    Case FileFormatType.Unknown
                        fileName &= "Jpg"
                    Case Else
                        '........
                End Select
                'Save the oleobject as a new excel file if the object type is xls.
                If ole.FileFormatType = FileFormatType.Xlsx Then
                    Dim ms As MemoryStream = New MemoryStream()
                    ms.Write(ole.ObjectData, 0, ole.ObjectData.Length)
                    Dim oleBook As Workbook = New Workbook(ms)
                    oleBook.Settings.IsHidden = False
                    oleBook.Save(dataDir & "outOle" & i & ".out.xlsx")

                    'Create the files based on the oleobject format types.
                Else
                    Dim fs As FileStream = File.Create(fileName)
                    fs.Write(ole.ObjectData, 0, ole.ObjectData.Length)
                    fs.Close()
                End If
                i += 1
            Loop
        End Sub
    End Class
End Namespace