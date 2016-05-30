Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace DrawingObjects.OLE
    Public Class ExtractingOLEObjects
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiating a Workbook object
            ' Open the template file.
            Dim workbook As New Workbook(dataDir & "book1.xls")

            ' Get the OleObject Collection in the first worksheet.
            Dim oles As Global.Aspose.Cells.Drawing.OleObjectCollection = workbook.Worksheets(0).OleObjects

            ' Loop through all the oleobjects and extract each object.
            ' In the worksheet.
            For i As Integer = 0 To oles.Count - 1
                Dim ole As Global.Aspose.Cells.Drawing.OleObject = oles(i)

                ' Specify the output filename.
                Dim fileName As String = dataDir & "ole_" & i & "."

                ' Specify each file format based on the oleobject format type.
                Select Case ole.FileType
                    Case Global.Aspose.Cells.Drawing.OleFileType.Doc
                        fileName &= "doc"
                    Case Global.Aspose.Cells.Drawing.OleFileType.Xls
                        fileName &= "Xls"
                    Case Global.Aspose.Cells.Drawing.OleFileType.Ppt
                        fileName &= "Ppt"
                    Case Global.Aspose.Cells.Drawing.OleFileType.Pdf
                        fileName &= "Pdf"
                    Case Global.Aspose.Cells.Drawing.OleFileType.Unknown
                        fileName &= "Jpg"
                    Case Else
                        '........
                End Select

                ' Save the oleobject as a new excel file if the object type is xls.
                If ole.FileType = Global.Aspose.Cells.Drawing.OleFileType.Xls Then
                    Dim ms As New MemoryStream()
                    ms.Write(ole.ObjectData, 0, ole.ObjectData.Length)
                    Dim oleBook As New Workbook(ms)
                    oleBook.Settings.IsHidden = False
                    oleBook.Save(dataDir & "Excel_File" & i & ".output.xls")

                    ' Create the files based on the oleobject format types.
                Else
                    Dim fs As FileStream = File.Create(fileName)
                    fs.Write(ole.ObjectData, 0, ole.ObjectData.Length)
                    fs.Close()
                End If
            Next i
            ' ExEnd:1
        End Sub
    End Class
End Namespace