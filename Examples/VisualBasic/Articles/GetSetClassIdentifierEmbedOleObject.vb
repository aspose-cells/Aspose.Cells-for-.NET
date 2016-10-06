
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Aspose.Cells.Drawing

Namespace Articles
    Public Class GetSetClassIdentifierEmbedOleObject
        Public Shared Sub Run()
            ' ExStart:GetSetClassIdentifierEmbedOleObject
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Load your sample workbook which contains embedded PowerPoint ole object
            Dim wb As New Workbook(dataDir & Convert.ToString("sample.xls"))

            ' Access its first worksheet
            Dim ws As Worksheet = wb.Worksheets(0)

            ' Access first ole object inside the worksheet
            Dim oleObj As OleObject = ws.OleObjects(0)

            ' Convert 16-bytes array into GUID
            Dim guid As New Guid(oleObj.ClassIdentifier)

            ' Print the GUID
            Console.WriteLine(guid.ToString().ToUpper())
            ' ExEnd:GetSetClassIdentifierEmbedOleObject
        End Sub
    End Class
End Namespace
